using DoctorAppointmentDemo.Service.Interfaces;
using DoctorAppointmentDemo.Service.Services;
using DoctorAppointmentDemo.UI.Enums;
using MyDoctorAppointment.Domain.Entities;
using MyDoctorAppointment.Service.Interfaces;
using MyDoctorAppointment.Service.Services;

namespace MyDoctorAppointment
{
    public class DoctorAppointment
    {
        private readonly IDoctorService _doctorService;
        private readonly IAppointmentService _appointmentService;
        

        public DoctorAppointment()
        {
            _doctorService = new DoctorService();
            _appointmentService = new AppointmentService();
        }
        public void ChooseOpearation<T>()
        {
            Console.WriteLine("Menu:");
            Console.WriteLine("1. Show all enties");
            Console.WriteLine("2. Create");
            Console.WriteLine("3. Read");
            Console.WriteLine("4. Update");
            Console.WriteLine("5. Delete");
            Console.WriteLine("6. Exit");
            Console.Write("Choose operation: ");

            if (Enum.TryParse<MenuOperations>(Console.ReadLine(), out MenuOperations choice))
            {
                switch (choice)
                {
                    case MenuOperations.Show_All:
                        Console.WriteLine("Show_All");
                        break;
                    case MenuOperations.Create:
                        Console.WriteLine("Create");
                        break;
                    case MenuOperations.Read:
                        Console.WriteLine("Read");
                        break;
                    case MenuOperations.Update:
                        Console.WriteLine("Update");
                        break;
                    case MenuOperations.Delete:
                        Console.WriteLine("Delete");
                        break;
                    case MenuOperations.Exit:
                        Console.WriteLine("Exit");
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
                        break;
                    case Entities.Doctor:
                        Console.WriteLine("Doctors");
                        break;
                    case Entities.Patient:
                        Console.WriteLine("Patients");
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


            ////////////
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
            //////////////

            var appointment = new Appointment
            {
                Doctor = _doctorService.Get(1),
                Patient = new Patient { Name = "Patient B", IllnessType = Domain.Enums.IllnessTypes.Ambulance },
                Description = "Опис"


            };
            _appointmentService.Create(appointment);
            
            Console.WriteLine("Current appoinments:");
            var appnts = _appointmentService.GetAll();
            foreach (var appnt in appnts)
            {
                Console.WriteLine(appnt.Description);
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