using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SchoolCourseRegistration.Data;
using SchoolCourseRegistration.Models;
using SchoolCourseRegistration.ViewModel;

namespace SchoolCourseRegistration.Controllers
{
    public class RegistrationsController : Controller
    {
        private readonly IRegistrationRepository _registrations;

        private readonly ILogger<StudentsController> _logger;


        public RegistrationsController(IRegistrationRepository registrationsRepository, ILogger<StudentsController> logger)

        {
            _registrations = registrationsRepository;
            _logger = logger;
        }

        public IActionResult Index()
        {
            var model = _registrations.GetAllRegistrations();
            return View(model);
        }


        // Details: Registrations/View
        public IActionResult Details(int id)
        {
            RegistrationViewModel registrationViewModel = new RegistrationViewModel()
            {
                Registration = _registrations.GetRegistration(id),
                PageTitle = "Registrations Details"
            };

            return View(registrationViewModel);
        }

        // GET: Registrations/Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Registration registration)
        {
            if (ModelState.IsValid)
            {
                Registration newRegistration = _registrations.AddRegistration(registration);
                return RedirectToAction("Index", new { RegistrationId = newRegistration.Id });

            }
            return View();
        }

        //Update: Registrations/Edit

        [HttpGet]
        public ViewResult Edit(int id)
        {
            Registration registration = _registrations.GetRegistration(id);


            Registration registrationModel = new Registration
            {
                Id = registration.Id,
                RegistrationType = registration.RegistrationType,
                StudentId = registration.StudentId,
                CourseId = registration.CourseId,
                InstructorId = registration.InstructorId

            };

            return View(registrationModel);

        }
        [HttpPost]
        public IActionResult Edit(Registration model)
        {
            if (ModelState.IsValid)
            {
                Registration registration = _registrations.GetRegistration(model.Id);
                registration.RegistrationType = model.RegistrationType;
                registration.StudentId = model.StudentId;
                registration.CourseId = model.CourseId;
                registration.InstructorId = model.InstructorId;

                Registration UpdateRegistration = _registrations.Update(registration);

                return RedirectToAction("Index");
            }

            return View(model);
        }



        // Delete: Registrations/Delete

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var registrations = _registrations.GetRegistration(id);

            return View(registrations);

        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirm(int id)
        {
            var registrations = _registrations.DeleteRegistration(id);
            return RedirectToAction("Index");
        }

    }
}
