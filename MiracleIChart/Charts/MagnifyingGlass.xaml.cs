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
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Openmiracle.MiracleIChart
{
	public partial class MagnifyingGlass : Grid, IPlotterElement
	{
		public MagnifyingGlass()
		{
			InitializeComponent();
			Loaded += MagnifyingGlass_Loaded;
		}

		private void MagnifyingGlass_Loaded(object sender, RoutedEventArgs e)
		{
			UpdateViewbox();
		}

		protected override void OnPreviewMouseWheel(MouseWheelEventArgs e)
		{
			Magnification += e.Delta / Mouse.MouseWheelDeltaForOneLine * 0.2;
			e.Handled = false;
		}

		private void plotter_PreviewMouseMove(object sender, MouseEventArgs e)
		{
			VisualBrush b = (VisualBrush)magnifierEllipse.Fill;
			Point pos = e.GetPosition(plotter.ParallelCanvas);

			Point plotterPos = e.GetPosition(plotter);

			Rect viewBox = b.Viewbox;
			double xoffset = viewBox.Width / 2.0;
			double yoffset = viewBox.Height / 2.0;
			viewBox.X = plotterPos.X - xoffset;
			viewBox.Y = plotterPos.Y - yoffset;
			b.Viewbox = viewBox;
			Canvas.SetLeft(this, pos.X - Width / 2);
			Canvas.SetTop(this, pos.Y - Height / 2);
		}

		private double magnification = 2.0;
		public double Magnification
		{
			get { return magnification; }
			set
			{
				magnification = value;

				UpdateViewbox();
			}
		}

		private void UpdateViewbox()
		{
			if (!IsLoaded)
				return;

			VisualBrush b = (VisualBrush)magnifierEllipse.Fill;
			Rect viewBox = b.Viewbox;
			viewBox.Width = Width / magnification;
			viewBox.Height = Height / magnification;
			b.Viewbox = viewBox;
		}

		protected override void OnPropertyChanged(DependencyPropertyChangedEventArgs e)
		{
			base.OnPropertyChanged(e);

			if (e.Property == WidthProperty || e.Property == HeightProperty)
			{
				UpdateViewbox();
			}
		}

		#region IPlotterElement Members

		Plotter plotter;
		public void OnPlotterAttached(Plotter plotter)
		{
			this.plotter = plotter;
			plotter.ParallelCanvas.Children.Add(this);
			plotter.PreviewMouseMove += plotter_PreviewMouseMove;

			VisualBrush b = (VisualBrush)magnifierEllipse.Fill;
			b.Visual = plotter.MainGrid;
		}

		public void OnPlotterDetaching(Plotter plotter)
		{
			plotter.PreviewMouseMove -= plotter_PreviewMouseMove;
			plotter.ParallelCanvas.Children.Remove(this);
			this.plotter = null;

			VisualBrush b = (VisualBrush)magnifierEllipse.Fill;
			b.Visual = null;
		}

		public Plotter Plotter
		{
			get { return plotter; ; }
		}

		#endregion
	}
}
