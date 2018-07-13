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
using System.Collections.ObjectModel;

namespace Openmiracle.MiracleIChart.Common
{
	/// <summary>
	/// Contains all charts added to ChartPlotter.
	/// </summary>
	public sealed class ChildrenCollection : D3Collection<IPlotterElement>
	{
		protected override void OnItemAdding(IPlotterElement item)
		{
			if (item == null)
				throw new ArgumentNullException("item");
		}

		/// <summary>
		/// This override enables notifying about removing each element, instead of
		/// notifying about collection reset.
		/// </summary>
		protected override void ClearItems()
		{
			var items = new List<IPlotterElement>(base.Items);
			foreach (var item in items)
			{
				Remove(item);
			}
		}
	}
}
