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
using System.ComponentModel;

namespace Openmiracle.MiracleIChart.Charts
{
	/// <summary>
	/// Represents interface that is implemented by each axis and provides uniform access to some non-generic properties.
	/// </summary>
	public interface IAxis : IPlotterElement
	{
		/// <summary>
		/// Gets or sets the axis placement.
		/// </summary>
		/// <value>The placement.</value>
		AxisPlacement Placement { get; set; }
		/// <summary>
		/// Occurs when ticks are changed.
		/// Used by AxisGrid.
		/// </summary>
		[EditorBrowsable(EditorBrowsableState.Never)]
		event EventHandler TicksChanged;

		/// <summary>
		/// Gets the screen coordinates of ticks.
		/// Used by AxisGrid.
		/// </summary>
		/// <value>The screen ticks.</value>
		[EditorBrowsable(EditorBrowsableState.Never)]
		double[] ScreenTicks { get; }
		/// <summary>
		/// Gets the screen coordinates of minor ticks.
		/// used by AxisGrid.
		/// </summary>
		/// <value>The minor screen ticks.</value>
		[EditorBrowsable(EditorBrowsableState.Never)]
		MinorTickInfo<double>[] MinorScreenTicks { get; }
	}
}
