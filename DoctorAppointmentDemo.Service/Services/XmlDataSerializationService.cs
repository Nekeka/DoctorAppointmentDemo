using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;
using DoctorAppointmentDemo.Data.Interfaces;
using MyDoctorAppointment.Domain.Entities;
namespace DoctorAppointmentDemo.Service.Services
{
    internal class XmlDataSerializationService : ISerializationService
    {


        public T Deserialize<T>(string path)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            using (StringReader reader = new StringReader(path)) { return (T)serializer.Deserialize(reader)!; }
            
        }

        public void Serialize<T>(string path, T data)
        {
            var serializer = new XmlSerializer(typeof(T));
            using (var writer = new StreamWriter(path))
            {
                serializer.Serialize(writer, data);
            }
        }
    }
}
