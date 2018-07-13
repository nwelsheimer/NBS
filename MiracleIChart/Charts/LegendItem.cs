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

using System.Windows.Controls;

namespace Openmiracle.MiracleIChart
{
	/// <summary>
	/// <see cref="LegendItem"/> is a base class for item in legend, that represents some chart. 
	/// </summary>
    public abstract class LegendItem : ContentControl
    {
		/// <summary>
		/// Initializes a new instance of the <see cref="LegendItem"/> class.
		/// </summary>
        protected LegendItem() { }

		/// <summary>
		/// Initializes a new instance of the <see cref="LegendItem"/> class.
		/// </summary>
		/// <param name="description">The description.</param>
        protected LegendItem(Description description)
        {
            Description = description;
        }

        private Description description;
		/// <summary>
		/// Gets or sets the description.
		/// </summary>
		/// <value>The description.</value>
        public Description Description
        {
            get { return description; }
            set
            {
                description = value;
                Content = description;
            }
        }
    }
}
