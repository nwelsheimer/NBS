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
using Openmiracle.MiracleIChart.Filters;
using Openmiracle.MiracleIChart.Common;
using System.Collections.Specialized;
using System.Windows;

namespace Openmiracle.MiracleIChart.Charts
{
	public sealed class FilterCollection : D3Collection<IPointsFilter>
	{
		protected override void OnItemAdding(IPointsFilter item)
		{
			if (item == null)
				throw new ArgumentNullException("item");
		}

		protected override void OnItemAdded(IPointsFilter item)
		{
			item.Changed += OnItemChanged;
		}

		private void OnItemChanged(object sender, EventArgs e)
		{
			OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
		}

		protected override void OnItemRemoving(IPointsFilter item)
		{
			item.Changed -= OnItemChanged;
		}

		internal List<Point> Filter(List<Point> points, Rect screenRect)
		{
			foreach (var filter in Items)
			{
				filter.SetScreenRect(screenRect);
				points = filter.Filter(points);
			}

			return points;
		}
	}
}
