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
using Openmiracle.MiracleIChart.Common.Auxiliary;

namespace Openmiracle.MiracleIChart.Charts.Axes
{
	/// <summary>
	/// Contains data for custom generation of tick's label.
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public sealed class LabelTickInfo<T>
	{
		internal LabelTickInfo() { }

		/// <summary>
		/// Gets or sets the tick.
		/// </summary>
		/// <value>The tick.</value>
		public T Tick { get; internal set; }
		/// <summary>
		/// Gets or sets the additional info about range.
		/// </summary>
		/// <value>The info.</value>
		public object Info { get; internal set; }
		/// <summary>
		/// Gets or sets the index of tick in ticks array.
		/// </summary>
		/// <value>The index.</value>
		public int Index { get; internal set; }
	}

	/// <summary>
	/// Base class for all label providers.
	/// Contains a number of properties that can be used to adjust generated labels.
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public abstract class LabelProviderBase<T>
	{
		/// <summary>
		/// Creates the labels by given ticks info.
		/// </summary>
		/// <param name="ticksInfo">The ticks info.</param>
		/// <returns></returns>
		public abstract UIElement[] CreateLabels(ITicksInfo<T> ticksInfo);

		/// <summary>
		/// Gets or sets the label string format.
		/// </summary>
		/// <value>The label string format.</value>
		public string LabelStringFormat { get; set; }
		/// <summary>
		/// Gets or sets the custom formatter - delegate that can be called to create custom string representation of tick.
		/// </summary>
		/// <value>The custom formatter.</value>
		public Func<LabelTickInfo<T>, string> CustomFormatter { get; set; }
		/// <summary>
		/// Gets or sets the custom view - delegate that is used to create a custom, non-default look of axis label.
		/// Can be used to adjust some properties of generated label.
		/// </summary>
		/// <value>The custom view.</value>
		public Action<LabelTickInfo<T>, UIElement> CustomView { get; set; }

		/// <summary>
		/// Sets the custom formatter.
		/// </summary>
		/// <param name="formatter">The formatter.</param>
		public void SetCustomFormatter(Func<LabelTickInfo<T>, string> formatter)
		{
			CustomFormatter = formatter;
		}

		/// <summary>
		/// Sets the custom view.
		/// </summary>
		/// <param name="view">The view.</param>
		public void SetCustomView(Action<LabelTickInfo<T>, UIElement> view)
		{
			CustomView = view;
		}

		protected virtual string GetString(LabelTickInfo<T> tickInfo)
		{
			string text = null;
			if (CustomFormatter != null)
			{
				text = CustomFormatter(tickInfo);
			}
			if (text == null)
			{
				text = GetStringCore(tickInfo);

				if (text == null)
					throw new ArgumentNullException(Properties.Resources.TextOfTickShouldNotBeNull);
			}
			if (LabelStringFormat != null)
			{
				text = String.Format(LabelStringFormat, text);
			}

			return text;
		}

		protected virtual string GetStringCore(LabelTickInfo<T> tickInfo)
		{
			return tickInfo.Tick.ToString();
		}

		protected void ApplyCustomView(LabelTickInfo<T> info, UIElement label)
		{
			if (CustomView != null)
			{
				CustomView(info, label);
			}
		}

		/// <summary>
		/// Occurs when label provider is changed.
		/// Notifies axis to update its view.
		/// </summary>
		public event EventHandler Changed;
		protected void RaiseChanged()
		{
			Changed.Raise(this);
		}
	}
}
