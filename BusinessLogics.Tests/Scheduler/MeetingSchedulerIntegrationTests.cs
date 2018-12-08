using BusinessLogics.Scheduler;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PizzaCabinInc.Infrastructure.JsonParserHelpers;
using PizzaCabinInc.Shared.DTO.ScheduleInformation;
using PizzaCabinInc.Shared.ScheduleDataProviders;
using Shared.TimeService;
using System;
using System.Linq;
using TestHelpers;

namespace BusinessLogics.Tests
{
	[TestClass]
	public class MeetingSchedulerIntegrationTests
	{
		private Mock<ITimeService> timeService;
		private MeetingScheduler scheduler;
		private ScheduleResult scheduleResult;

		[TestInitialize]
		public void TestInitialize()
		{
			var jsonParser = new JsonParser();
			var jsonRepository = new JsonRepository();
			var urlProvider = new RESTfulURLProvider();

			var dataProvider = new ScheduleDataProvider(jsonParser
				, jsonRepository
				, urlProvider
			);

			this.scheduleResult = dataProvider.GetSchedules();

			var calculator = new MeetingSchedulerCalculator(this.scheduleResult);

			this.timeService = new Mock<ITimeService>();

			this.scheduler = new MeetingScheduler(this.timeService.Object
				, calculator);
		}

		[TestMethod]
		public void ShouldBeAbleToGetAllAvailableMeetingsForAllPeople()
		{
			var currentDate = new DateTimeOffset(2015, 12, 14, 08, 00, 00, TimeSpan.FromHours(1));

			this.timeService.Setup(s => s.CurrentDate).Returns(currentDate);

			var personIds = this.scheduleResult.Schedules.Select(s => s.PersonId).ToSet();
			var result = this.scheduler.GetAvailableDatesForToday(personIds.Count()
				, personIds
			);

			Assert.AreEqual(0, result.Count());
		}

		[TestMethod]
		public void ShouldBeAbleToGetAllAvailableMeetingsForMin8AllPeople()
		{
			var currentDate = new DateTimeOffset(2015, 12, 14, 08, 00, 00, TimeSpan.Zero);

			this.timeService.Setup(s => s.CurrentDate).Returns(currentDate);

			var personIds = this.scheduleResult.Schedules.Select(s => s.PersonId).ToSet();
			var result = this.scheduler.GetAvailableDatesForToday(8
					, personIds
				)
				.ToList();

			Assert.AreEqual(15, result.Count());

			Assert.IsTrue(result.All(s => s.AvailablePersonIds.Count() >= 8));

			Assert.AreEqual(new DateTimeOffset(2015, 12, 14, 11, 00, 00, TimeSpan.Zero), result[0].AvailableDate);
			Assert.AreEqual(new DateTimeOffset(2015, 12, 14, 11, 15, 00, TimeSpan.Zero), result[1].AvailableDate);
			Assert.AreEqual(new DateTimeOffset(2015, 12, 14, 11, 30, 00, TimeSpan.Zero), result[2].AvailableDate);
			Assert.AreEqual(new DateTimeOffset(2015, 12, 14, 11, 45, 00, TimeSpan.Zero), result[3].AvailableDate);
			Assert.AreEqual(new DateTimeOffset(2015, 12, 14, 13, 00, 00, TimeSpan.Zero), result[4].AvailableDate);
			Assert.AreEqual(new DateTimeOffset(2015, 12, 14, 13, 15, 00, TimeSpan.Zero), result[5].AvailableDate);
			Assert.AreEqual(new DateTimeOffset(2015, 12, 14, 13, 45, 00, TimeSpan.Zero), result[6].AvailableDate);
			Assert.AreEqual(new DateTimeOffset(2015, 12, 14, 14, 00, 00, TimeSpan.Zero), result[7].AvailableDate);
			Assert.AreEqual(new DateTimeOffset(2015, 12, 14, 14, 15, 00, TimeSpan.Zero), result[8].AvailableDate);
			Assert.AreEqual(new DateTimeOffset(2015, 12, 14, 14, 30, 00, TimeSpan.Zero), result[9].AvailableDate);
			Assert.AreEqual(new DateTimeOffset(2015, 12, 14, 14, 45, 00, TimeSpan.Zero), result[10].AvailableDate);
			Assert.AreEqual(new DateTimeOffset(2015, 12, 14, 16, 00, 00, TimeSpan.Zero), result[11].AvailableDate);
			Assert.AreEqual(new DateTimeOffset(2015, 12, 14, 16, 15, 00, TimeSpan.Zero), result[12].AvailableDate);
			Assert.AreEqual(new DateTimeOffset(2015, 12, 14, 16, 30, 00, TimeSpan.Zero), result[13].AvailableDate);
			Assert.AreEqual(new DateTimeOffset(2015, 12, 14, 16, 45, 00, TimeSpan.Zero), result[14].AvailableDate);
		}

