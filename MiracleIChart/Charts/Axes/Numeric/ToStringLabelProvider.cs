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
	public class ToStringLabelProvider : NumericLabelProviderBase
	{
		public override UIElement[] CreateLabels(ITicksInfo<double> ticksInfo)
		{
			var ticks = ticksInfo.Ticks;

			Init(ticks);

			UIElement[] res = new UIElement[ticks.Length];
			LabelTickInfo<double> tickInfo = new LabelTickInfo<double> { Info = ticksInfo.Info };
			for (int i = 0; i < res.Length; i++)
			{
				tickInfo.Tick = ticks[i];
				tickInfo.Index = i;

				string label = GetString(tickInfo);
				res[i] = new TextBlock
				{
					Text = label,
					ToolTip = ticks[i].ToString()
				};

				ApplyCustomView(tickInfo, res[i]);
			}
			return res;
		}
	}
}
