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
    /// <summary>Abstract class that extends PointMarker and contains
    /// marker property as Pen, Brush and Size</summary>
	public abstract class ShapePointMarker : PointMarker {
		/// <summary>Size of marker in points</summary>
		public double Size {
			get { return (double)GetValue(SizeProperty); }
			set { SetValue(SizeProperty, value); }
		}

		public static readonly DependencyProperty SizeProperty =
			DependencyProperty.Register(
			  "Size",
			  typeof(double),
			  typeof(ShapePointMarker),
			  new FrameworkPropertyMetadata(5.0));


		/// <summary>Pen to outline marker</summary>
		public Pen Pen {
			get { return (Pen)GetValue(PenProperty); }
			set { SetValue(PenProperty, value); }
		}

		public static readonly DependencyProperty PenProperty =
			DependencyProperty.Register(
			  "Pen",
			  typeof(Pen),
			  typeof(ShapePointMarker),
			  new FrameworkPropertyMetadata(null));


		public Brush Fill {
			get { return (Brush)GetValue(FillProperty); }
			set { SetValue(FillProperty, value); }
		}

		public static readonly DependencyProperty FillProperty =
			DependencyProperty.Register(
			  "Fill",
			  typeof(Brush),
			  typeof(ShapePointMarker),
			  new FrameworkPropertyMetadata(Brushes.Red));
	}
}
