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

namespace PharmacySystem.Views
{
    /// <summary>
    /// Interaction logic for AddNewPatient.xaml
    /// </summary>
    public partial class AddNewPatient : Window
    {
        Patients newPatient;
        MainWindow _mainWindow;
        public AddNewPatient(MainWindow mainWindow)
        {
            InitializeComponent();
            _mainWindow = mainWindow;
        }

        private void btnCancelNewPatient_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void btnSavePatient_Click(object sender, RoutedEventArgs e)
        {
            newPatient = new Patients()
            {
                Name = txtName.Text,
                Dob = dpDOB.DisplayDate,
                Address = txtAddress.Text,
                Nhsnumber = txtNHSnumber.Text,
                Exemption = cboxExemption.SelectedItem.ToString()
            };

            _mainWindow.allPatients.Add(newPatient);

            this.Close();
        }
    }
}
