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

namespace Openmiracle.MiracleIChart.DataSources
{
	/// <summary>Data source that returns sequence of 2D points.</summary>
	public interface IPointDataSource
	{

		/// <summary>Returns object to enumerate points in source.</summary>
		IPointEnumerator GetEnumerator(DependencyObject context);

		/// <summary>This event is raised when contents of source are changed.</summary>
		event EventHandler DataChanged;
	}

	public class Context : DependencyObject
	{
		private readonly static Context emptyContext = new Context();

		public static Context EmptyContext
		{
			get { return emptyContext; }
		}

		public void ClearValues()
		{
			var localEnumerator = GetLocalValueEnumerator();
			localEnumerator.Reset();
			while (localEnumerator.MoveNext())
			{
				ClearValue(localEnumerator.Current.Property);
			}
		}

		public Rect VisibleRect
		{
			get { return (Rect)GetValue(VisibleRectProperty); }
			set { SetValue(VisibleRectProperty, value); }
		}

		public static readonly DependencyProperty VisibleRectProperty =
			DependencyProperty.Register(
			  "VisibleRect",
			  typeof(Rect),
			  typeof(Context),
			  new PropertyMetadata(new Rect()));

		public Rect Output
		{
			get { return (Rect)GetValue(OutputProperty); }
			set { SetValue(OutputProperty, value); }
		}

		public static readonly DependencyProperty OutputProperty =
			DependencyProperty.Register(
			  "Output",
			  typeof(Rect),
			  typeof(Context),
			  new PropertyMetadata(new Rect()));
	}
}
