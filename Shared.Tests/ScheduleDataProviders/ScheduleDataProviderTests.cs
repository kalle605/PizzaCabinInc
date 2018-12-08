using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PizzaCabinInc.Shared.DTO.ScheduleInformation;
using PizzaCabinInc.Shared.JsonParserHelpers;
using PizzaCabinInc.Shared.ScheduleDataProviders;

namespace PizzaCabinIncTests.ScheduleDataProviders
{
	[TestClass]
	public class ScheduleDataProviderTests
	{
		private Mock<IJsonParser> jsonParser;
		private Mock<IJsonRepository> jsonRepository;
		private Mock<IRESTfulURLProvider> urlProvider;
		private ScheduleDataProvider dataProvider;

		[TestInitialize]
		public void TestInitialize()
		{
			this.jsonParser = new Mock<IJsonParser>();
			this.jsonRepository = new Mock<IJsonRepository>();
			this.urlProvider = new Mock<IRESTfulURLProvider>();

			this.dataProvider = new ScheduleDataProvider(this.jsonParser.Object
				, this.jsonRepository.Object
				, this.urlProvider.Object
			);
		}

		[TestMethod]
		public void ShouldBeAbleToGetSchedule()
		{
			const string url = "My URL";
			const string json = "JSON";

			var scheduleResult = new ScheduleResult();

			this.urlProvider.Setup(s => s.GetUrl()).Returns(url);
			this.jsonRepository.Setup(s => s.Get(url)).Returns(json);
			this.jsonParser.Setup(s => s.ToObject<ScheduleResult>(json)).Returns(scheduleResult);

			var result = this.dataProvider.GetSchedules();

			Assert.AreSame(scheduleResult, result);
		}
	}
}
