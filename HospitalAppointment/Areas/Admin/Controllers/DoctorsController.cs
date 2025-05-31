using HospitalAppointment.Data;
using HospitalAppointment.Models;
using Microsoft.AspNetCore.Mvc;

namespace HospitalAppointment.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DoctorsController : Controller
    {
        public IActionResult Index()
        {
            var doctors = SampleDataDoctors.Doctors;
            return View(doctors);
        }

        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Create(Models.Doctor doctor)
        {
            SampleDataDoctors.Doctors.Add(doctor);
            return RedirectToAction(nameof(Index));
        }
    }
}
