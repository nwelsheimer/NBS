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

using System.Windows;
using System.Windows.Media;

namespace Openmiracle.MiracleIChart.PointMarkers
{
    /// <summary>Class that renders triangular marker at every point of graph</summary>
	public class TrianglePointMarker : ShapePointMarker {
		public override void Render(DrawingContext dc, Point screenPoint) {
			Point pt0 = Point.Add(screenPoint, new Vector(-Size / 2, -Size / 2));
			Point pt1 = Point.Add(screenPoint, new Vector(0, Size / 2));
			Point pt2 = Point.Add(screenPoint, new Vector(Size / 2, -Size / 2));
			
			StreamGeometry streamGeom = new StreamGeometry();
			using (var context = streamGeom.Open()) {
				context.BeginFigure(pt0, true, true);
				context.LineTo(pt1, true, true);
				context.LineTo(pt2, true, true);
			}
			dc.DrawGeometry(Fill, Pen, streamGeom);
		}
	}
}
