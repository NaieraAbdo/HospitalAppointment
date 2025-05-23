using HospitalAppointment.Models;
using Microsoft.AspNetCore.Mvc;

namespace HospitalAppointment.Controllers
{
    public class DoctorsController : Controller
    {
        public IActionResult BookAppointment()
        {
            var data = new SampleDataDoctors();
            var doctors = data.doctors;
            return View(doctors);

        }
    }
}
