﻿using DoctorAppointmentDemo.Service.Interfaces;
using MyDoctorAppointment.Data.Repositories;
using MyDoctorAppointment.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoctorAppointmentDemo.Data.Interfaces;
using DoctorAppointmentDemo.Data.Repositories;
using MyDoctorAppointment.Data.Interfaces;
using MyDoctorAppointment.Service.Interfaces;

namespace DoctorAppointmentDemo.Service.Services
{
    public class AppointmentService : IAppointmentService
    {
        
        private readonly IAppointmentRepository _appointmentRepository;
       


        public AppointmentService(string appSettings, ISerializationService serializationService)
        {
            _appointmentRepository = new AppointmentRepository(appSettings,  serializationService);
        }

        public Appointment Create(Appointment appointment)
        {      
            return _appointmentRepository.Create(appointment);   
        }

        public bool Delete(int id)
        {
            return _appointmentRepository.Delete(id);
        }

        public Appointment? Get(int id)
        {
            return _appointmentRepository.GetById(id);
        }

        public IEnumerable<Appointment> GetAll()
        {
            return _appointmentRepository.GetAll();
        }

        public Appointment Update(int id, Appointment appointment)
        {
            return _appointmentRepository.Update(id, appointment);
        }
    }
}
