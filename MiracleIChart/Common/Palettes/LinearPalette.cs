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
using System.ComponentModel;
using System.Windows.Markup;
using Openmiracle.MiracleIChart.Common.Auxiliary;
using System.Collections.ObjectModel;
using System.Diagnostics.CodeAnalysis;

namespace Openmiracle.MiracleIChart.Common.Palettes
{
	public class ColorStep
	{
		public Color Color { get; set; }
	}

	[ContentProperty("ColorSteps_XAML")]
	public sealed class LinearPalette : IPalette, ISupportInitialize
	{
		private double[] points;

		private ObservableCollection<Color> colors = new ObservableCollection<Color>();
		public ObservableCollection<Color> ColorSteps
		{
			get { return colors; }
		}

		private List<ColorStep> colorSteps_XAML = new List<ColorStep>();
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public List<ColorStep> ColorSteps_XAML
		{
			get { return colorSteps_XAML; }
		}

		[SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
		private void RaiseChanged()
		{
			Changed.Raise(this);
		}
		public event EventHandler Changed;

		public LinearPalette() { }

		public LinearPalette(params Color[] colors)
		{
			if (colors == null) throw new ArgumentNullException("colors");
			if (colors.Length < 2) throw new ArgumentException(Properties.Resources.PaletteTooFewColors);

			this.colors = new ObservableCollection<Color>(colors);
			FillPoints(colors.Length);
		}

		private void FillPoints(int size)
		{
			points = new double[size];
			for (int i = 0; i < size; i++)
			{
				points[i] = i / (double)(size - 1);
			}
		}

		private bool increaseBrightness = true;
		[DefaultValue(true)]
		public bool IncreaseBrightness
		{
			get { return increaseBrightness; }
			set { increaseBrightness = value; }
		}

		public Color GetColor(double t)
		{
			Verify.AssertIsFinite(t);
			Verify.IsTrue(0 <= t && t <= 1);

			if (t <= 0)
				return colors[0];
			else if (t >= 1)
				return colors[colors.Count - 1];
			else
			{
				int i = 0;
				while (points[i] < t)
					i++;

				double alpha = (points[i] - t) / (points[i] - points[i - 1]);

				Verify.IsTrue(0 <= alpha && alpha <= 1);

				Color c0 = colors[i - 1];
				Color c1 = colors[i];
				Color res = Color.FromRgb(
					(byte)(c0.R * alpha + c1.R * (1 - alpha)),
					(byte)(c0.G * alpha + c1.G * (1 - alpha)),
					(byte)(c0.B * alpha + c1.B * (1 - alpha)));

				// Increasing saturation and brightness
				if (increaseBrightness)
				{
					HsbColor hsb = res.ToHsbColor();
					//hsb.Saturation = 0.5 * (1 + hsb.Saturation);
					hsb.Brightness = 0.5 * (1 + hsb.Brightness);
					return hsb.ToArgb();
				}
				else
				{
					return res;
				}
			}
		}

		#region ISupportInitialize Members

		bool beganInit = false;
		public void BeginInit()
		{
			beganInit = true;
		}

		public void EndInit()
		{
			if (beganInit)
			{
				colors = new ObservableCollection<Color>(colorSteps_XAML.Select(step => step.Color));
				FillPoints(colors.Count);
			}
		}

		#endregion
	}
}
