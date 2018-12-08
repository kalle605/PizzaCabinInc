using System;
using System.Collections.Generic;

namespace Shared.Scheduler
{
	public interface IMeetingSchedulerCalculator
	{
		IEnumerable<MeetingSchedulerResult> GetAvailableMeetings(int minNumberOfAttendees
			, ISet<Guid> personIds
			, DateTimeOffset wantedMeetingDate);
	}
}