using Shared.Scheduler;

namespace Shared.Scheduler
{
	public interface IMeetingSchedulerFactory
	{
		IMeetingScheduler CreateScheduler();
	}
}