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
using Openmiracle.MiracleIChart;

namespace Openmiracle.MiracleIChart.Charts
{
	/// <summary>
	/// Paints horizontal filled and outlined range in viewport coordinates.
	/// </summary>
	public sealed class HorizontalRange : RangeHighlight
	{
		protected override void UpdateUIRepresentationCore()
		{
			var transform = Plotter.Viewport.Transform;
			Rect visible = Plotter.Viewport.Visible;

			Point p1_left = new Point(visible.Left, Value1).DataToScreen(transform);
			Point p1_right = new Point(visible.Right, Value1).DataToScreen(transform);
			Point p2_left = new Point(visible.Left, Value2).DataToScreen(transform);
			Point p2_right = new Point(visible.Right, Value2).DataToScreen(transform);

			LineGeometry1.StartPoint = p1_left;
			LineGeometry1.EndPoint = p1_right;

			LineGeometry2.StartPoint = p2_left;
			LineGeometry2.EndPoint = p2_right;

			RectGeometry.Rect = new Rect(p1_left, p2_right);
		}
	}
}
