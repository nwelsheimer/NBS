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
using Openmiracle.MiracleIChart.Charts;

namespace Openmiracle.MiracleIChart.Common.Auxiliary
{
	internal static class ArrayExtensions
	{
		internal static T Last<T>(this T[] array) {
			return array[array.Length - 1];
		}

		internal static T[] CreateArray<T>(int length, T defaultValue)
		{
			T[] res = new T[length];
			for (int i = 0; i < res.Length; i++)
			{
				res[i] = defaultValue;
			}
			return res;
		}

		internal static IEnumerable<Range<T>> GetPairs<T>(this T[] array)
		{
			for (int i = 0; i < array.Length - 1; i++)
			{
				yield return new Range<T>(array[i], array[i + 1]);
			}
		}
	}
}
