using System.ComponentModel.DataAnnotations;

namespace HospitalAppointment.ViewModels
{
    public class AppointmentViewModel
    {
        public int DoctorId { get; set; }

        [Required(ErrorMessage = "Patient name is required.")]
        public string PatientName { get; set; }

        [Required(ErrorMessage = "Appointment date is required.")]
        [DataType(DataType.Date)]
        public DateTime? AppointmentDate { get; set; }

        [Required(ErrorMessage = "Appointment time is required.")]
        [DataType(DataType.Time)]
        public TimeSpan? AppointmentTime { get; set; }
        public string DoctorName { get; set; }

    }
}
