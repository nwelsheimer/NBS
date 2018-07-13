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
using System.ComponentModel;
using System.Threading;
using System.Windows.Threading;
using System.Data;

namespace MiracleSkate
{
    /// <summary>
    /// Interaction logic for Skate.xaml
    /// </summary>
    public partial class Skate : Window
    {
        Propertiess propertiess = new Propertiess();
        public Skate()
        {
            InitializeComponent();
            propertiess.PropertyChanged += new PropertyChangedEventHandler(CategoryInfo_PropertyChanged);
            bg.DoWork += new DoWorkEventHandler(bg_DoWork);
            bg.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bg_RunWorkerCompleted);

            bgSave.DoWork += new DoWorkEventHandler(bgSave_DoWork);
            bgSave.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bgSave_RunWorkerCompleted);
        }

        Tally spTally;
        ExcellSp spExcell;
        OpenmiracleExport spOpenmiracleExport;
        GenerateExcell spGenerateExcel;
        Openmiracle openmiracle = new Openmiracle();
        void bgSave_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (((spTally != null) ? spTally.CheckTallyConnection() : false) || ((spExcell != null) ? spExcell.CheckExcellConnection() : false))
            {
                if (!bg.IsBusy)
                {
                    bg.RunWorkerAsync(Header);
                }
            }
            else
            {
                ShowMessage(Process);
                grdMain.Children.OfType<DataGrid>().ToList().ForEach(b => grdMain.Children.Remove(b));
                pbProgressBar.IsIndeterminate = false;
                mainmaenu.IsEnabled = true;
                grdLeftMenu.IsEnabled = true;
                grdMain.IsEnabled = true;
                Messages = null;
            }
        }
        Microsoft.Office.Interop.Excel.Range fontRange;
        void bgSave_DoWork(object sender, DoWorkEventArgs e)
        {
            DataGrid datagrid = e.Argument as DataGrid;

            mainmaenu.Dispatcher.Invoke(System.Windows.Threading.DispatcherPriority.Normal,
              new Action(
              delegate()
              {
                  mainmaenu.IsEnabled = false;
                  grdLeftMenu.IsEnabled = false;
                  grdMain.IsEnabled = false;
              }));
            if (Process == "btnImportFromExcel" || Process == "btnImportFromTally")
            {
                switch (Header)
                {
                    case ("Pricing Level"):
                        #region PriceLevel
                        List<PriceLevelInfofroOpenmiracle> lstObjPriceLevel = new List<PriceLevelInfofroOpenmiracle>();
                        foreach (pricingLevelInfo PriceLevel in datagrid.dgDatas.Items)
                        {
                            if (openmiracle.PriceLevelValidation(PriceLevel))
                            {
                                PriceLevelInfofroOpenmiracle obj = new PriceLevelInfofroOpenmiracle();
                                obj.PricingLevelName = PriceLevel.PricingLevelName;
                                obj.Narration = PriceLevel.Narration;
                                lstObjPriceLevel.Add(obj);
                            }
                        }

                        if (lstObjPriceLevel.Count != 0)
                        {
                            openmiracle.AddPriceLevel(lstObjPriceLevel, ref Messages, datagrid.lblEventMessage);
                        }
                        else
                        {
                            Messages = "All Pricing Level names are existed.!";
                        }
                        #endregion
                        break;
                    case ("Customer"):
                        #region Customer
                        List<AccountLedgerInfoforOpenmiracle> lstObj = new List<AccountLedgerInfoforOpenmiracle>();
                        foreach (CustomerSupplierInfo Customer in datagrid.dgDatas.Items)
                        {
                            if (openmiracle.CustomerValidations(Customer))
                            {
                                AccountLedgerInfoforOpenmiracle obj = new AccountLedgerInfoforOpenmiracle();
                                obj.AccountGroupId = 26;
                                obj.Account_Number = Customer.Account_Number;
                                obj.Address = Customer.Address;
                                obj.Area_ID = openmiracle.functionCheckAreaIdId(Customer.Area);
                                obj.Bill_By_Bill = Convert.ToBoolean(Customer.Bill_By_Bill);
                                obj.Brach_Code = Customer.Brach_Code;
                                obj.Branch_Name = Customer.Branch_Name;
                                obj.Credit_Limit = Convert.ToDecimal(Customer.Credit_Limit);
                                obj.Credit_Period = Convert.ToDecimal(Customer.Credit_Period);
                                obj.CrorDr = Customer.CrorDr;
                                obj.CST = Customer.CST;
                                obj.Email = Customer.Email;
                                obj.Mailing_Name = Customer.Mailing_Name;
                                obj.Mobile = Customer.Mobile;
                                obj.Name = Customer.Name;
                                obj.Narration = Customer.Narration;
                                obj.Opening_Balance = Convert.ToDecimal(Customer.Opening_Balance);
                                obj.PAN = Customer.PAN;
                                obj.Phone = Customer.Phone;
                                obj.Pricing_Level_ID = openmiracle.functionPricingLevelId(Customer.Pricing_Level);
                                obj.Route_ID = openmiracle.functionRoutId(Customer.Route, Customer.Area);
                                obj.TIN = Customer.TIN;
                                lstObj.Add(obj);
                            }

                        }
                        if (lstObj.Count != 0)
                        {
                            openmiracle.AddAccountLedger(lstObj, ref Messages, datagrid.lblEventMessage);
                        }
                        else
                        {
                            Messages = "All Customers names existed.!";
                        }
                        #endregion
                        break;
                    case ("Supplier"):
                        #region Supplier
                        List<AccountLedgerInfoforOpenmiracle> lstObj1 = new List<AccountLedgerInfoforOpenmiracle>();
                        foreach (CustomerSupplierInfo Supplier in datagrid.dgDatas.Items)
                        {
                            if (openmiracle.SupplierValidations(Supplier))
                            {
                                AccountLedgerInfoforOpenmiracle obj = new AccountLedgerInfoforOpenmiracle();
                                obj.AccountGroupId = 22;
                                obj.Account_Number = Supplier.Account_Number;
                                obj.Address = Supplier.Address;
                                obj.Area_ID = openmiracle.functionCheckAreaIdId(Supplier.Area);
                                obj.Bill_By_Bill = Convert.ToBoolean(Supplier.Bill_By_Bill);
                                obj.Brach_Code = Supplier.Brach_Code;
                                obj.Branch_Name = Supplier.Branch_Name;
                                obj.Credit_Limit = Convert.ToDecimal(Supplier.Credit_Limit);
                                obj.Credit_Period = Convert.ToDecimal(Supplier.Credit_Period);
                                obj.CrorDr = Supplier.CrorDr;
                                obj.CST = Supplier.CST;
                                obj.Email = Supplier.Email;
                                obj.Mailing_Name = Supplier.Mailing_Name;
                                obj.Mobile = Supplier.Mobile;
                                obj.Name = Supplier.Name;
                                obj.Narration = Supplier.Narration;
                                obj.Opening_Balance = Convert.ToDecimal(Supplier.Opening_Balance);
                                obj.PAN = Supplier.PAN;
                                obj.Phone = Supplier.Phone;
                                obj.Pricing_Level_ID = openmiracle.functionPricingLevelId(Supplier.Pricing_Level);
                                obj.Route_ID = openmiracle.functionRoutId(Supplier.Route, Supplier.Area);
                                obj.TIN = Supplier.TIN;
                                lstObj1.Add(obj);
                            }

                        }
                        if (lstObj1.Count != 0)
                        {
                            openmiracle.AddAccountLedger(lstObj1, ref Messages, datagrid.lblEventMessage);
                        }
                        else
                        {
                            Messages = "All Suppliers names existed.!";
                        }
                        #endregion
                        break;
                    case ("Account Ledgers"):
                        #region AccountLedger
                        List<AccountLedgerInfoforOpenmiracle> lstObj2 = new List<AccountLedgerInfoforOpenmiracle>();
                        foreach (LedgerInfo ledger in datagrid.dgDatas.Items)
                        {
                            if (openmiracle.LedgerValidations(ledger))
                            {
                                decimal AccountGroupId = openmiracle.functionCheckAccountGroupUnderId(ledger.Account_Group);
                                if (AccountGroupId != -1)
                                {
                                    AccountLedgerInfoforOpenmiracle obj = new AccountLedgerInfoforOpenmiracle();
                                    obj.AccountGroupId = AccountGroupId;
                                    obj.Account_Number = "";
                                    obj.Address = "";
                                    obj.Area_ID = 1;
                                    obj.Bill_By_Bill = false;
                                    obj.Brach_Code = "";
                                    obj.Branch_Name = "";
                                    obj.Credit_Limit = 0;
                                    obj.Credit_Period = 0;
                                    obj.CrorDr = ledger.CrorDr;
                                    obj.CST = "";
                                    obj.Email = "";
                                    obj.Mailing_Name = "";
                                    obj.Mobile = "";
                                    obj.Name = ledger.Name;
                                    obj.Narration = ledger.Narration;
                                    obj.Opening_Balance = Convert.ToDecimal(ledger.Opening_Balance);
                                    obj.PAN = "";
                                    obj.Phone = "";
                                    obj.Pricing_Level_ID = 1;
                                    obj.Route_ID = 1;
                                    obj.TIN = "";
                                    lstObj2.Add(obj);
                                }
                            }

                        }
                        if (lstObj2.Count != 0)
                        {
                            openmiracle.AddAccountLedger(lstObj2, ref Messages, datagrid.lblEventMessage);
                        }
                        else
                        {
                            Messages = "All Account Ledger names are existed.!";
                        }
                        #endregion
                        break;
                    case ("Account Groups"):
                        #region AccountGroup
                        List<AccountGroupInfoforOpenmiracle> lstObj3 = new List<AccountGroupInfoforOpenmiracle>();
                        foreach (accountGroupInfo AccountGroup in datagrid.dgDatas.Items)
                        {
                            if (openmiracle.AccountGroupValidation(AccountGroup))
                            {
                                AccountGroupInfoforOpenmiracle infoaccountGroup = new AccountGroupInfoforOpenmiracle();
                                infoaccountGroup.Name = AccountGroup.Name;
                                infoaccountGroup.Affect_Gross_Profit = Convert.ToBoolean(AccountGroup.Affect_Gross_Profit);
                                infoaccountGroup.Narration = AccountGroup.Narration;
                                infoaccountGroup.Under = openmiracle.functionCheckAccountGroupUnderId(AccountGroup.Under);
                                infoaccountGroup.Nature = AccountGroup.Nature;
                                lstObj3.Add(infoaccountGroup);
                            }

                        }
                        if (lstObj3.Count != 0)
                        {
                            openmiracle.AddAccountGroup(lstObj3, ref Messages, datagrid.lblEventMessage);
                        }
                        else
                        {
                            Messages = "All Account Group names are existed.!";
                        }
                        #endregion
                        break;
                    case ("Units"):
                        #region Unit
                        List<UnitinfoforOpenmiracle> lstObjUnit = new List<UnitinfoforOpenmiracle>();
                        foreach (unitsInfo Unit in datagrid.dgDatas.Items)
                        {
                            if (openmiracle.UnitValidation(Unit))
                            {
                                UnitinfoforOpenmiracle infoUnit = new UnitinfoforOpenmiracle();
                                infoUnit.FormalName = Unit.FormalName;
                                infoUnit.Narration = Unit.Narration;
                                infoUnit.Narration = Unit.Narration;
                                infoUnit.noOfDecimalPlaces = Convert.ToDecimal(Unit.noOfDecimalPlaces);
                                infoUnit.UnitName = Unit.UnitName;
                                lstObjUnit.Add(infoUnit);
                            }

                        }
                        if (lstObjUnit.Count != 0)
                        {
                            openmiracle.AddUnit(lstObjUnit, ref Messages, datagrid.lblEventMessage);
                        }
                        else
                        {
                            Messages = "All Units are existed.!";
                        }
                        #endregion
                        break;
                    case ("Product Groups"):
                        #region ProductGroup
                        List<ProductGroupinfoforOpenmiracle> lstObjProductGroup = new List<ProductGroupinfoforOpenmiracle>();
                        foreach (productGroupInfo ProductGroup in datagrid.dgDatas.Items)
                        {
                            if (openmiracle.ProductGroupValidation(ProductGroup))
                            {
                                ProductGroupinfoforOpenmiracle obj = new ProductGroupinfoforOpenmiracle();
                                obj.GroupName = ProductGroup.GroupName;
                                obj.GroupUnder = openmiracle.functionCheckProductGroupUnderId(ProductGroup.Group_Under);
                                obj.Narration = ProductGroup.Narration;
                                lstObjProductGroup.Add(obj);
                            }

                        }
                        if (lstObjProductGroup.Count != 0)
                        {
                            openmiracle.AddProductGroup(lstObjProductGroup, ref Messages, datagrid.lblEventMessage);
                        }
                        else
                        {
                            Messages = "All Product Group names are existed.!";
                        }
                        #endregion
                        break;
                    case ("Godowns"):
                        #region Godowns
                        List<GodowninfoforOpenmiracle> lstObjGodowns = new List<GodowninfoforOpenmiracle>();
                        foreach (godownInfo Godown in datagrid.dgDatas.Items)
                        {
                            if (openmiracle.GodownValidation(Godown))
                            {
                                GodowninfoforOpenmiracle obj = new GodowninfoforOpenmiracle();
                                obj.Godown_Name = Godown.Godown_Name;
                                obj.Narration = Godown.Narration;
                                lstObjGodowns.Add(obj);
                            }

                        }
                        if (lstObjGodowns.Count != 0)
                        {
                            openmiracle.AddGodwn(lstObjGodowns, ref Messages, datagrid.lblEventMessage);
                        }
                        else
                        {
                            Messages = "All Godown names are existed.!";
                        }
                        #endregion
                        break;
                    case ("Products"):
                        #region Products
                        List<ProductInfofroOpenmiracle> lstObj4 = new List<ProductInfofroOpenmiracle>();
                        foreach (productInfo Product in datagrid.dgDatas.Items)
                        {
                            if (openmiracle.ProductValidation(Product))
                            {
                                ProductInfofroOpenmiracle productinfo = new ProductInfofroOpenmiracle();
                                productinfo.AllowBatch = Convert.ToBoolean(Product.AllowBatch);
                                productinfo.ConversionRate = Convert.ToDecimal(Product.ConversionRate);
                                productinfo.GodownId = openmiracle.functionCheckGodownId(Product.DefaultGodown);
                                productinfo.Group = openmiracle.functionCheckProductGroupUnderId(Product.Group);
                                productinfo.MaximumStock = Convert.ToDecimal(Product.MaximumStock);
                                productinfo.MinimumStock = Convert.ToDecimal(Product.MinimumStock);
                                productinfo.MRP = Convert.ToDecimal(Product.MRP);
                                productinfo.MultipleUnit = Convert.ToBoolean(Product.MultipleUnit);
                                productinfo.Narration = Product.Narration;
                                productinfo.OpeningStock = Convert.ToBoolean(Product.OpeningStock);
                                productinfo.ProductCode = Product.ProductCode;
                                productinfo.ProductName = Product.ProductName;
                                productinfo.PurchaseRate = Convert.ToDecimal(Product.PurchaseRate);
                                productinfo.RackId = openmiracle.functionCheckRackId(Product.Rack);
                                productinfo.ReorderLevel = Convert.ToDecimal(Product.ReorderLevel);
                                productinfo.SalesRate = Convert.ToDecimal(Product.SalesRate);
                                productinfo.Size = Convert.ToDecimal(Product.Size);
                                productinfo.TaxApplicableOn = Product.TaxApplicableOn;
                                productinfo.TaxId = openmiracle.functionCheckTaxId(Product.Tax);
                                productinfo.UnitId = openmiracle.functionCheckUnitId(Product.Unit);
                                lstObj4.Add(productinfo);
                            }
                        }
                        if (lstObj4.Count != 0)
                        {
                            openmiracle.AddProduct(lstObj4, ref Messages, datagrid.lblEventMessage);
                        }
                        else
                        {
                            Messages = "All Product names are existed.!";
                        }
                        #endregion
                        break;
                    case ("Stock"):
                        #region Stock
                        List<StockforOpenmiracle> lstObjStock = new List<StockforOpenmiracle>();
                        foreach (StockInfo Stock in datagrid.dgDatas.Items)
                        {
                            if (openmiracle.StockValidation(Stock))
                            {
                                decimal decProductId = openmiracle.functionProductId(Stock.ProductName);
                                decimal decBatchId = openmiracle.functionBatchId(Stock.ProductName);
                                if (decProductId != -1 && decBatchId != -1)
                                {
                                    StockforOpenmiracle productinfo = new StockforOpenmiracle();
                                    productinfo.OpeningStock = Convert.ToBoolean(Stock.OpeningStock);
                                    productinfo.OpeningStockNumber = Convert.ToDecimal(Stock.OpeningStockNumber);
                                    productinfo.ProductId = decProductId;
                                    productinfo.BatchId = decBatchId;
                                    productinfo.UnitID = openmiracle.functionCheckUnitId(Stock.Unit);
                                    productinfo.ClosingRate = Convert.ToDecimal(Stock.ClosingRate);
                                    lstObjStock.Add(productinfo);
                                }
                            }
                        }
                        if (lstObjStock.Count != 0)
                        {
                            openmiracle.AddStock(lstObjStock, ref Messages, datagrid.lblEventMessage);
                        }
                        else
                        {
                            Messages = "All Stock existed.!";
                        }
                        #endregion
                        break;
                    case ("Currency"):
                        #region Currency
                        List<CurrencyInfoforOpenmiracle> lstObjCurrency = new List<CurrencyInfoforOpenmiracle>();
                        foreach (currencyInfo Currency in datagrid.dgDatas.Items)
                        {
                            if (openmiracle.CurrencyValidation(Currency))
                            {
                                CurrencyInfoforOpenmiracle currencyinfo = new CurrencyInfoforOpenmiracle();
                                currencyinfo.CurrencyName = Currency.CurrencyName;
                                currencyinfo.CurrencySymbol = Currency.CurrencySymbol;
                                currencyinfo.Narration = Currency.Narration;
                                currencyinfo.NoOfDecimalPlaces = Convert.ToInt32(Currency.NoOfDecimalPlaces);
                                currencyinfo.SubUnitName = Currency.SubUnitName;
                                lstObjCurrency.Add(currencyinfo);
                            }
                        }
                        if (lstObjCurrency.Count != 0)
                        {
                            openmiracle.AddCurrency(lstObjCurrency, ref Messages, datagrid.lblEventMessage);
                        }
                        else
                        {
                            Messages = "All Currency names are existed.!";
                        }
                        #endregion
                        break;
                    case ("Voucher Type"):
                        #region VoucherType
                        List<VoucherTypeinfoforOpenmiracle> lstObjVoucherType = new List<VoucherTypeinfoforOpenmiracle>();
                        foreach (voucherTypesInfo Voucher in datagrid.dgDatas.Items)
                        {
                            if (openmiracle.VoucherTypeValidation(Voucher))
                            {
                                VoucherTypeinfoforOpenmiracle voucherinfo = new VoucherTypeinfoforOpenmiracle();
                                voucherinfo.name = Voucher.name;
                                voucherinfo.active = Convert.ToBoolean(Voucher.active);
                                voucherinfo.declaration = Voucher.declaration;
                                voucherinfo.dotMatrixPrintFormat = Voucher.dotMatrixPrintFormat;
                                voucherinfo.methodOfVoucherNumbering = Voucher.methodOfVoucherNumbering;
                                voucherinfo.narration = Voucher.narration;
                                voucherinfo.typeOfVoucher = Voucher.typeOfVoucher;
                                lstObjVoucherType.Add(voucherinfo);
                            }
                        }
                        if (lstObjVoucherType.Count != 0)
                        {
                            openmiracle.AddVoucherType(lstObjVoucherType, ref Messages, datagrid.lblEventMessage);
                        }
                        else
                        {
                            Messages = "All Voucher Type names are existed.!";
                        }
                        #endregion
                        break;
                }
            }
            else if (Process == "btnExportExcel")
            {
                spGenerateExcel.GenerateExcellWithData(datagrid.dgDatas, saveDlg.FileName, fontRange);
            }
        }
        Microsoft.Win32.SaveFileDialog saveDlg = new Microsoft.Win32.SaveFileDialog();


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoginUser loginuser = new LoginUser(propertiess);
            string ss = loginuser.txtUserName.Text;
            grdMain.Children.Add(loginuser);
        }
        public void CategoryInfo_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "logIn_True")
            {
                mainmaenu.Visibility = System.Windows.Visibility.Visible;
                mainmaenu.btnPricingLevel.Click += new RoutedEventHandler(btnClick);
                mainmaenu.btnCustomer.Click += new RoutedEventHandler(btnClick);
                mainmaenu.btnSupplier.Click += new RoutedEventHandler(btnClick);
                mainmaenu.btnAccountGroups.Click += new RoutedEventHandler(btnClick);
                mainmaenu.btnAccountLedgers.Click += new RoutedEventHandler(btnClick);
                mainmaenu.btnProductGroups.Click += new RoutedEventHandler(btnClick);
                mainmaenu.btnUnits.Click += new RoutedEventHandler(btnClick);
                mainmaenu.btnGodowns.Click += new RoutedEventHandler(btnClick);
                mainmaenu.btnProducts.Click += new RoutedEventHandler(btnClick);
                mainmaenu.btnBatches.Click += new RoutedEventHandler(btnClick);
                mainmaenu.btnCurrency.Click += new RoutedEventHandler(btnClick);
                mainmaenu.btnVoucherType.Click += new RoutedEventHandler(btnClick);
                mainmaenu.btnSalesMan.Click += new RoutedEventHandler(btnClick);
                mainmaenu.btnStock.Click += new RoutedEventHandler(btnClick);
            }
        }
        BackgroundWorker bg = new BackgroundWorker();
        BackgroundWorker bgSave = new BackgroundWorker();
        object dtbl;
        string Header;
        string Process;
        private void ShowMessage(string Process)
        {
            switch (Process)
            {
                case ("btnImportFromTally"):
                    new wdoMessageBox("Source connection not established! Make sure you have open Tally to proceed.").ShowDialog();
                    break;
                case ("btnImportFromExcel"):
                    new wdoMessageBox("Source connection not established!").ShowDialog();
                    break;
            }

        }
        #region TopButtonCliks
        void btnClick(object sender, RoutedEventArgs e)
        {
            if (Process == "btnImportFromTally")
            {
                if (spTally == null || !spTally.CheckTallyConnection())
                    spTally = new Tally();
            }
            else if (Process == "btnImportFromExcel")
            {
                    spExcell = new ExcellSp();
            }
            else if (Process == "btnExportExcel")
            {
                if (spOpenmiracleExport == null)
                    spOpenmiracleExport = new OpenmiracleExport();
                if (spGenerateExcel == null)
                    spGenerateExcel = new GenerateExcell();
            }
            else if (Process == "btnExcellFormat")
            {
                if (spGenerateExcel == null)
                    spGenerateExcel = new GenerateExcell();
            }
            if (((spTally != null) ? spTally.CheckTallyConnection() : false) || ((spExcell != null) ? spExcell.CheckExcellConnection() : false) || spOpenmiracleExport != null || spGenerateExcel != null)
            {
                if (!bg.IsBusy)
                {
                    pbProgressBar.IsIndeterminate = true;
                    bg.RunWorkerAsync((sender as Button).ToolTip);
                }
            }
            else
            {
                ShowMessage(Process);
            }
        }
        #endregion
        DataGrid datagrid;
        System.Windows.Forms.FolderBrowserDialog myFolderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
        string Messages = null;
        void bg_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

            grdMain.Children.OfType<DataGrid>().ToList().ForEach(b => grdMain.Children.Remove(b));
            if (Process != "btnExcellFormat")
            {
                datagrid = new DataGrid(dtbl, Header, Messages);
                grdMain.Children.Add(datagrid);
            }
            pbProgressBar.IsIndeterminate = false;
            mainmaenu.IsEnabled = true;
            grdLeftMenu.IsEnabled = true;
            grdMain.IsEnabled = true;
            Messages = null;

        }
        System.Windows.Forms.FolderBrowserDialog folderbrowser = new System.Windows.Forms.FolderBrowserDialog();
        void bg_DoWork(object sender, DoWorkEventArgs e)
        {
            mainmaenu.Dispatcher.Invoke(System.Windows.Threading.DispatcherPriority.Normal,
               new Action(
               delegate()
               {
                   mainmaenu.IsEnabled = false;
                   grdLeftMenu.IsEnabled = false;
                   grdMain.IsEnabled = false;
               }));

            Header = e.Argument.ToString();
            if (Messages == null)
                Messages = e.Argument.ToString();
            switch (e.Argument.ToString())
            {
                case ("Pricing Level"):
                    switch (Process)
                    {
                        case ("btnImportFromTally"):
                            dtbl = spTally.GetPriceLevel();
                            break;
                        case ("btnImportFromExcel"):
                            dtbl = spExcell.GetPriceLevel();
                            break;
                        case ("btnExportExcel"):
                            dtbl = spOpenmiracleExport.PricingLevelToExcel();
                            break;
                        case ("btnExcellFormat"):
                            if (GetPath())
                                spGenerateExcel.PricingLevel(myFolderBrowserDialog.SelectedPath);
                            break;
                        default:
                            break;
                    }
                    break;
                case ("Customer"):
                    switch (Process)
                    {
                        case ("btnImportFromTally"):
                            dtbl = spTally.GetCustomer();
                            break;
                        case ("btnImportFromExcel"):
                            dtbl = spExcell.GetCustomer();
                            break;
                        case ("btnExportExcel"):
                            dtbl = spOpenmiracleExport.CustomerExportToExcel();
                            break;
                        case ("btnExcellFormat"):
                            if (GetPath())
                                spGenerateExcel.Customer(myFolderBrowserDialog.SelectedPath);
                            break;
                        default:
                            break;
                    }
                    break;
                case ("Supplier"):
                    switch (Process)
                    {
                        case ("btnImportFromTally"):
                            dtbl = spTally.GetSupplier();
                            break;
                        case ("btnImportFromExcel"):
                            dtbl = spExcell.GetSupplier();
                            break;
                        case ("btnExportExcel"):
                            dtbl = spOpenmiracleExport.SupplierExportToExcel();
                            break;
                        case ("btnExcellFormat"):
                            if (GetPath())
                                spGenerateExcel.Supplier(myFolderBrowserDialog.SelectedPath);
                            break;
                        default:
                            break;
                    }
                    break;
                case ("Account Groups"):
                    switch (Process)
                    {
                        case ("btnImportFromTally"):
                            dtbl = spTally.GetAccountGroup();
                            break;
                        case ("btnImportFromExcel"):
                            dtbl = spExcell.GetAccountGroup();
                            break;
                        case ("btnExportExcel"):
                            dtbl = spOpenmiracleExport.AccountGroupExportToExcel();
                            break;
                        case ("btnExcellFormat"):
                            if (GetPath())
                                spGenerateExcel.AccountGroup(myFolderBrowserDialog.SelectedPath);
                            break;
                        default:
                            break;
                    }
                    break;
                case ("Account Ledgers"):
                    switch (Process)
                    {
                        case ("btnImportFromTally"):
                            dtbl = spTally.GetAccountLedger();
                            break;
                        case ("btnImportFromExcel"):
                            dtbl = spExcell.GetAccountLedger();
                            break;
                        case ("btnExportExcel"):
                            dtbl = spOpenmiracleExport.AccountLegderExportToExcel();
                            break;
                        case ("btnExcellFormat"):
                            if (GetPath())
                                spGenerateExcel.AccountLeger(myFolderBrowserDialog.SelectedPath);
                            break;
                        default:
                            break;
                    }
                    break;
                case ("Product Groups"):
                    switch (Process)
                    {
                        case ("btnImportFromTally"):
                            dtbl = spTally.GetProductGroup();
                            break;
                        case ("btnImportFromExcel"):
                            dtbl = spExcell.GetProductGroup();
                            break;
                        case ("btnExportExcel"):
                            dtbl = spOpenmiracleExport.ProductGroupExportToExcel();
                            break;
                        case ("btnExcellFormat"):
                            if (GetPath())
                                spGenerateExcel.ProductGroup(myFolderBrowserDialog.SelectedPath);
                            break;
                        default:
                            break;
                    }
                    break;
                case ("Units"):
                    switch (Process)
                    {
                        case ("btnImportFromTally"):
                            dtbl = spTally.GetUnit();
                            break;
                        case ("btnImportFromExcel"):
                            dtbl = spExcell.GetUnit();
                            break;
                        case ("btnExportExcel"):
                            dtbl = spOpenmiracleExport.UnitExportToExcel();
                            break;
                        case ("btnExcellFormat"):
                            if (GetPath())
                                spGenerateExcel.Unit(myFolderBrowserDialog.SelectedPath);
                            break;
                        default:
                            break;
                    }
                    break;
                case ("Godowns"):
                    switch (Process)
                    {
                        case ("btnImportFromTally"):
                            dtbl = spTally.GetGodown();
                            break;
                        case ("btnImportFromExcel"):
                            dtbl = spExcell.GetGodown();
                            break;
                        case ("btnExportExcel"):
                            dtbl = spOpenmiracleExport.GodownExportToExcel();
                            break;
                        case ("btnExcellFormat"):
                            if (GetPath())
                                spGenerateExcel.Godown(myFolderBrowserDialog.SelectedPath);
                            break;
                        default:
                            break;
                    }
                    break;
                case ("Products"):
                    switch (Process)
                    {
                        case ("btnImportFromTally"):
                            dtbl = spTally.GetProduct();
                            break;
                        case ("btnImportFromExcel"):
                            dtbl = spExcell.GetProduct();
                            break;
                        case ("btnExportExcel"):
                            dtbl = spOpenmiracleExport.ProductExportTOExcel();
                            break;
                        case ("btnExcellFormat"):
                            if (GetPath())
                                spGenerateExcel.Product(myFolderBrowserDialog.SelectedPath);
                            break;
                        default:
                            break;
                    }
                    break;
                case ("Batches"):
                    switch (Process)
                    {
                        case ("btnImportFromTally"):
                            dtbl = spTally.GetBatch();
                            break;
                        case ("btnImportFromExcel"):
                            dtbl = spExcell.GetBatch();
                            break;
                        case ("btnExportExcel"):
                            dtbl = spOpenmiracleExport.BatchExportToExcel();
                            break;
                        case ("btnExcellFormat"):
                            if (GetPath())
                                spGenerateExcel.Batch(myFolderBrowserDialog.SelectedPath);
                            break;
                        default:
                            break;
                    }
                    break;
                case ("Currency"):
                    switch (Process)
                    {
                        case ("btnImportFromTally"):
                            dtbl = spTally.GetCurrency();
                            break;
                        case ("btnImportFromExcel"):
                            dtbl = spExcell.GetCurrency();
                            break;
                        case ("btnExportExcel"):
                            dtbl = spOpenmiracleExport.CurrencyExportToexcel();
                            break;
                        case ("btnExcellFormat"):
                            if (GetPath())
                                spGenerateExcel.Currency(myFolderBrowserDialog.SelectedPath);
                            break;
                        default:
                            break;
                    }
                    break;
                case ("Voucher Type"):
                    switch (Process)
                    {
                        case ("btnImportFromTally"):
                            dtbl = spTally.GetVoucherType();
                            break;
                        case ("btnImportFromExcel"):
                            dtbl = spExcell.GetVoucherType();
                            break;
                        case ("btnExportExcel"):
                            dtbl = spOpenmiracleExport.VoucherTypeExportToExcel();
                            break;
                        case ("btnExcellFormat"):
                            if (GetPath())
                                spGenerateExcel.Vochertype(myFolderBrowserDialog.SelectedPath);
                            break;
                        default:
                            break;
                    }
                    break;
                case ("SalesMan"):
                    switch (Process)
                    {
                        case ("btnImportFromTally"):
                            dtbl = spTally.GetSalesMen();
                            break;
                        case ("btnImportFromExcel"):
                            dtbl = spExcell.GetSalesMen();
                            break;
                        case ("btnExportExcel"):
                            dtbl = spOpenmiracleExport.SalesManExportToExcel();
                            break;
                        case ("btnExcellFormat"):
                            if (GetPath())
                                spGenerateExcel.SalesMan(myFolderBrowserDialog.SelectedPath);
                            break;
                        default:
                            break;
                    }
                    break;
                case ("Stock"):
                    switch (Process)
                    {
                        case ("btnImportFromTally"):
                            dtbl = spTally.GetStock();
                            break;
                        case ("btnImportFromExcel"):
                            dtbl = spExcell.GetStock();
                            break;
                        case ("btnExportExcel"):
                            dtbl = spOpenmiracleExport.StockExportToExcel();
                            break;
                        case ("btnExcellFormat"):
                            if (GetPath())
                                spGenerateExcel.Stock(myFolderBrowserDialog.SelectedPath);
                            break;
                        default:
                            break;
                    }
                    break;
            }
        }

        private bool GetPath()
        {
            Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();
            if (xlApp == null)
            {
                System.Windows.Application.Current.Dispatcher.Invoke((Action)(() => new wdoMessageBox("Suported Excel is not installed.").ShowDialog()));
                return false;
            }
            else
            {
                Thread t = new Thread(() => myFolderBrowserDialog.ShowDialog());
                t.IsBackground = true;
                t.SetApartmentState(ApartmentState.STA);
                t.Start();
                t.Join();
                return true;
            }
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = System.Windows.WindowState.Minimized;
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            if (Process == "btnExportExcel")
            {
                Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();
                if (xlApp == null)
                {
                    System.Windows.Application.Current.Dispatcher.Invoke((Action)(() => new wdoMessageBox("Suported Excel is not installed.").ShowDialog()));
                }
                else
                {
                    saveDlg.Filter = "Excel files (*.xls)|*.xls";
                    saveDlg.FilterIndex = 0;
                    saveDlg.RestoreDirectory = true;
                    saveDlg.Title = "Export Excel File To";
                    saveDlg.ShowDialog();
                }
            }
            List<DataGrid> dd = grdMain.Children.OfType<DataGrid>().ToList();
            if (dd.Count != 0)
            {
                if (!bgSave.IsBusy)
                {
                    pbProgressBar.IsIndeterminate = true;
                    bgSave.RunWorkerAsync(dd.Last());
                }
            }

        }

        private void grdMain_MouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                if (e.ChangedButton == MouseButton.Left)
                {
                    this.DragMove();
                }
            }
            catch (Exception ex)
            {
                System.Windows.Application.Current.Dispatcher.Invoke((Action)(() => new wdoMessageBox("VD 51 : " + ex.Message).ShowDialog()));
            }
        }
        ImageBrush images;
        private void btnProcess_Click(object sender, RoutedEventArgs e)
        {
            grdMain.Children.OfType<DataGrid>().ToList().ForEach(b => grdMain.Children.Remove(b));
            grdMain.Children.OfType<AboutUs>().ToList().ForEach(b => grdMain.Children.Remove(b));
            grdMain.Children.OfType<ContactUs>().ToList().ForEach(b => grdMain.Children.Remove(b));
            switch (Process)
            {
                case ("btnImportFromTally"):
                    btnImportFromTally.Content = null;
                    btnImportFromTally.Background = images;
                    break;
                case ("btnImportFromExcel"):
                    btnImportFromExcel.Content = null;
                    btnImportFromExcel.Background = images;
                    break;
                case ("btnExcellFormat"):
                    btnExcellFormat.Content = null;
                    btnExcellFormat.Background = images;
                    break;
                case ("btnExportExcel"):
                    btnExportExcel.Content = null;
                    btnExportExcel.Background = images;
                    break;
                case ("btnAboutUs"):
                    btnAboutUs.Content = null;
                    btnAboutUs.Background = images;
                    break;
                case ("btnContactUs"):
                    btnContactUs.Content = null;
                    btnContactUs.Background = images;
                    break;
                default:
                    break;
            }
            if ((sender as Button).Content == null)
            {
                images = (ImageBrush)(sender as Button).Background;
                (sender as Button).Background = Brushes.Goldenrod;
                Process = (sender as Button).Name;
            }
            switch ((sender as Button).Name)
            {
                case ("btnImportFromTally"):
                    (sender as Button).Content = "Import\n Tally.";
                    spExcell = null;
                    spGenerateExcel = null;
                    spOpenmiracleExport = null;
                    break;
                case ("btnImportFromExcel"):
                    (sender as Button).Content = "Import\n Excel.";
                    spTally = null;
                    spGenerateExcel = null;
                    spOpenmiracleExport = null;
                    break;
                case ("btnExcellFormat"):
                    (sender as Button).Content = "Generate\n Format";
                    spTally = null;
                    spExcell = null;
                    spOpenmiracleExport = null;
                    break;
                case ("btnExportExcel"):
                    (sender as Button).Content = "Export\n Excel";
                    spTally = null;
                    spExcell = null;
                    break;
                case ("btnAboutUs"):
                    (sender as Button).Content = "About\n   Us";
                    spTally = null;
                    spExcell = null;
                    spGenerateExcel = null;
                    spOpenmiracleExport = null;
                    if (grdMain.Children.OfType<AboutUs>().ToList().Count == 0)
                    {
                        AboutUs obj = new AboutUs();
                        grdMain.Children.Add(obj);
                    }
                    break;
                case ("btnContactUs"):
                    (sender as Button).Content = "Contact\n    Us";
                    spTally = null;
                    spExcell = null;
                    spGenerateExcel = null;
                    spOpenmiracleExport = null;
                    if (grdMain.Children.OfType<ContactUs>().ToList().Count == 0)
                    {
                        ContactUs obj = new ContactUs();
                        grdMain.Children.Add(obj);
                    }
                    break;
                default:
                    break;
            }

        }

        private void button8_Click(object sender, RoutedEventArgs e)
        {
            grdMain.Children.OfType<DataGrid>().ToList().ForEach(b => grdMain.Children.Remove(b));
            spGenerateExcel = null;
            spExcell = null;
            spOpenmiracleExport = null;
            spTally = null;
            mainmaenu.Visibility = Visibility.Hidden;
            LoginUser loginuser = new LoginUser(propertiess);
            string ss = loginuser.txtUserName.Text;
            grdMain.Children.Add(loginuser);
        }


    }
}

