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

namespace PharmacySystem.Views
{
    /// <summary>
    /// Interaction logic for PatientDetails.xaml
    /// </summary>
    public partial class PatientDetails : Window
    {
        //MainWindow _mainWindow;
        Patient _selectedPatient;
        BindingList<string> exemption = new BindingList<string>();
        public PatientDetails(Patient selectedPatient)
        {
            InitializeComponent();
            exemption.Add("A - Over 60 or under 16");
            exemption.Add("B - 16 to 18, and in full time education");
            exemption.Add("D - maternity exemption");
            exemption.Add("E - medical exemption");
            exemption.Add("F - prepayment certificate");
            cboxExemption.ItemsSource = exemption;

            //_mainWindow = mainWindow;
            _selectedPatient = selectedPatient;

            txtName.Text = _selectedPatient.Name;
            dpDOB.Text = _selectedPatient.Dob.ToString();
            txtNHSnumber.Text = _selectedPatient.Nhsnumber;
            txtAddress.Text = _selectedPatient.Address;
            cboxExemption.SelectedItem = _selectedPatient.Exemption;
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnMaximize_Click(object sender, RoutedEventArgs e)
        {
            if (this.WindowState != WindowState.Maximized)
            {
                this.WindowState = WindowState.Maximized;
            }
            else
            {
                this.WindowState = WindowState.Normal;
            }
        }

        private void btnEditPatient_Click(object sender, RoutedEventArgs e)
        {
            AddNewPatient editPatient = new AddNewPatient(null, _selectedPatient);
            editPatient.ShowDialog();

        }
    }
}
