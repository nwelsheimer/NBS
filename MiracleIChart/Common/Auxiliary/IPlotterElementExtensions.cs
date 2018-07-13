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

namespace Openmiracle.MiracleIChart
{
	public static class IPlotterElementExtensions
	{
		public static void Remove(this IPlotterElement element)
		{
			if (element == null)
				throw new ArgumentNullException("element");

			if (element.Plotter != null)
			{
				element.Plotter.Children.Remove(element);
			}
		}

		public static void AddToPlotter(this IPlotterElement element, Plotter plotter)
		{
			if (element == null)
				throw new ArgumentNullException("element");
			if (plotter == null)
				throw new ArgumentNullException("plotter");


			plotter.Children.Add(element);
		}
	}
}
