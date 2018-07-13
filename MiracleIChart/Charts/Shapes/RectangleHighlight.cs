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
using System.Windows.Media;
using System.Windows;
using System.ComponentModel;

namespace Openmiracle.MiracleIChart.Charts
{
	/// <summary>
	/// Represents a rectangle with corners bound to viewport coordinates.
	/// </summary>
	public sealed class RectangleHighlight : ViewportShape
	{
		public RectangleHighlight() { }

		private Rect rect = Rect.Empty;
		public Rect Bounds
		{
			get { return rect; }
			set
			{
				if (rect != value)
				{
					rect = value;
					UpdateUIRepresentation();
				}
			}
		}

		protected override void UpdateUIRepresentationCore()
		{
			var transform = Plotter.Viewport.Transform;

			Point p1 = rect.Location.DataToScreen(transform);
			Point p2 = rect.BottomRight.DataToScreen(transform);
			rectGeometry.Rect = new Rect(p1, p2);
		}

		private RectangleGeometry rectGeometry = new RectangleGeometry();
		protected override Geometry DefiningGeometry
		{
			get { return rectGeometry; }
		}
	}
}
