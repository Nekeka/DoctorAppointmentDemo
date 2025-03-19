using DoctorAppointmentDemo.Service;
using DoctorAppointmentDemo.Service.Interfaces;
using DoctorAppointmentDemo.Service.Services;
using DoctorAppointmentDemo.UI;
using DoctorAppointmentDemo.UI.Enums;
using MyDoctorAppointment.Data.Interfaces;
using MyDoctorAppointment.Domain.Entities;
using MyDoctorAppointment.Service.Interfaces;
using MyDoctorAppointment.Service.Services;

namespace MyDoctorAppointment
{
    public class DoctorAppointment
    {
        //private readonly IDoctorService _doctorService;
        //private readonly IAppointmentService _appointmentService;
        //private readonly IPatientService _patientService;

        public DoctorAppointment()
        {
            //_doctorService = new DoctorService();
            //_appointmentService = new AppointmentService();
            //_patientService = new PatientService();    
        }
        
        private void ChooseDataEntity()
        {
            Console.WriteLine("Choose data base");
            Console.WriteLine("1 - Doctors");
            Console.WriteLine("2 - Appointments");
            Console.WriteLine("3 - Patients");
            Console.WriteLine("4 - exit");

            
            if (Enum.TryParse<Entities>(Console.ReadLine(), out Entities choice))
            {
                switch (choice)
                {
                    case Entities.Appointment:
                        Console.WriteLine("Appointments");
                        Imanager<Appointment> imanager2 = new AppointmentManager();
                        imanager2.ChooseOperation();
                        break;
                    case Entities.Doctor:
                        Console.WriteLine("Doctors");
                        Imanager<Doctor> imanager1 = new DoctorManager();
                        imanager1.ChooseOperation();
                        break;
                    case Entities.Patient:
                        Console.WriteLine("Patients");
                        Imanager<Patient> imanager =new PatientManager();
                        imanager.ChooseOperation();
                        break;
                    case Entities.Exit:
                        Console.WriteLine("exit");
                        break;
                    default:
                        Console.WriteLine("wrong choice, try again");
                        break;        
                }
            }
            else
            {
                Console.WriteLine("wrong choice, try again");
            }

        }

        public void Menu()
        {
            
            while (true)
            {
                ChooseDataEntity();
            }

            //Console.WriteLine("Current doctors list: ");
            //var docs = _doctorService.GetAll();

            //foreach (var doc in docs)
            //{
            //    Console.WriteLine(doc.Name);
            //}

            //Console.WriteLine("Adding doctor: ");

            //var newDoctor = new Doctor
            //{
            //    Name = "Vasya",
            //    Surname = "Petrov",
            //    Experience = 20,
            //    DoctorType = Domain.Enums.DoctorTypes.Dentist
            //};

            //_doctorService.Create(newDoctor);

            //Console.WriteLine("Current doctors list: ");
            //docs = _doctorService.GetAll();

            //foreach (var doc in docs)
            //{
            //    Console.WriteLine(doc.Name);
            //}

        }
    }

    public static class Program
    {
        public static void Main()
        {
            var doctorAppointment = new DoctorAppointment();
            doctorAppointment.Menu();
        }
    }
}