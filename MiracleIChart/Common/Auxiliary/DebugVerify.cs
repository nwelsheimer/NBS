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
using System.Diagnostics;
using System.Windows;

namespace Openmiracle.MiracleIChart.Common.Auxiliary
{
	internal static class DebugVerify
	{
		[Conditional("DEBUG")]
		[DebuggerStepThrough]
		public static void Is(bool condition)
		{
			if (!condition)
			{
				throw new ArgumentException(Properties.Resources.AssertionFailed);
			}
		}

		[Conditional("DEBUG")]
		[DebuggerStepThrough]
		public static void IsNotNaN(double d)
		{
			DebugVerify.Is(!Double.IsNaN(d));
		}

		[Conditional("DEBUG")]
		[DebuggerStepThrough]
		public static void IsNotNaN(Vector vec)
		{
			DebugVerify.IsNotNaN(vec.X);
			DebugVerify.IsNotNaN(vec.Y);
		}

		[Conditional("DEBUG")]
		[DebuggerStepThrough]
		public static void IsNotNaN(Point point)
		{
			DebugVerify.IsNotNaN(point.X);
			DebugVerify.IsNotNaN(point.Y);
		}

		[Conditional("DEBUG")]
		[DebuggerStepThrough]
		public static void IsFinite(double d)
		{
			DebugVerify.Is(!Double.IsInfinity(d) && !(Double.IsNaN(d)));
		}

		[Conditional("DEBUG")]
		[DebuggerStepThrough]
		public static void IsNotNull(object obj)
		{
			DebugVerify.Is(obj != null);
		}
	}
}
