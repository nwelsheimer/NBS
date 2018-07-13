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
using System.Windows.Controls;
using System.Windows.Shapes;
using System.Windows.Media;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Data;
using MiracleI.BLL;
using Entity;
using System.Threading;

namespace Openmiracle.MiracleIChart.PointMarkers
{
    /// <summary>Adds Circle element at every point of graph</summary>
    public class CircleElementPointMarker : ShapeElementPointMarker
    {

        public override UIElement CreateMarker()
        {
            Ellipse result = new Ellipse();
            result.Width = Size;
            result.Height = Size;
            result.Stroke = Brush;
            result.Fill = Fill;
            result.MouseEnter += new System.Windows.Input.MouseEventHandler(result_MouseEnter);
            result.MouseLeave += new System.Windows.Input.MouseEventHandler(result_MouseLeave);
            if (!String.IsNullOrEmpty(ToolTipText))
            {
                ToolTip tt = new ToolTip();
                tt.Content = ToolTipText;
                tt.Visibility = Visibility.Hidden;
                result.ToolTip = tt;
            }
            return result;
        }

        void result_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (!PopupBox.IsMouseOver)
            {
                PopupBox.IsOpen = false;
            }
        }
        Popup PopupBox = new Popup();
        BrushConverter conv = new BrushConverter();
        void result_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            PopupBox.IsOpen = false;
            ToolTip tt = (ToolTip)(sender as Ellipse).ToolTip;
            if (tt.Content.ToString().Split('\n').Length > 3)
            {
                TextBox PopupText = new TextBox();
                PopupText.IsReadOnly = true;
                PopupText.Text = tt.Content.ToString();
                PopupText.MaxHeight = 200;
                PopupText.Foreground = conv.ConvertFromString("#FF343434") as SolidColorBrush;
                PopupText.Background = conv.ConvertFromString("#FFbebebe") as SolidColorBrush;
                PopupText.BorderThickness = new Thickness(0);
                PopupText.Padding = new Thickness(6);
                PopupText.FontSize = 11;
                PopupText.VerticalScrollBarVisibility = ScrollBarVisibility.Auto;
                PopupBox.Placement = System.Windows.Controls.Primitives.PlacementMode.MousePoint;
                PopupBox.PopupAnimation = System.Windows.Controls.Primitives.PopupAnimation.None;
                PopupBox.AllowsTransparency = true;
                PopupBox.IsOpen = true;
                PopupBox.StaysOpen = true;
                PopupBox.MouseLeave += new System.Windows.Input.MouseEventHandler(PopupBox_MouseLeave);
                Button ViewDetails = new Button();
                ViewDetails.Content = "View Details";
                ViewDetails.Padding = new Thickness(0, 0, 0, 3);
                ViewDetails.Foreground = conv.ConvertFromString("#FF3078B4") as SolidColorBrush;
                ViewDetails.Cursor = Cursors.Hand;
                ViewDetails.ToolTip = "Click";
                ViewDetails.BorderThickness = new Thickness(0, 1, 0, 0);
                ViewDetails.Click += new RoutedEventHandler(ViewDetails_Click);
                StackPanel stkPnl = new StackPanel();
                stkPnl.Children.Add(PopupText);
                stkPnl.Children.Add(ViewDetails);
                PopupBox.Child = stkPnl;

            }
        }
        void ViewDetails_Click(object sender, RoutedEventArgs e)
        {
            PopupBox.IsOpen = false;
            string[] str = null;
            StackPanel stk = (StackPanel)(((Control)sender).Parent);
            foreach (TextBox st in stk.Children)
            {
                str = st.Text.Split('\n');
                break;
            }
            ViewDetailsInfo.CheckValue = str[0].ToString().TrimEnd();
            ViewDetailsInfo.SubCatagory = (str[1].ToString().TrimEnd() != string.Empty) ? str[1].ToString().TrimEnd() : ViewDetailsInfo.SubCatagory;
            ViewDetailsInfo.OnDate = Convert.ToDateTime(str[2]);
            objViewDetails = new MiracleIViewDetails();
            objViewDetails.ShowDialog();
        }
        MiracleIViewDetails objViewDetails;
              
        void PopupBox_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            PopupBox.IsOpen = false;
        }

        public override void SetPosition(UIElement marker, Point screenPoint)
        {
            Canvas.SetLeft(marker, screenPoint.X - Size / 2);
            Canvas.SetTop(marker, screenPoint.Y - Size / 2);
        }
    }
}
