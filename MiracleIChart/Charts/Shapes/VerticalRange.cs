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
using System.Windows.Media;
using System.Windows;

namespace Openmiracle.MiracleIChart.Charts
{
	/// <summary>
	/// Paints vertical filled and outlined range in viewport coordinates.
	/// </summary>
	public sealed class VerticalRange : RangeHighlight
	{
		protected override void UpdateUIRepresentationCore()
		{
			var transform = Plotter.Viewport.Transform;
			Rect visible = Plotter.Viewport.Visible;

			Point p1_top = new Point(Value1, visible.Top).DataToScreen(transform);
			Point p1_bottom = new Point(Value1, visible.Bottom).DataToScreen(transform);
			Point p2_top = new Point(Value2, visible.Top).DataToScreen(transform);
			Point p2_bottom = new Point(Value2, visible.Bottom).DataToScreen(transform);

			LineGeometry1.StartPoint = p1_top;
			LineGeometry1.EndPoint = p1_bottom;

			LineGeometry2.StartPoint = p2_top;
			LineGeometry2.EndPoint = p2_bottom;

			RectGeometry.Rect = new Rect(p1_top, p2_bottom);
		}
	}
}
