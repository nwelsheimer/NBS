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

namespace Openmiracle.MiracleIChart.Charts
{
	/// <summary>
	/// Interaction logic for ViewportListView.xaml
	/// </summary>
	public partial class ViewportListView : ListView, IPlotterElement
	{
		public ViewportListView()
		{
			InitializeComponent();
		}

		#region IPlotterElement Members

		void IPlotterElement.OnPlotterAttached(Plotter plotter)
		{
			this.plotter = (Plotter2D)plotter;
			this.plotter.Viewport.PropertyChanged += Viewport_PropertyChanged;

			plotter.CentralGrid.Children.Add(this);
		}

		void IPlotterElement.OnPlotterDetaching(Plotter plotter)
		{
			plotter.CentralGrid.Children.Remove(this);

			this.plotter.Viewport.PropertyChanged -= Viewport_PropertyChanged;
			this.plotter = null;
		}

		private void Viewport_PropertyChanged(object sender, ExtendedPropertyChangedEventArgs e)
		{
		}

		Plotter IPlotterElement.Plotter
		{
			get { return plotter; }
		}

		private Plotter2D plotter;
		public Plotter2D Plotter
		{
			get { return plotter; }
		}

		#endregion
	}
}
