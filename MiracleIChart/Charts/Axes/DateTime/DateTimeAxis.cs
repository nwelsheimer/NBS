//This is a source code or part of OpenMiracle project
//Copyright (C) 2013 OpenMiracle
//This program is free software: you can redistribute it and/or modify
//it under the terms of the GNU General Public License as published by
//the Free Software Foundation, either version 3 of the License, or
//(at your option) any later version.
//This program is distributed in the hope that it will be useful,
//but WITHOUT ANY WARRANTY; without even the implied warranty of
//MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
//GNU General Public License for more details.
//You should have received a copy of the GNU General Public License
//along with this program. If not, see <http://www.gnu.org/licenses/>.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Openmiracle.MiracleIChart.Charts
{
	/// <summary>
	/// Base class for DateTime axis.
	/// </summary>
	public class DateTimeAxis : AxisBase<DateTime>
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="DateTimeAxis"/> class.
		/// </summary>
		public DateTimeAxis()
			: base(new DateTimeAxisControl(), DoubleToDate,
				dt => dt.Ticks / 10000000000.0)
		{ }

		private static readonly long minTicks = DateTime.MinValue.Ticks;
		private static readonly long maxTicks = DateTime.MaxValue.Ticks;
		private static DateTime DoubleToDate(double d)
		{
			long ticks = (long)(d * 10000000000L);

			// todo should we throw an exception if number of ticks is too big or small?
			if (ticks < minTicks)
				ticks = minTicks;
			else if (ticks > maxTicks)
				ticks = maxTicks;

			return new DateTime(ticks);
		}

		/// <summary>
		/// Sets the conversion of ticks.
		/// </summary>
		/// <param name="min">The minimal double value.</param>
		/// <param name="minDate">The minimal date, corresponding to minimal double value.</param>
		/// <param name="max">The maximal double value.</param>
		/// <param name="maxDate">The maximal date, correspondong to maximal double value.</param>
		public void SetConversion(double min, DateTime minDate, double max, DateTime maxDate)
		{
			var conversion = new DateTimeToDoubleConversion(min, minDate, max, maxDate);

			ConvertToDouble = conversion.ToDouble;
			ConvertFromDouble = conversion.FromDouble;
		}
	}
}
