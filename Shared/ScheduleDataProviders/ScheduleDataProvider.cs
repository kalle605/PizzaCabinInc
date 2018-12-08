using PizzaCabinInc.Shared.DTO.ScheduleInformation;
using PizzaCabinInc.Shared.JsonParserHelpers;

namespace PizzaCabinInc.Shared.ScheduleDataProviders
{
	public class ScheduleDataProvider : IScheduleDataProvider
	{
		private readonly IJsonParser jsonParser;
		private readonly IJsonRepository jsonRepository;
		private readonly IRESTfulURLProvider urlProvider;

		public ScheduleDataProvider(IJsonParser jsonParser
				, IJsonRepository jsonRepository
				, IRESTfulURLProvider urlProvider)
		{
			this.jsonParser = jsonParser;
			this.jsonRepository = jsonRepository;
			this.urlProvider = urlProvider;
		}

		public ScheduleResult GetSchedules()
		{
			var url = this.urlProvider.GetUrl();
			var json = this.jsonRepository.Get(url);

			return this.jsonParser.ToObject<RootObject>(json).ScheduleResult;
		}
	}

	public class RootObject
	{
		public ScheduleResult ScheduleResult { get; set; }
	}
}