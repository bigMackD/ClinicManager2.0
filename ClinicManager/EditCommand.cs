using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ClinicManager
{
    public class EditCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            if(ViewModelLocator.ViewModelLocator.MainWindowViewModel.SelectedPatient != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Execute(object parameter)
        {
           
            var pdv = new PatientDetailView();
            pdv.Patient = ViewModelLocator.ViewModelLocator.MainWindowViewModel.SelectedPatient;
            pdv.ShowDialog();
        }

        public void InvokeCanExecuteChanged()
        {
            if (CanExecuteChanged != null)
            {
                CanExecuteChanged.Invoke(this, new EventArgs());
            }
        }
    }
}
