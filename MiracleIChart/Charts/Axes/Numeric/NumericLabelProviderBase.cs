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
using System.Windows;
using Openmiracle.MiracleIChart.Charts.Axes;

namespace Openmiracle.MiracleIChart.Charts
{
	public abstract class NumericLabelProviderBase : LabelProviderBase<double>
	{
		bool shouldRound = true;
		private int rounding;
		protected void Init(double[] ticks)
		{
			if (ticks.Length == 0)
				return;

			double start = ticks[0];
			double finish = ticks[ticks.Length - 1];

			if (start == finish)
			{
				shouldRound = false;
				return;
			}

			double delta = finish - start;

			rounding = (int)Math.Round(Math.Log10(delta));

			double newStart = RoundHelper.Round(start, rounding);
			double newFinish = RoundHelper.Round(finish, rounding);
			if (newStart == newFinish)
				rounding--;
		}

		protected override string GetStringCore(LabelTickInfo<double> tickInfo)
		{
			string res;
			if (!shouldRound)
			{
				res = tickInfo.Tick.ToString();
			}
			else
			{
				int round = Math.Min(15, Math.Max(-15, rounding - 2));
				res = RoundHelper.Round(tickInfo.Tick, round).ToString();
			}

			return res;
		}
	}
}
