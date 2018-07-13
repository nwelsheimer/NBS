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
using System.Windows;

namespace Openmiracle.MiracleIChart.DataSources
{
	public interface IPointEnumerator : IDisposable {
        /// <summary>Move to next point in sequence</summary>
        /// <returns>True if successfully moved to next point 
        /// or false if end of sequence is reached</returns>
		bool MoveNext();

        /// <summary>Stores current value(s) in given point.</summary>
        /// <param name="p">Reference to store value</param>
        /// <remarks>Depending on implementing class this method may set only X or Y
        /// fiels in specified point. That's why GetCurrent is a regular method and
        /// not a property as in stardard enumerators</remarks>
		void GetCurrent(ref Point p);

		void ApplyMappings(DependencyObject target);
	}
}
