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
using System.Diagnostics.CodeAnalysis;

namespace Openmiracle.MiracleIChart.DataSources
{
	/// <summary>
	/// Empty data source - for testing purposes, represents data source with 0 points inside.
	/// </summary>
	public class EmptyDataSource : IPointDataSource
	{
		#region IPointDataSource Members

		public IPointEnumerator GetEnumerator(DependencyObject context)
		{
			return new EmptyPointEnumerator();
		}

		[SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
		private void RaiseDataChanged()
		{
			if (DataChanged != null)
			{
				DataChanged(this, EventArgs.Empty);
			}
		}

		public event EventHandler DataChanged;

		#endregion

		private sealed class EmptyPointEnumerator : IPointEnumerator
		{
			public bool MoveNext()
			{
				return false;
			}

			public void GetCurrent(ref Point p)
			{
				// nothing to do
			}

			public void ApplyMappings(DependencyObject target)
			{
				// nothing to do
			}

			public void Dispose() { }
		}
	}
}
