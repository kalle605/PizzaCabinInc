using BusinessLogics.Scheduler;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PizzaCabinInc.Shared.DTO.ScheduleInformation;
using Shared.TimeService;
using System;
using System.Collections.Generic;
using TestHelpers;

namespace BusinessLogics.Tests
{
	[TestClass]
	public class MeetingSchedulerExceptionHandlingTests
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
				, null);
		}

		[TestMethod]
		[ExpectedException(typeof(InvalidOperationException))]
		public void GetNextAvailableDateShouldThrowWhenPersonsAreEmpty()
		{
			this.scheduler.GetNextAvailableDate(0, new HashSet<Guid>());
		}

		[TestMethod]
		[ExpectedException(typeof(InvalidOperationException))]
		public void GetAvailableDatesForTodayThrowWhenPersonsAreEmpty()
		{
			this.scheduler.GetNextAvailableDate(0, new HashSet<Guid>());
		}

		[TestMethod]
		[ExpectedException(typeof(InvalidOperationException))]
		public void GetNextAvailableDateShouldTShouldThrowWhenPersonsCountAreLessThanMinNumberOfAttendees()
		{
			var personId1 = Guid.NewGuid();
			var personId2 = Guid.NewGuid();

			var personIds = new[] { personId1, personId2 };

			var result = this.scheduler.GetNextAvailableDate(3, personIds.ToSet());
		}

		[TestMethod]
		[ExpectedException(typeof(InvalidOperationException))]
		public void GetAvailableDatesForTodayShouldThrowWhenPersonsCountAreLessThanMinNumberOfAttendees()
		{
			var personId1 = Guid.NewGuid();
			var personId2 = Guid.NewGuid();

			var personIds = new[] { personId1, personId2 };

			this.scheduler.GetAvailableDatesForToday(3, personIds.ToSet());
		}

		[TestMethod]
		[ExpectedException(typeof(InvalidOperationException))]
		public void GetNextAvailableDateShouldNotAllowZeroMinNumberOfAttendees()
		{
			var personId1 = Guid.NewGuid();

			this.scheduler.GetNextAvailableDate(0, personId1.ToSet());
		}

		[TestMethod]
		[ExpectedException(typeof(InvalidOperationException))]
		public void GetAvailableDatesForTodayShouldNotAllowZeroMinNumberOfAttendees()
		{
			var personId1 = Guid.NewGuid();

			this.scheduler.GetAvailableDatesForToday(0, personId1.ToSet());
		}
	}
}
