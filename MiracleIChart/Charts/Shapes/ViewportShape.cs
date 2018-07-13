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
using System.Windows;
using System.Windows.Shapes;
using System.Windows.Media;

namespace Openmiracle.MiracleIChart.Charts
{
	/// <summary>
	/// ViewportShape is a base class for simple shapes with viewport-bound coordinates.
	/// </summary>
	public abstract class ViewportShape : Shape, IPlotterElement
	{
		static ViewportShape()
		{
			Type type = typeof(ViewportShape);
			Shape.StrokeProperty.AddOwner(type, new FrameworkPropertyMetadata(Brushes.Blue));
			Shape.StrokeThicknessProperty.AddOwner(type, new FrameworkPropertyMetadata(2.0));
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="ViewportShape"/> class.
		/// </summary>
		protected ViewportShape()
		{
		}

		protected void UpdateUIRepresentation()
		{
			if (Plotter == null)
				return;

			UpdateUIRepresentationCore();
		}
		protected virtual void UpdateUIRepresentationCore() { }

		#region IPlotterElement Members

		private Plotter2D plotter;
		void IPlotterElement.OnPlotterAttached(Plotter plotter)
		{
			plotter.CentralGrid.Children.Add(this);

			Plotter2D plotter2d = (Plotter2D)plotter;
			this.plotter = plotter2d;
			plotter2d.Viewport.PropertyChanged += Viewport_PropertyChanged;

			UpdateUIRepresentation();
		}

		private void Viewport_PropertyChanged(object sender, ExtendedPropertyChangedEventArgs e)
		{
			UpdateUIRepresentation();
		}

		void IPlotterElement.OnPlotterDetaching(Plotter plotter)
		{
			Plotter2D plotter2d = (Plotter2D)plotter;
			plotter2d.Viewport.PropertyChanged -= Viewport_PropertyChanged;
			plotter.CentralGrid.Children.Remove(this);

			this.plotter = null;
		}

		public Plotter2D Plotter
		{
			get { return plotter; }
		}

		Plotter IPlotterElement.Plotter
		{
			get { return plotter; }
		}

		#endregion
	}
}
