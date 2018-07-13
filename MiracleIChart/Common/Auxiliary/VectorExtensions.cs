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

namespace Openmiracle.MiracleIChart.Common.Auxiliary
{
	public static class VectorExtensions
	{
		public static Vector ToData(this Vector vector, IViewport2D viewport)
		{
			Vector result = new Vector(
				vector.X * viewport.Visible.Width / viewport.Output.Width,
				-vector.Y * viewport.Visible.Height / viewport.Output.Height);

			return result;
		}

		public static Vector ToScreen(this Vector vector, IViewport2D viewport)
		{
			Vector result = new Vector(
				vector.X * viewport.Output.Width / viewport.Visible.Width,
				-vector.Y * viewport.Output.Height / viewport.Visible.Height);

			return result;
		}

		public static Point ToPoint(this Vector vector)
		{
			return new Point(vector.X, vector.Y);
		}
	}
}
