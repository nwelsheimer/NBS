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
using System.Windows.Media;

namespace Openmiracle.MiracleIChart.PointMarkers
{
    /// <summary>Invokes specified delegate for rendering custon marker
    /// at every point of graph</summary>
	public sealed class DelegatePointMarker : PointMarker {
		public MarkerRenderer RenderCallback { get; set; }

		public DelegatePointMarker() { }
		public DelegatePointMarker(MarkerRenderer renderCallback) {
			if (renderCallback == null)
				throw new ArgumentNullException("renderCallback");
	
			RenderCallback = renderCallback;
		}

		public override void Render(DrawingContext dc, Point screenPoint) {
			RenderCallback(dc, screenPoint);
		}
	}
}
