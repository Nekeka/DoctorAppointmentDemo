using DoctorAppointmentDemo.Service;
using DoctorAppointmentDemo.Service.Interfaces;
using DoctorAppointmentDemo.Service.Services;
using DoctorAppointmentDemo.UI;
using DoctorAppointmentDemo.UI.Enums;
using DoctorAppointmentDemo.UI.Managers;
using MyDoctorAppointment.Data.Interfaces;
using MyDoctorAppointment.Domain.Entities;
using MyDoctorAppointment.Service.Interfaces;
using MyDoctorAppointment.Service.Services;

namespace MyDoctorAppointment
{
    public class DoctorAppointment
    {
        public DoctorAppointment()
        { 
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

        private void ChooseDataType()
        {

        }

        public void Menu()
        {
            
            while (true)
            {
                ChooseDataEntity();
            }
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