using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
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
using Newtonsoft.Json;

namespace ClinicManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            PatientsListBox.ItemsSource = LoadFromFile();
        }

        private Patient[] LoadFromFile()
        {
            var allText = File.ReadAllText("samplePatients.json");
            var jsonSerializer = JsonSerializer.Create(new JsonSerializerSettings()
            {
                DateFormatString = "dd/MM/yyyy"
            });
            var patients = jsonSerializer.Deserialize<List<Patient>>(new JsonTextReader(new StringReader(allText)));
            for (var i = 0; i < patients.Count; i++)
            {
                var patient = patients[i];
                patient.Photo = GetPhotoForUser(patient);
            }

            return patients.ToArray();
        }

        private static string GetPhotoForUser(Patient patient)
        {
            return patient.InsuranceNumber.Last() % 2 == 0 ? "Photos/male.png" : "Photos/female.png";
        }

        private void PatientsListBox_OnSelected(object sender, RoutedEventArgs e)
        {
            EditButton.IsEnabled = true;
            MenuEditButton.IsEnabled = true;
            var selectedPatient = (Patient) ((ListBox) sender).SelectedItem;
            NameTextBox.Text = selectedPatient.FirstName + " " + selectedPatient.SecondName;
            EmailTextBox.Text = selectedPatient.Email;
            PhoneTextBox.Text = selectedPatient.PhoneNumber;
            AgeTextBox.Text = ((DateTime.Now.Year - selectedPatient.BirthDate.Year) ).ToString();
            InsuranceNumberTextBox.Text = selectedPatient.InsuranceNumber;
            Photo.Source = new BitmapImage(new Uri(selectedPatient.Photo, UriKind.Relative));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            PatientDetailView detailView = new PatientDetailView();
            detailView.Patient = ((Patient) PatientsListBox.SelectedItem);
            detailView.ShowDialog();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            PatientDetailView detailView = new PatientDetailView();
            detailView.Patient = ((Patient) PatientsListBox.SelectedItem);
            detailView.ShowDialog();
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            var jsonSerializer = JsonSerializer.Create(new JsonSerializerSettings()
            {
                DateFormatString = "dd/MM/yyyy"
            });
            File.Delete("samplePatients.json");
            using (var streamWriter = new StreamWriter(File.OpenWrite("samplePatients.json")))
            {
                jsonSerializer.Serialize(streamWriter, PatientsListBox.Items);
            }
        }
    }
}
