//NBS nursery management system
//Author: NDW
//Created on: 7/12/2018
//Copyright 2018 Sawyer Nursery

using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

//<summary>    
//Summary description for SiteSP    
//</summary>    
namespace Open_Miracle
{
  class SiteSP : DBConnection
  {
    #region Function
    /// <summary>
    /// Function to delete particular details based on the parameter by checking reference
    /// </summary>
    /// <param name="decSiteId"></param>
    /// <returns></returns>
    public decimal SiteCheckReferenceAndDelete(decimal decSiteId)
    {
      decimal decReturnValue = 0;
      try
      {
        if (sqlcon.State == ConnectionState.Closed)
        {
          sqlcon.Open();
        }
        SqlCommand sqlcmd = new SqlCommand("SiteCheckReferenceAndDelete", sqlcon);
        sqlcmd.CommandType = CommandType.StoredProcedure;
        SqlParameter sprmparam = new SqlParameter();
        sprmparam = sqlcmd.Parameters.Add("@siteId", SqlDbType.Decimal);
        sprmparam.Value = decSiteId;
        decReturnValue = Convert.ToDecimal(sqlcmd.ExecuteNonQuery().ToString());
      }
      catch (Exception ex)
      {
        MessageBox.Show(ex.ToString());
      }
      finally
      {
        sqlcon.Close();
      }
      return decReturnValue;
    }
    /// <summary>
    /// Function to get all the values from site Table
    /// </summary>
    /// <returns></returns>
    public DataTable SiteOnlyViewAll()
    {
      DataTable dtbl = new DataTable();
      dtbl.Columns.Add("SL.NO", typeof(decimal));
      dtbl.Columns["SL.NO"].AutoIncrement = true;
      dtbl.Columns["SL.NO"].AutoIncrementSeed = 1;
      dtbl.Columns["SL.NO"].AutoIncrementStep = 1;
      try
      {
        if (sqlcon.State == ConnectionState.Closed)
        {
          sqlcon.Open();
        }
        SqlDataAdapter sdaadapter = new SqlDataAdapter("SiteOnlyViewAll", sqlcon);
        sdaadapter.SelectCommand.CommandType = CommandType.StoredProcedure;
        sdaadapter.Fill(dtbl);
      }
      catch (Exception ex)
      {
        MessageBox.Show(ex.ToString());
      }
      finally
      {
        sqlcon.Close();
      }
      return dtbl;
    }
    /// <summary>
    /// Function to insert values to site Table with same name
    /// </summary>
    /// <param name="siteinfo"></param>
    /// <returns></returns>
    public decimal SiteAddWithoutSameName(SiteInfo siteinfo)
    {
      // bool isSave = false;
      try
      {
        if (sqlcon.State == ConnectionState.Closed)
        {
          sqlcon.Open();
        }
        SqlCommand sccmd = new SqlCommand("SiteAddWithoutSameName", sqlcon);
        sccmd.CommandType = CommandType.StoredProcedure;
        SqlParameter sprmparam = new SqlParameter();
        sprmparam = sccmd.Parameters.Add("@siteName", SqlDbType.VarChar);
        sprmparam.Value = siteinfo.SiteName;
        sprmparam = sccmd.Parameters.Add("@address", SqlDbType.VarChar);
        sprmparam.Value = siteinfo.Address;
        sprmparam = sccmd.Parameters.Add("@managed", SqlDbType.VarChar);
        sprmparam.Value = siteinfo.managed;
        sprmparam = sccmd.Parameters.Add("@dflt", SqlDbType.VarChar);
        sprmparam.Value = siteinfo.dflt;
        decimal decWork = Convert.ToDecimal(sccmd.ExecuteScalar());
        if (decWork > 0)
        {
          return decWork;
        }
        else
        {
          return 0;
        }
      }
      catch (Exception ex)
      {
        MessageBox.Show(ex.ToString());
        return 0;
      }
      finally
      {
        sqlcon.Close();
      }

    }
    /// <summary>
    /// Function to get particular values from site table based on the parameter with narration
    /// </summary>
    /// <param name="decSiteId"></param>
    /// <returns></returns>
    public SiteInfo SiteWithNarrationView(decimal decSiteId)
    {
      SiteInfo siteinfo = new SiteInfo();
      SqlDataReader sdrreader = null;
      try
      {
        if (sqlcon.State == ConnectionState.Closed)
        {
          sqlcon.Open();
        }
        SqlCommand sccmd = new SqlCommand("SiteWithNarrationView", sqlcon);
        sccmd.CommandType = CommandType.StoredProcedure;
        SqlParameter sprmparam = new SqlParameter();
        sprmparam = sccmd.Parameters.Add("@siteId", SqlDbType.Decimal);
        sprmparam.Value = decSiteId;
        sdrreader = sccmd.ExecuteReader();
        while (sdrreader.Read())
        {
          siteinfo.SiteId = Convert.ToDecimal(sdrreader[0].ToString());
          siteinfo.SiteName = sdrreader[1].ToString();
          siteinfo.Address = sdrreader[2].ToString();
          siteinfo.managed = Convert.ToBoolean(sdrreader[3].ToString());
          siteinfo.dflt = Convert.ToBoolean(sdrreader[4].ToString());
        }
      }
      catch (Exception ex)
      {
        MessageBox.Show(ex.ToString());
      }
      finally
      {
        sdrreader.Close();
        sqlcon.Close();
      }
      return siteinfo;
    }
    /// <summary>
    /// Function to check the existance of site
    /// </summary>
    /// <param name="strSiteName"></param>
    /// <param name="strSiteId"></param>
    /// <returns></returns>
    public bool SiteCheckIfExist(String siteName, decimal siteId)
    {
      try
      {
        if (sqlcon.State == ConnectionState.Closed)
        {
          sqlcon.Open();
        }
        SqlCommand sqlcmd = new SqlCommand("SiteCheckIfExist", sqlcon);
        sqlcmd.CommandType = CommandType.StoredProcedure;
        SqlParameter sprmparam = new SqlParameter();
        sprmparam = sqlcmd.Parameters.Add("@siteName", SqlDbType.VarChar);
        sprmparam.Value = siteName;
        sprmparam = sqlcmd.Parameters.Add("@siteId", SqlDbType.Decimal);
        sprmparam.Value = siteId;
        object obj = sqlcmd.ExecuteScalar();
        decimal decCount = 0;
        if (obj != null)
        {
          decCount = Convert.ToDecimal(obj.ToString());
        }
        if (decCount > 0)
        {
          return true;
        }
        else
        {
          return false; ;
        }
      }
      catch (Exception ex)
      {
        Messages.ErrorMessage(ex.ToString());
      }
      finally
      {
        sqlcon.Close();
      }
      return false;
    }
    /// <summary>
    /// Function to Update values in site Table
    /// </summary>
    /// <param name="siteinfo"></param>
    /// <returns></returns>
    public bool SiteEditParticularField(SiteInfo siteinfo)
    {
      bool isEdit = false;
      try
      {
        if (sqlcon.State == ConnectionState.Closed)
        {
          sqlcon.Open();
        }
        SqlCommand sccmd = new SqlCommand("SiteEditParticularField", sqlcon);
        sccmd.CommandType = CommandType.StoredProcedure;
        SqlParameter sprmparam = new SqlParameter();
        sprmparam = sccmd.Parameters.Add("@siteId", SqlDbType.Decimal);
        sprmparam.Value = siteinfo.SiteId;
        sprmparam = sccmd.Parameters.Add("@siteName", SqlDbType.VarChar);
        sprmparam.Value = siteinfo.SiteName;
        sprmparam = sccmd.Parameters.Add("@address", SqlDbType.VarChar);
        sprmparam.Value = siteinfo.Address;
        sprmparam = sccmd.Parameters.Add("@managed", SqlDbType.Bit);
        sprmparam.Value = siteinfo.managed;
        sprmparam = sccmd.Parameters.Add("@dflt", SqlDbType.Bit);
        sprmparam.Value = siteinfo.dflt;
        int inAffectedRows = sccmd.ExecuteNonQuery();
        if (inAffectedRows > 0)
        {
          isEdit = true;
        }
        else
        {
          isEdit = false;
        }
      }
      catch (Exception ex)
      {
        MessageBox.Show(ex.ToString());
      }
      finally
      {
        sqlcon.Close();
      }
      return isEdit;
    }
    #endregion
  }
}
