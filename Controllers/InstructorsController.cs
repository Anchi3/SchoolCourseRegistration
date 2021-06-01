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
    public class InstructorsController : Controller
    {

        private readonly IRegistrationRepository _instructors;

        private readonly ILogger<InstructorsController> _logger;


        public InstructorsController(IRegistrationRepository instructorsRepository, ILogger<InstructorsController> logger)

        {
            _instructors = instructorsRepository;
            _logger = logger;
        }

        public IActionResult Index()
        {
            var model = _instructors.GetAllInstructors();
            return View(model);
        }


        // Details: Instructors/View
        public IActionResult Details(int id)
        {
            InstructorViewModel instructorViewModel = new InstructorViewModel()
            {
                Instructor = _instructors.GetInstructor(id),
                PageTitle = "Instructors Details"
            };

            return View(instructorViewModel);
        }

        // GET: Instructors/Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Instructor instructor)
        {
            if (ModelState.IsValid)
            {
                Instructor newInstructor = _instructors.AddInstructor(instructor);
                return RedirectToAction("Index", new { InstructorId = newInstructor.Id });

            }
            return View();
        }

        //Update: Instructors/Edit

        [HttpGet]
        public ViewResult Edit(int id)
        {
            Instructor instructor = _instructors.GetInstructor(id);


            Instructor instructorModel = new Instructor
            {
                Id = instructor.Id,
                FirstName = instructor.FirstName,
                LastName = instructor.LastName,
                Email = instructor.Email
            };

            return View(instructorModel);

        }

        [HttpPost]
        public IActionResult Edit(Instructor model)
        {
            if (ModelState.IsValid)
            {
                Instructor instructor = _instructors.GetInstructor(model.Id);
                instructor.Id = model.Id;
                instructor.FirstName = model.FirstName;
                instructor.LastName = model.LastName;
                instructor.Email = model.Email;

                Instructor updateInstructor = _instructors.Update(instructor);

                return RedirectToAction("Index");
            }

            return View(model);
        }

        // Delete: Instructors/Delete

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var instructors = _instructors.GetInstructor(id);

            return View(instructors);

        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirm(int id)
        {
            var courses = _instructors.DeleteInstructor(id);
            return RedirectToAction("Index");
        }

    }
}