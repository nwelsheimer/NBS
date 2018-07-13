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

using System.Windows.Controls;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows;

namespace Openmiracle.MiracleIChart
{
	public class VerticalAxisTitle : ContentControl, IPlotterElement
	{
		public VerticalAxisTitle()
		{
			LayoutTransform = new RotateTransform(-90);
			VerticalAlignment = VerticalAlignment.Center;
			FontSize = 16;
		}

		private Plotter plotter;
		public Plotter Plotter
		{
			get { return plotter; }
		}

		public void OnPlotterAttached(Plotter plotter)
		{
			this.plotter = plotter;
			plotter.LeftPanel.Children.Insert(0, this);
		}

		public void OnPlotterDetaching(Plotter plotter)
		{
			this.plotter = null;
			plotter.LeftPanel.Children.Remove(this);
		}
	}
}