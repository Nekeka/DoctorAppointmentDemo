using System.Xml.Serialization;
using DoctorAppointmentDemo.Data.Interfaces;
namespace DoctorAppointmentDemo.Service.Services
{
    public class XmlDataSerializationService : ISerializationService
    {
        public T Deserialize<T>(string path)
        {
            if (!File.Exists(path))
            {
                Console.WriteLine($"Path {path}");
                throw new Exception("Нема файла");
            }

            var serializer = new XmlSerializer(typeof(T));
            using (var stream = new FileStream(path, FileMode.OpenOrCreate))
            {
               return (T)serializer.Deserialize(stream);
            }
        }

        public void Serialize<T>(string path, T data)
        {
            var serializer = new XmlSerializer(typeof(T));
            using (var writer = new FileStream(path, FileMode.OpenOrCreate)) { serializer.Serialize(writer, data); }
        }
    }
}
