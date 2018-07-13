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

namespace Openmiracle.MiracleIChart
{
	public sealed class PenDescription : StandardDescription {
		/// <summary>
		/// Initializes a new instance of the <see cref="PenDescription"/> class.
		/// </summary>
		public PenDescription() { }
		
		/// <summary>
		/// Initializes a new instance of the <see cref="PenDescription"/> class.
		/// </summary>
		/// <param name="description">Custom description.</param>
		public PenDescription(string description) : base(description) { }

		protected override LegendItem CreateLegendItemCore() {
			return new LineLegendItem(this);
		}

		protected override void AttachCore(UIElement graph) {
			base.AttachCore(graph);
			LineGraph g = graph as LineGraph;
			if (g == null) {
				throw new ArgumentException("Pen description can only be attached to PointsGraph", "graph");
			}
			pen = g.LinePen;
		}

		private Pen pen;

		public Pen Pen {
			get { return pen; }
		}
	}
}
