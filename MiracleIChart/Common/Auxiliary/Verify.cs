﻿//This is a source code or part of OpenMiracle project
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

namespace Openmiracle.MiracleIChart.Common.Auxiliary
{
	internal static class Verify
	{
		[DebuggerStepThrough]
		public static void IsTrue(this bool condition)
		{
			if (!condition)
			{
				throw new ArgumentException(Properties.Resources.AssertionFailedSearch);
			}
		}

		[DebuggerStepThrough]
		public static void IsTrue(this bool condition, string paramName)
		{
			if (!condition)
			{
				throw new ArgumentException(Properties.Resources.AssertionFailedSearch, paramName);
			}
		}

		public static void IsTrueWithMessage(this bool condition, string message)
		{
			if (!condition)
				throw new ArgumentException(message);
		}

		[DebuggerStepThrough]
		public static void AssertNotNull(object obj)
		{
			Verify.IsTrue(obj != null);
		}

		public static void VerifyNotNull(this object obj, string paramName)
		{
			if (obj == null)
				throw new ArgumentNullException(paramName);
		}

		public static void VerifyNotNull(this object obj)
		{
			VerifyNotNull(obj, "value");
		}

		[DebuggerStepThrough]
		public static void AssertIsNotNaN(this double d)
		{
			Verify.IsTrue(!Double.IsNaN(d));
		}

		[DebuggerStepThrough]
		public static void AssertIsFinite(this double d)
		{
			Verify.IsTrue(!Double.IsInfinity(d) && !(Double.IsNaN(d)));
		}
	}
}
