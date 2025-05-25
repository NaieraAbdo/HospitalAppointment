using HospitalAppointment.Data;
using HospitalAppointment.Models;
using HospitalAppointment.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace HospitalAppointment.Controllers
{
    public class DoctorsController : Controller
    {
        public IActionResult BookAppointment(string searchName = "", string specialization = "All", int page = 1)
        {
            var data = new SampleDataDoctors();
            var doctors = data.doctors.AsQueryable();


            if (searchName is not null)
            {
                doctors = doctors.Where(d => d.Name.Contains(searchName, System.StringComparison.OrdinalIgnoreCase));
            }

            if (specialization is not null && specialization != "All")
            {
                doctors = doctors.Where(d => d.Specialization == specialization);
            }

            int totalDoctors = doctors.Count();
            int totalPages = (int)Math.Ceiling(totalDoctors / (double)3);
            var doctorsPaged = doctors.Skip((page - 1) * 3).Take(3).ToList();

            ViewBag.CurrentPage = page;
            ViewBag.TotalPages = totalPages;
            ViewBag.SearchName = searchName;
            ViewBag.SelectedSpecialization = specialization;

            return View(doctorsPaged);
        }


        public ActionResult CompleteAppointment(int doctorId)
        {
            var data = new SampleDataDoctors();
            var doctor = data.doctors.FirstOrDefault(d => d.Id == doctorId);

            if (doctor == null)
                return NotFound();

            var viewModel = new AppointmentViewModel
            {
                DoctorId = doctor.Id,
                DoctorName = doctor.Name
            };

            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CompleteAppointment(AppointmentViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var appointment = new Appointment
            {
                DoctorId = model.DoctorId,
                PatientName = model.PatientName,
                AppointmentDate = model.AppointmentDate,
                AppointmentTime = model.AppointmentTime
            };

            var _context = new ApplicationDbContext();
            _context.Appointments.Add(appointment);
            _context.SaveChanges();

            ViewBag.ShowSuccessModal = "true";
            ModelState.Clear();
            var doctorName = new SampleDataDoctors().doctors.FirstOrDefault(d => d.Id == model.DoctorId)?.Name;
            return View(new AppointmentViewModel { DoctorId = model.DoctorId,
                DoctorName = doctorName
            });

        }


        public IActionResult ListAppointments()
        {
            var _context = new ApplicationDbContext();
            var appointments = _context.Appointments.ToList();
            return View(appointments);
        }



    }
}
