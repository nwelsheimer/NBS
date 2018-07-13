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
using System.Windows.Controls;
using System.Windows.Media;
using Openmiracle.MiracleIChart.DataSources;
using Openmiracle.MiracleIChart.Filters;
using Openmiracle.MiracleIChart.PointMarkers;
using System.ComponentModel.Design.Serialization;
using System.ComponentModel;
using System.Windows;
using Openmiracle.MiracleIChart.Common;
using System.Collections.Generic;

namespace Openmiracle.MiracleIChart
{
	/// <summary>Control for plotting 2d images</summary>
	public class Plotter2D : Plotter
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="Plotter2D"/> class.
		/// </summary>
		public Plotter2D()
		{
			Children.Add(viewport);
		}

		private readonly Viewport2D viewport = new Viewport2D();

		/// <summary>
		/// Gets the viewport.
		/// </summary>
		/// <value>The viewport.</value>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public Viewport2D Viewport
		{
			get { return viewport; }
		}

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public DataTransform DataTransform
		{
			get { return viewport.Transform.DataTransform; }
			set { viewport.Transform = viewport.Transform.WithDataTransform(value); }
		}

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public CoordinateTransform Transform
		{
			get { return viewport.Transform; }
			set { viewport.Transform = value; }
		}

		public void FitToView()
		{
			viewport.FitToView();
		}

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public Rect Visible
		{
			get { return viewport.Visible; }
			set { viewport.Visible = value; }
		}
	}
}