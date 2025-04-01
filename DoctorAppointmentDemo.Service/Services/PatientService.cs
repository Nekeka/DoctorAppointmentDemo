using DoctorAppointmentDemo.Data.Interfaces;
using DoctorAppointmentDemo.Service.Interfaces;
using MyDoctorAppointment.Data.Interfaces;
using MyDoctorAppointment.Data.Repositories;
using MyDoctorAppointment.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoctorAppointmentDemo.Service;
using DoctorAppointmentDemo.Data.Repositories;
namespace DoctorAppointmentDemo.Service;

public class PatientService : IPatientService
{
    private readonly IPatientRepository _patientRepository;

    public PatientService(string appSettings, ISerializationService serializationService)
    {
        _patientRepository = new PatientRepository( appSettings,  serializationService);
    }

    public Patient Create(Patient patient)
    {
        return _patientRepository.Create(patient);
    }

    public bool Delete(int id)
    {
        return _patientRepository.Delete(id);
    }

    public Patient? Get(int id)
    {
        return _patientRepository.GetById(id);
    }

    public IEnumerable<Patient> GetAll()
    {
        return _patientRepository.GetAll();
    }

    public Patient Update(int id, Patient patient)
    {
        return _patientRepository.Update(id, patient);
    }
}
