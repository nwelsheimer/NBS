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

namespace Openmiracle.MiracleIChart.DataSources
{
	public static class DataSourceExtensions
	{
		public static RawDataSource AsDataSource(this IEnumerable<Point> points)
		{
			return new RawDataSource(points);
		}

		public static EnumerableDataSource<T> AsDataSource<T>(this IEnumerable<T> collection)
		{
			return new EnumerableDataSource<T>(collection);
		}

		public static EnumerableDataSource<T> AsXDataSource<T>(this IEnumerable<T> collection)
		{
			return new EnumerableXDataSource<T>(collection);
		}

		public static EnumerableDataSource<T> AsYDataSource<T>(this IEnumerable<T> collection)
		{
			return new EnumerableYDataSource<T>(collection);
		}

		public static EnumerableDataSource<double> AsXDataSource(this IEnumerable<double> collection)
		{
			EnumerableXDataSource<double> ds = new EnumerableXDataSource<double>(collection);
			ds.SetXMapping(x => x);
			return ds;
		}

		public static EnumerableDataSource<double> AsYDataSource(this IEnumerable<double> collection)
		{
			EnumerableYDataSource<double> ds = new EnumerableYDataSource<double>(collection);
			ds.SetYMapping(y => y);
			return ds;
		}

		public static CompositeDataSource Join(this IPointDataSource ds1, IPointDataSource ds2)
		{
			return new CompositeDataSource(ds1, ds2);
		}

		public static IEnumerable<Point> GetPoints(this IPointDataSource dataSource)
		{
			return DataSourceHelper.GetPoints(dataSource);
		}

		public static IEnumerable<Point> GetPoints(this IPointDataSource dataSource, DependencyObject context) {
			return DataSourceHelper.GetPoints(dataSource, context);
		}
	}
}
