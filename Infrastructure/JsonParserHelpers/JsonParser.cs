using Newtonsoft.Json;
using PizzaCabinInc.Shared.JsonParserHelpers;

namespace PizzaCabinInc.Infrastructure.JsonParserHelpers
{
	public class JsonParser : IJsonParser
	{
		public TType ToObject<TType>(string json)
			where TType : class, new()
		{
			var instance = JsonConvert.DeserializeObject<TType>(json);

			return instance;
		}
	}
}
