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
using System.Windows;

namespace Openmiracle.MiracleIChart
{
	public class ResolveLegendItemEventArgs : EventArgs {
		public ResolveLegendItemEventArgs(LegendItem legendItem) {
			LegendItem = legendItem;
		}

		public LegendItem LegendItem { get; set; }
	}

	public abstract class Description {

		private LegendItem legendItem;
		public LegendItem LegendItem {
			get {
				if (legendItem == null) {
					legendItem = CreateLegendItem();
				}
				return legendItem;
			}
		}

		private LegendItem CreateLegendItem() {
			LegendItem item = CreateLegendItemCore();
			return RaiseResolveLegendItem(item);
		}

		protected virtual LegendItem CreateLegendItemCore() {
			return null;
		}

		public event EventHandler<ResolveLegendItemEventArgs> ResolveLegendItem;
		private LegendItem RaiseResolveLegendItem(LegendItem uncustomizedLegendItem) {
			if (ResolveLegendItem != null) {
				ResolveLegendItemEventArgs e = new ResolveLegendItemEventArgs(uncustomizedLegendItem);
				ResolveLegendItem(this, e);
				return e.LegendItem;
			}
			else {
				return uncustomizedLegendItem;
			}
		}

		private UIElement viewportElement;
		public UIElement ViewportElement {
			get { return viewportElement; }
		}

		internal void Attach(UIElement element) {
			this.viewportElement = element;
			AttachCore(element);
		}

		protected virtual void AttachCore(UIElement element) { }

		internal void Detach() {
			viewportElement = null;
		}

		public abstract string Brief { get; }

		public abstract string Full { get; }

		public override string ToString() {
			return Brief;
		}
	}
}
