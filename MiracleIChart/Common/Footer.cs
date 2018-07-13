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
using System.Windows;

namespace Openmiracle.MiracleIChart
{
	/// <summary>
	/// Represents a text situated in ChartPlotter's footer.
	/// </summary>
	public class Footer : ContentControl, IPlotterElement
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="Footer"/> class.
		/// </summary>
		public Footer()
		{
			HorizontalAlignment = HorizontalAlignment.Center;
			Margin = new Thickness(0, 0, 0, 3);
		}

		public void OnPlotterAttached(Plotter plotter)
		{
			this.plotter = plotter;
			plotter.FooterPanel.Children.Add(this);
		}

		public void OnPlotterDetaching(Plotter plotter)
		{
			plotter.FooterPanel.Children.Remove(this);
			this.plotter = null;
		}

		private Plotter plotter;
		public Plotter Plotter
		{
			get { return plotter;; }
		}
	}
}
