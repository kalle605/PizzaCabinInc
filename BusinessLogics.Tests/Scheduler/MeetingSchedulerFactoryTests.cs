using BusinessLogics.Scheduler;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PizzaCabinInc.Shared.DTO.ScheduleInformation;
using PizzaCabinInc.Shared.ScheduleDataProviders;
using Shared.TimeService;

namespace BusinessLogics.Tests
{
	[TestClass]
	public class MeetingSchedulerFactoryTests
	{
		private ITimeService timeService;
		private ScheduleResult schedueResult;
		private MeetingSchedulerFactory factory;

		[TestInitialize]
		public void TestInitialize()
		{
			this.timeService = Mock.Of<ITimeService>();
			this.schedueResult = new ScheduleResult();

			var dataProvider = Mock.Of<IScheduleDataProvider>(s => s.GetSchedules() == this.schedueResult);

			this.factory = new MeetingSchedulerFactory(this.timeService, dataProvider);
		}

		[TestMethod]
		public void ShouldBeAbleToCreateScheduler()
		{
			var result = this.factory.CreateScheduler();

			Assert.IsInstanceOfType(result, typeof(MeetingScheduler));

			var scheduler = (MeetingScheduler)result;

			Assert.AreSame(this.timeService, scheduler.TimeService);
			Assert.AreSame(this.schedueResult, scheduler.ScheduleResult);
		}
	}
}
