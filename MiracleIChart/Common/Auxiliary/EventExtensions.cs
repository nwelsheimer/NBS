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
using System.Diagnostics;
using System.ComponentModel;
using System.Collections.Specialized;

namespace Openmiracle.MiracleIChart
{
	public static class EventExtensions
	{
		public static void Raise<T>(this EventHandler<T> @event, object sender, T args) where T : EventArgs
		{
			if (@event != null)
			{
				@event(sender, args);
			}
		}

		public static void Raise(this EventHandler @event, object sender)
		{
			if (@event != null)
			{
				@event(sender, EventArgs.Empty);
			}
		}

		public static void Raise(this EventHandler @event, object sender, EventArgs args)
		{
			if (@event != null)
			{
				@event(sender, args);
			}
		}

		public static void Raise(this PropertyChangedEventHandler @event, object sender, string propertyName)
		{
			if (@event != null)
			{
				@event(sender, new PropertyChangedEventArgs(propertyName));
			}
		}

		public static void Raise(this NotifyCollectionChangedEventHandler @event, object sender)
		{
			if (@event != null)
			{
				@event(sender, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
			}
		}

		public static void Raise(this NotifyCollectionChangedEventHandler @event, object sender, NotifyCollectionChangedAction action)
		{
			if (@event != null)
			{
				@event(sender, new NotifyCollectionChangedEventArgs(action));
			}
		}

		public static void Raise(this NotifyCollectionChangedEventHandler @event, object sender, NotifyCollectionChangedEventArgs e)
		{
			if (e == null)
				throw new ArgumentNullException("e");

			if (@event != null)
			{
				@event(sender, e);
			}
		}
	}
}
