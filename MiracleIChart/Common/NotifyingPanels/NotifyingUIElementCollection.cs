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
using System.Windows.Controls;
using System.Windows;
using System.Collections.Specialized;
using System.Collections.ObjectModel;

namespace Openmiracle.MiracleIChart.Common
{
	internal sealed class NotifyingUIElementCollection : UIElementCollection, INotifyCollectionChanged
	{
		public NotifyingUIElementCollection(UIElement visualParent, FrameworkElement logicalParent)
			: base(visualParent, logicalParent)
		{
			collection.CollectionChanged += OnCollectionChanged;
		}

		private void OnCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
		{
			CollectionChanged.Raise(this, e);
		}

		#region Overrides

		private readonly D3UIElementCollection collection = new D3UIElementCollection();

		public override int Add(UIElement element)
		{
			collection.Add(element);
			return base.Add(element);
		}

		public override void Clear()
		{
			collection.Clear();
			base.Clear();
		}

		public override void Insert(int index, UIElement element)
		{
			collection.Insert(index, element);
			base.Insert(index, element);
		}

		public override void Remove(UIElement element)
		{
			collection.Remove(element);
			base.Remove(element);
		}

		public override void RemoveAt(int index)
		{
			collection.RemoveAt(index);
			base.RemoveAt(index);
		}

		public override void RemoveRange(int index, int count)
		{
			for (int i = index; i < index + count; i++)
			{
				collection.RemoveAt(i);
			}
			base.RemoveRange(index, count);
		}

		public override UIElement this[int index]
		{
			get
			{
				return base[index];
			}
			set
			{
				collection[index] = value;
				base[index] = value;
			}
		}

		#endregion

		#region INotifyCollectionChanged Members

		public event NotifyCollectionChangedEventHandler CollectionChanged;

		#endregion
	}

	internal sealed class D3UIElementCollection : D3Collection<UIElement> { }
}
