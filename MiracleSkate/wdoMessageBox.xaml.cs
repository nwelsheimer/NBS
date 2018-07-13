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
//along with this program. If not, see <http://www.gnu.org/licenses/>

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

namespace MiracleSkate
{
    /// <summary>
    /// Interaction logic for wdoMessageBox.xaml
    /// </summary>
    public partial class wdoMessageBox : Window
    {
        #region Function
        /// <summary>
        /// Constructor
        /// </summary>
        public wdoMessageBox(string ss)
        {
            InitializeComponent();
            txtMessage.Text = ss;
            btnOk.Focus();
        }

        #endregion


        #region Events
              /// <summary>
        /// Event for Button OK click.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                this.Close();
            }

            catch (Exception ex)
            {
                System.Windows.Application.Current.Dispatcher.Invoke((Action)(() => new wdoMessageBox("WDOMB002" + ex.ToString()).ShowDialog()));
            }


        }
        #endregion
    }
}
