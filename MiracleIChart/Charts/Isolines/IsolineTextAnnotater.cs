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
using System.Windows;

namespace Openmiracle.MiracleIChart.Charts.Isolines
{
	/// <summary>
	/// IsolineTextAnnotater defines methods to annotate isolines - create a list of labels with its position.
	/// </summary>
	public sealed class IsolineTextAnnotater
	{
		private double wayBeforeText = 10;
		/// <summary>
		/// Gets or sets the distance between text labels.
		/// </summary>
		public double WayBeforeText
		{
			get { return wayBeforeText; }
			set { wayBeforeText = value; }
		}

		/// <summary>
		/// Annotates the specified isoline collection.
		/// </summary>
		/// <param name="collection">The collection.</param>
		/// <param name="visible">The visible rectangle.</param>
		/// <returns></returns>
		public Collection<IsolineTextLabel> Annotate(IsolineCollection collection, Rect visible)
		{
			Collection<IsolineTextLabel> res = new Collection<IsolineTextLabel>();

			foreach (var line in collection.Lines)
			{
				double way = 0;
				foreach (var segment in line.GetSegments())
				{
					double length = segment.GetLength();
					way += length;
					if (way > wayBeforeText)
					{
						way = 0;
						res.Add(new IsolineTextLabel
						{
							Text = line.RealValue.ToString("G2"),
							Position = segment.Max,
							Rotation = (segment.Max - segment.Min).ToAngle()
						});
					}
				}
			}

			return res;
		}
	}
}
