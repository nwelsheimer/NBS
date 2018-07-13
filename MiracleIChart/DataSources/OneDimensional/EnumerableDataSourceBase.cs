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
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Windows;

namespace Openmiracle.MiracleIChart.DataSources
{
    /// <summary>Base class for all sources who receive data for charting 
    /// from any IEnumerable of T</summary>
    /// <typeparam name="T">Type of items in IEnumerable</typeparam>
	public abstract class EnumerableDataSourceBase<T> : IPointDataSource {
        private IEnumerable data;
		
        public IEnumerable Data {
			get { return data; }
			set {
				if (value == null)
					throw new ArgumentNullException("value");

				data = value;

				var observableCollection = data as INotifyCollectionChanged;
				if (observableCollection != null) {
					observableCollection.CollectionChanged += observableCollection_CollectionChanged;
				}
			}
		}

		protected EnumerableDataSourceBase(IEnumerable<T> data) : this((IEnumerable)data) { }

		protected EnumerableDataSourceBase(IEnumerable data) {
			if (data == null)
				throw new ArgumentNullException("data");
			Data = data;
		}

		private void observableCollection_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e) {
			RaiseDataChanged();
		}

		public event EventHandler DataChanged;
		public void RaiseDataChanged() {
			if (DataChanged != null) {
				DataChanged(this, EventArgs.Empty);
			}
		}

		public abstract IPointEnumerator GetEnumerator(DependencyObject context);
	}
}
