using BusinessLogics.Scheduler;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PizzaCabinInc.Shared.DTO.ScheduleInformation;
using Shared.TimeService;
using System;
using TestHelpers;

namespace BusinessLogics.Tests
{
	[TestClass]
	public class MeetingSchedulerTests
	{
		private DateTime currentDate;
		private ScheduleResult scheduleResult;
		private MeetingScheduler scheduler;

		[TestInitialize]
		public void TestInitialize()
		{
			this.currentDate = new DateTime(2018, 01, 01);
			this.scheduleResult = new ScheduleResult();

			var timeService = Mock.Of<ITimeService>(s => s.CurrentDate == this.currentDate);

			this.scheduler = new MeetingScheduler(timeService
				, this.scheduleResult);
		}

		[TestMethod]
		public void ShouldBeAbleToGetNextAvailableDate()
		{
			var expectedDate = new DateTimeOffset(2018, 01, 01, 08, 00, 00, TimeSpan.Zero);

			var personId1 = Guid.NewGuid();
			var personId2 = Guid.NewGuid();

			var personIds = new[] { personId1, personId2 };

			var result = this.scheduler.GetNextAvailableDate(1, personIds.ToSet());

			Assert.Fail();
		}

		[TestMethod]
		public void ShouldBeAbleToGetAvailableDatesForToday()
		{
			var expectedDate = new DateTimeOffset(2018, 01, 01, 08, 00, 00, TimeSpan.Zero);

			var personId1 = Guid.NewGuid();
			var personId2 = Guid.NewGuid();

			var personIds = new[] { personId1, personId2 };

			var result = this.scheduler.GetAvailableDatesForToday(1, personIds.ToSet());

			Assert.Fail();
		}
	}
}
