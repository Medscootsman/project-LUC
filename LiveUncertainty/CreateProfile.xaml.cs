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
using LiveUncertainty.classes;
using LiveUncertainty.viewmodels;

namespace LiveUncertainty
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class ProfileCreate : MetroWindow
    {
        private readonly string Meter = "Meter";
        public USMViewModel _model
        {
            get;
            private set;
        }


        public ProfileCreate()
        {
            InitializeComponent();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
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

        private void btn_Save_Click(object sender, RoutedEventArgs e)
        {
           
            
        }

        private void btn_Cancel_Click(object sender, RoutedEventArgs e)
        {

        }

        private void txtbox_InternalDiameter_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }

        private void txtbox_nomDiameter_TextChanged(object sender, TextChangedEventArgs e)
        {
 
        }

        private void btn_Load_Click(object sender, RoutedEventArgs e)
        {
            USMViewModel model = (USMViewModel)this.pg_Main.Resources["viewmodel"];
            //send this back to the main window.
            this._model = model;
            this.DialogResult = true;
            this.Close();

        }
    }
}
