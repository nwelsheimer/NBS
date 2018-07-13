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
using System.Collections.Generic;
using System.Windows;

namespace Openmiracle.MiracleIChart
{
	public static class IPointCollectionExtensions {
		public static Rect GetBounds(this IEnumerable<Point> points) {
			return BoundsHelper.GetDataBounds(points);
		}

		public static IEnumerable<Point> Skip(this IList<Point> points, int skipCount) {
			for (int i = skipCount; i < points.Count; i++) {
				yield return points[i];
			}
		}
	}
}
