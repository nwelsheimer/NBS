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

namespace Openmiracle.MiracleIChart
{
	public static class IListExtensions
	{
		public static void AddMany<T>(this IList<T> collection, IEnumerable<T> children)
		{
			foreach (var item in children)
			{
				collection.Add(item);
			}
		}

		public static void AddMany<T>(this IList<T> collection, params T[] children)
		{
			foreach (var child in children)
			{
				collection.Add(child);
			}
		}

		public static void RemoveAll<T>(this IList<T> collection, Type type)
		{
			var children = collection.Where(el => type.IsAssignableFrom(el.GetType())).ToArray();
			foreach (var child in children)
			{
				collection.Remove((T)child);
			}
		}

		public static void RemoveAll<T, TDelete>(this IList<T> collection)
		{
			var children = collection.OfType<TDelete>().ToArray();
			foreach (var child in children)
			{
				collection.Remove((T)(object)child);
			}
		}
	}
}
