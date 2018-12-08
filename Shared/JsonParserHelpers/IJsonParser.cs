namespace PizzaCabinInc.Shared.JsonParserHelpers
{
	public interface IJsonParser
	{
		TType ToObject<TType>(string json)
			where TType : class, new();
	}
}
