//This is a source code or part of Openmiracle project
//Copyright (C) 2013  Openmiracle
//This program is free software: you can redistribute it and/or modify
//it under the terms of the GNU General Public License as published by
//the Free Software Foundation, either version 3 of the License, or
//(at your option) any later version.
//This program is distributed in the hope that it will be useful,
//but WITHOUT ANY WARRANTY; without even the implied warranty of
//MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//GNU General Public License for more details.
//You should have received a copy of the GNU General Public License
//along with this program.  If not, see <http://www.gnu.org/licenses/>.
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
namespace Open_Miracle
{
  public partial class frmSites : Form
  {
    #region Public Variables
    /// <summary>
    /// Public variable declaration part
    /// </summary>
    decimal decSiteId;
    decimal decIdForOtherForms;
    string strSiteName;
    int inNarrationCount = 0;
    int q = 0;
    public frmProductCreation frmProductCreationObj;
    public frmMultipleProductCreation frmMultipleProductCreationObj;
    #endregion
    #region Functions
    /// <summary>
    /// Creates an instance of frmGodown class
    /// </summary>
    public frmSites()
    {
      InitializeComponent();
    }
    /// <summary>
    /// Function to save
    /// </summary>
    public void SaveFunction()
    {
      try
      {
        SiteInfo infoSite = new SiteInfo();
        SiteSP spSite = new SiteSP();
        infoSite.SiteName = txtSiteName.Text.Trim();
        infoSite.Address = txtAddress.Text.Trim();
        infoSite.managed = chkManaged.Checked;
        infoSite.dflt = chkDflt.Checked;
        if (spSite.SiteCheckIfExist(txtSiteName.Text.Trim(), 0) == false)
        {
          decIdForOtherForms = spSite.SiteAddWithoutSameName(infoSite);
          if (decIdForOtherForms > 0)
          {
            Messages.SavedMessage();
            Clear();
          }
        }
        else
        {
          Messages.InformationMessage("Site name already exist");
          txtSiteName.Focus();
        }
      }
      catch (Exception ex)
      {
        formMDI.infoError.ErrorString = "G4:" + ex.Message;
      }
    }
    /// <summary>
    /// Function to Edit
    /// </summary>
    public void EditFunction()
    {
      try
      {
        SiteInfo infoSites = new SiteInfo();
        SiteSP spSites = new SiteSP();
        infoSites.SiteName = txtSiteName.Text.Trim();
        infoSites.Address = txtAddress.Text.Trim();
        infoSites.managed = chkManaged.Checked;
        infoSites.dflt = chkDflt.Checked;
        infoSites.SiteId = Convert.ToDecimal(dgvSites.CurrentRow.Cells["dgvtxtSiteId"].Value.ToString());
        if (txtSiteName.Text != strSiteName)
        {
          if (spSites.SiteCheckIfExist(txtSiteName.Text.Trim(), infoSites.SiteId) == false)
          {
            if (spSites.SiteEditParticularField(infoSites))
            {
              Messages.UpdatedMessage();
              Clear();
            }
          }
          else
          {
            Messages.InformationMessage("Site name already exist");
            txtSiteName.Focus();
          }
        }
        else
        {
          spSites.SiteEditParticularField(infoSites);
          Messages.UpdatedMessage();
          Clear();
        }
      }
      catch (Exception ex)
      {
        formMDI.infoError.ErrorString = "G5:" + ex.Message;
      }
    }
    /// <summary>
    /// Function to call save
    /// </summary>
    public void SaveOrEdit()
    {
      try
      {
        if (txtSiteName.Text.Trim() == string.Empty)
        {
          Messages.InformationMessage("Enter site name");
          txtSiteName.Focus();
        }
        else
        {
          if (btnSave.Text == "Save")
          {
            if (PublicVariables.isMessageAdd)
            {
              if (Messages.SaveMessage())
              {
                SaveFunction();
              }
            }
            else
            {
              SaveFunction();
            }
            if (frmProductCreationObj != null)
            {
              this.Close();
            }
            if (frmMultipleProductCreationObj != null)
            {
              this.Close();
            }
          }
          else
          {
            if (PublicVariables.isMessageEdit)
            {
              if (Messages.UpdateMessage())
              {
                EditFunction();
              }
            }
            else
            {
              EditFunction();
            }
          }
        }
      }
      catch (Exception ex)
      {
        formMDI.infoError.ErrorString = "G6:" + ex.Message;
      }
    }
    /// <summary>
    /// Function to fill datagridview
    /// </summary>
    public void Gridfill()
    {
      try
      {
        DataTable tblSites = new DataTable();
        SiteSP spSites = new SiteSP();
        tblSites = spSites.SiteOnlyViewAll();
        dgvSites.DataSource = tblSites;
      }
      catch (Exception ex)
      {
        formMDI.infoError.ErrorString = "G7:" + ex.Message;
      }
    }
    /// <summary>
    /// Function to delete
    /// </summary>
    public void DeleteFunction()
    {
      try
      {
        SiteSP spSite = new SiteSP();
        if (spSite.SiteCheckReferenceAndDelete(decSiteId) <= 0)
        {
          Messages.ReferenceExistsMessage();
        }
        else
        {
          // spGodown.GodownDelete(Convert.ToDecimal(dgvGodown.CurrentRow.Cells[1].Value.ToString()));
          //spGodown.GodownDelete(Convert.ToDecimal(dgvGodown.CurrentRow.Cells["dgvtxtGodownId"].Value.ToString()));
          Clear();
          btnSave.Text = "Save";
          Messages.DeletedMessage();
        }
      }
      catch (Exception ex)
      {
        formMDI.infoError.ErrorString = "G8:" + ex.Message;
      }
    }
    /// <summary>
    /// Function to call delete
    /// </summary>
    public void Delete()
    {
      try
      {
        if (PublicVariables.isMessageDelete)
        {
          if (Messages.DeleteMessage())
          {
            DeleteFunction();
          }
        }
        else
        {
          DeleteFunction();
        }
      }
      catch (Exception ex)
      {
        formMDI.infoError.ErrorString = "G9:" + ex.Message;
      }
    }
    /// <summary>
    /// Function to clear
    /// </summary>
    public void Clear()
    {
      try
      {
        txtSiteName.Text = string.Empty;
        txtAddress.Text = string.Empty;
        txtSiteName.Focus();
        chkDflt.Checked = false;
        chkManaged.Checked = false;
        btnSave.Text = "Save";
        btnDelete.Enabled = false;
        Gridfill();
      }
      catch (Exception ex)
      {
        formMDI.infoError.ErrorString = "G10:" + ex.Message;
      }
    }
    /// <summary>
    /// Function to fill controls for update
    /// </summary>
    public void FillControls()
    {
      try
      {
        SiteInfo infoSites = new SiteInfo();
        SiteSP spSites = new SiteSP();
        infoSites = spSites.SiteWithNarrationView(Convert.ToDecimal(dgvSites.CurrentRow.Cells[1].Value.ToString()));
        txtSiteName.Text = infoSites.SiteName;
        txtAddress.Text = infoSites.Address;
        btnSave.Text = "Update";
        btnDelete.Enabled = true;
        decSiteId = infoSites.SiteId;
        strSiteName = infoSites.SiteName;
        chkManaged.Checked = infoSites.managed;
        chkDflt.Checked = infoSites.dflt;
      }
      catch (Exception ex)
      {
        formMDI.infoError.ErrorString = "G11:" + ex.Message;
      }
    }
    #endregion
    #region Events
    /// <summary>
    /// on form close
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void btnFrmClose_Click(object sender, EventArgs e)
    {
      try
      {
        btnClose_Click(sender, e);
      }
      catch (Exception ex)
      {
        formMDI.infoError.ErrorString = "G12:" + ex.Message;
      }
    }
    /// <summary>
    /// On 'Save' button click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void btnSave_Click(object sender, EventArgs e)
    {
      try
      {
        if (CheckUserPrivilege.PrivilegeCheck(PublicVariables._decCurrentUserId, this.Name, btnSave.Text))
        {
          SaveOrEdit();
        }
        else
        {
          Messages.NoPrivillageMessage();
        }
      }
      catch (Exception ex)
      {
        formMDI.infoError.ErrorString = "G13:" + ex.Message;
      }
    }
    /// <summary>
    /// Load
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void frmGodown_Load(object sender, EventArgs e)
    {
      try
      {
        Clear();
      }
      catch (Exception ex)
      {
        formMDI.infoError.ErrorString = "G14:" + ex.Message;
      }
    }
    /// <summary>
    /// On 'Clear' button click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void btnClear_Click(object sender, EventArgs e)
    {
      try
      {
        Clear();
      }
      catch (Exception ex)
      {
        formMDI.infoError.ErrorString = "G15:" + ex.Message;
      }
    }
    /// <summary>
    /// On 'Delete' button click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void btnDelete_Click(object sender, EventArgs e)
    {
      try
      {
        if (CheckUserPrivilege.PrivilegeCheck(PublicVariables._decCurrentUserId, this.Name, "Delete"))
        {
          Delete();
        }
        else
        {
          Messages.NoPrivillageMessage();
        }
      }
      catch (Exception ex)
      {
        formMDI.infoError.ErrorString = "G16:" + ex.Message;
      }
    }
    /// <summary>
    /// On 'Close' button click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void btnClose_Click(object sender, EventArgs e)
    {
      try
      {
        if (PublicVariables.isMessageClose)
        {
          Messages.CloseMessage(this);
        }
        else
        {
          this.Close();
        }
      }
      catch (Exception ex)
      {
        formMDI.infoError.ErrorString = "G17:" + ex.Message;
      }
    }
    /// <summary>
    /// On datagridview cell doubleclick
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void dgvGodown_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
    {
      try
      {
        if (e.RowIndex != -1)
        {
          string strBatchName = dgvSites.CurrentRow.Cells["dgvtxtSiteName"].Value.ToString();
          if (strBatchName != "NA")
          {
            FillControls();
            txtSiteName.Focus();
          }
          else
          {
            Messages.WarningMessage("NA Site cannot update or delete");
            Clear();
          }
        }
      }
      catch (Exception ex)
      {
        formMDI.infoError.ErrorString = "G18:" + ex.Message;
      }
    }
    /// <summary>
    /// Clears selection on datagridview databinding complete
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void dgvGodown_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
    {
      try
      {
        dgvSites.ClearSelection();
      }
      catch (Exception ex)
      {
        formMDI.infoError.ErrorString = "G19:" + ex.Message;
      }
    }
    /// <summary>
    /// On form closing
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void frmGodown_FormClosing(object sender, FormClosingEventArgs e)
    {
      try
      {
        if (frmProductCreationObj != null)
        {
          frmProductCreationObj.ReturnFromGodownForm(decIdForOtherForms);
          dgvSites.Enabled = true;
          frmProductCreationObj.Enabled = true;
        }
        if (frmMultipleProductCreationObj != null)//Coded by shihab
        {
          frmMultipleProductCreationObj.ReturnFromGodownForm(decIdForOtherForms);
        }
      }
      catch (Exception ex)
      {
        formMDI.infoError.ErrorString = "G20:" + ex.Message;
      }
    }
    #endregion
    #region Navigation
    /// <summary>
    /// On 'Narratrion' textbox keypress 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void txtNarration_KeyPress(object sender, KeyPressEventArgs e)
    {
      try
      {
        if (e.KeyChar == 13)
        {
          inNarrationCount++;
          if (inNarrationCount == 2)
          {
            inNarrationCount = 0;
            btnSave.Focus();
          }
        }
        else
        {
          inNarrationCount = 0;
        }
      }
      catch (Exception ex)
      {
        formMDI.infoError.ErrorString = "G21:" + ex.Message;
      }
    }
    /// <summary>
    /// On 'Narratrion' textbox key enter
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void txtNarration_Enter(object sender, EventArgs e)
    {
      try
      {
        inNarrationCount = 0;
        txtAddress.Text = txtAddress.Text.Trim();
        if (txtAddress.Text == string.Empty)
        {
          txtAddress.SelectionStart = 0;
          txtAddress.SelectionLength = 0;
          txtAddress.Focus();
        }
        else
        {
          txtAddress.SelectionStart = txtAddress.Text.Length;
          txtAddress.Focus();
        }
      }
      catch (Exception ex)
      {
        formMDI.infoError.ErrorString = "G22:" + ex.Message;
      }
    }
    /// <summary>
    /// On 'GodownName' textbox keydown
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void txtGodownName_KeyDown(object sender, KeyEventArgs e)
    {
      try
      {
        if (e.KeyCode == Keys.Enter)
        {
          txtAddress.Focus();
          txtAddress.SelectionStart = txtAddress.TextLength;
        }
      }
      catch (Exception ex)
      {
        formMDI.infoError.ErrorString = "G23:" + ex.Message;
      }
    }
    /// <summary>
    /// On 'Narratrion' textbox keydown
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void txtNarration_KeyDown(object sender, KeyEventArgs e)
    {
      try
      {
        if (e.KeyCode == Keys.Back)
        {
          if (txtAddress.Text == string.Empty || txtAddress.SelectionStart == 0)
          {
            txtSiteName.Focus();
            txtSiteName.SelectionLength = 0;
            txtSiteName.SelectionStart = 0;
          }
        }
      }
      catch (Exception ex)
      {
        formMDI.infoError.ErrorString = "G24:" + ex.Message;
      }
    }
    /// <summary>
    /// On 'Save' textbox keypress 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void btnSave_KeyDown(object sender, KeyEventArgs e)
    {
      try
      {
        if (e.KeyCode == Keys.Back)
        {
          txtAddress.Focus();
          txtAddress.SelectionStart = 0;
          txtAddress.SelectionLength = 0;
        }
      }
      catch (Exception ex)
      {
        formMDI.infoError.ErrorString = "G25:" + ex.Message;
      }
    }
    /// <summary>
    /// On form keydown
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void frmGodown_KeyDown(object sender, KeyEventArgs e)
    {
      try
      {
        if (e.KeyCode == Keys.Escape)
        {
          btnClose_Click(sender, e);
        }
        if (e.KeyCode == Keys.S && Control.ModifierKeys == Keys.Control) //Save
        {
          btnSave_Click(sender, e);
        }
        if (e.KeyCode == Keys.D && Control.ModifierKeys == Keys.Control) //Delete
        {
          if (btnDelete.Enabled)
          {
            btnDelete_Click(sender, e);
          }
        }
      }
      catch (Exception ex)
      {
        formMDI.infoError.ErrorString = "G26:" + ex.Message;
      }
    }
    /// <summary>
    /// On datagridview keydown
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void dgvGodown_KeyDown(object sender, KeyEventArgs e)
    {
      try
      {
        if (e.KeyCode == Keys.Enter)
        {
          if (dgvSites.CurrentCell == dgvSites[dgvSites.Columns.Count - 1, dgvSites.Rows.Count - 1])
          {
            if (q == 1)
            {
              q = 0;
              btnClose.Focus();
              dgvSites.ClearSelection();
              e.Handled = true;
            }
            else
            {
              q++;
            }
          }
        }
        if (e.KeyCode == Keys.Back)
        {
          btnClose.Focus();
        }
      }
      catch (Exception ex)
      {
        formMDI.infoError.ErrorString = "G27:" + ex.Message;
      }
    }
    /// <summary>
    ///  On datagridview keyup
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void dgvGodown_KeyUp(object sender, KeyEventArgs e)
    {
      try
      {
        if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down || e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
        {
          if (dgvSites.CurrentRow != null)
          {
            DataGridViewCellEventArgs ex = new DataGridViewCellEventArgs(dgvSites.CurrentCell.ColumnIndex, dgvSites.CurrentCell.RowIndex);
            dgvGodown_CellDoubleClick(sender, ex);
          }
        }
      }
      catch (Exception ex)
      {
        formMDI.infoError.ErrorString = "G28:" + ex.Message;
      }
    }
    #endregion
  }
}
