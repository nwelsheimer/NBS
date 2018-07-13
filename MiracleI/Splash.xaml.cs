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
using System.Threading;
using System.ComponentModel;
using Entity;
using MiracleI.BLL;
using System.Diagnostics;
using System.Data;

namespace MiracleI
{
    /// <summary>
    /// Interaction logic for Splash.xaml
    /// </summary>
    public partial class Splash : Window
    {
        private readonly BackgroundWorker worker = new BackgroundWorker();
        public Splash()
        {
            InitializeComponent();
            grdLogIn.Visibility = System.Windows.Visibility.Hidden;
            worker.DoWork += worker_DoWork;
            worker.RunWorkerCompleted += worker_RunWorkerCompleted;
            worker.RunWorkerAsync();

        }
        DataTable dtbl = new DataTable();
        public void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            Thread.Sleep(2000);
            ConnectionString.IsConnectionTrue = false;
            ConnectionString.Connection = Environment.CurrentDirectory + @"\Data\DBOpenMiracle.mdf";
            CallSP objCallSp = new CallSP();
            if (objCallSp.GetCompanyName().Count > 0)
            {
                dtbl = objCallSp.GetCompanyName()[0];
            }
            else
            {
                string fullpath = string.Empty;
                List<Process> taskBarProcesses = Process.GetProcesses().Where(p => !string.IsNullOrEmpty(p.MainWindowTitle)).ToList();
                foreach (Process proc in taskBarProcesses)
                {
                    if (proc.ProcessName.ToLower() == "open miracle")
                    {
                        fullpath = proc.MainModule.FileName;
                        fullpath = fullpath.Remove(fullpath.Length - 16);
                        ConnectionString.Connection = fullpath + @"Data\DBOpenMiracle.mdf";
                        break;
                    }
                }
                if (objCallSp.GetCompanyName().Count > 0)
                {
                    dtbl = objCallSp.GetCompanyName()[0];
                }
            }
        }

        public void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (dtbl != null && dtbl.Rows.Count > 0)
            {
                grdSplash.Visibility = System.Windows.Visibility.Hidden;
                grdLogIn.Visibility = System.Windows.Visibility.Visible;
            }
            else
            {
                label1.Content = "Sorry, Cannot access database!.";
                label1.Foreground = Brushes.DarkKhaki;
            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            if (objCallSp.GetLoginCheck(txtUseName.Text, txtPassword.Password))
            {
                MainWindow objMainWindow = new MainWindow();
                this.Close();
                objMainWindow.Show();
            }
            else
            {
                label4.Visibility = System.Windows.Visibility.Visible;
                txtUseName.Text = "";
                txtPassword.Password = "";
                txtUseName.Focus();
            }

        }


        private void CompanyPickPopUp_Opened(object sender, EventArgs e)
        {
            button1.Visibility = System.Windows.Visibility.Hidden;
        }

        private void CompanyPickPopUp_Closed(object sender, EventArgs e)
        {
            button1.Visibility = System.Windows.Visibility.Visible;
        }

        CallSP objCallSp = new CallSP();

        private void txtUseName_KeyUp(object sender, KeyEventArgs e)
        {
            label4.Visibility = System.Windows.Visibility.Hidden;
        }

        private void txtPassword_KeyUp(object sender, KeyEventArgs e)
        {
            label4.Visibility = System.Windows.Visibility.Hidden;
        }

        private void button_MouseEnter(object sender, MouseEventArgs e)
        {
            (sender as Button).Foreground = Brushes.Black;
        }

        private void button_MouseLeave(object sender, MouseEventArgs e)
        {
            (sender as Button).Foreground = Brushes.White;
        }
    }
}
