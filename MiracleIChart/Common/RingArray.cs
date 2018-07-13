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
using System.Collections;
using System.Collections.Specialized;

namespace Openmiracle.MiracleIChart.Common
{
	public class RingArray<T> : INotifyCollectionChanged, IList<T>
	{
		public RingArray(int capacity)
		{
			this.capacity = capacity;
			array = new T[capacity];
		}

		public void Add(T item)
		{
			int index = (startIndex + count) % capacity;
			if (startIndex + count >= capacity)
			{
				startIndex++;
			}
			else
			{
				count++;
			}

			array[index] = item;

			CollectionChanged.Raise(this);
		}

		public T this[int index]
		{
			get { return array[(startIndex + index) % capacity]; }
			set
			{
				array[(startIndex + index) % capacity] = value;
				CollectionChanged.Raise(this);
			}
		}

		public void Clear()
		{
			count = 0;
			startIndex = 0;
			array = new T[capacity];
		}

		public IEnumerator<T> GetEnumerator()
		{
			for (int i = 0; i < count; i++)
			{
				yield return this[i];
			}
		}

		private int count;
		public int Count
		{
			get { return count; }
		}

		private T[] array;

		private int capacity;
		public int Capacity
		{
			get { return capacity; }
		}

		private int startIndex = 0;

		#region INotifyCollectionChanged Members

		public event NotifyCollectionChangedEventHandler CollectionChanged;

		#endregion

		#region IList<T> Members

		public int IndexOf(T item)
		{
			int index = Array.IndexOf(array, item);

			if (index == -1)
				return -1;

			return (index - startIndex + count) % capacity;
		}

		public void Insert(int index, T item)
		{
			throw new NotImplementedException();
		}

		public void RemoveAt(int index)
		{
			throw new NotImplementedException();
		}

		#endregion

		#region ICollection<T> Members

		public bool Contains(T item)
		{
			return Array.IndexOf(array, item) > -1;
		}

		public void CopyTo(T[] array, int arrayIndex)
		{
			throw new NotImplementedException();
		}

		public bool IsReadOnly
		{
			get { throw new NotImplementedException(); }
		}

		public bool Remove(T item)
		{
			throw new NotImplementedException();
		}

		#endregion

		#region IEnumerable Members

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		#endregion
	}
}
