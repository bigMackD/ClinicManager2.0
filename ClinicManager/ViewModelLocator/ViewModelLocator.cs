using ClinicManager.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManager.ViewModelLocator
{
    public class ViewModelLocator
    {
        public static MainWindowViewModel MainWindowViewModel = new MainWindowViewModel();
        public static PatientDetailViewModel PatientDetailViewModel = new PatientDetailViewModel();
    }
}
