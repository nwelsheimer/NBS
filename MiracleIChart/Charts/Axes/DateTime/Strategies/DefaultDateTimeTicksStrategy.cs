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
	public class DefaultDateTimeTicksStrategy : IDateTimeTicksStrategy
	{
		public virtual DifferenceIn GetDifference(TimeSpan span)
		{
			span = span.Duration();

			DifferenceIn diff;
			if (span.Days > 365)
				diff = DifferenceIn.Year;
			else if (span.Days > 30)
				diff = DifferenceIn.Month;
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

		public virtual bool TryGetLowerDiff(DifferenceIn diff, out DifferenceIn lowerDiff)
		{
			lowerDiff = diff;

			int code = (int)diff;
			bool res = code > (int)DifferenceIn.Smallest;
			if (res)
			{
				lowerDiff = (DifferenceIn)(code - 1);
			}
			return res;
		}

		public virtual bool TryGetBiggerDiff(DifferenceIn diff, out DifferenceIn biggerDiff)
		{
			biggerDiff = diff;

			int code = (int)diff;
			bool res = code < (int)DifferenceIn.Biggest;
			if (res)
			{
				biggerDiff = (DifferenceIn)(code + 1);
			}
			return res;
		}
	}
}
