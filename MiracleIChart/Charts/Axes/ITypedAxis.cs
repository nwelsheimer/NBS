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
using Openmiracle.MiracleIChart.Charts.Axes;

namespace Openmiracle.MiracleIChart.Charts
{
	/// <summary>
	/// Describes axis as having ticks type.
	/// Provides access to some typed properties.
	/// </summary>
	/// <typeparam name="T">Axis tick's type.</typeparam>
	public interface ITypedAxis<T> : IAxis
	{
		/// <summary>
		/// Gets the ticks provider.
		/// </summary>
		/// <value>The ticks provider.</value>
		ITicksProvider<T> TicksProvider { get; }
		/// <summary>
		/// Gets the label provider.
		/// </summary>
		/// <value>The label provider.</value>
		LabelProviderBase<T> LabelProvider { get; }

		/// <summary>
		/// Gets or sets the convertion of tick from double.
		/// Should not be null.
		/// </summary>
		/// <value>The convert from double.</value>
		Func<double, T> ConvertFromDouble { get; set; }
		/// <summary>
		/// Gets or sets the convertion of tick to double.
		/// Should not be null.
		/// </summary>
		/// <value>The convert to double.</value>
		Func<T, double> ConvertToDouble { get; set; }
	}
}
