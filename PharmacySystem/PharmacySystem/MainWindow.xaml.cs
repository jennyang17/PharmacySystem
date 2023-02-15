using PharmacySystem.Views;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PharmacySystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public BindingList<Patient> allPatients = new BindingList<Patient>();
        public BindingList<Prescription> allPrescriptions = new BindingList<Prescription>();
        public BindingList<Medicine> allMedicines = new BindingList<Medicine>();

        public Patient selectedPatient = new Patient();
        string currentTextSearch;

        public MainWindow()
        {
            InitializeComponent();
            //this.DataContext = new MainWindowViewModel();
            allPatients.Add(new Patient() { Name = "Markie", Dob = Convert.ToDateTime("01/01/1992"), Address = "2 The Lane, York", 
                Exemption = "A - Over 60 or under 16", Nhsnumber = "1234567890" });
            allPatients.Add(new Patient() { Name = "Jenny", Dob = Convert.ToDateTime("03/03/1993"), Address = "15 The Lane, York", 
                Exemption = "B - 16 to 18, and in full time education", Nhsnumber = "0987654321" });
            dgvPatientSearchResult.ItemsSource = allPatients;


            
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.Close();
        }

        private void btnMaximize_Click(object sender, RoutedEventArgs e)
        {
            if (Application.Current.MainWindow.WindowState != WindowState.Maximized)
            {
                Application.Current.MainWindow.WindowState = WindowState.Maximized;
            }
            else
            {
                Application.Current.MainWindow.WindowState = WindowState.Normal;
            }
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.WindowState = WindowState.Minimized;
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void btnAddNew_Click(object sender, RoutedEventArgs e)
        {
            AddNewPatient addNew = new AddNewPatient(this, null);
            addNew.ShowDialog();
        }

        private void btnSelect_Click(object sender, RoutedEventArgs e)
        {
            selectedPatient = (Patient)dgvPatientSearchResult.SelectedItem;
            PatientDetails patientDetails = new PatientDetails(selectedPatient);
            patientDetails.ShowDialog();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            selectedPatient = (Patient)dgvPatientSearchResult.SelectedItem;
            allPatients.Remove(selectedPatient);
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            List<Patient> searchedPatients = new List<Patient>();
            searchedPatients = allPatients.Where(p => p.Name == currentTextSearch).ToList();
            dgvPatientSearchResult.ItemsSource = searchedPatients;

        }

        private void txtSearchbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            currentTextSearch = txtSearchbox.Text;
        }
    }
}
