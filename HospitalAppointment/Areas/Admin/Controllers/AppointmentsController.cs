using HospitalAppointment.Data;
using HospitalAppointment.Models;
using Microsoft.AspNetCore.Mvc;

namespace HospitalAppointment.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AppointmentsController : Controller
    {
        private readonly ApplicationDbContext _context = new ();
        public IActionResult Index()
        {
            var appointments = _context.Appointments;
            return View(appointments.ToList());
        }

        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Create(Appointment appointment)
        {
            _context.Appointments.Add(appointment);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit([FromRoute]int id)
        {
            var appointment = _context.Appointments.Find(id);
            if(appointment is not null)
                return View(appointment);
            return RedirectToAction("NotFoundPage", "Home");
        }

        [HttpPost]
        public IActionResult Edit(Appointment appointment)
        {
            _context.Appointments.Update(appointment);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete([FromRoute]int id)
        {
            var appointment = _context.Appointments.Find(id);
            if (appointment is not null)
            {
                _context.Appointments.Remove(appointment);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction("NotFoundPage", "Home");
        }
    }
}
