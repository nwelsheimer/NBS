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
using Openmiracle.MiracleIChart.Charts.Isolines;

namespace Openmiracle.MiracleIChart.Common.Auxiliary
{
	internal static class DictionaryExtensions
	{
		internal static void Add<TKey, TValue>(this Dictionary<TKey, TValue> dict, TValue value, params TKey[] keys)
		{
			foreach (var key in keys)
			{
				dict.Add(key, value);
			}
		}

		internal static void Add(this Dictionary<int, Edge> dict, Edge value, params CellBitmask[] keys)
		{
			foreach (var key in keys)
			{
				dict.Add((int)key, value);
			}
		}
	}
}
