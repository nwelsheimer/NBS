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
using System.Windows.Controls;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Diagnostics.CodeAnalysis;

namespace Openmiracle.MiracleIChart.Charts.Axes
{
	public class CollectionLabelProvider<T> : LabelProviderBase<int>
	{
		private IList<T> collection;

		[SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
		public IList<T> Collection
		{
			get { return collection; }
			set
			{
				if (value == null)
					throw new ArgumentNullException("value");

				if (collection != value)
				{
					DetachCollection();

					collection = value;

					AttachCollection();

					RaiseChanged();
				}
			}
		}

		#region Collection changed

		private void AttachCollection()
		{
			INotifyCollectionChanged observableCollection = collection as INotifyCollectionChanged;
			if (observableCollection != null)
			{
				observableCollection.CollectionChanged += OnCollectionChanged;
			}
		}

		private void OnCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
		{
			RaiseChanged();
		}

		private void DetachCollection()
		{
			INotifyCollectionChanged observableCollection = collection as INotifyCollectionChanged;
			if (observableCollection != null)
			{
				observableCollection.CollectionChanged -= OnCollectionChanged;
			}
		} 

		#endregion

		/// <summary>
		/// Initializes a new instance of the <see cref="CollectionLabelProvider&lt;T&gt;"/> class with empty labels collection.
		/// </summary>
		public CollectionLabelProvider() { }

		public CollectionLabelProvider(IList<T> collection)
			: this()
		{
			Collection = collection;
		}

		public override UIElement[] CreateLabels(ITicksInfo<int> ticksInfo)
		{
			var ticks = ticksInfo.Ticks;

			UIElement[] res = new UIElement[ticks.Length];

			var tickInfo = new LabelTickInfo<int> { Info = ticksInfo.Info };

			for (int i = 0; i < res.Length; i++)
			{
				int tick = ticks[i];
				tickInfo.Tick = tick;

				if (0 <= tick && tick < collection.Count)
				{
					string text = collection[tick].ToString();
					res[i] = new TextBlock
					{
						Text = text,
						ToolTip = text
					};
				}
				else
				{
					res[i] = null;
				}
			}
			return res;
		}
	}
}
