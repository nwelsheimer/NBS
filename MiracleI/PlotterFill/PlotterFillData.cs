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
using Openmiracle.MiracleIChart.Common;

namespace MiracleI.PlotterFill
{
    public class PlotterFillData : RingArray<QueryFill>
    {
        private const int TOTAL_POINTS = 1000;

        public PlotterFillData()
            : base(TOTAL_POINTS)
        {

        }
    }

    public class QueryFill
    {
        public DateTime Date { get; set; }

        public double Value { get; set; }

        public string PopUp { get; set; }

        public QueryFill(double value, DateTime date, string popUp)
        {
            this.Date = date;
            this.Value = value;
            this.PopUp = popUp;
        }
    }
}
