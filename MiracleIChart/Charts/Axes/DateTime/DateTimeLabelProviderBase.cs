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
using Openmiracle.MiracleIChart.Charts.Axes;

namespace Openmiracle.MiracleIChart.Charts
{
	public abstract class DateTimeLabelProviderBase : LabelProviderBase<DateTime>
	{
		private string dateFormat;
		protected string DateFormat
		{
			get { return dateFormat; }
			set { dateFormat = value; }
		}

		protected override string GetStringCore(LabelTickInfo<DateTime> tickInfo)
		{
			return tickInfo.Tick.ToString(dateFormat);
		}

		protected virtual string GetDateFormat(DifferenceIn diff)
		{
			string format = null;

			switch (diff)
			{
				case DifferenceIn.Year:
					format = "yyyy";
					break;
				case DifferenceIn.Month:
					format = "MMM";
					break;
				case DifferenceIn.Day:
					format = "%d";
					break;
				case DifferenceIn.Hour:
					format = "HH:mm";
					break;
				case DifferenceIn.Minute:
					format = "%m";
					break;
				case DifferenceIn.Second:
					format = "ss";
					break;
				case DifferenceIn.Millisecond:
					format = "fff";
					break;
				default:
					break;
			}

			return format;
		}
	}
}
