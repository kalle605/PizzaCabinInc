using System.Collections.Generic;

namespace PizzaCabinInc.Shared.DTO.ScheduleInformation
{
	public class ScheduleResult
	{
		public IList<Schedule> Schedules { get; set; }

		public ScheduleResult()
		{
			this.Schedules = new List<Schedule>();
		}
	}
}
