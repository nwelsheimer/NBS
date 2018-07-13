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

using System.Linq;
using System.Windows;
using Openmiracle.MiracleIChart;
using Openmiracle.MiracleIChart.Common;
using Openmiracle.MiracleIChart.Common.Auxiliary;
using System;
using System.Collections.Specialized;

namespace Openmiracle.MiracleIChart.ViewportRestrictions
{
	public sealed class RestrictionCollection : D3Collection<IViewportRestriction>
	{
		protected override void OnItemAdding(IViewportRestriction item)
		{
			if (item == null)
				throw new ArgumentNullException("item");
		}

		protected override void OnItemAdded(IViewportRestriction item)
		{
			item.Changed += OnItemChanged;
		}

		private void OnItemChanged(object sender, EventArgs e)
		{
			OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
		}

		protected override void OnItemRemoving(IViewportRestriction item)
		{
			item.Changed -= OnItemChanged;
		}

		internal Rect ApplyRestrictions(Rect oldVisible, Rect newVisible, Viewport2D viewport)
		{
			Rect res = newVisible;
			foreach (var restriction in this)
			{
				res = restriction.Apply(oldVisible, newVisible, viewport);
			}
			return res;
		}
	}
}
