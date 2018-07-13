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
using System.Collections.Generic;
using System.Windows;
using System;

namespace Openmiracle.MiracleIChart.Filters
{
    /// <summary>Provides algorithm for filtering point lists in screen coordinates</summary>
    public interface IPointsFilter
    {

        /// <summary>Performs filtering</summary>
        /// <param name="points">List of source points</param>
        /// <returns>List of filtered points</returns>
        List<Point> Filter(List<Point> points);

        /// <summary>Sets visible rectangle in screen coordinates</summary>
        /// <param name="rect">Screen rectangle</param>
        /// <remarks>Should be invoked before first call to <see cref="Filter"/></remarks>
        void SetScreenRect(Rect screenRect);

		event EventHandler Changed;
    }
}
