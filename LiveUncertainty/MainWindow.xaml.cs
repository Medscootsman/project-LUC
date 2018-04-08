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
using LiveCharts.SeriesAlgorithms;
using LiveUncertainty.classes;
using LiveUncertainty.viewmodels;
using MahApps.Metro.Controls;
namespace LiveUncertainty
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public bool loadprofile;
        public USMViewModel viewmodel; 
        public MainWindow()
        {
            loadprofile = false;
            var splash = new SplashScreen("media/splash_placeholder.png");
            splash.Show(false);
            InitializeComponent();
            splash.Close(new TimeSpan(5));
            Collection = new SeriesCollection
                {

                    new LineSeries()
                    {
                        Title= "GOV values",
                        Values = new ChartValues<double>() {20, 18, 16, 14, 12, 10, 8, 6, 4, 2, 0.432 },
                        PointForeground = Brushes.Blue,
                       
                    }

                };
            this.DataContext = this;    


        }
        public SeriesCollection Collection { get; set; }
        public string[] Labels { get; set; }

        public Func<double, string> YFormatter
        {
            get; set;

        }

        public void UpdateCollection(object sender, RoutedEventArgs e)
        {
            try
            {
                var vals = ((USMViewModel)pg_main.Resources["viewmodel"]).Meter.OperatingConditions.CalculateViv().GetEnumerator();

                ChartValues<double> chartvals = new ChartValues<double>();
                while (vals.MoveNext())
                {
                    chartvals.Add(vals.Current);
                }
                Collection = new SeriesCollection
                {

                    new LineSeries()
                    {
                        Title= "GOV values",
                        Values = chartvals,
                        PointForeground = Brushes.Blue
                    }

                };
               
                this.DataContext = this;
            }
            catch (Exception ex)
            {

            }
        }
        private void Btn_Play_Click(object sender, RoutedEventArgs e)
        {

           
        }

        private void ProfileCreate_click(object sender, RoutedEventArgs e)
        {
            //Open CreateProfile.
            this.Visibility = Visibility.Collapsed;
            ProfileCreate profile = new ProfileCreate();
            profile.ShowDialog();

            if(profile.DialogResult == true)
            {
                this.pg_main.Resources["viewmodel"] = profile._model;
                //test 01
                MessageBox.Show(((USMViewModel)pg_main.Resources["viewmodel"]).Meter.Tag);


            }
            else
            {

            }
            //this.DataContext = profile.DataContext;
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

            else
            {
                e.Cancel = true;
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

        public bool LoadedProfile
        {
            get => loadprofile;
            set => loadprofile = value;
        }

        private void EditProfile_Click(object sender, RoutedEventArgs e)
        {
            
            //Logic for if there's a profile loaded in already should go here
            if(LoadedProfile)
            {
                EditProfile LoadedEditWindow = new EditProfile();
                
            }

            else
            {

                EditProfile EditWindow = new EditProfile();
                EditWindow.ShowDialog();
                EditWindow.DataContext = this.DataContext;
            }

        }

        private void AxesCollection_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            UpdateCollection(null, null);
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void tag_number_val_TargetUpdated(object sender, DataTransferEventArgs e)
        {
            tag_number_val.GetBindingExpression(System.Windows.Controls.Label.ContentProperty).UpdateTarget();
        }
    }
}