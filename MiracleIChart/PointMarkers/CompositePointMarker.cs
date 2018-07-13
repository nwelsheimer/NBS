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
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Media;

namespace Openmiracle.MiracleIChart.PointMarkers
{
    /// <summary>Composite point markers renders a specified set of markers
    /// at every point of graph</summary>
	public sealed class CompositePointMarker : PointMarker {
		public CompositePointMarker() { }

		public CompositePointMarker(params PointMarker[] markers) {
			if (markers == null)
				throw new ArgumentNullException("markers");

            foreach (PointMarker m in markers)
                this.markers.Add(m);
		}

		public CompositePointMarker(IEnumerable<PointMarker> markers) {
			if (markers == null)
				throw new ArgumentNullException("markers");
            foreach (PointMarker m in markers)
                this.markers.Add(m);
		}


		private readonly Collection<PointMarker> markers = new Collection<PointMarker>();
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		public Collection<PointMarker> Markers {
			get { return markers; }
		}

		public override void Render(DrawingContext dc, Point screenPoint) {
			LocalValueEnumerator enumerator = GetLocalValueEnumerator();
			foreach (var marker in markers) {
				enumerator.Reset();
				while (enumerator.MoveNext()) {
					marker.SetValue(enumerator.Current.Property, enumerator.Current.Value);
				}

				marker.Render(dc, screenPoint);
			}
		}
	}
}
