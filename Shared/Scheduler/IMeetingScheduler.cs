using System;
using System.Collections.Generic;

namespace Shared.Scheduler
{
	public interface IMeetingScheduler
	{
		/// <summary>
		/// Gets the all available dates for a meeting today and throws when person identities are empty.
		/// 
		/// <para>Returns <see cref="IEnumerable{T}"/> where <see cref="{T}"/> is <see cref="MeetingSchedulerResult"/></para>
		/// </summary>
		/// <param name="minNumberOfAttendees">Lowest accepted number of attendees.</param>
		/// <param name="personIds">Person identities that can attend the meeting.</param>
		/// <exception cref="InvalidOperationException"></exception>
		MeetingSchedulerResult GetNextAvailableDate(int minNumberOfAttendees
			, params Guid[] personIds);

		/// <summary>
		/// Gets the next available date for a meeting and throws when person identities are empty.
		/// 
		/// <para>Returns <see cref="MeetingSchedulerResult"/></para>
		/// </summary>
		/// <param name="minNumberOfAttendees">Lowest accepted number of attendees.</param>
		/// <param name="personIds">Person identities that can attend the meeting.</param>
		/// <exception cref="InvalidOperationException"></exception>
		/// <returns cref="MeetingSchedulerResult">Information about the next meeting</returns>
		IEnumerable<MeetingSchedulerResult> GetAvailableDatesForToday(int minNumberOfAttendees
			, params Guid[] personIds);
	}
}