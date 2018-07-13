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
	/// <summary>
	/// General interface for two-dimensional data source. Contains two-dimensional array of data items.
	/// </summary>
	/// <typeparam name="T">Data type - type of each data piece.</typeparam>
	public interface IDataSource2D<T> : IGridSource2D
	{
		/// <summary>
		/// Gets two-dimensional data array.
		/// </summary>
		/// <value>The data.</value>
		T[,] Data { get; }

		IDataSource2D<T> GetSubset(int x0, int y0, int countX, int countY, int stepX, int stepY);

		void ApplyMappings(DependencyObject marker, int x, int y);
	}

	/// <summary>
	/// General interface for two-dimensional data grids. Contains two-dimensional array of data points.
	/// </summary>
	public interface IGridSource2D
	{
		/// <summary>
		/// Gets the grid of data source.
		/// </summary>
		/// <value>The grid.</value>
		Point[,] Grid { get; }
		/// <summary>
		/// Gets data grid width.
		/// </summary>
		/// <value>The width.</value>
		int Width { get; }
		/// <summary>
		/// Gets data grid height.
		/// </summary>
		/// <value>The height.</value>
		int Height { get; }

		/// <summary>
		/// Occurs when data source changes.
		/// </summary>
		event EventHandler Changed;
	}
}
