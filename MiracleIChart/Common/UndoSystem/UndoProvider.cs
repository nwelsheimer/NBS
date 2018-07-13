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
using System.ComponentModel;
using System.Windows;

namespace Openmiracle.MiracleIChart.Common.UndoSystem
{
	public class UndoProvider : INotifyPropertyChanged
	{
		private readonly ActionStack undoStack = new ActionStack();
		private readonly ActionStack redoStack = new ActionStack();

		public UndoProvider()
		{
			undoStack.IsEmptyChanged += OnUndoStackIsEmptyChanged;
			redoStack.IsEmptyChanged += OnRedoStackIsEmptyChanged;
		}

		private bool isEnabled = true;
		public bool IsEnabled
		{
			get { return isEnabled; }
			set { isEnabled = value; }
		}

		private void OnUndoStackIsEmptyChanged(object sender, EventArgs e)
		{
			PropertyChanged.Raise(this, "CanUndo");
		}

		private void OnRedoStackIsEmptyChanged(object sender, EventArgs e)
		{
			PropertyChanged.Raise(this, "CanRedo");
		}

		public void AddAction(UndoableAction action)
		{
			if (!isEnabled)
				return;

			if (state != UndoState.None)
				return;

			undoStack.Push(action);
			redoStack.Clear();
		}

		public void Undo()
		{
			var action = undoStack.Pop();
			redoStack.Push(action);

			state = UndoState.Undoing;
			try
			{
				action.Undo();
			}
			finally
			{
				state = UndoState.None;
			}
		}

		public void Redo()
		{
			var action = redoStack.Pop();
			undoStack.Push(action);

			state = UndoState.Redoing;
			try
			{
				action.Do();
			}
			finally
			{
				state = UndoState.None;
			}
		}

		public bool CanUndo
		{
			get { return !undoStack.IsEmpty; }
		}

		public bool CanRedo
		{
			get { return !redoStack.IsEmpty; }
		}

		private UndoState state = UndoState.None;
		public UndoState State
		{
			get { return state; }
		}

		#region INotifyPropertyChanged Members

		public event PropertyChangedEventHandler PropertyChanged;

		#endregion

		private readonly Dictionary<CaptureKeyHolder, object> captureHolders = new Dictionary<CaptureKeyHolder, object>();
		public void CaptureOldValue(DependencyObject target, DependencyProperty property, object oldValue)
		{
			captureHolders[new CaptureKeyHolder { Target = target, Property = property }] = oldValue;
		}

		public void CaptureNewValue(DependencyObject target, DependencyProperty property, object newValue)
		{
			var holder = new CaptureKeyHolder { Target = target, Property = property };
			if (captureHolders.ContainsKey(holder))
			{
				object oldValue = captureHolders[holder];

				var action = new DPUndoAction(target, property, oldValue, newValue);
				AddAction(action);
			}
		}

		private sealed class CaptureKeyHolder
		{
			public DependencyObject Target { get; set; }
			public DependencyProperty Property { get; set; }

			public override int GetHashCode()
			{
				return Target.GetHashCode() ^ Property.GetHashCode();
			}

			public override bool Equals(object obj)
			{
				if (obj == null) return false;

				CaptureKeyHolder other = obj as CaptureKeyHolder;
				if (other == null) return false;

				return Target == other.Target && Property == other.Property;
			}
		}
	}

	public enum UndoState
	{
		None,
		Undoing,
		Redoing
	}
}
