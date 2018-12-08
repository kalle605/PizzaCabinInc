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
		public IMeetingSchedulerCalculator MeetingSchedulerCalculator { get; set; }

		public MeetingScheduler(ITimeService timeService
			, IMeetingSchedulerCalculator meetingSchedulerCalculator)
		{
			this.TimeService = timeService;
			this.MeetingSchedulerCalculator = meetingSchedulerCalculator;
		}

		public IEnumerable<MeetingSchedulerResult> GetAvailableDatesForToday(int minNumberOfAttendees
			, ISet<Guid> personIds)
		{
			EnsureValidParameters(minNumberOfAttendees, personIds);

			return this.MeetingSchedulerCalculator.GetAvailableMeetings(minNumberOfAttendees
				, personIds
				, this.TimeService.CurrentDate
				);
		}

		public MeetingSchedulerResult GetNextAvailableDate(int minNumberOfAttendees
			, ISet<Guid> personIds)
		{
			EnsureValidParameters(minNumberOfAttendees, personIds);

			var availableDates = this.MeetingSchedulerCalculator
				.GetAvailableMeetings(minNumberOfAttendees, personIds, this.TimeService.CurrentDate)
				.OrderBy(s => s.AvailableDate);

			return availableDates.FirstOrDefault();
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

			if (minNumberOfAttendees <= 0)
			{
				throw new InvalidOperationException();
			}
		}
	}
}
