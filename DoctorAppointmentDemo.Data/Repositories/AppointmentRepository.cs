using DoctorAppointmentDemo.Data.Interfaces;
using MyDoctorAppointment.Data.Interfaces;
using MyDoctorAppointment.Data.Repositories;
using MyDoctorAppointment.Data.Configuration;
using MyDoctorAppointment.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoctorAppointmentDemo.Service.Interfaces;

namespace DoctorAppointmentDemo.Data.Repositories
{
    public class AppointmentRepository : GenericRepository<Appointment>, IAppointmentRepository
    {
        private readonly ISerializationService serializationService;
        public override string Path { get; set; }

        public override int LastId { get; set; }

        public AppointmentRepository(string appSettings, ISerializationService serializationService) : base(appSettings, serializationService)
        {
            this.serializationService = serializationService;

            var result = ReadFromAppSettings();

            Path = result.Database.Appointments.Path;
           
            LastId = result.Database.Appointments.LastId;
        }

        public override void ShowInfo(Appointment appointment)
        {
            Console.WriteLine(); // implement view of all object fields
        }

        protected override void SaveLastId()
        {
            var result = ReadFromAppSettings();
            result.Database.Appointments.LastId = LastId;

            serializationService.Serialize(AppSettings, result);

        }
    }
}
