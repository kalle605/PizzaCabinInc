namespace PizzaCabinInc.Shared.JsonParserHelpers
{
	/// <summary>
	/// Repository to get JSon from the given Rest service.
	/// </summary>
	public interface IJsonRepository
	{
		string Get(string url);
	}
}
