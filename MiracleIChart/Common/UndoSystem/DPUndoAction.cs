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

namespace Openmiracle.MiracleIChart.Common.UndoSystem
{
	public class DPUndoAction : UndoableAction
	{
		private readonly DependencyProperty property;
		private readonly DependencyObject target;
		private readonly object oldValue;
		private readonly object newValue;

		public DPUndoAction(DependencyObject target, DependencyProperty property, object oldValue, object newValue)
		{
			this.target = target;
			this.property = property;
			this.oldValue = oldValue;
			this.newValue = newValue;
		}

		public DPUndoAction(DependencyObject target, DependencyPropertyChangedEventArgs e)
		{
			this.target = target;
			this.property = e.Property;
			this.oldValue = e.OldValue;
			this.newValue = e.NewValue;
		}

		public override void Do()
		{
			target.SetValue(property, newValue);
		}

		public override void Undo()
		{
			target.SetValue(property, oldValue);
		}
	}
}
