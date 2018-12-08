using System;

namespace Shared.TimeService
{
	public interface ITimeService
	{
		DateTimeOffset CurrentDate { get; }
	}
}