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
using System.Windows;
using System.Collections;

namespace Openmiracle.MiracleIChart.DataSources
{
	/// <summary>Data source that is a composer from several other data sources.</summary>
	public class CompositeDataSource : IPointDataSource {
		/// <summary>Initializes a new instance of the <see cref="CompositeDataSource"/> class</summary>
		public CompositeDataSource() { }

		/// <summary>
		/// Initializes a new instance of the <see cref="CompositeDataSource"/> class.
		/// </summary>
		/// <param name="dataSources">Data sources.</param>
		public CompositeDataSource(params IPointDataSource[] dataSources) {
			if (dataSources == null)
				throw new ArgumentNullException("dataSources");

			foreach (var dataSource in dataSources) {
				AddDataPart(dataSource);
			}
		}

		private readonly List<IPointDataSource> dataParts = new List<IPointDataSource>();

		public IEnumerable<IPointDataSource> DataParts {
			get { return dataParts; }
		}

		/// <summary>
		/// Adds data part.
		/// </summary>
		/// <param name="dataPart">The data part.</param>
		public void AddDataPart(IPointDataSource dataPart) {
			if (dataPart == null)
				throw new ArgumentNullException("dataPart");

			dataParts.Add(dataPart);
			dataPart.DataChanged += OnPartDataChanged;
		}

		private void OnPartDataChanged(object sender, EventArgs e) {
			RaiseDataChanged();
		}

		#region IPointSource Members

		public event EventHandler DataChanged;
		protected void RaiseDataChanged() {
			if (DataChanged != null) {
				DataChanged(this, EventArgs.Empty);
			}
		}

		public IPointEnumerator GetEnumerator(DependencyObject context) {
			return new CompositeEnumerator(this, context);
		}

		#endregion

		private sealed class CompositeEnumerator : IPointEnumerator {
			private readonly IEnumerable<IPointEnumerator> enumerators;

			public CompositeEnumerator(CompositeDataSource dataSource, DependencyObject context) {
				enumerators = dataSource.dataParts.Select(part => part.GetEnumerator(context)).ToList();
			}

			#region IChartPointEnumerator Members

			public bool MoveNext() {
				bool res = false;
				foreach (var enumerator in enumerators) {
					res |= enumerator.MoveNext();
				}
				return res;
			}

			public void ApplyMappings(DependencyObject glyph) {
				foreach (var enumerator in enumerators) {
					enumerator.ApplyMappings(glyph);
				}
			}

			public void GetCurrent(ref Point p) {
				foreach (var enumerator in enumerators) {
					enumerator.GetCurrent(ref p);
				}
			}

			public void Dispose() {
				foreach (var enumerator in enumerators) {
					enumerator.Dispose();
				}
			}

			#endregion
		}
	}
}
