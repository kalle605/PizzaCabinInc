using PizzaCabinInc.Shared.DTO.ScheduleInformation;
using Shared.Scheduler;
using Shared.TimeService;
using System;
using System.Collections.Generic;
using System.Linq;

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
			, ISet<Guid> personIds)
		{
			EnsureValidParameters(minNumberOfAttendees, personIds);

			return Enumerable.Empty<MeetingSchedulerResult>();
		}

		public MeetingSchedulerResult GetNextAvailableDate(int minNumberOfAttendees
			, ISet<Guid> personIds)
		{
			EnsureValidParameters(minNumberOfAttendees, personIds);

			return MeetingSchedulerResult.Invalid();
		}

		private static void EnsureValidParameters(int minNumberOfAttendees, ISet<Guid> personIds)
		{
			if (!personIds.Any())
			{
				throw new InvalidOperationException();
			}

			if (personIds.Count() < minNumberOfAttendees)
			{
				throw new InvalidOperationException();
			}

			if(minNumberOfAttendees <= 0)
			{
				throw new InvalidOperationException();
			}
		}
	}
}
