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
using System.Windows.Input;
using System.Windows;

namespace Openmiracle.MiracleIChart.Navigation
{
	// todo проверить, как происходит работа когда мышь не над плоттером, а над его ребенком
	// todo если все ОК, то перевести все маус навигейшн контролы на этот класс как базовый
	public abstract class MouseNavigationBase : NavigationBase
	{
		public override void OnPlotterAttached(Plotter plotter)
		{
			base.OnPlotterAttached(plotter);

			Mouse.AddMouseDownHandler(Parent, OnMouseDown);
			Mouse.AddMouseMoveHandler(Parent, OnMouseMove);
			Mouse.AddMouseUpHandler(Parent, OnMouseUp);
			Mouse.AddMouseWheelHandler(Parent, OnMouseWheel);
		}

		public override void OnPlotterDetaching(Plotter plotter)
		{
			Mouse.RemoveMouseDownHandler(Parent, OnMouseDown);
			Mouse.RemoveMouseMoveHandler(Parent, OnMouseMove);
			Mouse.RemoveMouseUpHandler(Parent, OnMouseUp);
			Mouse.RemoveMouseWheelHandler(Parent, OnMouseWheel);

			base.OnPlotterDetaching(plotter);
		}

		private void OnMouseWheel(object sender, MouseWheelEventArgs e)
		{
			OnPlotterMouseWheel(e);
		}

		protected virtual void OnPlotterMouseWheel(MouseWheelEventArgs e) { }

		private void OnMouseUp(object sender, MouseButtonEventArgs e)
		{
			OnPlotterMouseUp(e);
		}

		protected virtual void OnPlotterMouseUp(MouseButtonEventArgs e) { }

		private void OnMouseDown(object sender, MouseButtonEventArgs e)
		{
			OnPlotterMouseDown(e);
		}

		protected virtual void OnPlotterMouseDown(MouseButtonEventArgs e) { }

		private void OnMouseMove(object sender, MouseEventArgs e)
		{
			OnPlotterMouseMove(e);
		}

		protected virtual void OnPlotterMouseMove(MouseEventArgs e) { }

	}
}
