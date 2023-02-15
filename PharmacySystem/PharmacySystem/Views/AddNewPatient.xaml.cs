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
    /// Interaction logic for AddNewPatient.xaml
    /// </summary>
    public partial class AddNewPatient : Window
    {
        Patient newPatient;
        Patient _editPatient;
        MainWindow _mainWindow;
        BindingList<string> exemption = new BindingList<string>();
        public AddNewPatient(MainWindow? mainWindow, Patient? patient)
        {
            InitializeComponent();
            _mainWindow = mainWindow;
            _editPatient = patient;

            exemption.Add("A - Over 60 or under 16");
            exemption.Add("B - 16 to 18, and in full time education");
            exemption.Add("D - maternity exemption");
            exemption.Add("E - medical exemption");
            exemption.Add("F - prepayment certificate");
            cboxExemption.ItemsSource = exemption;

            if (_editPatient!= null)
            {
                txtName.Text = patient.Name;
                dpDOB.Text = patient.Dob.ToString();
                txtAddress.Text = patient.Address;
                txtNHSnumber.Text = patient.Nhsnumber;
                cboxExemption.SelectedItem = patient.Exemption;
            }
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
            if (_editPatient != null)
            {
                _editPatient.Name = txtName.Text;
                _editPatient.Address = txtAddress.Text;
                _editPatient.Dob = dpDOB.DisplayDate;
                _editPatient.Nhsnumber = txtNHSnumber.Text;
                _editPatient.Exemption = cboxExemption.SelectedItem.ToString();
            }
            else
            {
                newPatient = new Patient()
                {
                    Name = txtName.Text,
                    Dob = dpDOB.DisplayDate,
                    Address = txtAddress.Text,
                    Nhsnumber = txtNHSnumber.Text,
                    Exemption = cboxExemption.SelectedItem.ToString()
                };
                _mainWindow.allPatients.Add(newPatient);
            }
            

            this.Close();
        }
    }
}
