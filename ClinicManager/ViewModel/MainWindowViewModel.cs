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
using System.Windows.Input;
using ClinicManager;
using ClinicManager.Utilities;
using ClinicManager.Services;

namespace ClinicManager.ViewModel
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        public EditCommand EditCommand { get; set; }
        private PatientDataService _patientDataService;
        private DialogService _dialogService;
      
        private PatientViewModel _selectedPatient;
        public ObservableCollection<PatientViewModel> AllPatients { get; set; }

        void Edit(object param)
        {
            _dialogService.ShowPatientsDetailDialog();
        }
        public PatientViewModel SelectedPatient {
            get => _selectedPatient;
            set
            {
                _selectedPatient = value;
                if(PropertyChanged != null)
                {
                    PropertyChanged.Invoke(this, new PropertyChangedEventArgs("SelectedPatient"));
                    EditCommand.InvokeCanExecuteChanged();
                }
               
                Messenger.Default.Send(_selectedPatient);

            }
        }
      
        public MainWindowViewModel()
        {
            _dialogService = new DialogService();
            _patientDataService = new PatientDataService();
            EditCommand = new EditCommand();
            AllPatients = new ObservableCollection<PatientViewModel>();
            var allPatients = _patientDataService.GetAllPatients().Select(x=>PatientViewModel.FromModel(x));
            foreach (var patient in allPatients)
            {
                AllPatients.Add(patient);
            }
            Messenger.Default.Register<DeletePatient>(this, deletePatient);
        }

        private void deletePatient(DeletePatient obj)
        {
            AllPatients.Remove(obj.patientTodelete);
            _patientDataService.DeletePatient(obj.patientTodelete.Model);            
          
        }

        public event PropertyChangedEventHandler PropertyChanged;

       

      

       
    }
}
