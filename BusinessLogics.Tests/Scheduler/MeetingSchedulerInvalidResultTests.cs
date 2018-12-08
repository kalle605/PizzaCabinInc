using BusinessLogics.Scheduler;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PizzaCabinInc.Shared.DTO.ScheduleInformation;
using Shared.Scheduler;
using Shared.TimeService;
using System;
using System.Collections.Generic;
using System.Linq;
using TestHelpers;

namespace BusinessLogics.Tests
{
	[TestClass]
	public class MeetingSchedulerInvalidResultTests
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

			var meetingSchedulerCalculator = Mock.Of<IMeetingSchedulerCalculator>(s => s.GetAvailableMeetings(It.IsAny<int>()
				, It.IsAny<ISet<Guid>>()
				, this.currentDate) == Enumerable.Empty<MeetingSchedulerResult>());

			this.scheduler = new MeetingScheduler(timeService
				, meetingSchedulerCalculator);
		}

		[TestMethod]
		public void GetNextAvailableDateShouldBeAbleToHandleInvalidResult()
		{
			var expectedDate = new DateTimeOffset(2018, 01, 01, 08, 00, 00, TimeSpan.Zero);

			var personId1 = Guid.NewGuid();
			var personId2 = Guid.NewGuid();

			var personIds = new[] { personId1, personId2 };

			var result = this.scheduler.GetNextAvailableDate(1, personIds.ToSet());

			Assert.IsNull(result.AvailableDate);
		}

		[TestMethod]
		public void GetAvailableDatesForTodayShouldBeAbleToHandleInvalidResult()
		{
			var expectedDate = new DateTimeOffset(2018, 01, 01, 08, 00, 00, TimeSpan.Zero);

			var personId1 = Guid.NewGuid();
			var personId2 = Guid.NewGuid();

			var personIds = new[] { personId1, personId2 };

			var result = this.scheduler.GetAvailableDatesForToday(1, personIds.ToSet());

			Assert.AreEqual(0, result.Count());
		}
	}
}
