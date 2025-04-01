using MyDoctorAppointment.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointmentDemo.Service.ViewModels
{
    public class PatientViewModel
    {
        public string Name { get; set; } = string.Empty;

        public string Surname { get; set; } = string.Empty;

        public string? Phone { get; set; }

        public string? Email { get; set; }

        public string? IllnessType { get; set; }

        public string? AdditionalInfo { get; set; }

        public string? Address { get; set; }
    }
}
