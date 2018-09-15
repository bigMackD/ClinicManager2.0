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
using ClinicManager.ViewModel;
using Newtonsoft.Json;
using ClinicManager.ViewModelLocator;

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
            DataContext = ViewModelLocator.ViewModelLocator.MainWindowViewModel;

           // DataContext = new MainWindowViewModel();
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
