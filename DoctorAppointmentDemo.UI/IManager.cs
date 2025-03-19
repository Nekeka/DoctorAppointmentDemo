using MyDoctorAppointment.Domain.Entities;
using Newtonsoft.Json.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointmentDemo.UI
{
    internal interface Imanager<out T> where T: Auditable
    {
        void ShowAll();
        void Create();
        void Read();
        void Update();
        void Delete();
        void ChooseOperation();
        //T newEntity();

    }
}
