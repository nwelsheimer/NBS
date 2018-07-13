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
using System.Windows;
using System.Windows.Media;

namespace Openmiracle.MiracleIChart.Navigation
{
	/// <summary>Base class for all navigation providers</summary>
	public abstract class NavigationBase : ViewportElement2D
	{
		protected NavigationBase()
		{
			ManualTranslate = true;
			ManualClip = true;
			Loaded += NavigationBase_Loaded;
		}

		private void NavigationBase_Loaded(object sender, RoutedEventArgs e)
		{
			OnLoaded(e);
		}

		protected virtual void OnLoaded(RoutedEventArgs e)
		{
			// this call enables contextMenu to be shown after loading and
			// before any changes to Viewport - without this call 
			// context menu was not shown.
			InvalidateVisual();
		}

		protected override void OnRenderCore(DrawingContext dc, RenderState state)
		{
			dc.DrawRectangle(Brushes.Transparent, null, state.Output);
		}
	}
}
