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

	public override bool Equals(object obj)
	{
		if (!(obj is MeetingSchedulerResult))
		{
			return false;
		}

		var result = (MeetingSchedulerResult)obj;

		return EqualityComparer<IEnumerable<Guid>>.Default.Equals(this.AvailablePersonIds, result.AvailablePersonIds) &&
			   EqualityComparer<DateTimeOffset?>.Default.Equals(this.AvailableDate, result.AvailableDate);
	}
}