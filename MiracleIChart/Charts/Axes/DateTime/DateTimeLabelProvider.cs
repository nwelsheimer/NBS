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
using System.Windows.Controls;
using Openmiracle.MiracleIChart.Charts.Axes;

namespace Openmiracle.MiracleIChart.Charts
{
	public class DateTimeLabelProvider : DateTimeLabelProviderBase
	{
		public override UIElement[] CreateLabels(ITicksInfo<DateTime> ticksInfo)
		{
			object info = ticksInfo.Info;
			var ticks = ticksInfo.Ticks;

			if (info is DifferenceIn)
			{
				DifferenceIn diff = (DifferenceIn)info;
				DateFormat = GetDateFormat(diff);
			}

			LabelTickInfo<DateTime> tickInfo = new LabelTickInfo<DateTime> { Info = info };

			UIElement[] res = new UIElement[ticks.Length];
			for (int i = 0; i < ticks.Length; i++)
			{
				tickInfo.Tick = ticks[i];

				string tickText = GetString(tickInfo);
				UIElement label = new TextBlock { Text = tickText, ToolTip = ticks[i] };
				ApplyCustomView(tickInfo, label);
				res[i] = label;
			}

			return res;
		}
	}
}
