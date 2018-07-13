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
using System.Windows.Media;
using System.Windows;

namespace Openmiracle.MiracleIChart.Charts
{
	/// <summary>
	/// Represents simple line bound to viewport coordinates.
	/// </summary>
	public abstract class SimpleLine : ViewportShape
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="SimpleLine"/> class.
		/// </summary>
		protected SimpleLine() { }

		/// <summary>
		/// Gets or sets the value of line - e.g., its horizontal or vertical coordinate.
		/// </summary>
		/// <value>The value.</value>
		public double Value
		{
			get { return (double)GetValue(ValueProperty); }
			set { SetValue(ValueProperty, value); }
		}

		/// <summary>
		/// Identifies Value dependency property.
		/// </summary>
		public static readonly DependencyProperty ValueProperty =
			DependencyProperty.Register(
			  "Value",
			  typeof(double),
			  typeof(SimpleLine),
			  new PropertyMetadata(
				  0.0, OnValueChanged));

		private static void OnValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			SimpleLine line = (SimpleLine)d;
			line.OnValueChanged();
		}

		protected virtual void OnValueChanged()
		{
			UpdateUIRepresentation();
		}

		private LineGeometry lineGeometry = new LineGeometry();
		protected LineGeometry LineGeometry
		{
			get { return lineGeometry; }
		}
		protected override Geometry DefiningGeometry
		{
			get { return lineGeometry; }
		}
	}
}
