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
using System.Data;
using System.Linq;
using System.Windows;
using System.Collections.Generic;

namespace Openmiracle.MiracleIChart.DataSources
{
	/// <summary>Data source that extracts sequence of points and their attributes from DataTable</summary>
	public class TableDataSource : EnumerableDataSource<DataRow>
	{
		public TableDataSource(DataTable table)
			: base(table.Rows)
		{
			// Subscribe to DataTable events
			table.TableNewRow += NewRowInsertedHandler;
			table.RowChanged += RowChangedHandler;
			table.RowDeleted += RowChangedHandler;
		}

		private void RowChangedHandler(object sender, DataRowChangeEventArgs e)
		{
			RaiseDataChanged();
		}

		private void NewRowInsertedHandler(object sender, DataTableNewRowEventArgs e)
		{
			// Raise DataChanged event. ChartPlotter should redraw graph.
			// This will be done automatically when rows are added to table.
			RaiseDataChanged();
		}
	}
}
