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
using System.ComponentModel;
using System.Data;
using MiracleI.BLL;
using Entity;

namespace WPFPieChart
{
    public class AssetClass : INotifyPropertyChanged
    {
        private String myClass;

        public String Class
        {
            get { return myClass; }
            set {
                myClass = value;
                RaisePropertyChangeEvent("Class");
            }
        }

        private double dblValue;

        public double Value
        {
            get { return dblValue; }
            set {
                dblValue = value;
                RaisePropertyChangeEvent("Value");
            }
        }

        public static List<AssetClass> ConstructTestData(CategoryInfo infoCatagory)
        {
            CallSP objCallSP = new CallSP();
            List<DataTable> objList = objCallSP.GetPieChartDetails(infoCatagory);

            List<AssetClass> assetClasses = new List<AssetClass>();
            for (int i = 0; i < objList[0].Rows.Count; i++)
            {
                assetClasses.Add(new AssetClass() { Class = objList[0].Rows[i][0].ToString(), Value = Convert.ToDouble(objList[0].Rows[i][1]) });               
            }

            return assetClasses;
        }

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChangeEvent(String propertyName)
        {
            if (PropertyChanged!=null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            
        }

        #endregion
    }
}
