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
using Entity;

namespace MiracleI
{
    class YaxisModeAnalizier
    {
        public bool isEnable(CategoryInfo infoCatagory)
        {
            bool isTrue = true;

            if (infoCatagory.ModuleName == "Overall Statistics")
            {
                isTrue = false;
            }
            else if (infoCatagory.ModuleName == "Bank")
            {
                isTrue = false;
            }
            else if (infoCatagory.ModuleName == "Customer" || infoCatagory.ModuleName == "Supplier")
            {
                if (infoCatagory.CatagoryName == "Transactions")
                {
                    if (infoCatagory.SubCatagoryName == "Overall Statistics")
                    {
                        isTrue = false;
                    }
                    else
                    {
                        isTrue = true;
                    }
                }
                else if (infoCatagory.CatagoryName == "Tax Free Sales" || infoCatagory.CatagoryName == "Tax Free Purchase" || infoCatagory.CatagoryName == "Credit Sales" || infoCatagory.CatagoryName == "Credit Purchase")
                {
                    isTrue = true;
                }
                else
                {
                    isTrue = false;
                }

            }
            else if (infoCatagory.ModuleName == "Product")
            {
                if (infoCatagory.CatagoryName == "Stock Details" || infoCatagory.CatagoryName == "Transactions" || infoCatagory.CatagoryName == "Unused Products" || infoCatagory.CatagoryName == "Stock Out" || infoCatagory.CatagoryName == "Finished Goods")
                {
                    isTrue = true;
                }
                else
                {
                    isTrue = false;
                }

            }
            else if (infoCatagory.ModuleName == "Party Balance")
            {
                if (infoCatagory.CatagoryName == "Bill Allocation")
                {
                    isTrue = true;
                }
                else
                {
                    isTrue = false;
                }
            }
            else if (infoCatagory.ModuleName == "Payroll")
            {
                if (infoCatagory.CatagoryName == "Attendance" || infoCatagory.CatagoryName == "Overall Statistics" || infoCatagory.CatagoryName == "Designation")
                {
                    isTrue = false;
                }
                else if (infoCatagory.CatagoryName == "Salesman")
                {
                    if (infoCatagory.SubCatagoryName == "Overall Statistics")
                    {
                        isTrue = false;
                    }
                    else
                    {
                        isTrue = true;
                    }
                }
                else
                {
                    isTrue = true;
                }
            }
            else if (infoCatagory.ModuleName == "Finance")
            {
                if (infoCatagory.CatagoryName == "Daily Report")
                {
                    isTrue = true;
                }
                else
                {
                    isTrue = false;
                }
            }
            return isTrue;
        }
        public bool isAmount(CategoryInfo infoCatagory)
        {
            bool isTrue = true;
            if (infoCatagory.ModuleName == "Overall Statistics")
            {
                isTrue = false;
            }
            else if (infoCatagory.ModuleName == "Bank")
            {
                isTrue = false;
            }
            else if (infoCatagory.ModuleName == "Customer" || infoCatagory.ModuleName == "Supplier")
            {
                if (infoCatagory.CatagoryName == "Transactions")
                {
                    isTrue = false;
                }
                else if (infoCatagory.CatagoryName == "Customer Balance" || infoCatagory.CatagoryName == "Supplier Balance" || infoCatagory.CatagoryName == "Tax Paid" || infoCatagory.CatagoryName == "Bill Discount")
                {
                    isTrue = false;
                }
                else
                {
                    isTrue = true;
                }
            }
            else if (infoCatagory.ModuleName == "Product")
            {
                if (infoCatagory.CatagoryName == "Rate")
                {
                    isTrue = false;
                }
                else
                {
                    isTrue = true;
                }
            }
            else if (infoCatagory.ModuleName == "Party Balance")
            {
                if (infoCatagory.CatagoryName == "Bill Allocation")
                {
                    isTrue = true;
                }
                else
                {
                    isTrue = false;
                }
            }
            else if (infoCatagory.ModuleName == "Payroll")
            {
                if (infoCatagory.CatagoryName == "Attendance" || infoCatagory.CatagoryName == "Overall Statistics" || infoCatagory.CatagoryName == "Designation")
                {
                    isTrue = true;
                }
                else if (infoCatagory.CatagoryName == "Salesman")
                {
                    if (infoCatagory.SubCatagoryName == "Overall Statistics")
                    {
                        isTrue = true;
                    }
                    else
                    {
                        isTrue = false;
                    }
                }
                else
                {
                    isTrue = false;
                }
            }
            else if (infoCatagory.ModuleName == "Finance")
            {

                isTrue = false;

            }
            return isTrue;
        }
        public bool isChange(CategoryInfo infoCatagory)
        {
            bool isTrue = true;
            if (infoCatagory.ModuleName == "Overall Statistics")
            {
                isTrue = true;
            }
            else if (infoCatagory.ModuleName == "Bank")
            {
                isTrue = true;
            }
            else if (infoCatagory.ModuleName == "Customer" || infoCatagory.ModuleName == "Supplier")
            {
                if (infoCatagory.CatagoryName == "Transactions")
                {
                    if (infoCatagory.SubCatagoryName == "Overall Statistics")
                    {
                        isTrue = true;
                    }
                    else
                    {
                        isTrue = false;
                    }
                }
                else if (infoCatagory.CatagoryName == "Tax Free Sales" || infoCatagory.CatagoryName == "Tax Free Purchase" || infoCatagory.CatagoryName == "Credit Sales" || infoCatagory.CatagoryName == "Credit Purchase")
                {
                    isTrue = false;
                }
                else
                {
                    isTrue = true;
                }
            }
            else if (infoCatagory.ModuleName == "Product")
            {
                if (infoCatagory.CatagoryName == "Stock Details" || infoCatagory.CatagoryName == "Transactions" || infoCatagory.CatagoryName == "Unused Products" || infoCatagory.CatagoryName == "Stock Out" || infoCatagory.CatagoryName == "Finished Goods")
                {
                    isTrue = false;
                }
                else
                {
                    isTrue = true;
                }
            }
            else if (infoCatagory.ModuleName == "Party Balance")
            {
                if (infoCatagory.CatagoryName == "Bill Allocation")
                {
                    isTrue = false;
                }
                else
                {
                    isTrue = true;
                }
            }
            else if (infoCatagory.ModuleName == "Payroll")
            {
                if (infoCatagory.CatagoryName == "Attendance" || infoCatagory.CatagoryName == "Overall Statistics" || infoCatagory.CatagoryName == "Designation")
                {
                    isTrue = true;
                }
                else if (infoCatagory.CatagoryName == "Salesman")
                {
                    if (infoCatagory.SubCatagoryName == "Overall Statistics")
                    {
                        isTrue = true;
                    }
                    else
                    {
                        isTrue = false;
                    }
                }
                else
                {
                    isTrue = false;
                }
            }
            else if (infoCatagory.ModuleName == "Finance")
            {
                if (infoCatagory.CatagoryName == "Daily Report")
                {
                    isTrue = false;
                }
                else
                {
                    isTrue = true;
                }
            }
            else if (infoCatagory.ModuleName == "Purchase" || infoCatagory.ModuleName == "Sales")
            {
                isTrue = false;
            }
            return isTrue;
        }
    }
}
