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
using System.Windows.Shapes;
using System.Windows;
using System.Windows.Media;
using Openmiracle.MiracleIChart;

namespace Openmiracle.MiracleIChart.Charts
{
	/// <summary>
	/// Represents horizontal line with specified y-coordinate.
	/// </summary>
	public sealed class HorizontalLine : SimpleLine
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="HorizontalLine"/> class.
		/// </summary>
		public HorizontalLine(){}

		/// <summary>
		/// Initializes a new instance of the <see cref="HorizontalLine"/> class.
		/// </summary>
		/// <param name="yCoordinate">The y coordinate of line.</param>
		public HorizontalLine(double yCoordinate)
		{
			Value = yCoordinate;
		}

		protected override void UpdateUIRepresentationCore()
		{
			var transform = Plotter.Viewport.Transform;

			Point p1 = new Point(Plotter.Viewport.Visible.Left, Value).DataToScreen(transform);
			Point p2 = new Point(Plotter.Viewport.Visible.Right, Value).DataToScreen(transform);

			LineGeometry.StartPoint = p1;
			LineGeometry.EndPoint = p2;
		}
	}
}
