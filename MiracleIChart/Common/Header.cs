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
using System.Windows.Markup;

namespace Openmiracle.MiracleIChart
{
	public class Header : ContentControl, IPlotterElement
	{
		public Header()
		{
			FontSize = 18;
			HorizontalAlignment = HorizontalAlignment.Center;
			Margin = new Thickness(0, 0, 0, 3);
		}

		private Plotter plotter;
		public Plotter Plotter
		{
			get { return plotter; }
		}
		
		public void OnPlotterAttached(Plotter plotter)
		{
			this.plotter = plotter;
			plotter.HeaderPanel.Children.Add(this);
		}

		public void OnPlotterDetaching(Plotter plotter)
		{
			this.plotter = null;
			plotter.HeaderPanel.Children.Remove(this);
		}
	}
}