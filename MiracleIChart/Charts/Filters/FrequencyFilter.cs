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
    public sealed class FrequencyFilter : PointsFilterBase
    {

        /// <summary>Visible region in screen coordinates</summary>
        private Rect screenRect;

        #region IPointFilter Members

        public override void SetScreenRect(Rect screenRect)
        {
            this.screenRect = screenRect;
        }

        // todo probably use LINQ here.
        public override List<Point> Filter(List<Point> points)
        {
            if (points.Count == 0) return points;

            List<Point> resultPoints = points;

            if (points.Count > 2 * screenRect.Width)
            {
                resultPoints = new List<Point>();

                List<Point> currentChain = new List<Point>();
                double currentX = Math.Floor(points[0].X);
                foreach (Point p in points)
                {
                    if (Math.Floor(p.X) == currentX)
                    {
                        currentChain.Add(p);
                    }
                    else
                    {
                        // Analyse current chain
                        if (currentChain.Count <= 2)
                        {
                            resultPoints.AddRange(currentChain);
                        }
                        else
                        {
                            Point first = MinByX(currentChain);
                            Point last = MaxByX(currentChain);
                            Point min = MinByY(currentChain);
                            Point max = MaxByY(currentChain);
                            resultPoints.Add(first);

                            Point smaller = min.X < max.X ? min : max;
                            Point greater = min.X > max.X ? min : max;
                            if (smaller != resultPoints.GetLast())
                            {
                                resultPoints.Add(smaller);
                            }
                            if (greater != resultPoints.GetLast())
                            {
                                resultPoints.Add(greater);
                            }
                            if (last != resultPoints.GetLast())
                            {
                                resultPoints.Add(last);
                            }
                        }
                        currentChain.Clear();
                        currentChain.Add(p);
                        currentX = Math.Floor(p.X);
                    }
                }
            }

            return resultPoints;
        }

        #endregion

        private static Point MinByX(IList<Point> points)
        {
            Point minPoint = points[0];
            foreach (Point p in points)
            {
                if (p.X < minPoint.X)
                {
                    minPoint = p;
                }
            }
            return minPoint;
        }

        private static Point MaxByX(IList<Point> points)
        {
            Point maxPoint = points[0];
            foreach (Point p in points)
            {
                if (p.X > maxPoint.X)
                {
                    maxPoint = p;
                }
            }
            return maxPoint;
        }

        private static Point MinByY(IList<Point> points)
        {
            Point minPoint = points[0];
            foreach (Point p in points)
            {
                if (p.Y < minPoint.Y)
                {
                    minPoint = p;
                }
            }
            return minPoint;
        }

        private static Point MaxByY(IList<Point> points)
        {
            Point maxPoint = points[0];
            foreach (Point p in points)
            {
                if (p.Y > maxPoint.Y)
                {
                    maxPoint = p;
                }
            }
            return maxPoint;
        }
    }
}
