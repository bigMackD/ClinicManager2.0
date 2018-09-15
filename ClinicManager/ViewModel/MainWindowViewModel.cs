using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ClinicManager.ViewModel
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private PatientViewModel _selectedPatient;
        public ObservableCollection<PatientViewModel> AllPatients { get; set; }
        public PatientViewModel SelectedPatient {
            get => _selectedPatient;
            set
            {
                _selectedPatient = value;

                PropertyChanged(this, new PropertyChangedEventArgs("SelectedPatient"));
            }
        }

        public MainWindowViewModel()
        {

            AllPatients = new ObservableCollection<PatientViewModel>();
            var allPatients = LoadFromFile();
            foreach (var patient in allPatients)
            {
                AllPatients.Add(patient);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private PatientViewModel[] LoadFromFile()
        {
            var allText = File.ReadAllText("samplePatients.json");
            var jsonSerializer = JsonSerializer.Create(new JsonSerializerSettings()
            {
                DateFormatString = "dd/MM/yyyy"
            });
            var patients = jsonSerializer.Deserialize<List<PatientViewModel>>(new JsonTextReader(new StringReader(allText)));
            for (var i = 0; i < patients.Count; i++)
            {
                var patient = patients[i];
                patient.Photo = GetPhotoForUser(patient);
            }

            return patients.ToArray();
        }

        private static string GetPhotoForUser(PatientViewModel patient)
        {
            return patient.InsuranceNumber.Last() % 2 == 0 ? "Photos/male.png" : "Photos/female.png";
        }

       
    }
}
