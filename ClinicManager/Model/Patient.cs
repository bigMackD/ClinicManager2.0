using System;

namespace ClinicManager
{
    public class Patient
    {
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Email { get; set; }
        public DateTimeOffset BirthDate { get; set; }
        public string InsuranceNumber { get; set; }
        public string PhoneNumber { get; set; }
        public string Photo { get; set; }
    }

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
    }
}