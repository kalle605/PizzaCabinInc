using Shared.TimeService;
using System;

namespace Infrastructure.TimeService
{
	public class TimeService : ITimeService
	{
		public DateTimeOffset CurrentDate => DateTime.Now;
	}
}
