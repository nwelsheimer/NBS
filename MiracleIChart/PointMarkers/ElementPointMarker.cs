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

using System.Windows;

namespace Openmiracle.MiracleIChart.PointMarkers
{
	/// <summary>Provides elements that represent markers along the graph</summary>
	public abstract class ElementPointMarker : DependencyObject {

        /// <summary>Creates marker element at specified point</summary>
        /// <returns>UIElement representing marker</returns>
        public abstract UIElement CreateMarker();

        /// <summary>Moves specified marker so its center is located at specified screen point</summary>
        /// <param name="marker">UIElement created using CreateMarker</param>
        /// <param name="screenPoint">Point to center element around</param>
        public abstract void SetPosition(UIElement marker, Point screenPoint);
	}
}
