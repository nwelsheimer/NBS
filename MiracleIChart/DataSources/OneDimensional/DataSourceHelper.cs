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

namespace Openmiracle.MiracleIChart.DataSources
{
	public static class DataSourceHelper {
		public static IEnumerable<Point> GetPoints(IPointDataSource dataSource) {
			return GetPoints(dataSource, null);
		}

		public static IEnumerable<Point> GetPoints(IPointDataSource dataSource, DependencyObject context)
		{
			if (dataSource == null)
				throw new ArgumentNullException("dataSource");

			if (context == null)
				context = Context.EmptyContext;

			using (IPointEnumerator enumerator = dataSource.GetEnumerator(context))
			{
				Point p = new Point();
				while (enumerator.MoveNext())
				{
					enumerator.GetCurrent(ref p);
					yield return p;
					p = new Point();
				}
			}
		}
	}
}
