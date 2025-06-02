using HospitalAppointment.Data;
using HospitalAppointment.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HospitalAppointment.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DoctorsController : Controller
    {
        private readonly ApplicationDbContext _context = new();
        public IActionResult Index()
        {
            var doctors = _context.Doctors.ToList();
            return View(doctors);
        }

        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Create(Models.Doctor doctor,IFormFile? Img)
        {
            if(Img is not null && Img.Length > 0)
            {
                //Add file to wwwroot
                var fileName = Guid.NewGuid().ToString() +Path.GetExtension(Img.FileName);
               var path = Path.Combine(Directory.GetCurrentDirectory(),"wwwroot\\images\\",fileName);

                using (var stream = System.IO.File.Create(path))
                {
                    Img.CopyTo(stream);
                }
                //Add file name to DB
                doctor.Img = fileName;
              
            }
            _context.Doctors.Add(doctor);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));

        }

        public IActionResult Edit([FromRoute] int id)
        {
            var doctor = _context.Doctors.Find(id);
            if (doctor is not null)
                return View(doctor);
            return RedirectToAction("NotFoundPage", "Home");
        }

        [HttpPost]
        public IActionResult Edit(Models.Doctor doctor, IFormFile? NewImg)
        {
      
            if (NewImg != null && NewImg.Length > 0)
            {
                var fileName = Guid.NewGuid().ToString() + Path.GetExtension(NewImg.FileName);
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images\\", fileName);

                using (var stream = System.IO.File.Create(path))
                {
                    NewImg.CopyTo(stream);
                }
                doctor.Img = fileName;
            }

            _context.Doctors.Update(doctor);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
        public IActionResult Delete([FromRoute] int id)
        {
            var doctor = _context.Doctors.Find(id);
            if (doctor is not null)
            {
                //Delete img
                var path = Path.Combine(Directory.GetCurrentDirectory(),"wwwroot\\images\\",doctor.Img);
                if (System.IO.File.Exists(path))
                {
                    System.IO.File.Delete(path);
                }
                _context.Doctors.Remove(doctor);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction("NotFoundPage", "Home");
        }
    }
}
