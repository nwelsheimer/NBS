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
using System.Timers;
using System.Windows;
using System.Windows.Controls;

namespace MiracleI
{
    /// <summary>
    /// Interaction logic for Progress.xaml
    /// </summary>
    public partial class Progress : UserControl
    {
        private delegate void VoidDelegete();
        private Timer timer;
        private int progress;

        public Progress()
        {
            InitializeComponent();
            Loaded += OnLoaded;
        }
        void OnLoaded(object sender, RoutedEventArgs e)
        {
            timer = new Timer(80);
            timer.Elapsed += OnTimerElapsed;
            timer.Start();
        }

        void OnTimerElapsed(object sender, ElapsedEventArgs e)
        {
            rotationCanvas.Dispatcher.Invoke
                (
                new VoidDelegete(
                    delegate
                    {
                        SpinnerRotate.Angle += 25;
                        if (SpinnerRotate.Angle == 360)
                        {
                            SpinnerRotate.Angle = 5;
                        }
                    }
                    ),
                null
                );

        }



        public int Progresss
        {
            get { return progress; }
            set
            {
                progress = value;
            }
        }
    }
}
