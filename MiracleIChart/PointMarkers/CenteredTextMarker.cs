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

using System.Threading;
using System.Windows;
using System.Windows.Media;

namespace Openmiracle.MiracleIChart.PointMarkers
{
    /// <summary>Renders specified text near the point</summary>
	public class CenteredTextMarker : PointMarker {
		public string Text {
			get { return (string)GetValue(TextProperty); }
			set { SetValue(TextProperty, value); }
		}

		public static readonly DependencyProperty TextProperty =
			DependencyProperty.Register(
			  "Text",
			  typeof(string),
			  typeof(CenteredTextMarker),
			  new FrameworkPropertyMetadata(""));

		public override void Render(DrawingContext dc, Point screenPoint) {
			FormattedText textToDraw = new FormattedText(Text, Thread.CurrentThread.CurrentCulture,
				 FlowDirection.LeftToRight, new Typeface("Arial"), 12, Brushes.Black);

			double width = textToDraw.Width;
			double height = textToDraw.Height;

			const double verticalShift = -20; // px

			Rect bounds = RectExtensions.FromCenterSize(new Point(screenPoint.X, screenPoint.Y + verticalShift - height / 2),
				new Size(width, height));

			Point loc = bounds.Location;
			bounds = CoordinateUtilities.RectZoom(bounds, 1.05, 1.15);

			dc.DrawLine(new Pen(Brushes.Black, 1), Point.Add(screenPoint, new Vector(0, verticalShift)), screenPoint);
			dc.DrawRectangle(Brushes.White, new Pen(Brushes.Black, 1), bounds);
			dc.DrawText(textToDraw, loc);
		}
	}
}
