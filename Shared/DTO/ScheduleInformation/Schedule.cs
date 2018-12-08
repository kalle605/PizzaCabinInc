using System;
using System.Collections.Generic;

namespace PizzaCabinInc.Shared.DTO.ScheduleInformation
{
	public class Schedule
	{
		public int ContractTimeMinutes { get; set; }
		public DateTimeOffset Date { get; set; }
		public bool IsFullDayAbsence { get; set; }
		public string Name { get; set; }
		public Guid PersonId { get; set; }
		public IList<Projection> Projection { get; set; }

		public Schedule()
		{
			this.Projection = new List<Projection>();
		}
	}
}
