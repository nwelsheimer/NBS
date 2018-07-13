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
using System.Collections;
using System.Windows;

namespace Openmiracle.MiracleIChart.DataSources
{
    /// <summary>This enumerator enumerates given enumerable object as sequence of points</summary>
    /// <typeparam name="T">Type parameter of source IEnumerable</typeparam>
	public sealed class EnumerablePointEnumerator<T> : IPointEnumerator {
		private readonly EnumerableDataSource<T> dataSource;
		private readonly IEnumerator enumerator;

		public EnumerablePointEnumerator(EnumerableDataSource<T> dataSource) {
			this.dataSource = dataSource;
			enumerator = dataSource.Data.GetEnumerator();
		}

		public bool MoveNext() {
			return enumerator.MoveNext();
		}

		public void GetCurrent(ref Point p) {
			dataSource.FillPoint((T)enumerator.Current, ref p);
		}

		public void ApplyMappings(DependencyObject target) {
			dataSource.ApplyMappings(target, (T)enumerator.Current);
		}

		public void Dispose() {
			//enumerator.Reset();
		}
	}
}
