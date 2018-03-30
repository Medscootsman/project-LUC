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
using LiveUncertainty.classes;
using MahApps.Metro.Controls;

namespace LiveUncertainty
{
    /// <summary>
    /// Interaction logic for EditProfile.xaml
    /// </summary>
    public partial class EditProfile : MetroWindow
    {
        public EditProfile()
        {
            InitializeComponent();
        }

        public EditProfile(USM meter)
        {
            InitializeComponent();
            
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        void ProfileEdit_Closing(object sender, CancelEventArgs e)
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

        private void submit_Click(object sender, RoutedEventArgs e)
        {
            //Create an object and save it into a the file directory.
        }
    }
}
