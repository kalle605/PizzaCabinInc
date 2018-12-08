using System;
using System.Collections.Generic;

public class MeetingSchedulerResult
{
	public IEnumerable<Guid> AvailablePersonIds { get; set; }
	public DateTimeOffset AvailableDate { get; set; }
}