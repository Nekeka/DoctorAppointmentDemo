namespace MyDoctorAppointment.Domain.Entities
{
    //change to public
    public class Appointment : Auditable
    {
        public Patient? Patient { get; set; }

        public Doctor? Doctor { get; set; }

        public DateTime DateTimeFrom { get; set; }

        public DateTime DateTimeTo { get; set; }

        public string? Description { get; set; }
    }
}
