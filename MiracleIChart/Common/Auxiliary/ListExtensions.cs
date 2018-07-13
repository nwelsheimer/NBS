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

namespace Openmiracle.MiracleIChart
{
	internal static class ListExtensions
	{
		/// <summary>
		/// Gets last element of list.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="list"></param>
		/// <returns></returns>
		internal static T GetLast<T>(this List<T> list)
		{
			if (list == null) throw new ArgumentNullException("list");
			if (list.Count == 0) throw new InvalidOperationException(Properties.Resources.CannotGetLastElement);

			return list[list.Count - 1];
		}

		internal static void ForEach<T>(this IEnumerable<T> source, Action<T> action) {
			if (action == null)
				throw new ArgumentNullException("action");
			if (source == null)
				throw new ArgumentNullException("source");

			foreach (var item in source)
			{
				action(item);
			}
		}
	}
}
