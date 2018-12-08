using PizzaCabinInc.Shared.DTO.ScheduleInformation;
using Shared.Scheduler;
using Shared.TimeService;
using System;
using System.Collections.Generic;

namespace BusinessLogics.Scheduler
{
	public class MeetingScheduler : IMeetingScheduler
	{
		public ITimeService TimeService { get; }
		public ScheduleResult ScheduleResult { get; }

		public MeetingScheduler(ITimeService timeService
			, ScheduleResult scheduleResult)
		{
			this.TimeService = timeService;
			this.ScheduleResult = scheduleResult;
		}


		public IEnumerable<MeetingSchedulerResult> GetAvailableDatesForToday(int minNumberOfAttendees
			, params Guid[] personIds)
		{
			throw new NotImplementedException();
		}

		public MeetingSchedulerResult GetNextAvailableDate(int minNumberOfAttendees
			, params Guid[] personIds)
		{
			throw new NotImplementedException();
		}
	}
}
