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

namespace Openmiracle.MiracleIChart
{
	public static class CoordinateUtilities
	{
		public static Rect RectZoom(Rect rect, double ratio)
		{
			return RectZoom(rect, rect.GetCenter(), ratio);
		}

		public static Rect RectZoom(Rect rect, double horizontalRatio, double verticalRatio)
		{
			return RectZoom(rect, rect.GetCenter(), horizontalRatio, verticalRatio);
		}

		public static Rect RectZoom(Rect rect, Point zoomCenter, double ratio)
		{
			return RectZoom(rect, zoomCenter, ratio, ratio);
		}

		public static Rect RectZoom(Rect rect, Point zoomCenter, double horizontalRatio, double verticalRatio)
		{
			Rect res = new Rect();
			res.X = zoomCenter.X - (zoomCenter.X - rect.X) * horizontalRatio;
			res.Y = zoomCenter.Y - (zoomCenter.Y - rect.Y) * verticalRatio;
			res.Width = rect.Width * horizontalRatio;
			res.Height = rect.Height * verticalRatio;
			return res;
		}

		public static Rect RectZoomX(Rect rect, Point zoomCenter, double ratio)
		{
			Rect res = rect;
			res.X = zoomCenter.X - (zoomCenter.X - rect.X) * ratio;
			res.Width = rect.Width * ratio;
			return res;
		}

		public static Rect RectZoomY(Rect rect, Point zoomCenter, double ratio)
		{
			Rect res = rect;
			res.Y = zoomCenter.Y - (zoomCenter.Y - rect.Y) * ratio;
			res.Height = rect.Height * ratio;
			return res;
		}
	}
}
