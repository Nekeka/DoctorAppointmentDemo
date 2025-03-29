using DoctorAppointmentDemo.UI.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoctorAppointmentDemo.Service.Interfaces;
using DoctorAppointmentDemo.Service;
using System.Transactions;
using DoctorAppointmentDemo.Data;
using MyDoctorAppointment.Domain.Entities;


namespace DoctorAppointmentDemo.UI.Managers
{
    internal class PatientManager : Imanager<Patient>
    {
        private readonly IPatientService _patientService = new PatientService();

        public void ShowAll()
        {
            var patients = _patientService.GetAll();
            if (!patients.Any())
            {
                Console.WriteLine("No patients found.");
                return;
            }

            foreach (var p in patients)
            {
                Console.WriteLine($"id {p.Id}: {p.Name} {p.Surname}");
            }
        }

        private int GetPatientId()
        {
            Console.Write("Enter patient ID:");
            if (int.TryParse(Console.ReadLine(), out int id) && id >= 0 && id <= _patientService.GetAll().Count())
            {

                return id;
            }
            Console.WriteLine("Invalid ID");
            return 0;
        }

        private Patient GetNewPatientData()
        {
            Console.Write("Enter name: ");
            string name = Console.ReadLine();

            Console.Write("Enter surname: ");
            string surname = Console.ReadLine();

            return new Patient { Name = name, Surname = surname };
        }

        public void Create()
        {
            _patientService.Create(GetNewPatientData());
            Console.WriteLine("Patient added successfully");
        }

        public void Read()
        {
            int id = GetPatientId();
            if (id == -1) return;

            var patient = _patientService.Get(id);
            Console.WriteLine($"Patient: {patient.Name}");

        }

        public void Update()
        {
            int id = GetPatientId();
            if (id == -1) return;

            _patientService.Update(id, GetNewPatientData());
            Console.WriteLine("Patient updated successfully");
        }

        public void Delete()
        {
            int id = GetPatientId();
            if (id == -1) return;

            _patientService.Delete(id);


            Console.WriteLine("Patient deleted successfully");
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