using ClinicManager.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManager.ViewModel
{
    public class PatientDetailViewModel : INotifyPropertyChanged
    {
        public PatientDetailViewModel()
        {
            Messenger.Default.Register<PatientViewModel>(this, SetSelectedPatient);
        }

        private void SetSelectedPatient(PatientViewModel selectedPatientMessage)
        {
            selectedPatient = selectedPatientMessage;
        }
            private PatientViewModel _selectedPatient;
            public PatientViewModel selectedPatient
            {
                get
                {
                    return _selectedPatient;
                }
                set
                {
                    _selectedPatient = value;
                    if (PropertyChanged != null)
                    {
                        PropertyChanged.Invoke(this, new PropertyChangedEventArgs("selectedPatient"));
                    }
                }
            }

            public event PropertyChangedEventHandler PropertyChanged;
        }
}
