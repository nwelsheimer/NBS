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
using Openmiracle.MiracleIChart.Common.Auxiliary;

namespace Openmiracle.MiracleIChart.Charts
{
	public abstract class DateTimeTicksProviderBase : ITicksProvider<DateTime>
	{
		public event EventHandler Changed;
		protected void RaiseChanged()
		{
			if (Changed != null)
			{
				Changed(this, EventArgs.Empty);
			}
		}

		protected static DateTime Shift(DateTime dateTime, DifferenceIn diff)
		{
			DateTime res = dateTime;

			switch (diff)
			{
				case DifferenceIn.Year:
					res = res.AddYears(1);
					break;
				case DifferenceIn.Month:
					res = res.AddMonths(1);
					break;
				case DifferenceIn.Day:
					res = res.AddDays(1);
					break;
				case DifferenceIn.Hour:
					res = res.AddHours(1);
					break;
				case DifferenceIn.Minute:
					res = res.AddMinutes(1);
					break;
				case DifferenceIn.Second:
					res = res.AddSeconds(1);
					break;
				case DifferenceIn.Millisecond:
					res = res.AddMilliseconds(1);
					break;
				default:
					break;
			}

			return res;
		}

		protected static DateTime RoundDown(DateTime dateTime, DifferenceIn diff)
		{
			DateTime res = dateTime;

			switch (diff)
			{
				case DifferenceIn.Year:
					res = new DateTime(dateTime.Year, 1, 1);
					break;
				case DifferenceIn.Month:
					res = new DateTime(dateTime.Year, dateTime.Month, 1);
					break;
				case DifferenceIn.Day:
					res = dateTime.Date;
					break;
				case DifferenceIn.Hour:
					res = dateTime.Date.AddHours(dateTime.Hour);
					break;
				case DifferenceIn.Minute:
					res = dateTime.Date.AddHours(dateTime.Hour).AddMinutes(dateTime.Minute);
					break;
				case DifferenceIn.Second:
					res = dateTime.Date.AddHours(dateTime.Hour).AddMinutes(dateTime.Minute).AddSeconds(dateTime.Second);
					break;
				case DifferenceIn.Millisecond:
					res = dateTime.Date.AddHours(dateTime.Hour).AddMinutes(dateTime.Minute).AddSeconds(dateTime.Second).AddMilliseconds(dateTime.Millisecond);
					break;
				default:
					break;
			}

			DebugVerify.Is(res <= dateTime);

			return res;
		}

		protected static DateTime RoundUp(DateTime dateTime, DifferenceIn diff)
		{
			DateTime res = RoundDown(dateTime, diff);

			switch (diff)
			{
				case DifferenceIn.Year:
					res = res.AddYears(1);
					break;
				case DifferenceIn.Month:
					res = res.AddMonths(1);
					break;
				case DifferenceIn.Day:
					res = res.AddDays(1);
					break;
				case DifferenceIn.Hour:
					res = res.AddHours(1);
					break;
				case DifferenceIn.Minute:
					res = res.AddMinutes(1);
					break;
				case DifferenceIn.Second:
					res = res.AddSeconds(1);
					break;
				case DifferenceIn.Millisecond:
					res = res.AddMilliseconds(1);
					break;
				default:
					break;
			}

			return res;
		}

		#region ITicksProvider<DateTime> Members

		public abstract ITicksInfo<DateTime> GetTicks(Range<DateTime> range, int ticksCount);
		public abstract int DecreaseTickCount(int ticksCount);
		public abstract int IncreaseTickCount(int ticksCount);
		public abstract ITicksProvider<DateTime> MinorProvider { get; }
		public abstract ITicksProvider<DateTime> MayorProvider { get; }

		#endregion
	}
}
