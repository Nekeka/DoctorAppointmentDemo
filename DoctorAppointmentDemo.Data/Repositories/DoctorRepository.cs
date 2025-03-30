using DoctorAppointmentDemo.Service.Interfaces;
using MyDoctorAppointment.Data.Configuration;
using MyDoctorAppointment.Data.Interfaces;
using MyDoctorAppointment.Domain.Entities;

namespace MyDoctorAppointment.Data.Repositories
{
    public class DoctorRepository : GenericRepository<Doctor>, IDoctorRepository
    {
        private readonly ISerializationService serializationService;
        public override string Path { get; set; }

        public override int LastId { get; set; }

        public DoctorRepository(string appSettings, ISerializationService serializationService) : base(appSettings, serializationService)
        {
            this.serializationService = serializationService;

            var result = ReadFromAppSettings();

            Path = result.Database.Doctors.Path;
            LastId = result.Database.Doctors.LastId;
        }

        public override void ShowInfo(Doctor doctor)
        {
            Console.WriteLine(); // implement view of all object fields
        }

        protected override void SaveLastId()
        {
            var result = ReadFromAppSettings();
            result.Database.Doctors.LastId = LastId;

            serializationService.Serialize(AppSettings, result);
        }

    }
}