		[TestMethod]
		public void ShouldBeAbleToGetAllAvailableMeetingsFor4People()
		{
			var currentDate = new DateTimeOffset(2015, 12, 14, 08, 00, 00, TimeSpan.Zero);

			this.timeService.Setup(s => s.CurrentDate).Returns(currentDate);

			var personIds = this.scheduleResult.Schedules.Select(s => s.PersonId).Reverse().Take(4).ToSet();
			var result = this.scheduler.GetAvailableDatesForToday(3
					, personIds
				)
				.ToList();

			Assert.AreEqual(30, result.Count());

			Assert.IsTrue(result.All(s => s.AvailablePersonIds.Count() >= 3));

			Assert.AreEqual(new DateTimeOffset(2015, 12, 14, 08, 00, 00, TimeSpan.Zero), result[0].AvailableDate);
			Assert.AreEqual(new DateTimeOffset(2015, 12, 14, 08, 15, 00, TimeSpan.Zero), result[1].AvailableDate);
			Assert.AreEqual(new DateTimeOffset(2015, 12, 14, 08, 30, 00, TimeSpan.Zero), result[2].AvailableDate);
			Assert.AreEqual(new DateTimeOffset(2015, 12, 14, 08, 45, 00, TimeSpan.Zero), result[3].AvailableDate);
			Assert.AreEqual(new DateTimeOffset(2015, 12, 14, 09, 00, 00, TimeSpan.Zero), result[4].AvailableDate);
			Assert.AreEqual(new DateTimeOffset(2015, 12, 14, 09, 15, 00, TimeSpan.Zero), result[5].AvailableDate);
			Assert.AreEqual(new DateTimeOffset(2015, 12, 14, 09, 30, 00, TimeSpan.Zero), result[6].AvailableDate);
			Assert.AreEqual(new DateTimeOffset(2015, 12, 14, 09, 45, 00, TimeSpan.Zero), result[7].AvailableDate);
			Assert.AreEqual(new DateTimeOffset(2015, 12, 14, 10, 15, 00, TimeSpan.Zero), result[8].AvailableDate);
			Assert.AreEqual(new DateTimeOffset(2015, 12, 14, 10, 30, 00, TimeSpan.Zero), result[9].AvailableDate);
			Assert.AreEqual(new DateTimeOffset(2015, 12, 14, 10, 45, 00, TimeSpan.Zero), result[10].AvailableDate);
			Assert.AreEqual(new DateTimeOffset(2015, 12, 14, 11, 00, 00, TimeSpan.Zero), result[11].AvailableDate);
			Assert.AreEqual(new DateTimeOffset(2015, 12, 14, 11, 15, 00, TimeSpan.Zero), result[12].AvailableDate);
			Assert.AreEqual(new DateTimeOffset(2015, 12, 14, 11, 30, 00, TimeSpan.Zero), result[13].AvailableDate);
			Assert.AreEqual(new DateTimeOffset(2015, 12, 14, 11, 45, 00, TimeSpan.Zero), result[14].AvailableDate);

			Assert.AreEqual(new DateTimeOffset(2015, 12, 14, 13, 00, 00, TimeSpan.Zero), result[15].AvailableDate);
			Assert.AreEqual(new DateTimeOffset(2015, 12, 14, 13, 15, 00, TimeSpan.Zero), result[16].AvailableDate);
			Assert.AreEqual(new DateTimeOffset(2015, 12, 14, 13, 30, 00, TimeSpan.Zero), result[17].AvailableDate);
			Assert.AreEqual(new DateTimeOffset(2015, 12, 14, 13, 45, 00, TimeSpan.Zero), result[18].AvailableDate);
			Assert.AreEqual(new DateTimeOffset(2015, 12, 14, 14, 00, 00, TimeSpan.Zero), result[19].AvailableDate);
			Assert.AreEqual(new DateTimeOffset(2015, 12, 14, 14, 15, 00, TimeSpan.Zero), result[20].AvailableDate);
			Assert.AreEqual(new DateTimeOffset(2015, 12, 14, 14, 30, 00, TimeSpan.Zero), result[21].AvailableDate);
			Assert.AreEqual(new DateTimeOffset(2015, 12, 14, 14, 45, 00, TimeSpan.Zero), result[22].AvailableDate);
			Assert.AreEqual(new DateTimeOffset(2015, 12, 14, 15, 15, 00, TimeSpan.Zero), result[23].AvailableDate);
			Assert.AreEqual(new DateTimeOffset(2015, 12, 14, 15, 30, 00, TimeSpan.Zero), result[24].AvailableDate);
			Assert.AreEqual(new DateTimeOffset(2015, 12, 14, 15, 45, 00, TimeSpan.Zero), result[25].AvailableDate);
			Assert.AreEqual(new DateTimeOffset(2015, 12, 14, 16, 00, 00, TimeSpan.Zero), result[26].AvailableDate);
			Assert.AreEqual(new DateTimeOffset(2015, 12, 14, 16, 15, 00, TimeSpan.Zero), result[27].AvailableDate);
			Assert.AreEqual(new DateTimeOffset(2015, 12, 14, 16, 30, 00, TimeSpan.Zero), result[28].AvailableDate);
			Assert.AreEqual(new DateTimeOffset(2015, 12, 14, 16, 45, 00, TimeSpan.Zero), result[29].AvailableDate);
		}

		[TestMethod]
		public void ShouldHandlePersonWithoutProjections()
		{
			var personId = Guid.Parse("1a714f36-ee87-4a06-88d6-9b5e015b2585");

			var currentDate = new DateTimeOffset(2015, 12, 14, 08, 00, 00, TimeSpan.Zero);

			this.timeService.Setup(s => s.CurrentDate).Returns(currentDate);

			var result = this.scheduler.GetAvailableDatesForToday(1
					, personId.ToSet()
				)
				.ToList();

			Assert.AreEqual(0, result.Count());
		}
	}
}
