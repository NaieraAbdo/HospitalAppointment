﻿using System.ComponentModel.DataAnnotations;

namespace HospitalAppointment.Models
{
    public class Appointment
    {
       public int Id { get; set; }
        public int DoctorId { get; set; }
        public string PatientName { get; set; }
        public DateTime? AppointmentDate { get; set; }
        public TimeSpan? AppointmentTime { get; set; }
        public Doctor Doctor { get; set; }
    }
}
