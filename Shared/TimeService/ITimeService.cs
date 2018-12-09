using System;

namespace Shared.TimeService
{
	/// <summary>
	/// Time service to get current date.
	/// <para>Returns <see cref="DateTimeOffset"/></para>
	/// </summary>
	public interface ITimeService
	{
		DateTimeOffset CurrentDate { get; }
	}
}