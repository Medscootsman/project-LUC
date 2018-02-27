using System;
using System.Collections.Generic;
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

namespace LiveUncertainty
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
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

        private void CreateProfile_click(object sender, RoutedEventArgs e)
        {

        }
    }
}