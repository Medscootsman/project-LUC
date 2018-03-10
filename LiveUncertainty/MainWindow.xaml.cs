using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using LiveCharts;
using LiveCharts.Wpf;
using LiveUncertainty.classes;
using MahApps.Metro.Controls;
namespace LiveUncertainty
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            var splash = new SplashScreen("media/splash_placeholder.png");
            splash.Show(false);
            InitializeComponent();
            splash.Close(new TimeSpan(5));
            ChartValues<double> vals = new ChartValues<double>();
            Collection = new SeriesCollection()
            {
                new LineSeries
                {

                    Title = "Example 1",
                    Values = new ChartValues<double> {2.4543, 2.234234, 1.958435, 1.65344, 1.2344543, 0.545, 0.516, 0.5, 0.4, 0.3,},
                    PointForeground = Brushes.Blue,
                    
                }
            };
            DataContext = this;


        }
        public SeriesCollection Collection { get; set; }
        public string[] Labels { get; set; }

        public Func<double, string> YFormatter
        {
            get; set;

        }


        private void btn_Play_Click(object sender, RoutedEventArgs e)
        {

           
        }

        private void ProfileCreate_click(object sender, RoutedEventArgs e)
        {
            //Open CreateProfile.
            this.Visibility = Visibility.Collapsed;
            ProfileCreate profile = new ProfileCreate();
            profile.ShowDialog();
            this.Visibility = Visibility.Visible;
            
        }

        private void MetroWindow_Closing(object sender, CancelEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show(
                "Are you sure you want to exit? Unsaved work will be lost.",
                "Warning",
                MessageBoxButton.OKCancel,
                MessageBoxImage.Question);

            if(result == MessageBoxResult.OK)
            {
                e.Cancel = false;
            }
        }

        private void Feedback_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://docs.google.com/forms/d/1ypplB3Ii4ga1W71xXTvZiCW4hEXJgOOZNVKJ6uuAxNs/edit?usp=sharing");
        }

        private void settings_open_click(object sender, RoutedEventArgs e)
        {
            settings settingswindow = new settings();
            settingswindow.ShowDialog();
        }
    }
}