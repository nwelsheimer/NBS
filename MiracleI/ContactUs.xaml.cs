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
using System.Net.Mail;
using Microsoft.Win32;
using System.ComponentModel;
using System.Threading;
using System.Net;

namespace MiracleI
{
    /// <summary>
    /// Interaction logic for ContactUs.xaml
    /// </summary>
    public partial class ContactUs : Window
    {
        public ContactUs()
        {
            InitializeComponent();
        }
        #region Variables
        //  ProgressBarWindow frmLodingObj = new ProgressBarWindow();
        bool isCheck = false;
        int inBodyCount = 0;
        #endregion
        #region Functions

        public void clear()
        {
            try
            {
                txtMailId.Focus();
                txtMailId.Text = string.Empty;
                txtSubjest.Text = string.Empty;
                txtBody.Text = string.Empty;
                lstbxAttach.Items.Clear();
                inBodyCount = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("SM" + ex.Message, "OpenMiracle", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        public bool ValidateEmail()
        {
            bool result = true;
            try
            {
                if (txtMailId.Text.Trim() != string.Empty)
                {
                    System.Text.RegularExpressions.Regex rEMail = new System.Text.RegularExpressions.Regex(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*");//^[a-zA-Z][\w\.-]{2,28}[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$
                    if (txtMailId.Text.Length > 0)
                    {
                        if (!rEMail.IsMatch(txtMailId.Text))
                        {
                            MessageBox.Show("Invalid Email", "Pharmasoft", MessageBoxButton.OK, MessageBoxImage.Information);
                            result = false;
                            txtMailId.Focus();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("SM" + ex.Message, "OpenMiracle", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            return result;
        }

       
        private void SendMessage()
        {
            try
            {
                MailMessage oMessage = new MailMessage();
                SmtpClient smtpClient = new SmtpClient("smtp.gmail.com");

                oMessage.From = new MailAddress("");
                oMessage.To.Add("");
                this.Dispatcher.Invoke(
          new Action(
          () =>
          {
              oMessage.Subject = txtMailId.Text.Trim() + "--" + txtSubjest.Text.Trim();
              oMessage.Body = txtBody.Text;
              oMessage.IsBodyHtml = false;
          }));
                int SendUsing = 0;
                int AuthenticationMode = 1;
                switch (SendUsing)
                {
                    case 0:
                        smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                        break;
                    case 1:
                        smtpClient.DeliveryMethod = SmtpDeliveryMethod.PickupDirectoryFromIis;
                        break;
                    case 2:
                        smtpClient.DeliveryMethod = SmtpDeliveryMethod.SpecifiedPickupDirectory;
                        break;
                    default:
                        smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                        break;

                }
                if (AuthenticationMode > 0)
                {
                    smtpClient.Credentials = new NetworkCredential("", "");
                }

                smtpClient.Port = 25;
                smtpClient.EnableSsl = true;

                // Create and add the attachment

                foreach (string strPath in lstbxAttach.Items)
                {
                    oMessage.Attachments.Add(new Attachment(strPath));
                }



                try
                {
                    // Deliver the message 
                    smtpClient.Send(oMessage);

                }

                catch (Exception ex)
                {
                    ex.ToString();

                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            this.Dispatcher.Invoke(
          new Action(
          () =>
          {
              this.Cursor = Cursors.Arrow;
              isCheck = true;
              grid1.IsEnabled = true;
              grid2.Visibility = System.Windows.Visibility.Hidden;
              clear();
          }));
        }




        public void SendMail()
        {
            try
            {
                if (ValidateEmail())
                {

                    if (txtSubjest.Text == string.Empty)
                    {
                        if (MessageBox.Show("Send this message without a subject ?", "OpenMiracle", MessageBoxButton.OKCancel, MessageBoxImage.Information) == MessageBoxResult.OK)
                        {
                            if (txtBody.Text == string.Empty)
                            {
                                if (MessageBox.Show("Send this message without text in the body ?", "OpenMiracle", MessageBoxButton.OKCancel, MessageBoxImage.Information) == MessageBoxResult.OK)
                                {
                                    new Thread(new ThreadStart(SendMessage)).Start();
                                    grid1.IsEnabled = false;
                                    grid2.Visibility = System.Windows.Visibility.Visible;
                                }
                                else
                                {
                                    txtBody.Focus();
                                }
                            }
                            else
                            {
                                new Thread(new ThreadStart(SendMessage)).Start();
                                grid1.IsEnabled = false;
                                grid2.Visibility = System.Windows.Visibility.Visible;
                            }
                        }
                        else
                        {
                            txtSubjest.Focus();
                        }
                    }
                    else
                    {
                        if (txtBody.Text == string.Empty)
                        {
                            if (MessageBox.Show("Send this message without text in the body ?", "OpenMiracle", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                            {
                                new Thread(new ThreadStart(SendMessage)).Start();
                                grid1.IsEnabled = false;
                                grid2.Visibility = System.Windows.Visibility.Visible;
                            }
                            else
                            {
                                txtBody.Focus();
                            }
                        }
                        else
                        {
                            new Thread(new ThreadStart(SendMessage)).Start();
                            grid1.IsEnabled = false;
                            grid2.Visibility = System.Windows.Visibility.Visible;
                        }
                    }
                }
                if (isCheck)
                {
                    clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("SM" + ex.Message, "OpenMiracle", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
        #endregion

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnSend_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txtMailId.Text == string.Empty)
                {
                    MessageBox.Show("Enter your Email id to send mail", "OpenMiracle", MessageBoxButton.YesNo, MessageBoxImage.Information);
                    txtMailId.Focus();
                }
                else
                {
                    SendMail();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("SM" + ex.Message, "OpenMiracle", MessageBoxButton.OK, MessageBoxImage.Information);
            }

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("SM" + ex.Message, "OpenMiracle", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void btnBrowse_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                OpenFileDialog folderB = new OpenFileDialog();
                folderB.ShowDialog();
                if (folderB.FileName.ToString() != string.Empty)
                {
                    lstbxAttach.Items.Add(folderB.FileName.ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("SM" + ex.Message, "OpenMiracle", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("SM" + ex.Message, "OpenMiracle", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
       
        private void txtMailId_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.Key == Key.Enter)
                {
                    txtSubjest.Focus();
                    txtSubjest.SelectionStart = 0;
                    txtSubjest.SelectionLength = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("SM" + ex.Message, "OpenMiracle", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void txtSubjest_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.Key == Key.Enter)
                {
                    txtBody.Focus();
                }
                else if (e.Key == Key.Back)
                {
                    if (txtSubjest.Text.Trim() == string.Empty || txtSubjest.SelectionStart == 0)
                    {
                        txtMailId.SelectionStart = 0;
                        txtMailId.SelectionLength = 0;
                        txtMailId.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("SM" + ex.Message, "OpenMiracle", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void txtBody_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.Key == Key.Enter)
                {
                    inBodyCount++;
                    if (inBodyCount == 3)
                    {
                        inBodyCount = 0;
                        btnSend.Focus();
                    }
                }
                else
                {
                    inBodyCount = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("SM" + ex.Message, "OpenMiracle", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

       
    }
}
