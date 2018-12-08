using System;

namespace PizzaCabinInc.Shared.DTO.ScheduleInformation
{
	public class Projection
	{
		public string Color { get; set; }
		public string Description { get; set; }
		public DateTimeOffset Start { get; set; }
		public int minutes { get; set; }

		public bool IsBreak => this.Description.Equals("Lunch", StringComparison.InvariantCultureIgnoreCase)
			|| this.Description.Equals("Short break", StringComparison.InvariantCultureIgnoreCase);
	}
}
