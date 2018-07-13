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
	internal sealed class DateTimeToDoubleConversion
	{
		public DateTimeToDoubleConversion(double min, DateTime minDate, double max, DateTime maxDate)
		{
			this.min = min;
			this.length = max - min;
			this.ticksMin = minDate.Ticks;
			this.ticksLength = maxDate.Ticks - ticksMin;
		}

		private double min;
		private double length;
		private long ticksMin;
		private long ticksLength;

		internal DateTime FromDouble(double d)
		{
			double ratio = (d - min) / length;
			long tick = (long)(ticksMin + ticksLength * ratio);

			tick = MathHelper.Clamp(tick, DateTime.MinValue.Ticks, DateTime.MaxValue.Ticks);

			return new DateTime(tick);
		}

		internal double ToDouble(DateTime dt)
		{
			double ratio = (dt.Ticks - ticksMin) / (double)ticksLength;
			return min + ratio * length;
		}
	}
}
