using Microsoft.VisualStudio.TestTools.UnitTesting;
using PizzaCabinInc.Infrastructure.JsonParserHelpers;
using PizzaCabinInc.Shared.JsonParserHelpers;
using PizzaCabinInc.Shared.ScheduleDataProviders;
using System;
using System.Linq;

namespace PizzaCabinIncTests.ScheduleDataProviders
{
	[TestClass]
	public class ScheduleDataProviderIntegrationTests
	{
		private IJsonParser jsonParser;
		private IJsonRepository jsonRepository;
		private IRESTfulURLProvider urlProvider;
		private ScheduleDataProvider dataProvider;

		[TestInitialize]
		public void TestInitialize()
		{
			this.jsonParser = new JsonParser();
			this.jsonRepository = new JsonRepository();
			this.urlProvider = new RESTfulURLProvider();

			this.dataProvider = new ScheduleDataProvider(this.jsonParser
				, this.jsonRepository
				, this.urlProvider
			);
		}

		[TestMethod]
		public void ShouldBeAbleToGetSchedule()
		{
			var result = this.dataProvider.GetSchedules();

			Assert.IsNotNull(result);

			Assert.AreEqual(10, result.Schedules.Count);

			var schedule1 = result.Schedules[0];

			Assert.AreEqual("Daniel Billsus", schedule1.Name);
			Assert.AreEqual(new DateTimeOffset(2015, 12, 14, 0, 0, 0, TimeSpan.Zero), schedule1.Date);

			Assert.IsFalse(schedule1.IsFullDayAbsence);
			Assert.AreEqual(Guid.Parse("4fd900ad-2b33-469c-87ac-9b5e015b2564"), schedule1.PersonId);
			Assert.AreEqual(480, schedule1.ContractTimeMinutes);
			Assert.AreEqual(7, schedule1.Projection.Count());

			var projection1 = schedule1.Projection.First();

			Assert.AreEqual("#1E90FF", projection1.Color);
			Assert.AreEqual("Social Media", projection1.Description);
			Assert.AreEqual(120, projection1.minutes);
			Assert.AreEqual(new DateTimeOffset(2015, 12, 14, 8, 0, 0, TimeSpan.Zero), projection1.Start);
		}
	}
}
