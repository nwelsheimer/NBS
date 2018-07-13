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

namespace Openmiracle.MiracleIChart.ViewportRestrictions
{
	public class BorderRestriction : ViewportRestrictionBase
	{
		Rect border = new Rect(-1, -1, 200, 100);
		public override Rect Apply(Rect oldDataRect, Rect newDataRect, Viewport2D viewport)
		{
			Rect res = oldDataRect;
			if (newDataRect.IntersectsWith(border))
			{
				res = newDataRect;
				if (newDataRect.Size == oldDataRect.Size)
				{
					if (res.X < border.X) res.X = border.X;
					if (res.Y < border.Y) res.Y = border.Y;
					if (res.Right > border.Right) res.X += border.Right - res.Right;
					if (res.Bottom > border.Bottom) res.Y += border.Bottom - res.Bottom;
				}
				else
				{
					res = Rect.Intersect(newDataRect, border);
				}
			}
			return res;
		}
	}
}
