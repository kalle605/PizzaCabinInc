using PizzaCabinInc.Shared.DTO.ScheduleInformation;
using Shared.Scheduler;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLogics.Scheduler
{
	public class MeetingSchedulerCalculator : IMeetingSchedulerCalculator
	{
		public ScheduleResult ScheduleResult { get; }

		private const int WorkingHoursPerDay = 8;

		public MeetingSchedulerCalculator(ScheduleResult scheduleResult)
		{
			this.ScheduleResult = scheduleResult;
		}

		public IEnumerable<MeetingSchedulerResult> GetAvailableMeetings(int minNumberOfAttendees
			, ISet<Guid> personIds
			, DateTimeOffset wantedMeetingDate)
		{
			var schedules = this.ScheduleResult.Schedules
				.Where(s => personIds.Contains(s.PersonId)
					&& !s.IsFullDayAbsence
					&& wantedMeetingDate.Date == s.Date.Date
				);

			var availableDates = new List<UnAvailableDataHolder>();

			foreach (var schedule in schedules)
			{
				foreach (var projection in schedule.Projection.Where(s => !s.IsBreak))
				{
					availableDates.Add(new UnAvailableDataHolder(projection.Start
						, projection.Start.AddMinutes(projection.minutes)
						, schedule.PersonId));
				}
			}

			var firstAvailableDate = schedules.Min(s => s.Date);
			var quarters = firstAvailableDate.Minute / 15;

			Math.DivRem(firstAvailableDate.Minute, 15, out var reminder);

			var minutesToNextQuarter = quarters * 15 + reminder != 0 ? 15 : 0;

			for (var meetingDate = firstAvailableDate; firstAvailableDate.Date.AddDays(1) >= meetingDate; meetingDate = meetingDate.AddMinutes(15))
			{
				var a = availableDates
					.GroupBy(s => s.PersonId)
					.Where(s => s.Any(x => x.IsAvailable(meetingDate)))
					.ToList();

				if (a.Count >= minNumberOfAttendees)
				{
					yield return new MeetingSchedulerResult(a.Select(s => s.Key).ToList(), meetingDate);
				}
			}
		}

		private class UnAvailableDataHolder
		{
			private const int MeetingDuration = 15;

			public DateTimeOffset From { get; }
			public DateTimeOffset To { get; }
			public Guid PersonId { get; }

			public UnAvailableDataHolder(DateTimeOffset unavailableFrom
				, DateTimeOffset unavailableTo
				, Guid personId
				)
			{
				this.From = unavailableFrom;
				this.To = unavailableTo;
				this.PersonId = personId;
			}

			public bool IsAvailable(DateTimeOffset meetingDate)
			{
				var isAvailable = this.From <= meetingDate && this.To.AddMinutes(-MeetingDuration) >= meetingDate;

				return isAvailable;
			}

			public override bool Equals(object obj)
			{
				var holder = obj as UnAvailableDataHolder;

				return holder != null &&
					   this.PersonId.Equals(holder.PersonId);
			}
		}
	}
}
