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
using System.Diagnostics;
using System.Globalization;
using Openmiracle.MiracleIChart.Common.Auxiliary;

namespace Openmiracle.MiracleIChart.Charts
{
	public class DateTimeTicksProvider : TimeTicksProviderBase<DateTime>
	{
		static DateTimeTicksProvider()
		{
			Providers.Add(DifferenceIn.Year, new YearDateTimeProvider());
			Providers.Add(DifferenceIn.Month, new MonthDateTimeProvider());
			Providers.Add(DifferenceIn.Day, new DayDateTimeProvider());
			Providers.Add(DifferenceIn.Hour, new HourDateTimeProvider());
			Providers.Add(DifferenceIn.Minute, new MinuteDateTimeProvider());
			Providers.Add(DifferenceIn.Second, new SecondDateTimeProvider());
			Providers.Add(DifferenceIn.Millisecond, new MillisecondDateTimeProvider());

			MinorProviders.Add(DifferenceIn.Year, new MinorDateTimeProvider(new YearDateTimeProvider()));
			MinorProviders.Add(DifferenceIn.Month, new MinorDateTimeProvider(new MonthDateTimeProvider()));
			MinorProviders.Add(DifferenceIn.Day, new MinorDateTimeProvider(new DayDateTimeProvider()));
			MinorProviders.Add(DifferenceIn.Hour, new MinorDateTimeProvider(new HourDateTimeProvider()));
			MinorProviders.Add(DifferenceIn.Minute, new MinorDateTimeProvider(new MinuteDateTimeProvider()));
			MinorProviders.Add(DifferenceIn.Second, new MinorDateTimeProvider(new SecondDateTimeProvider()));
			MinorProviders.Add(DifferenceIn.Millisecond, new MinorDateTimeProvider(new MillisecondDateTimeProvider()));
		}


		protected sealed override TimeSpan GetDifference(DateTime start, DateTime end)
		{
			return end - start;
		}
	}

	internal static class DateTimeArrayExt
	{
		internal static int GetIndex(this DateTime[] array, DateTime value)
		{
			for (int i = 0; i < array.Length - 1; i++)
			{
				if (array[i] <= value && value < array[i + 1])
					return i;
			}

			return array.Length - 1;
		}
	}

	internal sealed class MinorDateTimeProvider : MinorTimeProviderBase<DateTime>
	{
		public MinorDateTimeProvider(ITicksProvider<DateTime> owner) : base(owner) { }

		protected override bool IsInside(DateTime value, Range<DateTime> range)
		{
			return range.Min < value && value < range.Max;
		}
	}

	internal sealed class YearDateTimeProvider : DatePeriodTicksProvider
	{
		protected override DifferenceIn GetDifferenceCore()
		{
			return DifferenceIn.Year;
		}

		protected override int[] GetTickCountsCore()
		{
			return new int[] { 20, 10, 5, 4, 2, 1 };
		}

		protected override int GetSpecificValue(DateTime start, DateTime dt)
		{
			return dt.Year;
		}

		protected override DateTime GetStart(DateTime start, int value, int step)
		{
			int year = start.Year;
			int newYear = (year / step) * step;
			if (newYear == 0) newYear = 1;

			return new DateTime(newYear, 1, 1);
		}

		protected override bool IsMinDate(DateTime dt)
		{
			return dt.Year == DateTime.MinValue.Year;
		}

		protected override DateTime AddStep(DateTime dt, int step)
		{
			if (dt.Year + step > DateTime.MaxValue.Year)
				return DateTime.MaxValue;

			return dt.AddYears(step);
		}
	}

	internal sealed class MonthDateTimeProvider : DatePeriodTicksProvider
	{
		protected override DifferenceIn GetDifferenceCore()
		{
			return DifferenceIn.Month;
		}

		protected override int[] GetTickCountsCore()
		{
			return new int[] { 12, 6, 4, 3, 2, 1 };
		}

		protected override int GetSpecificValue(DateTime start, DateTime dt)
		{
			return dt.Month + (dt.Year - start.Year) * 12;
		}

		protected override DateTime GetStart(DateTime start, int value, int step)
		{
			return new DateTime(start.Year, 1, 1);
		}

		protected override bool IsMinDate(DateTime dt)
		{
			return dt.Month == DateTime.MinValue.Month;
		}

