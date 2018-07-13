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
using System.Windows.Media;
using System.Data;

namespace MiracleI
{
    class RecordCollection : System.Collections.ObjectModel.ObservableCollection<Record>
    {
        public RecordCollection(List<Bar> barvalues)
        {
            SolidColorBrush myBrush = new SolidColorBrush();
            BrushConverter conv = new BrushConverter();
            foreach (Bar barval in barvalues)
            {
                if (barval.BarName == "Debit")
                {
                    myBrush = conv.ConvertFromString("#FF69C774") as SolidColorBrush;
                }
                else if (barval.BarName == "Credit")
                {
                    myBrush = conv.ConvertFromString("#FFFF6969") as SolidColorBrush;
                }
                else if (barval.BarName == "Bank" || barval.BarName == "Customer")
                {
                    myBrush = conv.ConvertFromString("#FFFF9600") as SolidColorBrush;
                }
                else if (barval.BarName == "Product")
                {
                    DataRow results = (from m in MainWindow.dtblColor.AsEnumerable()
                                       where m.Field<string>("Item") == "Product"
                                       select m).FirstOrDefault();
                    myBrush = (results[1].ToString() == "Asset") ? conv.ConvertFromString("#FFFF9600") as SolidColorBrush : conv.ConvertFromString("#FF00C4D9") as SolidColorBrush;
                }
                else if (barval.BarName == "Party Balance")
                {
                    DataRow results = (from m in MainWindow.dtblColor.AsEnumerable()
                                       where m.Field<string>("Item") == "Party Balance"
                                       select m).FirstOrDefault();
                    myBrush = (results[1].ToString() == "Asset") ? conv.ConvertFromString("#FFFF9600") as SolidColorBrush : conv.ConvertFromString("#FFDA0077") as SolidColorBrush;
                }
                else if (barval.BarName == "Supplier")
                {
                    myBrush = conv.ConvertFromString("#FFDA0077") as SolidColorBrush;
                }
                else if (barval.BarName == "Sales")
                {
                    myBrush = conv.ConvertFromString("#FF5AB401") as SolidColorBrush;
                }
                else if (barval.BarName == "Purchase" || barval.BarName == "Pay Roll")
                {
                    myBrush = conv.ConvertFromString("#FF8A00D1") as SolidColorBrush;
                }
                else if (barval.BarName == "Finance")
                {
                    DataRow results = (from m in MainWindow.dtblColor.AsEnumerable()
                                       where m.Field<string>("Item") == "Profit and Loss"
                                       select m).FirstOrDefault();
                    myBrush = (results[1].ToString() == "Loss") ? conv.ConvertFromString("#FFE60101") as SolidColorBrush : conv.ConvertFromString("#FF008BF4") as SolidColorBrush;

                }
                Add(new Record(barval.Value, myBrush, barval.BarName));
            }
        }
    }

    class Bar
    {

        public string BarName { set; get; }

        public double Value { set; get; }

    }

    class Record : System.ComponentModel.INotifyPropertyChanged
    {
        public Brush Color { set; get; }

        public string Name { set; get; }

        private double _data;
        public double Data
        {
            set
            {
                if (_data != value)
                {
                    _data = value;

                }
            }
            get
            {
                return _data;
            }
        }

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        public Record(double value, Brush color, string name)
        {
            Data = value;
            Color = color;
            Name = name;
        }

        protected void PropertyOnChange(string propname)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propname));
            }
        }
    }
}
