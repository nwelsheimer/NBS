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
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Diagnostics;
using System.Reflection;
using Openmiracle.MiracleIChart.Common.Auxiliary;

namespace Openmiracle.MiracleIChart.Charts.Navigation
{
	/// <summary>
	/// Interaction logic for AboutWindow.xaml
	/// </summary>
	internal partial class AboutWindow : Window
	{
		public AboutWindow()
		{
			InitializeComponent();

			Title = Properties.Resources.AboutTitle;
			r1.Text = Properties.Resources.About_1;
            r2.Text = Properties.Resources.About_2;
			r3.Text = Properties.Resources.About_3;
			r4.Text = Properties.Resources.About_4;
            r5.Text = Properties.Resources.About_5;
			r6.Text = Properties.Resources.About_6;
            r7.Text = Properties.Resources.About_7;
            r8.Text = Properties.Resources.About_8;
			r9.Text = Properties.Resources.About_9;
			r10.Text = Properties.Resources.About_10;
            r11.Text = Properties.Resources.About_11;
			r12.Text = Properties.Resources.About_10;
			r13.Text = Properties.Resources.About_13;
			r14.Text = Properties.Resources.About_14;
			r15.Text = Properties.Resources.About_15;
		}

		private void Hyperlink_Click(object sender, RoutedEventArgs e)
		{
			Hyperlink source = (Hyperlink)sender;
			Process.Start(source.NavigateUri.ToString());
		}

		private void Window_KeyDown(object sender, KeyEventArgs e)
		{
			// close on Esc or Enter pressed
			if (e.Key == Key.Escape || e.Key == Key.Enter)
			{
				Close();
			}
		}

		private void Hyperlink_Click_1(object sender, RoutedEventArgs e)
		{
			Hyperlink source = (Hyperlink)sender;
			Process.Start(source.NavigateUri.ToString());
		}

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
	}
}
