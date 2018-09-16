using System;

namespace ClinicManager
{
    public class PatientViewModel
    {
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string FullName
        {
            get
            {
                return FirstName + " " + SecondName;
            }
        }
        public string Email { get; set; }
        public DateTimeOffset BirthDate { get; set; }
        public int Age
        {
            get
            {
                return DateTime.Today.Year - BirthDate.Year;
            }
        }
        public string InsuranceNumber { get; set; }
        public string PhoneNumber { get; set; }
        public string Photo { get; set; }
        public Patient Model { get; set; }

        public static PatientViewModel FromModel(Patient model)
        {
            PatientViewModel pvm = new PatientViewModel();
            pvm.FirstName = model.FirstName;
            pvm.SecondName = model.SecondName;
            pvm.InsuranceNumber = model.InsuranceNumber;
            pvm.PhoneNumber = model.PhoneNumber;
            pvm.Photo = model.Photo;
            pvm.Model = model;
            return pvm;
        }
    }
}