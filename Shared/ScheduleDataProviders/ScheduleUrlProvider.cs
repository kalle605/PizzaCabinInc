namespace PizzaCabinInc.Shared.ScheduleDataProviders
{
	public interface IRESTfulURLProvider
	{
		string GetUrl();
	}

	public class RESTfulURLProvider : IRESTfulURLProvider
	{
		public string GetUrl()
		{
			return "http://pizzacabininc.azurewebsites.net/PizzaCabinInc.svc/schedule/2015-12-14";
		}
	}
}
