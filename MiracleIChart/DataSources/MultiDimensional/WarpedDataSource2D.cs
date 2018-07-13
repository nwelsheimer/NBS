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
using Openmiracle.MiracleIChart.Common.Auxiliary;

namespace Openmiracle.MiracleIChart.DataSources.MultiDimensional
{
	/// <summary>
	/// Defines warped two-dimensional data source.
	/// </summary>
	/// <typeparam name="T">Data piece type</typeparam>
	public sealed class WarpedDataSource2D<T> : IDataSource2D<T>
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="WarpedDataSource2D&lt;T&gt;"/> class.
		/// </summary>
		/// <param name="data">Data.</param>
		/// <param name="grid">Grid.</param>
		public WarpedDataSource2D(T[,] data, Point[,] grid)
		{
			if (data == null)
				throw new ArgumentNullException("data");
			if (grid == null)
				throw new ArgumentNullException("grid");

			Verify.IsTrue(data.GetLength(0) == grid.GetLength(0));
			Verify.IsTrue(data.GetLength(1) == grid.GetLength(1));

			this.data = data;
			this.grid = grid;
			width = data.GetLength(0);
			height = data.GetLength(1);
		}

		#region DataSource<T> Members

		private readonly T[,] data;
		/// <summary>
		/// Gets two-dimensional data array.
		/// </summary>
		/// <value>The data.</value>
		public T[,] Data
		{
			get { return data; }
		}

		private readonly Point[,] grid;
		/// <summary>
		/// Gets the grid of data source.
		/// </summary>
		/// <value>The grid.</value>
		public Point[,] Grid
		{
			get { return grid; }
		}

		private readonly int width;
		/// <summary>
		/// Gets data grid width.
		/// </summary>
		/// <value>The width.</value>
		public int Width
		{
			get { return width; }
		}

		private readonly int height;
		/// <summary>
		/// Gets data grid height.
		/// </summary>
		/// <value>The height.</value>
		public int Height
		{
			get { return height; }
		}

		IDataSource2D<T> IDataSource2D<T>.GetSubset(int x0, int y0, int countX, int countY, int stepX, int stepY)
		{
			throw new NotImplementedException();
		}

		void IDataSource2D<T>.ApplyMappings(DependencyObject marker, int x, int y)
		{
			throw new NotImplementedException();
		}

		private void RaiseChanged()
		{
			if (Changed != null)
			{
				Changed(this, EventArgs.Empty);
			}
		}
		/// <summary>
		/// Occurs when data source changes.
		/// </summary>
		public event EventHandler Changed;

		#endregion
	}
}
