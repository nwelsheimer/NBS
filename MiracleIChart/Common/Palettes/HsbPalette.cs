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
using Openmiracle.MiracleIChart.Common.Auxiliary;
using System.ComponentModel;
using System.Windows.Media;

namespace Openmiracle.MiracleIChart.Common.Palettes
{
	public sealed class HSBPalette : IPalette
	{
		private double start = 0;
		[DefaultValue(0.0)]
		public double Start
		{
			get { return start; }
			set
			{
				if (start != value)
				{
					start = value;
					Changed.Raise(this);
				}
			}
		}

		private double width = 360;
		[DefaultValue(360.0)]
		public double Width
		{
			get { return width; }
			set
			{
				if (width != value)
				{
					width = value;
					Changed.Raise(this);
				}
			}
		}

		#region IPalette Members

		public Color GetColor(double t)
		{
			Verify.IsTrue(0 <= t && t <= 1);

			return new HsbColor(start + t * width, 1, 1).ToArgb();
		}

		public event EventHandler Changed;

		#endregion
	}
}
