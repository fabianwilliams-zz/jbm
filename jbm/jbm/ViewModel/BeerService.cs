using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;
using Microsoft.WindowsAzure.MobileServices.SQLiteStore;
using Microsoft.WindowsAzure.MobileServices.Sync;
#if __IOS__
using UIKit;
#elif __ANDROID__
using Mono;
#endif
using System.Threading;

namespace jbm
{
	public class BeerService
	{

		private MobileServiceClient MobileService = new MobileServiceClient(
			"https://jbbeer.azure-mobile.net/",
			"FNnxPlkEqCPQgvDGQjHsYILmYSwujX42"
		);
		public List<Beer> Items { get; private set;}

		private IMobileServiceSyncTable<Beer> beerTable;

		public async Task InitializeAsync()
		{
			var store = new MobileServiceSQLiteStore("localdata.db");
			store.DefineTable<Beer> ();
			await this.MobileService.SyncContext.InitializeAsync(store);
			beerTable = this.MobileService.GetSyncTable<Beer>();
		}

		public async Task SyncAsync()
		{
			// Comment this back in if you want auth
			//if (!await IsAuthenticated())
			//    return;
			await InitializeAsync();
			await this.MobileService.SyncContext.PushAsync();

			var query = beerTable.CreateQuery();
			//.Where(td => td.Complete == false);
			await beerTable.PullAsync("Beers", query);
		}

		public async Task<List<Beer>> GetAllTodoItems()
		{
			try {
				// update the local store
				// all operations on todoTable use the local database, call SyncAsync to send changes
				await SyncAsync(); 							
				// This code refreshes the entries in the list view by querying the local TodoItems table.
				// The query excludes completed TodoItems -- not anymore
				Items = await beerTable.ToListAsync();
				//.Where (ga => ga.Complete == false).ToListAsync ();
			} catch (MobileServiceInvalidOperationException e) {
				Console.Error.WriteLine (@"ERROR {0}", e.Message);
				return null;
			}
			return Items;
		}

		public async Task InsertTodoItemAsync (Beer todoItem)
		{
			try {                
				await SyncAsync();
				await beerTable.InsertAsync (todoItem); // Insert a new TodoItem into the local database. 
				await SyncAsync(); // send changes to the mobile service

			} catch (MobileServiceInvalidOperationException e) {
				Console.Error.WriteLine (@"ERROR {0}", e.Message);
			}
		}

	}
}
