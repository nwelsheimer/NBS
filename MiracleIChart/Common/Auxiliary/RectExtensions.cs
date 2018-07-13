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
using Openmiracle.MiracleIChart.Common;
using System.Diagnostics;

namespace Openmiracle.MiracleIChart
{
	public static class RectExtensions
	{
		public static Point GetCenter(this Rect rect)
		{
			return new Point(rect.Left + rect.Width * 0.5, rect.Top + rect.Height * 0.5);
		}

		public static Rect FromCenterSize(Point center, Size size)
		{
			return FromCenterSize(center, size.Width, size.Height);
		}

		public static Rect FromCenterSize(Point center, double width, double height)
		{
			Rect res = new Rect(center.X - width / 2, center.Y - height / 2, width, height);
			return res;
		}

		public static Rect Zoom(this Rect rect, Point to, double ratio)
		{
			return CoordinateUtilities.RectZoom(rect, to, ratio);
		}

		public static Rect ZoomX(this Rect rect, Point to, double ratio)
		{
			return CoordinateUtilities.RectZoomX(rect, to, ratio);
		}

		public static Rect ZoomY(this Rect rect, Point to, double ratio)
		{
			return CoordinateUtilities.RectZoomY(rect, to, ratio);
		}

		public static Int32Rect ToInt32Rect(this Rect rect)
		{
			Int32Rect intRect = new Int32Rect(
				(int)rect.X,
				(int)rect.Y,
				(int)rect.Width,
				(int)rect.Height);

			return intRect;
		}

		[DebuggerStepThrough]
		public static DataRect ToDataRect(this Rect rect)
		{
			return new DataRect(rect);
		}
	}
}
