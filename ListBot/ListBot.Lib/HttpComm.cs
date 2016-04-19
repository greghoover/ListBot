using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;

namespace ListBot.Lib
{
	public class HttpComm
	{
		public static async Task<string> GetWebContent(string url)
		{
			string content = null;
			if (string.IsNullOrWhiteSpace(url))
				url = "http://stat.pcanet.org/ac/directory/directory.cfm";

			HttpClient http = new HttpClient();
			var rqst = new HttpRequestMessage(HttpMethod.Get, url);
			var resp = await http.SendAsync(rqst).ConfigureAwait(false);
			content = await resp.Content.ReadAsStringAsync();

			return content;
		}
	}
}
