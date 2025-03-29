using DoctorAppointmentDemo.Service.Interfaces;
using DoctorAppointmentDemo.Service;
using DoctorAppointmentDemo.UI.Enums;
using MyDoctorAppointment.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoctorAppointmentDemo.Service.Services;
using MyDoctorAppointment.Service.Interfaces;
using MyDoctorAppointment.Service.Services;

namespace DoctorAppointmentDemo.UI.Managers
{
    internal class AppointmentManager : Imanager<Appointment>
    {
        private readonly IAppointmentService _appointmentService = new AppointmentService();

        public void ShowAll()
        {
            var appointments = _appointmentService.GetAll();
            if (!appointments.Any())
            {
                Console.WriteLine("No appointments found.");
                return;
            }

            foreach (var p in appointments)
            {
                Console.WriteLine($"id {p.Id}: {p.Description} ");
            }
        }

        private int GetAppointment()
        {
            Console.Write("Enter appointment ID:");
            if (int.TryParse(Console.ReadLine(), out int id) && id >= 0 && id <= _appointmentService.GetAll().Count())
            {

                return id;
            }
            Console.WriteLine("Invalid ID");
            return 0;
        }

        private Appointment GetNewAppointment()
        {
            IDoctorService doctors = new DoctorService();
            IPatientService patients = new PatientService();

            Console.Write("Enter description:");
            string desc = Console.ReadLine();

            int doc_id;
            while (true)
            {
                Console.Write("Enter doctor ID: ");
                if (int.TryParse(Console.ReadLine(), out doc_id) && doctors.Get(doc_id) != null)
                {
                    break;
                }
                Console.WriteLine("Invalid Id");
            }

            int pat_id;
            while (true)
            {
                Console.Write("Enter patient ID:");
                if (int.TryParse(Console.ReadLine(), out pat_id) && patients.Get(pat_id) != null)
                {
                    break;
                }
                Console.WriteLine("Invalid ID");
            }

            return new Appointment
            {
                Description = desc,
                Doctor = doctors.Get(doc_id),
                Patient = patients.Get(pat_id)
            };
        }


        public void Create()
        {
            _appointmentService.Create(GetNewAppointment());
            Console.WriteLine("appointment added successfully");
        }

        public void Read()
        {
            int id = GetAppointment();
            if (id == -1) return;

            var appointment = _appointmentService.Get(id);
            Console.WriteLine($"appointment: {appointment.Description}");

        }

        public void Update()
        {
            int id = GetAppointment();
            if (id == -1) return;

            _appointmentService.Update(id, GetNewAppointment());
            Console.WriteLine("appointment updated successfully");
        }

        public void Delete()
        {
            int id = GetAppointment();
            if (id == -1) return;

            _appointmentService.Delete(id);


            Console.WriteLine("appointment deleted successfully");
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
