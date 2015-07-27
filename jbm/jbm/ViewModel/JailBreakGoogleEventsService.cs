using System;
using System.Net;
using System.Net.Http;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Threading.Tasks;


namespace jbm
{
	public class JailBreakGoogleEventsService
	{
		public JailBreakGoogleEventsService ()
		{
		}
			
		public async Task<JBEvent.RootObject> GetJBEventsAsync () {
			var client = new System.Net.Http.HttpClient ();
			var requestMessage = new HttpRequestMessage()
			{
				RequestUri = new Uri("https://www.googleapis.com/calendar/v3/calendars/{put ur own calendar id}/events?key={put ur own key here}"),
				Method = HttpMethod.Get,
			};

			var response = await client.SendAsync (requestMessage);
			var eventJson = response.Content.ReadAsStringAsync().Result;
			var rootobject = JsonConvert.DeserializeObject<JBEvent.RootObject>(eventJson);

			return rootobject;



		}

	}
}

