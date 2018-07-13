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
using System.ComponentModel;
using Openmiracle.MiracleIChart;

namespace Openmiracle.MiracleIChart
{
	public class ExtendedPropertyChangedEventArgs : EventArgs
	{
		public string PropertyName { get; set; }
		public object OldValue { get; set; }
		public object NewValue { get; set; }

		public static ExtendedPropertyChangedEventArgs FromDependencyPropertyChanged(DependencyPropertyChangedEventArgs e)
		{
			return new ExtendedPropertyChangedEventArgs { PropertyName = e.Property.Name, NewValue = e.NewValue, OldValue = e.OldValue };
		}
	}

	public interface IViewport2D
	{
		Rect Visible { get; set; }
		Rect Output { get; }
		CoordinateTransform Transform { get; set; }
        void FitToView();

		event EventHandler<ExtendedPropertyChangedEventArgs> PropertyChanged;
	}
}
