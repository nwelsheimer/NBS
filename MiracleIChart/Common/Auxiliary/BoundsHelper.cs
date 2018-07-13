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
using System.Windows;

namespace Openmiracle.MiracleIChart
{
	public static class BoundsHelper
	{
		/// <summary>Computes bounding rectangle for sequence of points</summary>
		/// <param name="points">Points sequence</param>
		/// <returns>Minimal axis-aligned bounding rectangle</returns>
		public static Rect GetDataBounds(IEnumerable<Point> points)
		{
			Rect bounds = Rect.Empty;

			double xMin = Double.PositiveInfinity;
			double xMax = Double.NegativeInfinity;

			double yMin = Double.PositiveInfinity;
			double yMax = Double.NegativeInfinity;

			foreach (Point p in points)
			{
				xMin = Math.Min(xMin, p.X);
				xMax = Math.Max(xMax, p.X);

				yMin = Math.Min(yMin, p.Y);
				yMax = Math.Max(yMax, p.Y);
			}

			// were some points in collection
			if (!Double.IsInfinity(xMin))
			{
				bounds = MathHelper.CreateRectByPoints(xMin, yMin, xMax, yMax);
			}

			return bounds;
		}

		public static Rect GetViewportBounds(IEnumerable<Point> dataPoints, DataTransform transform)
		{
			return GetDataBounds(dataPoints.DataToViewport(transform));
		}
	}
}
