using BusinessLogics.Scheduler;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PizzaCabinInc.Shared.DTO.ScheduleInformation;
using Shared.TimeService;
using System;

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

			var result = this.scheduler.GetNextAvailableDate(1, personIds);

			Assert.AreEqual(expectedDate, result);
		}

		[TestMethod]
		public void ShouldBeAbleToGetAvailableDatesForToday()
		{
			var expectedDate = new DateTimeOffset(2018, 01, 01, 08, 00, 00, TimeSpan.Zero);

			var personId1 = Guid.NewGuid();
			var personId2 = Guid.NewGuid();

			var personIds = new[] { personId1, personId2 };

			var result = this.scheduler.GetNextAvailableDate(1, personIds);

			Assert.AreEqual(expectedDate, result);
		}

		[TestMethod]
		[ExpectedException(typeof(InvalidOperationException))]
		public void GetNextAvailableDateShouldThrowWhenPersonsAreEmpty()
		{
			this.scheduler.GetNextAvailableDate(0);
		}

		[TestMethod]
		[ExpectedException(typeof(InvalidOperationException))]
		public void GetAvailableDatesForTodayThrowWhenPersonsAreEmpty()
		{
			this.scheduler.GetNextAvailableDate(0);
		}

		[TestMethod]
		[ExpectedException(typeof(InvalidOperationException))]
		public void GetNextAvailableDateShouldTShouldThrowWhenPersonsCountAreLessThanMinNumberOfAttendees()
		{
			var personId1 = Guid.NewGuid();
			var personId2 = Guid.NewGuid();

			var personIds = new[] { personId1, personId2 };

			var result = this.scheduler.GetNextAvailableDate(3, personIds);
		}

		[TestMethod]
		[ExpectedException(typeof(InvalidOperationException))]
		public void GetAvailableDatesForTodayShouldThrowWhenPersonsCountAreLessThanMinNumberOfAttendees()
		{
			var personId1 = Guid.NewGuid();
			var personId2 = Guid.NewGuid();

			var personIds = new[] { personId1, personId2 };

			this.scheduler.GetAvailableDatesForToday(3, personIds);
		}
	}
}
