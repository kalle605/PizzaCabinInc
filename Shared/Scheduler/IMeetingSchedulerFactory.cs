using Shared.Scheduler;

namespace Shared.Scheduler
{
	/// <summary>
	/// Factory to create <see cref="IMeetingScheduler"/>.
	/// </summary>
	public interface IMeetingSchedulerFactory
	{
		IMeetingScheduler CreateScheduler();
	}
}