		protected override DateTime AddStep(DateTime dt, int step)
		{
			return dt.AddMonths(step);
		}
	}

	internal sealed class DayDateTimeProvider : DatePeriodTicksProvider
	{
		protected override DifferenceIn GetDifferenceCore()
		{
			return DifferenceIn.Day;
		}

		protected override int[] GetTickCountsCore()
		{
			return new int[] { 30, 15, 10, 5, 2, 1 };
		}

		protected override int GetSpecificValue(DateTime start, DateTime dt)
		{
			return (dt - start).Days;
		}

		protected override DateTime GetStart(DateTime start, int value, int step)
		{
			return start.Date;
		}

		protected override bool IsMinDate(DateTime dt)
		{
			return dt.Day == 1;
		}

		protected override DateTime AddStep(DateTime dt, int step)
		{
			return dt.AddDays(step);
		}
	}

	internal sealed class HourDateTimeProvider : DatePeriodTicksProvider
	{
		protected override DifferenceIn GetDifferenceCore()
		{
			return DifferenceIn.Hour;
		}

		protected override int[] GetTickCountsCore()
		{
			return new int[] { 24, 12, 6, 4, 3, 2, 1 };
		}

		protected override int GetSpecificValue(DateTime start, DateTime dt)
		{
			return (int)(dt - start).TotalHours;
		}

		protected override DateTime GetStart(DateTime start, int value, int step)
		{
			return start.Date;
		}

		protected override bool IsMinDate(DateTime dt)
		{
			return false;
		}

		protected override DateTime AddStep(DateTime dt, int step)
		{
			return dt.AddHours(step);
		}
	}

	internal sealed class MinuteDateTimeProvider : DatePeriodTicksProvider
	{
		protected override DifferenceIn GetDifferenceCore()
		{
			return DifferenceIn.Minute;
		}

		protected override int[] GetTickCountsCore()
		{
			return new int[] { 60, 30, 20, 15, 10, 5, 4, 3, 2 };
		}

		protected override int GetSpecificValue(DateTime start, DateTime dt)
		{
			return (int)(dt - start).TotalMinutes;
		}

		protected override DateTime GetStart(DateTime start, int value, int step)
		{
			return start.Date.AddHours(start.Hour);
		}

		protected override bool IsMinDate(DateTime dt)
		{
			return false;
		}

		protected override DateTime AddStep(DateTime dt, int step)
		{
			return dt.AddMinutes(step);
		}
	}

	internal sealed class SecondDateTimeProvider : DatePeriodTicksProvider
	{
		protected override DifferenceIn GetDifferenceCore()
		{
			return DifferenceIn.Second;
		}

		protected override int[] GetTickCountsCore()
		{
			return new int[] { 60, 30, 20, 15, 10, 5, 4, 3, 2 };
		}

		protected override int GetSpecificValue(DateTime start, DateTime dt)
		{
			return (int)(dt - start).TotalSeconds;
		}

		protected override DateTime GetStart(DateTime start, int value, int step)
		{
			return start.Date.AddHours(start.Hour).AddMinutes(start.Minute);
		}

		protected override bool IsMinDate(DateTime dt)
		{
			return false;
		}

		protected override DateTime AddStep(DateTime dt, int step)
		{
			return dt.AddSeconds(step);
		}
	}

	internal sealed class MillisecondDateTimeProvider : DatePeriodTicksProvider
	{
		protected override DifferenceIn GetDifferenceCore()
		{
			return DifferenceIn.Millisecond;
		}

		protected override int[] GetTickCountsCore()
		{
			return new int[] { 100, 50, 40, 25, 20, 10, 5, 4, 2 };
		}

		protected override int GetSpecificValue(DateTime start, DateTime dt)
		{
			return (int)(dt - start).TotalMilliseconds;
		}

		protected override DateTime GetStart(DateTime start, int value, int step)
		{
			return start.Date.AddHours(start.Hour).AddMinutes(start.Minute).AddSeconds(start.Second);
		}

		protected override bool IsMinDate(DateTime dt)
		{
			return false;
		}

		protected override DateTime AddStep(DateTime dt, int step)
		{
			return dt.AddMilliseconds(step);
		}
	}
}
