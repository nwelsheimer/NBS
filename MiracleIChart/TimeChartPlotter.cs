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
using Openmiracle.MiracleIChart;
using System.Windows;
using Openmiracle.MiracleIChart.Navigation;
using Openmiracle.MiracleIChart.Common;
using System.Windows.Controls;
using Openmiracle.MiracleIChart.Charts;


namespace Openmiracle.MiracleIChart
{
	public class TimeChartPlotter : ChartPlotter
	{
		public TimeChartPlotter()
		{
			HorizontalAxis = new HorizontalDateTimeAxis();
		}

		public void SetHorizontalAxisMapping(Func<double, DateTime> fromDouble, Func<DateTime, double> toDouble)
		{
			if (fromDouble == null)
				throw new ArgumentNullException("fromDouble");
			if (toDouble == null)
				throw new ArgumentNullException("toDouble");
	

			HorizontalDateTimeAxis axis = (HorizontalDateTimeAxis)HorizontalAxis;
			axis.ConvertFromDouble = fromDouble;
			axis.ConvertToDouble = toDouble;
		}

		public void SetHorizontalAxisMapping(double min, DateTime minDate, double max, DateTime maxDate) {
			HorizontalDateTimeAxis axis = (HorizontalDateTimeAxis)HorizontalAxis;
			
			axis.SetConversion(min, minDate, max, maxDate);
		}
	}
}
