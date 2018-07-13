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

namespace Openmiracle.MiracleIChart.Charts
{
	internal static class RoundHelper
	{
		internal static int GetDifferenceLog(double min, double max)
		{
			return (int)Math.Log(Math.Abs(max - min));
		}

		internal static double Round(double number, int rem)
		{
			if (rem <= 0)
			{
				rem = MathHelper.Clamp(-rem, 0, 15);
				return Math.Round(number, rem);
			}
			else
			{
				double pow = Math.Pow(10, rem - 1);
				double val = pow * Math.Round(number / Math.Pow(10, rem - 1));
				return val;
			}
		}

		internal static RoundingInfo CreateRoundedRange(double min, double max)
		{
			double delta = max - min;

			if (delta == 0)
				return new RoundingInfo { Min = min, Max = max, Log = 0 };

			int log = (int)Math.Round(Math.Log10(Math.Abs(delta))) + 1;

			double newMin = Round(min, log);
			double newMax = Round(max, log);
			if (newMin == newMax)
			{
				log--;
				newMin = Round(min, log);
				newMax = Round(max, log);
			}

			return new RoundingInfo { Min = newMin, Max = newMax, Log = log };
		}
	}

	[DebuggerDisplay("{Min} - {Max}, Log = {Log}")]
	internal sealed class RoundingInfo
	{
		public double Min { get; set; }
		public double Max { get; set; }
		public int Log { get; set; }
	}
}
