﻿//This is a source code or part of OpenMiracle project
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

namespace Openmiracle.MiracleIChart
{
    public class StandardDescription : Description
    {
        public StandardDescription() { }
        public StandardDescription(string description)
        {
            if (String.IsNullOrEmpty(description))
                throw new ArgumentNullException("description");

            this.description = description;
        }

        protected override void AttachCore(UIElement element)
        {
            if (description == null)
            {
                string str = element.GetType().Name;
                description = str;
            }
        }

		private string description;
		public string DescriptionString {
			get { return description; }
			set { description = value; }
		}

        public sealed override string Brief
        {
            get { return description; }
        }

        public sealed override string Full
        {
            get { return description; }
        }
    }
}
