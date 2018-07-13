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
using System.Windows.Documents;
using System.Windows.Media;

namespace Openmiracle.MiracleIChart.Navigation
{
    /// <summary>Helper class to draw semitransparent rectangle over the
    /// selection area</summary>
	public sealed class RectangleSelectionAdorner : Adorner {

		private Rect? border = null;
		public Rect? Border {
			get { return border; }
			set { border = value; }
		}

		public Brush Fill {
			get { return (Brush)GetValue(FillProperty); }
			set { SetValue(FillProperty, value); }
		}

		public static readonly DependencyProperty FillProperty =
			DependencyProperty.Register(
			  "Fill",
			  typeof(Brush),
			  typeof(RectangleSelectionAdorner),
			  new FrameworkPropertyMetadata(
				  new SolidColorBrush(Color.FromArgb(60, 100, 100, 100)),
				  FrameworkPropertyMetadataOptions.AffectsRender));

		private Pen pen;
		public Pen Pen {
			get { return pen; }
			set { pen = value; }
		}

		public RectangleSelectionAdorner(UIElement element)
			: base(element) {
			pen = new Pen(Brushes.Black, 1.0);
		}

		protected override void OnRender(DrawingContext dc) {
			if (border.HasValue) {
				dc.DrawRectangle(Fill, pen, border.Value);
			}
		}
	}
}
