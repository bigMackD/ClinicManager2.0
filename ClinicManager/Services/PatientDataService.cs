using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManager.Services
{
    class PatientDataService
    {
        public List<Patient> GetAllPatients()
        {
           return LoadFromFile().ToList();
        }

        public void DeletePatient(Patient toBeDeleted)
        {
            var all = GetAllPatients();
            var oneToBeDeleted = all.Single(x => x.FirstName == toBeDeleted.FirstName && x.SecondName == toBeDeleted.SecondName);
            all.Remove(oneToBeDeleted);
            var jsonSerializer = JsonSerializer.Create(new JsonSerializerSettings()
            {
                DateFormatString = "dd/MM/yyyy"
            });
            File.Delete("samplePatients.json");

            using (var streamWriter = new StreamWriter(File.OpenWrite("samplePatients.json")))
            {
                jsonSerializer.Serialize(streamWriter, all);
            }
        }

        public void UpdatePatient(Patient toBeUpdated)
        { 

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
    }
}
