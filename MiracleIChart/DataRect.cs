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

namespace Openmiracle.MiracleIChart
{
	public struct DataRect<TH, TV>
	{
		private TH x1;
		private TV y1;

		private TH x2;
		private TV y2;

		public DataRect(TH x1, TV y1, TH x2, TV y2)
		{
			this.x1 = x1;
			this.x2 = x2;
			this.y1 = y1;
			this.y2 = y2;
		}

		public TH X1 { get { return x1; } }
		public TV Y1 { get { return y1; } }
		public TH X2 { get { return x2; } }
		public TV Y2 { get { return y2; } }
	}
}
