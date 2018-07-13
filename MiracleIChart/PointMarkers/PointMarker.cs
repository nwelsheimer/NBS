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

namespace Openmiracle.MiracleIChart.PointMarkers
{
	public delegate void MarkerRenderer(DrawingContext dc, Point screenPoint);

	/// <summary>Renders markers along graph</summary>
	public abstract class PointMarker : DependencyObject {

		/// <summary>Renders marker on screen</summary>
		/// <param name="dc">Drawing context to render marker on</param>
		/// <param name="dataPoint">Point from data source</param>
		/// <param name="screenPoint">Marker center coordinates on drawing context</param>
		public abstract void Render(DrawingContext dc, Point screenPoint);

		public static implicit operator PointMarker(MarkerRenderer renderer) {
            return FromRenderer(renderer);
		}

        public static PointMarker FromRenderer(MarkerRenderer renderer)
        {
            return new DelegatePointMarker(renderer);
        }
	}
}
