using PizzaCabinInc.Shared.ScheduleDataProviders;
using Shared.Scheduler;
using Shared.TimeService;

namespace BusinessLogics.Scheduler
{
	public class MeetingSchedulerFactory : IMeetingSchedulerFactory
	{
		private readonly ITimeService timeService;
		private readonly IScheduleDataProvider scheduleDataProvider;

		public MeetingSchedulerFactory(ITimeService timeService
			, IScheduleDataProvider scheduleDataProvider)
		{
			this.timeService = timeService;
			this.scheduleDataProvider = scheduleDataProvider;
		}

		public IMeetingScheduler CreateScheduler()
		{
			return new MeetingScheduler(this.timeService, this.scheduleDataProvider.GetSchedules());
		}
	}
}
