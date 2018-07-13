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
using System.Windows;
using System.Windows.Media;
using Openmiracle.MiracleIChart.DataSources;
using Openmiracle.MiracleIChart.PointMarkers;

namespace Openmiracle.MiracleIChart
{
	public class MarkerPointsGraph : PointsGraphBase
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="MarkerPointsGraph"/> class.
		/// </summary>
		public MarkerPointsGraph()
		{
			ManualTranslate = true;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="MarkerPointsGraph"/> class.
		/// </summary>
		/// <param name="dataSource">The data source.</param>
		public MarkerPointsGraph(IPointDataSource dataSource)
			: this()
		{
			DataSource = dataSource;
		}

		protected override void OnVisibleChanged(Rect newRect, Rect oldRect)
		{
			base.OnVisibleChanged(newRect, oldRect);
			InvalidateVisual();
		}

		public PointMarker Marker
		{
			get { return (PointMarker)GetValue(MarkerProperty); }
			set { SetValue(MarkerProperty, value); }
		}

		public static readonly DependencyProperty MarkerProperty =
			DependencyProperty.Register(
			  "Marker",
			  typeof(PointMarker),
			  typeof(MarkerPointsGraph),
			  new FrameworkPropertyMetadata { DefaultValue = null, AffectsRender = true }
				  );

		protected override void OnRenderCore(DrawingContext dc, RenderState state)
		{
			if (DataSource == null) return;
			if (Marker == null) return;

			var transform = Plotter2D.Viewport.Transform;

			Rect bounds = Rect.Empty;
			using (IPointEnumerator enumerator = DataSource.GetEnumerator(GetContext()))
			{
				Point point = new Point();
				while (enumerator.MoveNext())
				{
					enumerator.GetCurrent(ref point);
					enumerator.ApplyMappings(Marker);

					//Point screenPoint = point.Transform(state.Visible, state.Output);
					Point screenPoint = point.DataToScreen(transform);

					bounds = Rect.Union(bounds, point);
					Marker.Render(dc, screenPoint);
				}
			}

			ContentBounds = bounds;
		}
	}
}
