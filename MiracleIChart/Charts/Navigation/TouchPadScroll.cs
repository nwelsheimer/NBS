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
using System.Windows.Input;
using System.Windows.Interop;


namespace Openmiracle.MiracleIChart.Navigation
{
    /// <summary>This class allows convenient navigation around viewport using touchpad on
    /// some notebooks</summary>
	public sealed class TouchpadScroll : NavigationBase {
		public TouchpadScroll() {
			Loaded += OnLoaded;
		}

		private void OnLoaded(object sender, RoutedEventArgs e) {
			WindowInteropHelper helper = new WindowInteropHelper(Window.GetWindow(this));
			HwndSource source = HwndSource.FromHwnd(helper.Handle);
			source.AddHook(OnMessageAppeared);
		}

		private IntPtr OnMessageAppeared(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled) {
			if (msg == WindowsMessages.WM_MOUSEWHEEL) {
				Point mousePos = MessagesHelper.GetMousePosFromLParam(lParam);
				mousePos = TranslatePoint(mousePos, this);

				if (Viewport.Output.Contains(mousePos)) {
					MouseWheelZoom(MessagesHelper.GetMousePosFromLParam(lParam), MessagesHelper.GetWheelDataFromWParam(wParam));
					handled = true;
				}
			}
			return IntPtr.Zero;
		}

		double wheelZoomSpeed = 1.2;
		public double WheelZoomSpeed {
			get { return wheelZoomSpeed; }
			set { wheelZoomSpeed = value; }
		}

		private void MouseWheelZoom(Point mousePos, int wheelRotationDelta) {
			Point zoomTo = mousePos.ScreenToData(Viewport.Transform);

			double zoomSpeed = Math.Abs(wheelRotationDelta / Mouse.MouseWheelDeltaForOneLine);
			zoomSpeed *= wheelZoomSpeed;
			if (wheelRotationDelta < 0) {
				zoomSpeed = 1 / zoomSpeed;
			}
			Viewport.Visible = Viewport.Visible.Zoom(zoomTo, zoomSpeed);
		}
	}
}
