using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Threading;
using System.Security.AccessControl;
using System.Security.Permissions;
using System.Configuration;
using System.Data.Sql;
using System.Web.Services.Protocols;
using System.Text.RegularExpressions;
using System.Data.SqlClient;

namespace Open_Miracle
{

  public partial class frmMsSqlInstallerforOpenmiracle : Form
  {
    public frmMsSqlInstallerforOpenmiracle()
    {
      try
      {
        InitializeComponent();
      }
      catch (Exception)
      {
      }
    }

    private void frmMySqlInstallerforOpenmiracle_Load(object sender, EventArgs e)
    {
      refreshServerList();
    }

    private void refreshServerList()
    {
      objTbl = Microsoft.SqlServer.Management.Smo.SmoApplication.EnumAvailableSqlServers();

      if (objTbl != null)
      {
        cmbServers1.DataSource = objTbl.DefaultView.ToTable(true, "Server");
        cmbServers1.DisplayMember = "Server";
        cmbServers1.ValueMember = "Server";
      }
    }
    
    private void ConfigureDataBase(string serverName, string userId, string password, string ApplicationPath)
    {
      try
      {
        SClass ClassS = new SClass();
        if (ClassS.CheckMsSqlConnection(serverName, userId, password, ApplicationPath))
        {

          ClassS.UpdateAppConfig("MsSqlServer", serverName);
          ClassS.UpdateAppConfig("MsSqlUserId", userId);
          ClassS.UpdateAppConfig("MsSqlPassword", password);
          ClassS.UpdateAppConfig("ApplicationPath", ApplicationPath);

          serverName = (ConfigurationManager.AppSettings["MsSqlServer"] == null || ConfigurationManager.AppSettings["MsSqlServer"].ToString() == string.Empty) ? null : ConfigurationManager.AppSettings["MsSqlServer"].ToString();
          userId = (ConfigurationManager.AppSettings["MsSqlUserId"] == null || ConfigurationManager.AppSettings["MsSqlUserId"].ToString() == string.Empty) ? null : ConfigurationManager.AppSettings["MsSqlUserId"].ToString();
          password = (ConfigurationManager.AppSettings["MsSqlPassword"] == null || ConfigurationManager.AppSettings["MsSqlPassword"].ToString() == string.Empty) ? null : ConfigurationManager.AppSettings["MsSqlPassword"].ToString();
          ApplicationPath = (ConfigurationManager.AppSettings["ApplicationPath"] == null || ConfigurationManager.AppSettings["ApplicationPath"].ToString() == string.Empty) ? null : ConfigurationManager.AppSettings["ApplicationPath"].ToString();
          if (ClassS.CheckMsSqlConnection(serverName, userId, password, ApplicationPath))
          {
            Environment.ExitCode = 100;
            this.Close();
          }
          else
          {
            Environment.ExitCode = 101;
            this.Close();
          }
        }
      }
      catch (Exception)
      {

      }
    }

    DataTable objTbl;

    private void radioButton3_CheckedChanged(object sender, EventArgs e)
    {
      if (radioButton3.Checked)
      {
        label10.Enabled = true;
        label11.Enabled = true;
        textBox1.Enabled = true;
        textBox2.Enabled = true;
      }
      else
      {
        label10.Enabled = false;
        label11.Enabled = false;
        textBox1.Enabled = false;
        textBox2.Enabled = false;
      }
      textBox1.Text = string.Empty;
      textBox2.Text = string.Empty;
    }

    private void btnOkServer_Click(object sender, EventArgs e)
    {
      cmbDatabase.DataSource = GetDatabaseList();
    }

    private List<string> GetDatabaseList()
    {
      List<string> list = new List<string>();
      string conString;
      // Open connection to the database
      if (radioButton3.Checked)
      {
        conString = "server="+cmbServers1.Text+";uid="+textBox1.Text+ ";pwd=" + textBox2.Text + "; database=northwind";
      } else
      {
        conString = "server=" + cmbServers1.Text + ";Integrated Security=True;database=master";
      }

      using (SqlConnection con = new SqlConnection(conString))
      {
        con.Open();

        // Set up a command with the given query and associate
        // this with the current connection.
        using (SqlCommand cmd = new SqlCommand("SELECT name from sys.databases", con))
        {
          using (IDataReader dr = cmd.ExecuteReader())
          {
            while (dr.Read())
            {
              list.Add(dr[0].ToString());
            }
          }
        }
      }
      return list;
    }

    private void button2_Click(object sender, EventArgs e)
    {
      if (cmbDatabase.Text != string.Empty)
      {
        if (!radioButton3.Checked)
        {
          ConfigureDataBase(cmbServers1.Text, null, null, cmbDatabase.Text);
        }
        else
        {
          ConfigureDataBase(cmbServers1.Text, textBox1.Text, textBox2.Text, cmbDatabase.Text);
        }
      }
      else
      {
        cmbDatabase.Focus();
        MessageBox.Show("Invalid database connection parameters.");
      }

    }

    private void linkLabel4_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
    {
      refreshServerList();
    }
  }
}
