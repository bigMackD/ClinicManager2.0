using System;
using System.Collections.Generic;
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

namespace ClinicManager
{
    /// <summary>
    /// Interaction logic for PatientDetailView.xaml
    /// </summary>
    public partial class PatientDetailView : Window
    {
        public PatientViewModel Patient { get; set; }

        public PatientDetailView()
        {
            InitializeComponent();
            this.Loaded += DetailView_Loaded;
        }

        void DetailView_Loaded(object sender, RoutedEventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            NameLabel.Content = Patient.FirstName + " " + Patient.SecondName;
            PhoneTextBox.Text = Patient.PhoneNumber;
            EmailTextBox.Text = Patient.Email;
            AgeTextBox.Text = (DateTime.Now.Year - Patient.BirthDate.Year).ToString();
            Image.Source = new BitmapImage(new Uri(Patient.Photo, UriKind.Relative));
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
