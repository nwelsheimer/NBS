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
using System.Windows.Media;

namespace Openmiracle.MiracleIChart.Common.Auxiliary
{
	internal static class VisualTreeHelperHelper
	{
		public static DependencyObject GetParent(DependencyObject target, int depth)
		{
			DependencyObject parent = target;
			do
			{
				parent = VisualTreeHelper.GetParent(parent);
				if (parent == null)
				{
					break;
				}
			} while (--depth > 0);

			return parent;
		}
	}
}
