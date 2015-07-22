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


//			// Create a client
//			var httpClient = new System.Net.Http.HttpClient();
//
//			// Add a new Request Message
//			var requestMessage = new System.Net.Http.HttpRequestMessage(System.Net.Http.HttpMethod.Put, "https://fabianooc.azure-api.net/breakin/Beer");
//
//			// Add our custom headers
//			requestMessage.Headers.Add("Ocp-Apim-Trace", "true");
//			requestMessage.Headers.Add("Ocp-Apim-Subscription-Key", "dfda3434dd624baaa88f7e6fada83524");
//
//			// Send the request to the server
//			System.Net.Http.HttpResponseMessage response = await httpClient.SendAsync(requestMessage);
//
//			// Just as an example I'm turning the response into a string here
//			var responseAsString = await response.Content.ReadAsStringAsync();
//
//			var rootbeer = JsonConvert.DeserializeObject<RootBeers>(responseAsString);
//
//			return rootbeer.rbeers;

		}
	}
}

