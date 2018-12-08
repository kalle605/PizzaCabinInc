using System;
using System.Collections.Generic;

public struct MeetingSchedulerResult
{
	public IEnumerable<Guid> AvailablePersonIds { get; }
	public DateTimeOffset? AvailableDate { get; }

	public MeetingSchedulerResult(IEnumerable<Guid> availablePersonIds
		, DateTimeOffset availableDate) : this()
	{
		this.AvailablePersonIds = availablePersonIds;
		this.AvailableDate = availableDate;
	}
}