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
using System.Windows.Controls;

namespace Openmiracle.MiracleIChart.Charts
{
	public abstract class ContentGraph : ContentControl, IPlotterElement
	{
		#region IPlotterElement Members

		private void Viewport_PropertyChanged(object sender, ExtendedPropertyChangedEventArgs e)
		{
			OnViewportPropertyChanged(e);
		}

		protected virtual void OnViewportPropertyChanged(ExtendedPropertyChangedEventArgs e) { }

		protected virtual Panel HostPanel
		{
			get { return plotter.CentralGrid; }
		}

		void IPlotterElement.OnPlotterAttached(Plotter plotter)
		{
			this.plotter = (Plotter2D)plotter;
			HostPanel.Children.Add(this);
			this.plotter.Viewport.PropertyChanged += Viewport_PropertyChanged;

			OnPlotterAttached();
		}

		protected virtual void OnPlotterAttached() { }

		void IPlotterElement.OnPlotterDetaching(Plotter plotter)
		{
			OnPlotterDetaching();

			this.plotter.Viewport.PropertyChanged -= Viewport_PropertyChanged;
			HostPanel.Children.Remove(this);
			this.plotter = null;
		}

		protected virtual void OnPlotterDetaching() { }

		private Plotter2D plotter;
		protected Plotter2D Plotter2D
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
