using PizzaCabinInc.Shared.DTO.ScheduleInformation;

namespace PizzaCabinInc.Shared.ScheduleDataProviders
{
	public interface IScheduleDataProvider
	{
		ScheduleResult GetSchedules();
	}
}