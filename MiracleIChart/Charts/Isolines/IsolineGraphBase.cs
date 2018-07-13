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
using Openmiracle.MiracleIChart.Common.Palettes;
using Openmiracle.MiracleIChart.DataSources;
using DataSource = Openmiracle.MiracleIChart.DataSources.IDataSource2D<double>;
using System.Windows;

namespace Openmiracle.MiracleIChart.Charts.Isolines
{
	public abstract class IsolineGraphBase : ContentGraph
	{
		protected IsolineGraphBase() { }

		private IsolineCollection collection = new IsolineCollection();
		protected IsolineCollection Collection
		{
			get { return collection; }
		}

		private readonly IsolineBuilder isolineBuilder = new IsolineBuilder();
		protected IsolineBuilder IsolineBuilder
		{
			get { return isolineBuilder; }
		}

		private readonly IsolineTextAnnotater annotater = new IsolineTextAnnotater();
		protected IsolineTextAnnotater Annotater
		{
			get { return annotater; }
		}

		private IPalette palette = new HSBPalette();
		/// <summary>
		/// Gets or sets the palette for coloring isoline lines.
		/// </summary>
		/// <value>The palette.</value>
		public IPalette Palette
		{
			get { return palette; }
			set
			{
				if (value == null)
					throw new ArgumentNullException("value");

				if (palette != value)
				{
					palette = value;
					CreateUIRepresentation();
				}
			}
		}

		private bool drawLabels = true;
		/// <summary>
		/// Gets or sets a value indicating whether to draw text labels.
		/// </summary>
		/// <value><c>true</c> if isolines draws labels; otherwise, <c>false</c>.</value>
		public bool DrawLabels
		{
			get { return drawLabels; }
			set
			{
				if (drawLabels != value)
				{
					drawLabels = value;
					CreateUIRepresentation();
				}
			}
		}

		#region DataSource

		private DataSource dataSource = null;
		/// <summary>
		/// Gets or sets the data source.
		/// </summary>
		/// <value>The data source.</value>
		public DataSource DataSource
		{
			get { return dataSource; }
			set
			{
				if (dataSource != value)
				{
					DetachDataSource(dataSource);
					dataSource = value;
					AttachDataSource(dataSource);

					UpdateDataSource();
				}
			}
		}

		/// <summary>
		/// This method is called when data source changes.
		/// </summary>
		protected virtual void UpdateDataSource()
		{
			if (dataSource != null)
			{
				IsolineBuilder.DataSource = dataSource;
				collection = IsolineBuilder.Build();
			}
			else
			{
				collection = null;
			}
		}

		protected virtual void CreateUIRepresentation() { }

		protected virtual void AttachDataSource(IDataSource2D<double> dataSource)
		{
			if (dataSource != null)
			{
				dataSource.Changed += OnDataSourceChanged;
			}
		}

		protected virtual void DetachDataSource(IDataSource2D<double> dataSource)
		{
			if (dataSource != null)
			{
				dataSource.Changed -= OnDataSourceChanged;
			}
		}

		protected virtual void OnDataSourceChanged(object sender, EventArgs e)
		{
			UpdateDataSource();
		}

		#endregion

		#region StrokeThickness

		/// <summary>
		/// Gets or sets thickness of isoline lines.
		/// </summary>
		/// <value>The stroke thickness.</value>
		public double StrokeThickness
		{
			get { return (double)GetValue(StrokeThicknessProperty); }
			set { SetValue(StrokeThicknessProperty, value); }
		}

		/// <summary>
		/// Identifies the StrokeThickness dependency property.
		/// </summary>
		public static readonly DependencyProperty StrokeThicknessProperty =
			DependencyProperty.Register(
			  "StrokeThickness",
			  typeof(double),
			  typeof(IsolineGraphBase),
			  new FrameworkPropertyMetadata(
				  2.0,
				  OnLineThicknessChanged)
				  );

		private static void OnLineThicknessChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			IsolineGraphBase graph = (IsolineGraphBase)d;
			graph.UpdateLineThickness();
		}

		protected virtual void UpdateLineThickness() { }

		#endregion
	}
}
