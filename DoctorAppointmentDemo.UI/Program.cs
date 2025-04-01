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
        
        private void ChooseDataEntity(string dataType)
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
                        Imanager<Appointment> imanager2 = new AppointmentManager(dataType);
                        imanager2.ChooseOperation();
                        break;
                    case Entities.Doctor:
                        Console.WriteLine("Doctors");
                        Imanager<Doctor> imanager1 = new DoctorManager(dataType);
                        imanager1.ChooseOperation();
                        break;
                    case Entities.Patient:
                        Console.WriteLine("Patients");
                        Imanager<Patient> imanager =new PatientManager(dataType);
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
        //!!!!!!!!! заменить на enum
        private string ChooseDataType()
        {
            while (true)
            {
                Console.WriteLine("Type to select file.\n 1 - for JSON\n 2 - for XML");

                string choice = Console.ReadLine();

                if (choice == "1")
                    return "JSON";
                else if (choice == "2")
                    return "XML";

                Console.WriteLine("Error. Try again");
            }
        }

        public void Menu()
        {
            
            while (true)
            {
                ChooseDataEntity(this.ChooseDataType());
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