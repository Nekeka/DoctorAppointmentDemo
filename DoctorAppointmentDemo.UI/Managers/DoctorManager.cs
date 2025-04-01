using DoctorAppointmentDemo.Service.Interfaces;
using DoctorAppointmentDemo.Service;
using DoctorAppointmentDemo.UI.Enums;
using MyDoctorAppointment.Domain.Entities;
using MyDoctorAppointment.Service.Interfaces;
using MyDoctorAppointment.Service.Services;
using DoctorAppointmentDemo.Service.Services;
using DoctorAppointmentDemo.Data.Configuration;

namespace DoctorAppointmentDemo.UI.Managers
{
    internal class DoctorManager : Imanager<Doctor>
    {
        private readonly IDoctorService _doctorService;

        public DoctorManager(string dataType)
        {
            if (dataType == "JSON")
            {
                _doctorService = new DoctorService(Constants.JsonAppSettingsPath, new JsonDataSerializerService());
            }
        }
        public void ShowAll()
        {
            var doctors = _doctorService.GetAll();
            if (!doctors.Any())
            {
                Console.WriteLine("No Doctors found.");
                return;
            }

            foreach (var p in doctors)
            {
                Console.WriteLine($"{p.Name} {p.Surname}");
            }
        }

        private int GetDoctorId()
        {
            Console.Write("Enter Doctor ID:");
            if (int.TryParse(Console.ReadLine(), out int id) && id >= 0 && id <= _doctorService.GetAll().Count())
            {

                return id;
            }
            Console.WriteLine("Invalid ID");
            return 0;
        }

        private Doctor GetNewDoctortData()
        {
            Console.Write("Enter name: ");
            string name = Console.ReadLine();

            Console.Write("Enter surname: ");
            string surname = Console.ReadLine();

            return new Doctor { Name = name, Surname = surname };
        }

        public void Create()
        {
            _doctorService.Create(GetNewDoctortData());
            Console.WriteLine("Doctor added successfully");
        }

        public void Read()
        {
            int id = GetDoctorId();
            if (id == -1) return;

            var Doctor = _doctorService.Get(id);
            Console.WriteLine($"Doctor: {Doctor.Name}");

        }

        public void Update()
        {
            int id = GetDoctorId();
            if (id == -1) return;

            _doctorService.Update(id, GetNewDoctortData());
            Console.WriteLine("Doctor updated successfully");
        }

        public void Delete()
        {
            int id = GetDoctorId();
            if (id == -1) return;

            _doctorService.Delete(id);


            Console.WriteLine("Doctor deleted successfully");
        }

        public void ChooseOperation()
        {
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("\nMenu:");
                Console.WriteLine("1. Show all entries");
                Console.WriteLine("2. Create");
                Console.WriteLine("3. Read");
                Console.WriteLine("4. Update");
                Console.WriteLine("5. Delete");
                Console.WriteLine("6. Exit");
                Console.Write("Choose operation: ");

                if (!Enum.TryParse(Console.ReadLine(), out MenuOperations choice))
                {
                    Console.WriteLine("Invalid choice, try again.");
                    continue;
                }

                switch (choice)
                {
                    case MenuOperations.Show_All:
                        ShowAll();
                        break;
                    case MenuOperations.Create:
                        Create();
                        break;
                    case MenuOperations.Read:
                        Read();
                        break;
                    case MenuOperations.Update:
                        Update();
                        break;
                    case MenuOperations.Delete:
                        Delete();
                        break;
                    case MenuOperations.Exit:
                        Console.WriteLine("Exiting...");
                        return;
                    default:
                        Console.WriteLine("Invalid choice, try again.");
                        break;
                }
            }
        }
    }
}
