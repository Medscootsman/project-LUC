using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace LiveUncertainty
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class ProfileCreate : MetroWindow
    {
        public ProfileCreate()
        {
            InitializeComponent();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        void ProfileCreate_Closing(object sender, CancelEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show(
                "Are you sure you want to close this window? Any unsaved progress will be lost!", //Message
                "Warning!", //Caption
                MessageBoxButton.YesNoCancel,
                MessageBoxImage.Warning
                );

            if (result == MessageBoxResult.No || result == MessageBoxResult.Cancel)
            {
                e.Cancel = true;
            }

            else
            {
                e.Cancel = false;
            }
        }
    }
}
