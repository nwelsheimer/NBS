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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections.ObjectModel;
using WPFPieChart;
using System.Data;
using Entity;
using System.ComponentModel;
using MiracleI.BLL;
using System.Threading;
using System.Threading.Tasks;
using MiracleI.PlotterFill;
using Openmiracle.MiracleIChart.Charts.Navigation;
using Openmiracle.MiracleIChart.DataSources;
using Openmiracle.MiracleIChart.PointMarkers;
using Openmiracle.MiracleIChart;
using System.Windows.Controls.Primitives;

namespace MiracleI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
           
            #region SelectCompanyName

            lblCompanyName.Content = objCallSP.GetCompanyNameDetails();

            #endregion

            #region ColorSelector
            List<DataTable> objColorList = objCallSP.GetBarChartColorDetails(CategoryInfo);
            dtblColor = (objColorList[0].Rows.Count != 0) ? (DataTable)objColorList[0].Rows[0].Table : null;
            #endregion

            #region CatagoryInfoPropertySet
            CategoryInfo.DateFrom = Convert.ToDateTime(objCallSP.GetFromDate());
            CategoryInfo.DateTo = Convert.ToDateTime(objCallSP.GetToDate());
            CategoryInfo.PropertyChanged += new PropertyChangedEventHandler(CategoryInfo_PropertyChanged);
            #endregion

            #region PiChartFill
            ObservableCollection<AssetClass> classes = new ObservableCollection<AssetClass>(AssetClass.ConstructTestData(CategoryInfo));
            piePlotter.DataContext = classes;
            #endregion

            #region PieChartTableFill
            List<DataTable> objList = objCallSP.GetPieChartTableDetails(CategoryInfo);
            DataTable dtblNatureTable = (DataTable)objList[0].Rows[0].Table;
            double dblTotalValue = 0;
            tbkpiChartError1.Visibility = System.Windows.Visibility.Hidden;
            dblTotalValue = dblTotalValue + classes[0].Value + dblTotalValue + classes[1].Value + dblTotalValue + classes[2].Value + dblTotalValue + classes[3].Value;
            ObservableCollection<OverAllClass> OverAll = null;
            for (int i = 0; i < classes.Count; i++)
            {
                if (classes[i].Value != 0)
                {
                    OverAll = new ObservableCollection<OverAllClass>(OverAllClass.ConstructTest(classes[i].Class, dtblNatureTable));
                    tbkpiChartError1.Visibility = System.Windows.Visibility.Hidden;
                    lblOverAllName.Content = classes[i].Class;
                    lblOverAllName.Visibility = (classes[i].Value == dblTotalValue) ? System.Windows.Visibility.Visible : System.Windows.Visibility.Hidden;
                    break;
                }
                tbkpiChartError1.Visibility = System.Windows.Visibility.Visible;
            }
            lstOverAll.DataContext = OverAll;
            #endregion

            #region TopBarChartFill
            List<DataTable> objTopBoxList = objCallSP.GetTopBarChartDetails();
            List<Bar> _bar = new List<Bar>();
            for (int i = 0; i < objTopBoxList[0].Rows.Count; i++)
            {
                _bar.Add(new Bar() { BarName = objTopBoxList[0].Rows[i][0].ToString(), Value = Convert.ToDouble(objTopBoxList[0].Rows[i][1]) });
            }
            icBarchart.DataContext = new RecordCollection(_bar);
            #endregion

            #region AccountGroupBarChart
            List<DataTable> objAccountGroupList = objCallSP.GetAccountGroupBarChartDetails();
            DataTable dtblAccountGroup = (objAccountGroupList[0].Rows.Count != 0) ? (DataTable)objAccountGroupList[0].Rows[0].Table : null;
            List<string> lstAccountGroupName = (dtblAccountGroup != null) ? dtblAccountGroup.AsEnumerable().Select(s => s.Field<string>("accountGroupName")).ToList<string>() : null;
            cmbAccountGroup.ItemsSource = lstAccountGroupName;
            tbkAccountGroupBal.Text = (lstAccountGroupName == null) ? "Statistics Not Available" : "Balance Amount";
            #endregion
            
        }
        public event OnWorkerMethodCompleteDelegate OnWorkerComplete;

        #region Variables
        /// <summary>
        /// variable declaration part
        /// </summary>
        CallSP objCallSP = new CallSP();
        public static DataTable dtblColor;
        public CategoryInfo CategoryInfo = new CategoryInfo();
        Random random = new Random();
        bool isClear = false;
        bool isControllPressed = false;
        Thread t;
        public delegate void OnWorkerMethodCompleteDelegate(List<PlotterFillData> LstPlotterDataCollection);
        private ProgressBarWindow pbw = null;
        #endregion
       
        #region Property
        public ObservableCollection<CheckedListItem<CheckBoxItems>> ListItems { get; set; }
        #endregion
        
        #region Function
        /// <summary>
        /// Function for Clear Main Category
        /// </summary>
        private void FunctionClearMainCategory()
        {
            try
            {
            cbxMainCatogry.Items.Clear();
            cbxMainCatogry.Items.Add("Overall Statistics");
            cbxMainCatogry.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("MW:01" + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        /// <summary>
        /// Function for Clear SubCategory
        /// </summary>
        private void FunctionClearSubCategory()
        {
            try
            {
            cbxSubCatogry.Items.Clear();
            cbxSubCatogry.SelectedIndex = 0;
            cbxSubCatogry.IsEnabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("MW:02" + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        /// <summary>
        /// Function for Desabling Sub Catagory ComboBox
        /// </summary>
        private void FunctionDesablingSubCatagoryCombo()
        {
            try
            {
                cbxSubCatogry.Items.Clear();
                cbxSubCatogry.IsEnabled = false;
            
            }
            catch (Exception ex)
            {
                MessageBox.Show("MW:03" + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        /// <summary>
        /// Function for GetPlotterData
        /// </summary>
        private void FunctionGetPlotterData()
        {
            MemoryManagement.FlushMemory();
            List<PlotterFillData> LstPlotterDataCollection = new List<PlotterFillData>();
            CallSP spCall = new CallSP();
            List<DataTable> lstPlotterData = spCall.GetPlotterFill(CategoryInfo);
            if (lstPlotterData.Count > 0)
            {
                for (int j = 0; j < lstPlotterData.Count; j++)
                {
                    PlotterFillData DataCollection = new PlotterFillData();
                    for (int i = 0; i < lstPlotterData[j].Rows.Count; i++)
                    {
                        DataCollection.Add(new QueryFill(Convert.ToDouble(lstPlotterData[j].Rows[i][1]), Convert.ToDateTime(lstPlotterData[j].Rows[i][0]), Convert.ToString(lstPlotterData[j].Rows[i][2]).Trim()));
                    }
                    LstPlotterDataCollection.Add(DataCollection);
                }
            }
            OnWorkerComplete(LstPlotterDataCollection);
        }
        /// <summary>
        /// Function for Clear Plotter
        /// </summary>
        private void FunctionClearPlotter()
        {
            try
            {
            CategoryInfo.CheckedValueName = string.Empty;
            plotter.Children.RemoveAll(typeof(LineGraph));
            plotter.Children.RemoveAll(typeof(ElementMarkerPointsGraph));
            MemoryManagement.FlushMemory();
            }
            catch (Exception ex)
            {
                MessageBox.Show("MW:05" + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        /// <summary>
        /// Function for Fill ListBox
        /// </summary>
        private void FunctionListBoxFill()
        {
            List<DataTable> objList = objCallSP.GetListDetails(CategoryInfo);
            ListItems = new ObservableCollection<CheckedListItem<CheckBoxItems>>();
            lbxCheckBox.Dispatcher.Invoke(
            new Action(
            () =>
            {
                ListItems.Clear();
                for (int i = 0; i < objList[0].Rows.Count; i++)
                {
                    if (i == 0)
                    {
                        tiList.Header = objList[0].Rows[i][0].ToString();
                    }
                    else
                    {
                        ListItems.Add(new CheckedListItem<CheckBoxItems>(new CheckBoxItems() { Name = objList[0].Rows[i][0].ToString(), ToolTips = (objList[0].Columns.Count > 1) ? objList[0].Rows[i][1].ToString() : null }));
                    }
                }
                lbxCheckBox.ItemsSource = ListItems;
                if (lbxCheckBox.Items.Count > 0)
                {
                    isClear = true;
                    tiList.IsEnabled = true;
                    tcListAndChart.SelectedIndex = 0;
                }
                else
                {
                    tiList.IsEnabled = false;
                    tcListAndChart.SelectedIndex = 1;
                    tiList.Header = "List";
                }
            }));
            OnWorkerComplete(null);
        }
        /// <summary>
        /// Function for  Identification of Module
        /// </summary>
        private void FunctionModuleIdentification(string strModuleName)
        {

            lblBank.Foreground = (strModuleName == "Bank") ? Brushes.White : Brushes.Gray;
            lblCustomer.Foreground = (strModuleName == "Customer") ? Brushes.White : Brushes.Gray;
            lblFinance.Foreground = (strModuleName == "Finance") ? Brushes.White : Brushes.Gray;
            lblPartyBalance.Foreground = (strModuleName == "Party Balance") ? Brushes.White : Brushes.Gray;
            lblPayroll.Foreground = (strModuleName == "Payroll") ? Brushes.White : Brushes.Gray;
            lblProduct.Foreground = (strModuleName == "Product") ? Brushes.White : Brushes.Gray;
            lblPurchase.Foreground = (strModuleName == "Purchase") ? Brushes.White : Brushes.Gray;
            lblSales.Foreground = (strModuleName == "Sales") ? Brushes.White : Brushes.Gray;
            lblSupplier.Foreground = (strModuleName == "Supplier") ? Brushes.White : Brushes.Gray;
           
        }
        /// <summary>
        /// Function OnWorkerMethodStart
        /// </summary>
        private void OnWorkerMethodStart(string Function)
        {
                MemoryManagement.FlushMemory();
                OnWorkerComplete += new OnWorkerMethodCompleteDelegate(OnWorkerMethodComplete);
                if (Function == "ListFill")
                {
                    ThreadStart tStart = new ThreadStart(FunctionListBoxFill);
                    t = new Thread(tStart);
                    if (!t.IsAlive)
                    {
                        t.Start();
                    }

                }
                else if (Function == "PlotterData")
                {
                    ThreadStart tStart = new ThreadStart(FunctionGetPlotterData);
                    t = new Thread(tStart);
                    if (!t.IsAlive)
                    {
                        t.Start();
                    }
                }
                pbw = new ProgressBarWindow();
                pbw.Owner = this;
                pbw.ShowDialog();
          
        }
        /// <summary>
        /// Function for Display Dates
        /// </summary>
        private void FunctionDisplayDates()
        {
            try
            {
            calendar.DisplayDateStart = new DateTime(Convert.ToDateTime(objCallSP.GetFromDate()).Year, Convert.ToDateTime(objCallSP.GetFromDate()).Month, Convert.ToDateTime(objCallSP.GetFromDate()).Day);
            calendar.DisplayDateEnd = new DateTime(Convert.ToDateTime(objCallSP.GetLastDate()).Year, Convert.ToDateTime(objCallSP.GetLastDate()).Month, Convert.ToDateTime(objCallSP.GetLastDate()).Day);
            }
            catch (Exception ex)
            {
                MessageBox.Show("MW:09" + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
         }
        /// <summary>
        /// Function OnWorkerMethodComplete
        /// </summary>
        private void OnWorkerMethodComplete(List<PlotterFillData> LstPlotterDataCollection)
        {
                pbw.Dispatcher.Invoke(System.Windows.Threading.DispatcherPriority.Normal,
                new Action(
                delegate()
                {

                    if (LstPlotterDataCollection != null && LstPlotterDataCollection.Count > 0)
                    {
                        this.Cursor = Cursors.Wait;
                        if (CategoryInfo.CheckedValueName != "Overall Statistics" && CategoryInfo.CheckedValueName != string.Empty)
                        {
                            FunctionSilgleLineGraph(CategoryInfo.CheckedValueName, LstPlotterDataCollection);
                        }
                        else if (CategoryInfo.SubCatagoryName != "Overall Statistics" && CategoryInfo.SubCatagoryName != string.Empty)
                        {
                            FunctionSilgleLineGraph(CategoryInfo.SubCatagoryName, LstPlotterDataCollection);
                        }
                        else if (CategoryInfo.CatagoryName != "Overall Statistics" && CategoryInfo.CatagoryName != string.Empty)
                        {
                            FunctionSilgleLineGraph(CategoryInfo.CatagoryName, LstPlotterDataCollection);
                        }
                        else if (CategoryInfo.ModuleName != "Overall Statistics" && CategoryInfo.ModuleName != string.Empty)
                        {
                            FunctionSilgleLineGraph(CategoryInfo.ModuleName + " Overall Statistics", LstPlotterDataCollection);
                        }
                        else
                        {
                            FunctionSilgleLineGraph("Profit & Loss statistics", LstPlotterDataCollection);
                        }
                        this.Cursor = Cursors.Arrow;
                    }

                    pbw.Close();
                    t.Abort();
                }

                ));
                MemoryManagement.FlushMemory();
        }
        /// <summary>
        /// Function for SilgleLineGraph
        /// </summary>
        private void FunctionSilgleLineGraph(string ValueName, List<PlotterFillData> LstPlotterDataCollection)
        {
            
            int inI = 0;
            try
            {
                string ItemValueName = ValueName;
                foreach (PlotterFillData item in LstPlotterDataCollection)
                {
                    string strValue = string.Empty;
                    if (CategoryInfo.SplitValue.Count() > 1)
                    {
                        ItemValueName = ValueName + " " + CategoryInfo.SplitValue[inI].Trim();
                        strValue = CategoryInfo.SplitValue[inI].Trim();
                        inI++;
                    }
                    if (item != null && item.Count > 0)
                    {
                        PenDescription pDescription = new PenDescription(ItemValueName);
                        var ds = new EnumerableDataSource<QueryFill>(item);
                        ds.SetXMapping(x => dateAxis.ConvertToDouble(x.Date));
                        ds.SetYMapping(y => y.Value);

                        var tempDataSource = new EnumerableDataSource<QueryFill>(item);
                        tempDataSource.SetYMapping(y => y.Value);
                        string MyValueName = (CategoryInfo.CheckedValueName == string.Empty) ? "Overall Statistics" : CategoryInfo.CheckedValueName;
                        if (CategoryInfo.TypeName == "Month")
                        {
                            tempDataSource.AddMapping(ShapeElementPointMarker.ToolTipTextProperty, y => string.Format("{0}\n{1}\n{2}\n\n{3}", MyValueName, strValue.Trim(), y.Date.ToString("MMM-yyyy"), y.PopUp.Trim()).Trim());
                        }
                        else
                        {
                            tempDataSource.AddMapping(ShapeElementPointMarker.ToolTipTextProperty, y => string.Format("{0}\n{1}\n{2}\n\n{3}", MyValueName, strValue.Trim(), y.Date.ToString("dd-MMM-yyyy"), y.PopUp.Trim()).Trim());
                        }

                        CompositeDataSource compositeDataSource1 = new
                          CompositeDataSource(ds, tempDataSource);

                        SolidColorBrush myBrush = new SolidColorBrush(Color.FromRgb((byte)random.Next(70, 255), (byte)random.Next(70, 255), (byte)random.Next(70, 255)));
                        Pen pen = new Pen(myBrush, 2);

                        CircleElementPointMarker cpMarker = new CircleElementPointMarker { Size = 3.5, Fill = myBrush, Brush = (Brush)myBrush };

                        plotter.AddLineGraph(compositeDataSource1, pen, cpMarker, pDescription);

                        //  CursorCoordinateGraph ccg = new CursorCoordinateGraph();
                        // ccg.XTextMapping = x => dateAxis.ConvertFromDouble(x).ToString("MMM-yyyy");
                        // plotter.Children.Add(ccg);
                        plotter.Viewport.FitToView();

                    }
                    MemoryManagement.FlushMemory();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("MW:11" + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        #endregion

        #region Event
        /// <summary>
        /// br_MouseDown Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void br_MouseDown(object sender, MouseButtonEventArgs e)
        {
            TextBlock_MouseDown(sender, e);
        }
        /// <summary>
        /// TextBlock_MouseDown Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            double dblVal = (e.OriginalSource.ToString() == "System.Windows.Controls.TextBlock") ? Convert.ToDouble((sender as System.Windows.Controls.TextBlock).Text.ToString()) : Convert.ToDouble((sender as System.Windows.Controls.Border).Height.ToString());
            if (dblVal != 0)
            {
                CategoryInfo.ModuleName = (e.OriginalSource.ToString() == "System.Windows.Controls.TextBlock") ? (sender as System.Windows.Controls.TextBlock).ToolTip.ToString() : (sender as System.Windows.Controls.Border).ToolTip.ToString();
                FunctionModuleIdentification(CategoryInfo.ModuleName);
                if (CategoryInfo.ModuleName == "Bank")
                {
                    FunctionClearMainCategory();
                    cbxMainCatogry.Items.Add("Deposit & Withdrawal");
                    cbxMainCatogry.Items.Add("PDC Payable");
                    cbxMainCatogry.Items.Add("PDC Receivable");
                    cbxMainCatogry.Items.Add("Bank Reconciliation");
                }
                else if (CategoryInfo.ModuleName == "Customer")
                {
                    FunctionClearMainCategory();
                    cbxMainCatogry.Items.Add("Area");
                    cbxMainCatogry.Items.Add("Bill By Bill");
                    cbxMainCatogry.Items.Add("Transactions");
                    cbxMainCatogry.Items.Add("Standard Rate");
                    cbxMainCatogry.Items.Add("Pricing Level");
                    cbxMainCatogry.Items.Add("Tax Free Sales");
                    cbxMainCatogry.Items.Add("Free Sales");
                    cbxMainCatogry.Items.Add("Credit Sales");
                    cbxMainCatogry.Items.Add("Tax Paid");
                    cbxMainCatogry.Items.Add("Bill Discount");
                    cbxMainCatogry.Items.Add("Customer Balance");
                }
                else if (CategoryInfo.ModuleName == "Supplier")
                {
                    FunctionClearMainCategory();
                    cbxMainCatogry.Items.Add("Area");
                    cbxMainCatogry.Items.Add("Bill By Bill");
                    cbxMainCatogry.Items.Add("Transactions");
                    cbxMainCatogry.Items.Add("Bill Discount");
                    cbxMainCatogry.Items.Add("Tax Free Purchase");
                    cbxMainCatogry.Items.Add("Free Purchase");
                    cbxMainCatogry.Items.Add("Credit Purchase");
                    cbxMainCatogry.Items.Add("Tax Paid");
                    cbxMainCatogry.Items.Add("Supplier Balance");
                }
                else if (CategoryInfo.ModuleName == "Product")
                {
                    FunctionClearMainCategory();
                    cbxMainCatogry.Items.Add("Product Group");
                    cbxMainCatogry.Items.Add("Active Products");
                    cbxMainCatogry.Items.Add("Fast Moving Products");
                    cbxMainCatogry.Items.Add("Godown");
                    cbxMainCatogry.Items.Add("Brand");
                    cbxMainCatogry.Items.Add("Model");
                    cbxMainCatogry.Items.Add("Tax Details");
                    cbxMainCatogry.Items.Add("Rate");
                    cbxMainCatogry.Items.Add("Frequently Rate Changing");
                    cbxMainCatogry.Items.Add("Raw Materials");
                    cbxMainCatogry.Items.Add("Finished Goods");
                    cbxMainCatogry.Items.Add("Batch");
                    cbxMainCatogry.Items.Add("Stock Details");
                    cbxMainCatogry.Items.Add("Product On Basis Of Expiry Date");
                    cbxMainCatogry.Items.Add("Transactions");
                    cbxMainCatogry.Items.Add("Free Sale Product");
                    cbxMainCatogry.Items.Add("Unused Products");
                    cbxMainCatogry.Items.Add("Stock Out");
                }
                else if (CategoryInfo.ModuleName == "Party Balance")
                {
                    FunctionClearMainCategory();
                    cbxMainCatogry.Items.Add("Payable & Receivable");
                    cbxMainCatogry.Items.Add("Paid & Received");
                    cbxMainCatogry.Items.Add("Bill Allocation");
                }
                else if (CategoryInfo.ModuleName == "Sales")
                {
                    FunctionClearMainCategory();
                    cbxMainCatogry.Items.Add("Sales Order");
                    cbxMainCatogry.Items.Add("Delivery Note");
                    cbxMainCatogry.Items.Add("Sales Quotation");
                    cbxMainCatogry.Items.Add("Rejection In");
                    cbxMainCatogry.Items.Add("Sales Invoice");
                    cbxMainCatogry.Items.Add("Sales Return");

                }
                else if (CategoryInfo.ModuleName == "Purchase")
                {
                    FunctionClearMainCategory();
                    cbxMainCatogry.Items.Add("Purchase Order");
                    cbxMainCatogry.Items.Add("Material Receipt");
                    cbxMainCatogry.Items.Add("Rejection Out");
                    cbxMainCatogry.Items.Add("Purchase Invoice");
                    cbxMainCatogry.Items.Add("Purchase Return");
                }
                else if (CategoryInfo.ModuleName == "Payroll")
                {
                    FunctionClearMainCategory();
                    cbxMainCatogry.Items.Add("Designation");
                    cbxMainCatogry.Items.Add("Receive Salary By Bank");
                    cbxMainCatogry.Items.Add("Receive Wage By Bank");
                    cbxMainCatogry.Items.Add("Advance Received");
                    cbxMainCatogry.Items.Add("Bonus Amount");
                    cbxMainCatogry.Items.Add("Deduction Amount");
                    cbxMainCatogry.Items.Add("LOP");
                    cbxMainCatogry.Items.Add("Daily Wage");
                    cbxMainCatogry.Items.Add("Monthly Salary");
                    cbxMainCatogry.Items.Add("Attendance");
                    cbxMainCatogry.Items.Add("Salesman");
                }
                else if (CategoryInfo.ModuleName == "Finance")
                {
                    FunctionClearMainCategory();
                    cbxMainCatogry.Items.Add("Tax Details");
                    cbxMainCatogry.Items.Add("Exchange Rate");
                    cbxMainCatogry.Items.Add("Account Ledger");
                    cbxMainCatogry.Items.Add("Account Group");
                    cbxMainCatogry.Items.Add("Budget");
                    cbxMainCatogry.Items.Add("Trial Balance");
                    cbxMainCatogry.Items.Add("Balance Sheet");
                    cbxMainCatogry.Items.Add("Profit And Loss");
                    cbxMainCatogry.Items.Add("Cash Flow");
                    cbxMainCatogry.Items.Add("Fund Flow");
                    cbxMainCatogry.Items.Add("Daily Report");
                }
                CategoryInfo.TypeName = CategoryInfo.TypeName;
            }

        }
        /// <summary>
        /// Button btnClose_Click Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }
        /// <summary>
        /// Button btnMinimize_Click Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = System.Windows.WindowState.Minimized;
        }
        /// <summary>
        /// Grid grdTitle_MouseDown Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void grdTitle_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }
        /// <summary>
        /// CheckBox cbxMain_Checked Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbxMain_Checked(object sender, RoutedEventArgs e)
        {
            if (isClear)
            {
                FunctionClearPlotter();
                isClear = false;
            }
            CategoryInfo.CheckedValueName = ((sender as CheckBox).ToolTip != null) ? (sender as CheckBox).Content.ToString() + " | " + (sender as CheckBox).ToolTip.ToString() : (sender as CheckBox).Content.ToString();

        }
        /// <summary>
        /// CheckBox cbxMain_Unchecked Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbxMain_Unchecked(object sender, RoutedEventArgs e)
        {
            if (CategoryInfo.SplitValue.Count() == 1)
            {
                var lineToRemove = ((sender as CheckBox).ToolTip == null) ? plotter.Children.OfType<LineGraph>().Where(x => x.Description.ToString() == (sender as CheckBox).Content.ToString()).Max() : plotter.Children.OfType<LineGraph>().Where(x => x.Description.ToString() == (sender as CheckBox).Content.ToString() + " | " + (sender as CheckBox).ToolTip.ToString()).Max();
                if (lineToRemove != null)
                {
                    int a = plotter.Children.IndexOf(lineToRemove);
                    plotter.Children.Remove(lineToRemove);
                    plotter.Children.RemoveAt(a++);
                }
            }
            else
            {
                foreach (string word in CategoryInfo.SplitValue)
                {
                    var lineToRemove = ((sender as CheckBox).ToolTip == null) ? plotter.Children.OfType<LineGraph>().Where(x => x.Description.ToString() == (sender as CheckBox).Content.ToString() + " " + word.Trim()).Max() : plotter.Children.OfType<LineGraph>().Where(x => x.Description.ToString() == (sender as CheckBox).Content.ToString() + " | " + (sender as CheckBox).ToolTip.ToString() + " " + word.Trim()).Max();
                    if (lineToRemove != null)
                    {
                        int a = plotter.Children.IndexOf(lineToRemove);
                        plotter.Children.Remove(lineToRemove);
                        plotter.Children.RemoveAt(a++);
                    }
                }
            }
        }
        /// <summary>
        /// piePlotter_MouseUp Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void piePlotter_MouseUp(object sender, MouseButtonEventArgs e)
        {
            List<DataTable> objList = objCallSP.GetPieChartTableDetails(CategoryInfo);
            DataTable dtblNatureTable = (DataTable)objList[0].Rows[0].Table;
            tbkpiChartError1.Visibility = System.Windows.Visibility.Hidden;
            if (ScottLogic.Controls.PieChart.PiePlotter.strMainPiesColor == "#FF8A00D1")
            {
                ObservableCollection<OverAllClass> OverAll = new ObservableCollection<OverAllClass>(OverAllClass.ConstructTest("Expence", dtblNatureTable));
                lstOverAll.DataContext = OverAll;
            }
            else if (ScottLogic.Controls.PieChart.PiePlotter.strMainPiesColor == "#FF5AB401")
            {
                ObservableCollection<OverAllClass> OverAll = new ObservableCollection<OverAllClass>(OverAllClass.ConstructTest("Income", dtblNatureTable));
                lstOverAll.DataContext = OverAll;
            }
            else if (ScottLogic.Controls.PieChart.PiePlotter.strMainPiesColor == "#FFFF9600")
            {
                ObservableCollection<OverAllClass> OverAll = new ObservableCollection<OverAllClass>(OverAllClass.ConstructTest("Asset", dtblNatureTable));
                lstOverAll.DataContext = OverAll;
            }
            else if (ScottLogic.Controls.PieChart.PiePlotter.strMainPiesColor == "#FFDA0077")
            {
                ObservableCollection<OverAllClass> OverAll = new ObservableCollection<OverAllClass>(OverAllClass.ConstructTest("Liability", dtblNatureTable));
                lstOverAll.DataContext = OverAll;
            }
        }
        /// <summary>
        /// CheckBox cbxMainCatogry_SelectionChanged Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbxMainCatogry_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            CategoryInfo.CatagoryName = (cbxMainCatogry.SelectedValue != null) ? cbxMainCatogry.SelectedValue.ToString() : "Overall Statistics";

            if (CategoryInfo.ModuleName == "Payroll")
            {
                if (Convert.ToString(cbxMainCatogry.SelectedValue) == "Salesman")
                {
                    FunctionClearSubCategory();
                    cbxSubCatogry.Items.Add("Overall Statistics");
                    cbxSubCatogry.Items.Add("Performance");
                }
                else if (Convert.ToString(cbxMainCatogry.SelectedValue) == "Daily Wage")
                {
                    FunctionClearSubCategory();
                    cbxSubCatogry.Items.Add("Overall Statistics");
                    cbxSubCatogry.Items.Add("Salary Status");
                }
                else if (Convert.ToString(cbxMainCatogry.SelectedValue) == "Monthly Salary")
                {
                    FunctionClearSubCategory();
                    cbxSubCatogry.Items.Add("Overall Statistics");
                    cbxSubCatogry.Items.Add("Salary Package");
                    cbxSubCatogry.Items.Add("Salary Status");
                }
                else
                {
                    FunctionDesablingSubCatagoryCombo();
                }
            }
            else if (CategoryInfo.ModuleName == "Bank")
            {
                if (Convert.ToString(cbxMainCatogry.SelectedValue) == "PDC Payable")
                {
                    FunctionClearSubCategory();
                    cbxSubCatogry.Items.Add("Overall Statistics");
                    cbxSubCatogry.Items.Add("Party");
                    cbxSubCatogry.Items.Add("Bank");
                }
                else if (Convert.ToString(cbxMainCatogry.SelectedValue) == "PDC Receivable")
                {
                    FunctionClearSubCategory();
                    cbxSubCatogry.Items.Add("Overall Statistics");
                    cbxSubCatogry.Items.Add("Party");
                    cbxSubCatogry.Items.Add("Bank");
                }
                else if (Convert.ToString(cbxMainCatogry.SelectedValue) == "Bank Reconciliation")
                {
                    FunctionClearSubCategory();
                    cbxSubCatogry.Items.Add("Overall Statistics");
                    cbxSubCatogry.Items.Add("Reconciled");
                    cbxSubCatogry.Items.Add("Unreconciled");
                }
                else
                {
                    FunctionDesablingSubCatagoryCombo();
                }
            }
            else if (CategoryInfo.ModuleName == "Finance")
            {
                if (Convert.ToString(cbxMainCatogry.SelectedValue) == "Tax Details")
                {
                    FunctionClearSubCategory();
                    cbxSubCatogry.Items.Add("Overall Statistics");
                    cbxSubCatogry.Items.Add("Bill Wise Tax");
                    cbxSubCatogry.Items.Add("Product Wise Tax");
                }
                else if (Convert.ToString(cbxMainCatogry.SelectedValue) == "Cash Flow")
                {
                    FunctionClearSubCategory();
                    cbxSubCatogry.Items.Add("Overall Statistics");
                    cbxSubCatogry.Items.Add("In Flow");
                    cbxSubCatogry.Items.Add("Out Flow");
                }
                else if (Convert.ToString(cbxMainCatogry.SelectedValue) == "Budget")
                {
                    FunctionClearSubCategory();
                    cbxSubCatogry.Items.Add("Select Budget");
                    List<DataTable> objList = objCallSP.GetBudgetNameFill();
                    if (objList[0].Rows.Count > 0)
                    {
                        foreach (DataRow item in objList[0].Rows)
                        {
                            cbxSubCatogry.Items.Add(item[0].ToString());
                        }
                    }
                }
                else
                {
                    FunctionDesablingSubCatagoryCombo();
                }
            }
            else if (CategoryInfo.ModuleName == "Customer")
            {
                if (Convert.ToString(cbxMainCatogry.SelectedValue) == "Transactions")
                {
                    FunctionClearSubCategory();
                    cbxSubCatogry.Items.Add("Overall Statistics");
                    cbxSubCatogry.Items.Add("Sales");
                    cbxSubCatogry.Items.Add("Sales Order");
                    cbxSubCatogry.Items.Add("Sales Quotation");
                    cbxSubCatogry.Items.Add("Delivery Note");
                    cbxSubCatogry.Items.Add("Sales Return");
                    cbxSubCatogry.Items.Add("Rejection In");
                }
                else
                {
                    FunctionDesablingSubCatagoryCombo();
                }
            }
            else if (CategoryInfo.ModuleName == "Supplier")
            {
                if (Convert.ToString(cbxMainCatogry.SelectedValue) == "Transactions")
                {
                    FunctionClearSubCategory();
                    cbxSubCatogry.Items.Add("Overall Statistics");
                    cbxSubCatogry.Items.Add("Purchase");
                    cbxSubCatogry.Items.Add("Purchase Order");
                    cbxSubCatogry.Items.Add("Material Receipt");
                    cbxSubCatogry.Items.Add("Purchase Return");
                    cbxSubCatogry.Items.Add("Rejection Out");
                }
                else
                {
                    FunctionDesablingSubCatagoryCombo();
                }
            }
            else if (CategoryInfo.ModuleName == "Sales")
            {
                if (Convert.ToString(cbxMainCatogry.SelectedValue) == "Sales Order")
                {
                    FunctionClearSubCategory();
                    cbxSubCatogry.Items.Add("Overall Statistics");
                    cbxSubCatogry.Items.Add("Order Recieved");
                    cbxSubCatogry.Items.Add("Over Due");
                    cbxSubCatogry.Items.Add("Cancelled");
                    cbxSubCatogry.Items.Add("Pending");
                }
                else if (Convert.ToString(cbxMainCatogry.SelectedValue) == "Delivery Note")
                {
                    FunctionClearSubCategory();
                    cbxSubCatogry.Items.Add("Overall Statistics");
                    cbxSubCatogry.Items.Add("Against Quotation");
                    cbxSubCatogry.Items.Add("Against Order");
                    cbxSubCatogry.Items.Add("Pricing Level");
                }
                else if (Convert.ToString(cbxMainCatogry.SelectedValue) == "Sales Quotation")
                {
                    FunctionClearSubCategory();
                    cbxSubCatogry.Items.Add("Overall Statistics");
                    cbxSubCatogry.Items.Add("Approved");
                    cbxSubCatogry.Items.Add("Pending");
                    cbxSubCatogry.Items.Add("Pricing Level");
                }
                else if (Convert.ToString(cbxMainCatogry.SelectedValue) == "Rejection In")
                {
                    FunctionClearSubCategory();
                    cbxSubCatogry.Items.Add("Overall Statistics");
                    cbxSubCatogry.Items.Add("Pricing Level");
                    cbxSubCatogry.Items.Add("Godown");
                    cbxSubCatogry.Items.Add("Area");
                }
                else if (Convert.ToString(cbxMainCatogry.SelectedValue) == "Sales Invoice")
                {
                    FunctionClearSubCategory();
                    cbxSubCatogry.Items.Add("Overall Statistics");
                    cbxSubCatogry.Items.Add("Against Order");
                    cbxSubCatogry.Items.Add("Against Quotation");
                    cbxSubCatogry.Items.Add("Against DeliveryNote");
                    cbxSubCatogry.Items.Add("Pricing Level");
                    cbxSubCatogry.Items.Add("Standard Rate");
                    cbxSubCatogry.Items.Add("Taxable Sale");
                    cbxSubCatogry.Items.Add("Discount");
                    cbxSubCatogry.Items.Add("Counter Sale");
                    cbxSubCatogry.Items.Add("Area");
                    cbxSubCatogry.Items.Add("Additional Cost");
                }
                else if (Convert.ToString(cbxMainCatogry.SelectedValue) == "Sales Return")
                {
                    FunctionClearSubCategory();
                    cbxSubCatogry.Items.Add("Overall Statistics");
                    cbxSubCatogry.Items.Add("Product");
                    cbxSubCatogry.Items.Add("Godown");
                    cbxSubCatogry.Items.Add("Area");
                }
                else
                {
                    FunctionDesablingSubCatagoryCombo();
                }
            }
            else if (CategoryInfo.ModuleName == "Product")
            {
                if (Convert.ToString(cbxMainCatogry.SelectedValue) == "Godown")
                {
                    FunctionClearSubCategory();
                    cbxSubCatogry.Items.Add("Overall Statistics");
                    cbxSubCatogry.Items.Add("Sale");
                    cbxSubCatogry.Items.Add("Purchase");
                }
                else if (Convert.ToString(cbxMainCatogry.SelectedValue) == "Brand")
                {
                    FunctionClearSubCategory();
                    cbxSubCatogry.Items.Add("Overall Statistics");
                    cbxSubCatogry.Items.Add("Sold");
                    cbxSubCatogry.Items.Add("Purchase");
                    cbxSubCatogry.Items.Add("Sales Return");
                    cbxSubCatogry.Items.Add("Purchase Return");
                }
                else if (Convert.ToString(cbxMainCatogry.SelectedValue) == "Stock Details")
                {
                    FunctionClearSubCategory();
                    cbxSubCatogry.Items.Add("Overall Statistics");
                    cbxSubCatogry.Items.Add("Current Stock");
                    cbxSubCatogry.Items.Add("Stock Value");
                    cbxSubCatogry.Items.Add("Minimum Level");
                    cbxSubCatogry.Items.Add("Maximum Level");
                    cbxSubCatogry.Items.Add("Re-order Level");
                    cbxSubCatogry.Items.Add("Negative Stock");
                }
                else if (Convert.ToString(cbxMainCatogry.SelectedValue) == "Transactions")
                {
                    FunctionClearSubCategory();
                    cbxSubCatogry.Items.Add("Overall Statistics");
                    cbxSubCatogry.Items.Add("Sales");
                    cbxSubCatogry.Items.Add("Purchase");
                    cbxSubCatogry.Items.Add("Sales Return");
                    cbxSubCatogry.Items.Add("Purchase Return");
                    cbxSubCatogry.Items.Add("Sales Order");
                    cbxSubCatogry.Items.Add("Purchase Order");
                    cbxSubCatogry.Items.Add("Rejection In");
                    cbxSubCatogry.Items.Add("Rejection Out");
                    cbxSubCatogry.Items.Add("Material Receipt");
                    cbxSubCatogry.Items.Add("Delivery Note");
                    cbxSubCatogry.Items.Add("Sales Quotation");
                }
                else if (Convert.ToString(cbxMainCatogry.SelectedValue) == "Finished Goods")
                {
                    FunctionClearSubCategory();
                    cbxSubCatogry.Items.Add("Overall Statistics");
                    cbxSubCatogry.Items.Add("Additional Cost");
                }
                else
                {
                    FunctionDesablingSubCatagoryCombo();
                }
            }
            else if (CategoryInfo.ModuleName == "Party Balance")
            {
                FunctionDesablingSubCatagoryCombo();
            }
            else if (CategoryInfo.ModuleName == "Purchase")
            {
                if (Convert.ToString(cbxMainCatogry.SelectedValue) == "Purchase Order")
                {
                    FunctionClearSubCategory();
                    cbxSubCatogry.Items.Add("Overall Statistics");
                    cbxSubCatogry.Items.Add("Order Placed");
                    cbxSubCatogry.Items.Add("Order Cancelled");
                    cbxSubCatogry.Items.Add("Pending");
                    cbxSubCatogry.Items.Add("Over Due");
                }
                else if (Convert.ToString(cbxMainCatogry.SelectedValue) == "Material Receipt")
                {
                    FunctionClearSubCategory();
                    cbxSubCatogry.Items.Add("Overall Statistics");
                    cbxSubCatogry.Items.Add("Purchase Order");
                }
                else if (Convert.ToString(cbxMainCatogry.SelectedValue) == "Rejection Out")
                {
                    FunctionClearSubCategory();
                    cbxSubCatogry.Items.Add("Overall Statistics");
                    cbxSubCatogry.Items.Add("Material Receipt");
                    cbxSubCatogry.Items.Add("Godown");
                    cbxSubCatogry.Items.Add("Area");
                }
                else if (Convert.ToString(cbxMainCatogry.SelectedValue) == "Purchase Invoice")
                {
                    FunctionClearSubCategory();
                    cbxSubCatogry.Items.Add("Overall Statistics");
                    cbxSubCatogry.Items.Add("Purchase Order");
                    cbxSubCatogry.Items.Add("Material Receipt");
                    cbxSubCatogry.Items.Add("Taxable Purchase");
                    cbxSubCatogry.Items.Add("Additional Cost");
                    cbxSubCatogry.Items.Add("Discount");
                    cbxSubCatogry.Items.Add("Area");
                }
                else if (Convert.ToString(cbxMainCatogry.SelectedValue) == "Purchase Return")
                {
                    FunctionClearSubCategory();
                    cbxSubCatogry.Items.Add("Overall Statistics");
                    cbxSubCatogry.Items.Add("No Of Product");
                    cbxSubCatogry.Items.Add("Godown");
                    cbxSubCatogry.Items.Add("Area");
                }
                else
                {
                    FunctionDesablingSubCatagoryCombo();
                }
            }
            CategoryInfo.TypeName = CategoryInfo.TypeName;
        }
        /// <summary>
        /// CategoryInfo_PropertyChanged Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void CategoryInfo_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            lblModuleName.Content = CategoryInfo.ModuleName;
            lblMode.Content = CategoryInfo.SortByName;
            YaxisModeAnalizier objYaxis = new YaxisModeAnalizier();
            cbxYaxisMode.Visibility = (objYaxis.isEnable(CategoryInfo)) ? System.Windows.Visibility.Visible : System.Windows.Visibility.Hidden;
            if (objYaxis.isChange(CategoryInfo))
            {
                cbxYaxisMode.IsChecked = objYaxis.isAmount(CategoryInfo);
            }

            if (e.PropertyName == "TypeName")
            {
                FunctionClearPlotter();
                lblFromDate.Text = (CategoryInfo.TypeName == "Day") ? CategoryInfo.DateFrom.ToString("dd-MMM-yyyy") : CategoryInfo.DateFrom.ToString("MMM-yyyy");
                txtBlkFromDate.Text = (CategoryInfo.TypeName == "Day") ? CategoryInfo.DateFrom.ToString("dd-MMM-yyyy") : CategoryInfo.DateFrom.ToString("MMM-yyyy");
                lblToDate.Text = (CategoryInfo.TypeName == "Day") ? CategoryInfo.DateTo.ToString("dd-MMM-yyyy") : CategoryInfo.DateTo.ToString("MMM-yyyy");
                txtBlkToDate.Text = (CategoryInfo.TypeName == "Day") ? CategoryInfo.DateTo.ToString("dd-MMM-yyyy") : CategoryInfo.DateTo.ToString("MMM-yyyy");
                ViewDetailsInfo.ModuleName = CategoryInfo.ModuleName;
                ViewDetailsInfo.Catagory = CategoryInfo.CatagoryName;
                ViewDetailsInfo.Type = CategoryInfo.TypeName;
                ViewDetailsInfo.CheckValue = CategoryInfo.CheckedValueName;
                ViewDetailsInfo.SubCatagory = CategoryInfo.SubCatagoryName;
                ViewDetailsInfo.SortBy = CategoryInfo.SortByName;
                OnWorkerMethodStart("ListFill");
                OnWorkerMethodStart("PlotterData");
            }
            if (e.PropertyName == "CheckedValueName")
            {
                if (CategoryInfo.CheckedValueName != null && CategoryInfo.CheckedValueName != string.Empty)
                {
                    OnWorkerMethodStart("PlotterData");
                }
            }
        }
      
        /// <summary>
        /// CheckBox cbxSubCatogry_SelectionChanged Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbxSubCatogry_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CategoryInfo.SubCatagoryName = Convert.ToString(cbxSubCatogry.SelectedValue);
            lblInputorOutput.Visibility = (CategoryInfo.CatagoryName == "Tax Details") ? Visibility.Visible : Visibility.Hidden;
            cbxInputorOutput.Visibility = (CategoryInfo.CatagoryName == "Tax Details") ? Visibility.Visible : Visibility.Hidden;
            CategoryInfo.TypeName = CategoryInfo.TypeName;
        }
        /// <summary>
        /// Label lblAboutUs_MouseEnter Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblAboutUs_MouseEnter(object sender, MouseEventArgs e)
        {
            (sender as Label).Foreground = Brushes.OrangeRed;
        }
        /// <summary>
        /// Label lblAboutUs_MouseLeave Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblAboutUs_MouseLeave(object sender, MouseEventArgs e)
        {
            (sender as Label).Foreground = Brushes.Gray;
        }
        /// <summary>
        /// ComboBox cmbAccountGroup_SelectionChanged Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbAccountGroup_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            List<DataTable> objAccountGroupList = objCallSP.GetAccountGroupBarChartDetails();
            DataTable dtblAccountGroup = (objAccountGroupList[0].Rows.Count != 0) ? (DataTable)objAccountGroupList[0].Rows[0].Table : null;
            if (dtblAccountGroup != null)
            {
                tbkAccountGroupBal.Visibility = System.Windows.Visibility.Visible;
                tbkAccountGroupBalance.Visibility = System.Windows.Visibility.Visible;
                DataRow results = (from m in dtblAccountGroup.AsEnumerable()
                                   where m.Field<string>("accountGroupName") == cmbAccountGroup.SelectedItem.ToString()
                                   select m).FirstOrDefault();


                List<Bar> _bar1 = new List<Bar>();
                _bar1.Add(new Bar() { BarName = "Debit", Value = Convert.ToDouble(results[1]) });
                _bar1.Add(new Bar() { BarName = "Credit", Value = Convert.ToDouble(results[2]) });
                icFinancialGraph.DataContext = new RecordCollection(_bar1);
                tbkAccountGroupBalance.Text = Convert.ToDouble(results[3]).ToString("0.00") + "/-";
            }
        }
        /// <summary>
        /// CheckBox cbxInputorOutput_IsVisibleChanged Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbxInputorOutput_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (cbxInputorOutput.IsVisible)
            {
                cbxYaxisMode.Visibility = Visibility.Hidden;
                lblYaxisMode.Visibility = Visibility.Hidden;
                lblMode.Visibility = Visibility.Hidden;
            }
            else
            {
                cbxYaxisMode.Visibility = Visibility.Visible;
                lblYaxisMode.Visibility = Visibility.Visible;
                lblMode.Visibility = Visibility.Visible;
            }
        }
        /// <summary>
        /// Window_Loaded Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            lblDate.Content = DateTime.Today.ToString("dd-MMM-yyyy");
            DateTime DateFrom = Convert.ToDateTime(objCallSP.GetFromDate());
            CategoryInfo.DateTo = (Convert.ToDateTime(objCallSP.GetLastDate()));
            cbxMainCatogry.Items.Add("Overall Statistics");
            CategoryInfo.TypeName = ((CategoryInfo.DateTo - DateFrom).TotalDays > 90) ? "Month" : "Day";
            calendar.DisplayMode = ((CategoryInfo.DateTo - DateFrom).TotalDays > 90) ? CalendarMode.Year : CalendarMode.Month;
            cbxDate.SelectedIndex = ((CategoryInfo.DateTo - DateFrom).TotalDays > 90) ? 0 : 1;
            FunctionDisplayDates();
            MemoryManagement.FlushMemory();
        }
        /// <summary>
        /// CheckBox cbxDate_DropDownClosed Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbxDate_DropDownClosed(object sender, EventArgs e)
        {
            if (DatePickPopUp != null)
            {
                if (cbxDate.SelectedIndex == 0)
                {
                    DatePickPopUp.IsOpen = true;
                }
                else
                {
                    DatePickPopUp.IsOpen = true;
                }
            }
        }
        /// <summary>
        /// calendar calendar_SelectedDatesChanged Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void calendar_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CategoryInfo.TypeName == "Day")
            {
                if (isControllPressed)
                {
                    if (lblFromDate != null)
                    {
                        CategoryInfo.DateFrom = Convert.ToDateTime(calendar.SelectedDate);
                    }
                }
                else
                {
                    if (lblToDate != null)
                    {
                        CategoryInfo.DateTo = Convert.ToDateTime(calendar.SelectedDate);
                    }
                }
                CategoryInfo.TypeName = "Day";
            }
        }
        /// <summary>
        /// calendar calendar_DisplayModeChanged Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void calendar_DisplayModeChanged(object sender, CalendarModeChangedEventArgs e)
        {
            if (cbxDate.SelectedIndex == 0)
            {
                if (calendar.DisplayMode != CalendarMode.Year)
                {
                    calendar.DisplayMode = CalendarMode.Year;
                }
            }
            else
            {
                calendar.DisplayMode = CalendarMode.Month;
            }
        }
        /// <summary>
        /// calendar calendar_DisplayDateChanged Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void calendar_DisplayDateChanged(object sender, CalendarDateChangedEventArgs e)
        {
            if (CategoryInfo.TypeName == "Month")
            {
                if (isControllPressed)
                {
                    if (lblFromDate != null)
                    {
                        CategoryInfo.DateFrom = (calendar.DisplayDate);
                    }
                }
                else
                {
                    if (lblToDate != null)
                    {
                        CategoryInfo.DateTo = (calendar.DisplayDate);
                    }
                }
                CategoryInfo.TypeName = "Month";
            }
        }
        /// <summary>
        /// calendar calendar_PreviewMouseUp Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void calendar_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            if (Mouse.Captured is CalendarItem)
            {
                Mouse.Capture(null);
            }
        }
        /// <summary>
        /// Label lblFromDate_TextChanged Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblFromDate_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (isControllPressed)
            {
                lblFromDate.FontWeight = FontWeights.Bold;
                lblToDate.FontWeight = FontWeights.Normal;
                lblFromDate.Foreground = Brushes.Coral;
                lblToDate.Foreground = Brushes.White;
                txtBlkFromDate.Text = lblFromDate.Text;
            }
        }
        /// <summary>
        /// Label lblToDate_TextChanged Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblToDate_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!isControllPressed)
            {
                lblFromDate.FontWeight = FontWeights.Normal;
                lblToDate.FontWeight = FontWeights.Bold;
                lblFromDate.Foreground = Brushes.White;
                lblToDate.Foreground = Brushes.Coral;
                txtBlkToDate.Text = lblToDate.Text;
            }
        }
        /// <summary>
        /// Date Picker DatePickPopUp_Opened Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DatePickPopUp_Opened(object sender, EventArgs e)
        {
            isControllPressed = true;
            lblDisplayDate.Content = "Select From Date";
        }
        /// <summary>
        /// Label lblFromDate_MouseUp Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblFromDate_MouseUp(object sender, MouseButtonEventArgs e)
        {
            isControllPressed = true;
            lblDisplayDate.Content = "Select From Date";
        }
        /// <summary>
        /// Label lblToDate_MouseUp Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblToDate_MouseUp(object sender, MouseButtonEventArgs e)
        {
            isControllPressed = false;
            lblDisplayDate.Content = "Select To Date";
        }
        /// <summary>
        /// Label lblToDate_PreviewMouseLeftButtonUp Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblToDate_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            isControllPressed = false;
            lblDisplayDate.Content = "Select To Date";
        }
        /// <summary>
        /// Label lblFromDate_PreviewMouseLeftButtonUp Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblFromDate_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            isControllPressed = true;
            lblDisplayDate.Content = "Select From Date";
        }
        /// <summary>
        /// Button btnPopClose_Click Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPopClose_Click(object sender, RoutedEventArgs e)
        {
            DatePickPopUp.IsOpen = false;
        }
        /// <summary>
        /// CheckBox cbxDate_SelectionChanged Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbxDate_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DatePickPopUp != null)
            {
                if (cbxDate.SelectedIndex == 0)
                {
                    calendar.DisplayMode = CalendarMode.Year;
                    DatePickPopUp.IsOpen = true;
                }
                else
                {
                    calendar.DisplayMode = CalendarMode.Month;
                    DatePickPopUp.IsOpen = true;
                }
                FunctionDisplayDates();
                CategoryInfo.DateFrom = (Convert.ToDateTime(objCallSP.GetFromDate()));
                CategoryInfo.DateTo = (Convert.ToDateTime(objCallSP.GetLastDate()));
                CategoryInfo.TypeName = (cbxDate.SelectedIndex == 0) ? "Month" : "Day";
            }
        }
        /// <summary>
        /// Label lblLogOut_MouseUp Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblLogOut_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Splash objSplash = new Splash();
            this.Close();
            objSplash.Show();
        }
        /// <summary>
        /// Window_MouseLeave Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_MouseLeave(object sender, MouseEventArgs e)
        {
            if (!DatePickPopUp.IsMouseOver && !pbw.IsActive)
            {
                DatePickPopUp.IsOpen = false;
            }
        }
        /// <summary>
        ///Date Picker DatePickPopUp_MouseLeave Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DatePickPopUp_MouseLeave(object sender, MouseEventArgs e)
        {
            if (!this.IsMouseOver && !pbw.IsActive)
            {
                DatePickPopUp.IsOpen = false;
            }
        }
        /// <summary>
        /// plotter_MouseEnter Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void plotter_MouseEnter(object sender, MouseEventArgs e)
        {
            MemoryManagement.FlushMemory();
        }
        /// <summary>
        /// CheckBox cbxYaxisMode_Checked Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbxYaxisMode_Checked(object sender, RoutedEventArgs e)
        {
            CategoryInfo.SortByName = "Number";
            CategoryInfo.TypeName = CategoryInfo.TypeName;
        }
        /// <summary>
        /// CheckBox cbxYaxisMode_Unchecked Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbxYaxisMode_Unchecked(object sender, RoutedEventArgs e)
        {
            CategoryInfo.SortByName = "Amount";
            CategoryInfo.TypeName = CategoryInfo.TypeName;
        }
        /// <summary>
        /// CheckBox cbxInputorOutput_Checked Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbxInputorOutput_Checked(object sender, RoutedEventArgs e)
        {
            CategoryInfo.SortByName = "Number";
            CategoryInfo.TypeName = CategoryInfo.TypeName;
        }
        /// <summary>
        /// CheckBox cbxInputorOutput_Unchecked Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbxInputorOutput_Unchecked(object sender, RoutedEventArgs e)
        {
            CategoryInfo.SortByName = "Amount";
            CategoryInfo.TypeName = CategoryInfo.TypeName;
        }
        /// <summary>
        /// CheckBox cbxYaxisMode_IsVisibleChanged Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbxYaxisMode_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (cbxYaxisMode.Visibility == System.Windows.Visibility.Hidden)
            {
                lblMode.Visibility = System.Windows.Visibility.Visible;
            }
            else
            {
                lblMode.Visibility = System.Windows.Visibility.Hidden;
            }
        }
        /// <summary>
        /// Label lblHelp_MouseUp Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblHelp_MouseUp(object sender, MouseButtonEventArgs e)
        {
            System.Diagnostics.Process.Start(Environment.CurrentDirectory + "\\MiracleIHelp.chm");
        }
        /// <summary>
        /// Label lblAboutUs_MouseUp Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblAboutUs_MouseUp(object sender, MouseButtonEventArgs e)
        {
            wdoAboutUs objAboutUs = new wdoAboutUs();
            objAboutUs.Owner = this;
            objAboutUs.Show();
        }
        /// <summary>
        /// Label lblContactUs_MouseUp Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblContactUs_MouseUp(object sender, MouseButtonEventArgs e)
        {
            ContactUs objContactUs = new ContactUs();
            objContactUs.Owner = this;
            objContactUs.Show();
        }
    }
        #endregion
}
