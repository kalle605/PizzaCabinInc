using PizzaCabinInc.Shared.DTO.ScheduleInformation;

namespace PizzaCabinInc.Shared.ScheduleDataProviders
{
	/// <summary>
	/// Repository for schedules.
	/// <para>Returns <see cref="ScheduleResult"/></para>
	/// </summary>
	public interface IScheduleDataProvider
	{
		ScheduleResult GetSchedules();
	}
}