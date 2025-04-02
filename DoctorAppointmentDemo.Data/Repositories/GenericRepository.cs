﻿using DoctorAppointmentDemo.Data.Interfaces;
using MyDoctorAppointment.Data.Interfaces;
using MyDoctorAppointment.Domain.Entities;
using Newtonsoft.Json;

namespace MyDoctorAppointment.Data.Repositories
{
    public abstract class GenericRepository<TSource> : IGenericRepository<TSource> where TSource : Auditable
    {
        public string AppSettings { get; private set; } // путь к настройкам
        public ISerializationService SerializationService { get; private set; } //
        public abstract string Path { get; set; }

        public abstract int LastId { get; set; }

        public GenericRepository(string appSettings, ISerializationService serializationService)
        {
            AppSettings = appSettings;
            SerializationService = serializationService;
        }
        public TSource Create(TSource source)
        {
            source.Id = ++LastId;
            source.CreatedAt = DateTime.Now;
           
            var enteties = GetAll().Append(source).ToList(); //IEnumerable<TSource>

            SerializationService.Serialize(Path, enteties);
            SaveLastId();

            return source;
        }

        public bool Delete(int id)
        {
            if (GetById(id) is null)
                return false;
            SerializationService.Serialize(Path, GetAll().Where(x => x.Id != id));

            return true;
        }

        public IEnumerable<TSource> GetAll()
        {   
            return SerializationService.Deserialize<IEnumerable<TSource>>(Path);
        }

        public TSource? GetById(int id)
        {
            return GetAll().FirstOrDefault(x => x.Id == id);
        }

        public TSource Update(int id, TSource source)
        {
            source.UpdatedAt = DateTime.Now;
            source.Id = id;

            SerializationService.Serialize(Path, GetAll().Select(x => x.Id == id ? source : x));

            return source; ;
        }

        public abstract void ShowInfo(TSource source);

        protected abstract void SaveLastId();

        protected Repository ReadFromAppSettings()
        {
            return SerializationService.Deserialize<Repository>(AppSettings);
        }
    }
}
