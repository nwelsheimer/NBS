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
using System.Windows;
using Openmiracle.MiracleIChart.Charts.Filters;

namespace Openmiracle.MiracleIChart.Filters
{
    public sealed class InclinationFilter : PointsFilterBase
    {
        private double criticalAngle = 178;
        public double CriticalAngle
        {
            get { return criticalAngle; }
            set { criticalAngle = value; }
        }

        #region IPointFilter Members

        public override List<Point> Filter(List<Point> points)
        {
            if (points.Count == 0)
                return points;

            List<Point> res = new List<Point> { points[0] };

            int i = 1;
            while (i < points.Count)
            {
                bool added = false;
                int j = i;
                while (!added && (j < points.Count - 1))
                {
                    Point x1 = res[res.Count - 1];
                    Point x2 = points[j];
                    Point x3 = points[j + 1];

                    double a = (x1 - x2).Length;
                    double b = (x2 - x3).Length;
                    double c = (x1 - x3).Length;

                    double angle13 = Math.Acos((a * a + b * b - c * c) / (2 * a * b));
                    double degrees = 180 / Math.PI * angle13;
                    if (degrees < criticalAngle)
                    {
                        res.Add(x2);
                        added = true;
                        i = j + 1;
                    }
                    else
                    {
                        j++;
                    }
                }
                // reached the end of resultPoints
                if (!added)
                {
                    res.Add(points.GetLast());
                    break;
                }
            }
            return res;
        }

        #endregion
    }
}
