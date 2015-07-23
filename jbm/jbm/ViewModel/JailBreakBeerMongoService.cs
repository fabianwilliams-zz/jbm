using System;
using System.Net;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace jbm
{
	public class JailBreakBeerMongoService
	{
		public JailBreakBeerMongoService ()
		{
		}

		public async Task<Beer[]> GetBeersAsync () {
			//above was <Beer[]>
			var client = new System.Net.Http.HttpClient ();
			var requestMessage = new System.Net.Http.HttpRequestMessage()
			{
				RequestUri = new Uri("https://fabianooc.azure-api.net/breakin/Beer"),
				Method = System.Net.Http.HttpMethod.Get,
			};

			requestMessage.Headers.Add("Ocp-Apim-Trace", "true");
			requestMessage.Headers.Add("Ocp-Apim-Subscription-Key", "dfda3434dd624baaa88f7e6fada83524");

			var response = await client.SendAsync (requestMessage);
			var beerJson = "{\"beers\":" + response.Content.ReadAsStringAsync().Result + "}";
			var rootobject = JsonConvert.DeserializeObject<MyRootObject>(beerJson);
			//var rootobject = JsonConvert.DeserializeObject<List<RootBeers>>(beerJson);
			//List<Beer> rootobject = (Beer)Newtonsoft.Json.JsonConvert.DeserializeObject(beerJson, typeof(Beer));


			return rootobject.beers;


		}
	}
}

