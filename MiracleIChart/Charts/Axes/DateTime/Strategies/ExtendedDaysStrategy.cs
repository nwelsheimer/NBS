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
	public class ExtendedDaysStrategy : IDateTimeTicksStrategy
	{
		private static readonly DifferenceIn[] diffs = new DifferenceIn[] { 
			DifferenceIn.Year,
			DifferenceIn.Day,
			DifferenceIn.Hour,
			DifferenceIn.Minute,
			DifferenceIn.Second,
			DifferenceIn.Millisecond
		};

		public DifferenceIn GetDifference(TimeSpan span)
		{
			span = span.Duration();

			DifferenceIn diff;
			if (span.Days > 365)
				diff = DifferenceIn.Year;
			else if (span.Days > 0)
				diff = DifferenceIn.Day;
			else if (span.Hours > 0)
				diff = DifferenceIn.Hour;
			else if (span.Minutes > 0)
				diff = DifferenceIn.Minute;
			else if (span.Seconds > 0)
				diff = DifferenceIn.Second;
			else
				diff = DifferenceIn.Millisecond;

			return diff;
		}

		public bool TryGetLowerDiff(DifferenceIn diff, out DifferenceIn lowerDiff)
		{
			lowerDiff = diff;

			int index = Array.IndexOf(diffs, diff);
			if (index == -1)
				return false;

			if (index == diffs.Length - 1)
				return false;

			lowerDiff = diffs[index + 1];
			return true;
		}

		public bool TryGetBiggerDiff(DifferenceIn diff, out DifferenceIn biggerDiff)
		{
			biggerDiff = diff;

			int index = Array.IndexOf(diffs, diff);
			if (index == -1 || index == 0)
				return false;

			biggerDiff = diffs[index - 1];
			return true;
		}
	}
}
