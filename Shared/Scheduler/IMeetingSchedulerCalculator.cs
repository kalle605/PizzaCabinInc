using System;
using System.Collections.Generic;

namespace Shared.Scheduler
{
	/// <summary>
	/// Calculator to calculate the next meeting with the minimum amount of attendeees.
	/// <para>Returns <see cref="MeetingSchedulerResult"/></para>
	/// </summary>
	public interface IMeetingSchedulerCalculator
	{
		IEnumerable<MeetingSchedulerResult> GetAvailableMeetings(int minNumberOfAttendees
			, ISet<Guid> personIds
			, DateTimeOffset wantedMeetingDate);
	}
}