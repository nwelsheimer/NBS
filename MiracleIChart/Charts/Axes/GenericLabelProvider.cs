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

namespace Openmiracle.MiracleIChart.Charts.Axes
{
	public class GenericLabelProvider<T> : LabelProviderBase<T>
	{
		#region ILabelProvider<T> Members

		public override UIElement[] CreateLabels(ITicksInfo<T> ticksInfo)
		{
			var ticks = ticksInfo.Ticks;
			var info = ticksInfo.Info;

			LabelTickInfo<T> tickInfo = new LabelTickInfo<T>();
			UIElement[] res = new UIElement[ticks.Length];
			for (int i = 0; i < res.Length; i++)
			{
				tickInfo.Tick = ticks[i];
				tickInfo.Info = info;

				string text = GetString(tickInfo);

				res[i] = new TextBlock
				{
					Text = text,
					ToolTip = ticks[i].ToString()
				};
			}
			return res;
		}

		#endregion
	}
}
