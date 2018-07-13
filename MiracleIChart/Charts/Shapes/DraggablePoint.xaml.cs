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
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Controls.Primitives;
using Openmiracle.MiracleIChart;

namespace Openmiracle.MiracleIChart.Charts.Shapes
{
	/// <summary>
	/// Represents a simple draggable point with position bound to point in viewport coordinates, which allows to drag iself by mouse.
	/// </summary>
	public partial class DraggablePoint : ViewportUIContainer
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="DraggablePoint"/> class.
		/// </summary>
		public DraggablePoint()
		{
			InitializeComponent();
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="DraggablePoint"/> class.
		/// </summary>
		/// <param name="position">The position of DraggablePoint.</param>
		public DraggablePoint(Point position) : this() { Position = position; }

		bool dragging = false;
		Point dragStart;
		Vector shift;
		protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
		{
			dragStart = e.GetPosition(Plotter.Viewport).ScreenToData(Plotter.Viewport.Transform);
			shift = Position - dragStart;
			dragging = true;

			CaptureMouse();
		}

		protected override void OnMouseMove(MouseEventArgs e)
		{
			if (!dragging) return;

			Point mouseInData = e.GetPosition(Plotter.Viewport).ScreenToData(Plotter.Viewport.Transform);

			if (mouseInData != dragStart)
			{
				Position = mouseInData + shift;
			}
		}

		protected override void OnMouseLeftButtonUp(MouseButtonEventArgs e)
		{
			ReleaseMouseCapture();

			dragging = false;
		}
	}
}
