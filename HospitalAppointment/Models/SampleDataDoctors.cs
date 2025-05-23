namespace HospitalAppointment.Models
{
    public class SampleDataDoctors
    {
        public List<Doctor> doctors;
        public SampleDataDoctors()
        {
            doctors = new List<Doctor>
            {
            new Doctor { Id = 1, Name = "Dr. John Smith", Specialization = "Cardiology", Img = "doctor1.jpg" },
            new Doctor { Id = 2, Name = "Dr. Sarah Johnson", Specialization = "Pediatrics", Img = "doctor5.jpg" },
            new Doctor { Id = 3, Name = "Dr. Emily Davis", Specialization = "Dermatology", Img = "doctor3.jpg" },
             new Doctor { Id = 4, Name = "Dr. Michael Lee", Specialization = "Orthopedics", Img = "doctor4.jpg" },
            new Doctor { Id = 5, Name = "Dr. William Clark", Specialization = "Neurology", Img = "doctor2.jpg" },
            };
        }
    }
}
