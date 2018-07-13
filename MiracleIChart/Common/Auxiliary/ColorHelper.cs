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
using System.Windows.Media;
using System.Diagnostics.CodeAnalysis;

namespace Openmiracle.MiracleIChart
{
	public static class ColorHelper
	{
		private readonly static Random random = new Random();

		/// <summary>
		/// Creates color from HSB color space with random hue and saturation and brighness equal to 1.
		/// </summary>
		/// <returns></returns>
		public static Color CreateColorWithRandomHue()
		{
			double hue = random.NextDouble() * 360;
			HsbColor hsbColor = new HsbColor(hue, 1, 1);
			return hsbColor.ToArgb();
		}

		public static Color[] CreateRandomColors(int colorNum)
		{
			double startHue = random.NextDouble() * 360;

			Color[] res = new Color[colorNum];
			double hueStep = 360.0 / colorNum;
			for (int i = 0; i < res.Length; i++)
			{
				double hue = startHue + i * hueStep;
				res[i] = new HsbColor(hue, 1, 1).ToArgb();
			}

			return res;
		}

		/// <summary>
		/// Creates color with fully random hue and slightly random saturation and brightness.
		/// </summary>
		/// <returns></returns>
		[SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Hsb")]
		public static Color CreateRandomHsbColor()
		{
			double h = random.NextDouble() * 360;
			double s = random.NextDouble() * 0.5 + 0.5;
			double b = random.NextDouble() * 0.25 + 0.75;
			return new HsbColor(h, s, b).ToArgb();
		}

		/// <summary>
		/// Gets the random color (this property is created to use it from Xaml).
		/// </summary>
		/// <value>The random color.</value>
		public static Color RandomColor
		{
			get { return CreateRandomHsbColor(); }
		}

		/// <summary>
		/// Gets the random brush.
		/// </summary>
		/// <value>The random brush.</value>
		public static SolidColorBrush RandomBrush
		{
			get { return new SolidColorBrush(CreateRandomHsbColor()); }
		}

		[SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Rgba")]
		public static int ToRgba32(this Color color)
		{
			int result =
				color.A << 24 |
				color.R << 16 |
				color.G << 8 |
				color.B;

			return result;
		}
	}
}
