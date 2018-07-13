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

namespace Openmiracle.MiracleIChart.Navigation
{
    /// <summary>Helper class to parse Windows messages</summary>
	internal static class MessagesHelper {
		internal static int GetXFromLParam(IntPtr lParam) {
			return LOWORD(lParam.ToInt32());
		}

		internal static int GetYFromLParam(IntPtr lParam) {
			return HIWORD(lParam.ToInt32());
		}

		internal static Point GetMousePosFromLParam(IntPtr lParam) {
			return new Point(GetXFromLParam(lParam), GetYFromLParam(lParam));
		}

		internal static int GetWheelDataFromWParam(IntPtr wParam) {
			return HIWORD(wParam.ToInt32());
		}

		internal static short HIWORD(int i) {
			return (short)((i & 0xFFFF0000) >> 16);
		}

		internal static short LOWORD(int i) {
			return (short)(i & 0x0000FFFF);
		}
	}
}
