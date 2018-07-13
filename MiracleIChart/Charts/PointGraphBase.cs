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
using System.Windows;
using Openmiracle.MiracleIChart.DataSources;
using System.Collections.Generic;

namespace Openmiracle.MiracleIChart
{
	public abstract class PointsGraphBase : ViewportElement2D, IOneDimensionalChart
	{

		#region DataSource

		public IPointDataSource DataSource
		{
			get { return (IPointDataSource)GetValue(DataSourceProperty); }
			set { SetValue(DataSourceProperty, value); }
		}

		public static readonly DependencyProperty DataSourceProperty =
			DependencyProperty.Register(
			  "DataSource",
			  typeof(IPointDataSource),
			  typeof(PointsGraphBase),
			  new FrameworkPropertyMetadata
			  {
				  AffectsRender = true,
				  DefaultValue = null,
				  PropertyChangedCallback = OnDataSourceChangedCallback
			  }
			);

		private static void OnDataSourceChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			PointsGraphBase graph = (PointsGraphBase)d;
			if (e.NewValue != e.OldValue)
			{
				graph.DetachDataSource(e.OldValue as IPointDataSource);
				graph.AttachDataSource(e.NewValue as IPointDataSource);
			}
			graph.OnDataSourceChanged(e);
		}

		private void AttachDataSource(IPointDataSource source)
		{
			if (source != null)
			{
				source.DataChanged += OnDataChanged;
			}
		}

		private void DetachDataSource(IPointDataSource source)
		{
			if (source != null)
			{
				source.DataChanged -= OnDataChanged;
			}
		}

		private void OnDataChanged(object sender, EventArgs e)
		{
			OnDataChanged();
		}

		protected virtual void OnDataChanged()
		{
			UpdateBounds(DataSource);

			RaiseDataChanged();
			Update();
		}

		private void RaiseDataChanged()
		{
			if (DataChanged != null)
			{
				DataChanged(this, EventArgs.Empty);
			}
		}
		public event EventHandler DataChanged;

		protected virtual void OnDataSourceChanged(DependencyPropertyChangedEventArgs args)
		{
			IPointDataSource newDataSource = (IPointDataSource)args.NewValue;
			if (newDataSource != null)
			{
				UpdateBounds(newDataSource);
			}

			Update();
		}

		private void UpdateBounds(IPointDataSource dataSource)
		{
			if (Plotter2D != null)
			{
				var transform = GetTransform();
				Rect bounds = BoundsHelper.GetViewportBounds(dataSource.GetPoints(), transform.DataTransform);
				ContentBounds = bounds;
			}
		}

		#endregion

		#region DataTransform

		private DataTransform dataTransform = null;
		public DataTransform DataTransform
		{
			get { return dataTransform; }
			set
			{
				if (dataTransform != value)
				{
					dataTransform = value;
					Update();
				}
			}
		}

		protected CoordinateTransform GetTransform()
		{
			if (Plotter == null)
				return null;

			var transform = Plotter2D.Viewport.Transform;
			if (dataTransform != null)
				transform = transform.WithDataTransform(dataTransform);

			return transform;
		}

		#endregion

		protected IEnumerable<Point> GetPoints()
		{
			return DataSource.GetPoints(GetContext());
		}

		private readonly Context context = new Context();
		protected DependencyObject GetContext()
		{
			context.ClearValues();

			context.VisibleRect = Plotter2D.Viewport.Visible;
			context.Output = Plotter2D.Viewport.Output;

			return context;
		}
	}
}
