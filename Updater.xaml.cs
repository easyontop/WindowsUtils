using Microsoft.Win32;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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

        // IMPORTANT: DO NOT EDIT!!!
        string BootstrapperVersion = "1.0.0";
        bool needToUpdate = false;

        DispatcherTimer RGBTime;

        public static string HttpGet(string url)
        {
            using (var webClient = new WebClient())
            {
                webClient.Headers.Add(HttpRequestHeader.UserAgent, "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");
                return webClient.DownloadString(url);
            }
        }

        WebClient version = new WebClient();
        RegistryKey regSettings = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\WinUtilsBySnwDev");
        dynamic dataJson = JsonConvert.DeserializeObject(HttpGet("https://raw.githubusercontent.com/easyontop/WindowsUtils/main/packageData.json"));

        private void _Win32_Loaded_2(object sender, RoutedEventArgs e)
        {
            if (!needToUpdate)
            {
                Animator.FadeOut2(this);
            } else
            {
                MessageBox.Show("Updating...");
            }
        }
        public Updater()
        {
            InitializeComponent();
            RGBTime = new DispatcherTimer(TimeSpan.FromMilliseconds(10), DispatcherPriority.Normal, delegate
            {
                rgbRotation.Angle += 4;
            }, Application.Current.Dispatcher);
            RGBTime.Start();

            if(!dataJson.Version.ToString().Contains(BootstrapperVersion))
            {
                needToUpdate = true;
            }
        }
    }
}
