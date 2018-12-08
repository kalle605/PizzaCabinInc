using PizzaCabinInc.Shared.JsonParserHelpers;
using System.IO;
using System.Net;

namespace PizzaCabinInc.Infrastructure.JsonParserHelpers
{
	public class JsonRepository : IJsonRepository
	{
		public string Get(string url)
		{
			var request = (HttpWebRequest)WebRequest.Create(url);
			var response = request.GetResponse();
			using (var responseStream = response.GetResponseStream())
			{
				var reader = new StreamReader(responseStream, System.Text.Encoding.UTF8);
				return reader.ReadToEnd();
			}
		}
	}
}
