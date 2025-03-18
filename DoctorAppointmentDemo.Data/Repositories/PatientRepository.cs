using DoctorAppointmentDemo.Data.Interfaces;
using MyDoctorAppointment.Data.Repositories;
using MyDoctorAppointment.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyDoctorAppointment.Data.Configuration;

namespace DoctorAppointmentDemo.Data.Repositories
{
    public class PatientRepository : GenericRepository<Patient>, IPatientRepository
    {
        public override string Path { get; set; }

        public override int LastId { get; set; }

        public PatientRepository()
        {
            dynamic result = ReadFromAppSettings();

            Path = result.Database.Patients.Path;
            LastId = result.Database.Patients.LastId;
        }

        public override void ShowInfo(Patient patient)
        {
            Console.WriteLine(); // implement view of all object fields
        }

        protected override void SaveLastId()
        {
            dynamic result = ReadFromAppSettings();
            result.Database.Patients.LastId = LastId;

            File.WriteAllText(Constants.AppSettingsPath, result.ToString());
        }
    }
}
