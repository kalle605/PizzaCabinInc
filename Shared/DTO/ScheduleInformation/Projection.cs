using System;
using System.Drawing;

namespace PizzaCabinInc.Shared.DTO.ScheduleInformation
{
	public class Projection
	{
		public Color Color { get; set; }
		public string Description { get; set; }
		public DateTimeOffset Start { get; set; }
		public int minutes { get; set; }
	}
}
