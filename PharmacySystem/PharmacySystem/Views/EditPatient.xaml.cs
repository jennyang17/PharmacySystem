using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace PharmacySystem.Views
{
    /// <summary>
    /// Interaction logic for EditPatient.xaml
    /// </summary>
    public partial class EditPatient : Window
    {
        Patient _editingPatient;
        BindingList<string> exemption = new BindingList<string>();
        public EditPatient(Patient editingPatient)
        {
            InitializeComponent();
            _editingPatient = editingPatient;

            exemption.Add("A - Over 60 or under 16");
            exemption.Add("B - 16 to 18, and in full time education");
            exemption.Add("D - maternity exemption");
            exemption.Add("E - medical exemption");
            exemption.Add("F - prepayment certificate");
            cboxExemption.ItemsSource = exemption;

            txtName.Text = _editingPatient.Name;
            txtAddress.Text = _editingPatient.Address;
            txtNHSnumber.Text = _editingPatient.Nhsnumber;
            dpDOB.Text = _editingPatient.Dob.ToString();
            cboxExemption.SelectedItem = _editingPatient.Exemption;

            

        }

        private void btnSavePatient_Click(object sender, RoutedEventArgs e)
        {
            _editingPatient.Name = txtName.Text;
            _editingPatient.Address = txtAddress.Text;
            _editingPatient.Nhsnumber = txtNHSnumber.Text;
            _editingPatient.Dob = dpDOB.DisplayDate;
            _editingPatient.Exemption = (string)cboxExemption.SelectedItem;

            this.Close();
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
    }
}
