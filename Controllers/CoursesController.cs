using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using SchoolCourseRegistration.Models;
using SchoolCourseRegistration.ViewModel;

namespace SchoolCourseRegistration.Controllers
{
    public class CoursesController : Controller
    {
        private readonly IRegistrationRepository _courses;

        private readonly ILogger<StudentsController> _logger;


        public CoursesController(IRegistrationRepository coursesRepository, ILogger<StudentsController> logger)

        {
            _courses = coursesRepository;
            _logger = logger;
        }

        public IActionResult Index()
        {
            var model = _courses.GetAllCourses();
            return View(model);
        }


       // Details: Courses/View
        public IActionResult Details(int id)
        {
            CourseViewModel courseViewModel = new CourseViewModel()
            {
                Course = _courses.GetCourse(id),
                PageTitle = "Courses Details"
            };

            return View(courseViewModel);
        }

        // GET: Courses/Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Course course)
        {
            if (ModelState.IsValid)
            {
                Course newCourse = _courses.AddCourse(course);
                return RedirectToAction("Index", new { CourseId = newCourse.Id });

            }
            return View();
        }

        //Update: Courses/Edit

        [HttpGet]
        public ViewResult Edit(int id)
        {
            Course course = _courses.GetCourse(id);


            Course courseModel = new Course
            {
                Id = course.Id,
                CourseName = course.CourseName,
                CourseNumber = course.CourseNumber,
                Description = course.Description,
                Credits = course.Credits

            };

            return View(courseModel);

        }
        [HttpPost]
        public IActionResult Edit(Course model)
        {
            if (ModelState.IsValid)
            {
                Course course = _courses.GetCourse(model.Id);
                course.CourseNumber = model.CourseNumber;
                course.CourseName = model.CourseName;
                course.Description = model.Description;
                course.Credits = model.Credits;

                Course updateCourse = _courses.Update(course);

                return RedirectToAction("Index");
            }

            return View(model);
        }



                // Delete: Courses/Delete

                [HttpGet]
        public IActionResult Delete(int id)
        {
            var courses = _courses.GetCourse(id);

            return View(courses);

        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirm(int id)
        {
            var courses = _courses.DeleteCourse(id);
            return RedirectToAction("Index");
        }

    }
}
