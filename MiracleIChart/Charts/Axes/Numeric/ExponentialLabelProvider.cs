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
using System.Windows.Documents;
using System.Globalization;
using System.Diagnostics;
using Openmiracle.MiracleIChart.Charts.Axes;

namespace Openmiracle.MiracleIChart.Charts
{
	public sealed class ExponentialLabelProvider : NumericLabelProviderBase
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

				if (label.Contains('E'))
				{
					string[] substrs = label.Split('E');
					string mantissa = substrs[0];
					string exponenta = substrs[1];
					exponenta = exponenta.TrimStart('+');
					Span span = new Span();
					span.Inlines.Add(String.Format(CultureInfo.CurrentCulture, "{0}·10", mantissa));
					Span exponentaSpan = new Span(new Run(exponenta));
					exponentaSpan.BaselineAlignment = BaselineAlignment.Superscript;
					exponentaSpan.FontSize = 8;
					span.Inlines.Add(exponentaSpan);
					res[i] = new TextBlock(span);
				}
				else
				{
					res[i] = new TextBlock { Text = label };
				}
				((TextBlock)res[i]).ToolTip = ticks[i].ToString(CultureInfo.CurrentCulture);

				ApplyCustomView(tickInfo, res[i]);
			}

			return res;
		}
	}
}
