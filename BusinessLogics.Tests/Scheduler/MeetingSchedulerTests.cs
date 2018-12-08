using BusinessLogics.Scheduler;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Shared.Scheduler;
using Shared.TimeService;
using System;
using TestHelpers;

namespace BusinessLogics.Tests
{
	[TestClass]
	public class MeetingSchedulerTests
	{
		private DateTime currentDate;
		private Mock<IMeetingSchedulerCalculator> calculator;
		private MeetingScheduler scheduler;

		[TestInitialize]
		public void TestInitialize()
		{
			this.calculator = new Mock<IMeetingSchedulerCalculator>();
			this.currentDate = new DateTime(2018, 01, 01);

			var timeService = Mock.Of<ITimeService>(s => s.CurrentDate == this.currentDate);

			this.scheduler = new MeetingScheduler(timeService
				, this.calculator.Object);
		}

		[TestMethod]
		public void ShouldBeAbleToGetAvailableDatesForToday()
		{
			const int MinNumberOfAttendees = 1;

			var personId1 = Guid.NewGuid();
			var personId2 = Guid.NewGuid();

			var personIds = new[] { personId1, personId2 }.ToSet();

			var schedulerResults = new[]
			{
				new MeetingSchedulerResult(null, this.currentDate.AddHours(1)),
				new MeetingSchedulerResult(null, this.currentDate),
			};

			this.calculator
				.Setup(s => s.GetAvailableMeetings(MinNumberOfAttendees
					, personIds
					, this.currentDate))
				.Returns(schedulerResults);


			var result = this.scheduler.GetAvailableDatesForToday(MinNumberOfAttendees, personIds);

			Assert.AreSame(schedulerResults, result);
		}

		[TestMethod]
		public void ShouldBeAbleToGetNextAvailableDate()
		{
			const int MinNumberOfAttendees = 1;

			var personId1 = Guid.NewGuid();
			var personId2 = Guid.NewGuid();

			var personIds = new[] { personId1, personId2 }.ToSet();

			var meetingSchedulerResult = new MeetingSchedulerResult(null, this.currentDate);

			var schedulerResults = new[]
			{
				new MeetingSchedulerResult(null, this.currentDate.AddHours(1)),
				meetingSchedulerResult,
			};

			this.calculator
				.Setup(s => s.GetAvailableMeetings(MinNumberOfAttendees
					, personIds
					, this.currentDate))
				.Returns(schedulerResults);


			var result = this.scheduler.GetNextAvailableDate(MinNumberOfAttendees, personIds);

			Assert.AreEqual(meetingSchedulerResult.AvailableDate, result.AvailableDate);
			Assert.AreSame(meetingSchedulerResult.AvailablePersonIds, result.AvailablePersonIds);
		}
	}
}
