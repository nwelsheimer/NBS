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
using MiracleI.BLL;
using System.Threading;

namespace Openmiracle.MiracleIChart
{
    /// <summary>
    /// Interaction logic for MiracleIViewDetails.xaml
    /// </summary>
    public partial class MiracleIViewDetails : Window
    {
        public MiracleIViewDetails()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Thread t = new Thread(new ThreadStart(FunctionViewDetail));
            t.Start();
        }
        public void FunctionViewDetail()
        {
            dataGrid1.Dispatcher.Invoke(
          new Action(
           () =>
           {
               CallSP SPCall = new CallSP();
               dataGrid1.ItemsSource = SPCall.GetViewDetailsFill()[0].DefaultView;
           }));
        }

        private void dataGrid1_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            lblLoading.Visibility = System.Windows.Visibility.Hidden;
        }

        private void Window_Deactivated(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
