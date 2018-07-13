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
using ScottLogic.ScottLogic.PieChart;
using System.Windows;

namespace ScottLogic.Controls.PieChart
{
    /// <summary>
    /// Selects a colour purely based on its location within a collection.
    /// </summary>
    public class IndexedColourSelector : DependencyObject, IColorSelector
    {
        /// <summary>
        /// An array of brushes.
        /// </summary>
        public Brush[] Brushes
        {
            get { return (Brush[])GetValue(BrushesProperty); }
            set { SetValue(BrushesProperty, value); }
        }

        public static readonly DependencyProperty BrushesProperty = 
                       DependencyProperty.Register("BrushesProperty", typeof(Brush[]), typeof(IndexedColourSelector), new UIPropertyMetadata(null));


        public Brush SelectBrush(object item, int index)
        {
            SolidColorBrush myBrush = new SolidColorBrush();
            BrushConverter conv = new BrushConverter();
            if ( (item as WPFPieChart.AssetClass).Class.ToString() == "Asset")
            {
                myBrush = conv.ConvertFromString("#FFFF9600") as SolidColorBrush;
                return myBrush;
            }
            else if ((item as WPFPieChart.AssetClass).Class.ToString() == "Expenses")
            {
                myBrush = conv.ConvertFromString("#FF8A00D1") as SolidColorBrush;
                return myBrush;
            }
            else if ((item as WPFPieChart.AssetClass).Class.ToString() == "Income")
            {
                myBrush = conv.ConvertFromString("#FF5AB401") as SolidColorBrush;
                return myBrush;
            }
            else if ((item as WPFPieChart.AssetClass).Class.ToString() == "Liability")
            {
                myBrush = conv.ConvertFromString("#FFDA0077") as SolidColorBrush;
                return myBrush;
            }
           
            return System.Windows.Media.Brushes.Black;
        }
    }
}
