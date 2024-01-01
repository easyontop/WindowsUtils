using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Windows_Utilities
{
    /// <summary>
    /// Interaction logic for Updater.xaml
    /// </summary>
    public partial class Updater : Window
    {
        DispatcherTimer RGBTime;
        public Updater()
        {
            InitializeComponent();
            RGBTime = new DispatcherTimer(TimeSpan.FromMilliseconds(10), DispatcherPriority.Normal, delegate
            {
                rgbRotation.Angle += 4;
            }, Application.Current.Dispatcher);
            RGBTime.Start();
        }

        private void _Win32_Loaded_2(object sender, RoutedEventArgs e)
        {

        }
    }
}
