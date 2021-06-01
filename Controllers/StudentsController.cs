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

    public class StudentsController : Controller
    {
        private readonly IRegistrationRepository _students;

        private readonly ILogger<StudentsController> _logger;


        public StudentsController(IRegistrationRepository studentsRepository, ILogger<StudentsController> logger)

        {
            _students = studentsRepository;
            _logger = logger;
        }

        public IActionResult Index()
        {
            var model = _students.GetAllStudents();
            return View(model);
        }


        // Details: Students/View
        public IActionResult Details(int id)
        {
            StudentViewModel studentViewModel = new StudentViewModel()
            {
                Student = _students.GetStudent(id),
                PageTitle = "Students Details"
            };

            return View(studentViewModel);
        }

        // GET: Students/Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Student student)
        {
            if (ModelState.IsValid)
            {
                Student newStudent = _students.AddStudent(student);
                return RedirectToAction("Index", new { StudentId = newStudent.Id });

            }
            return View();
        }

        //Update: Students/Edit

        [HttpGet]
        public ViewResult Edit(int id)
        {
            Student student = _students.GetStudent(id);


            Student studentModel = new Student
            {
                Id = student.Id,
                StudentNumber = student.StudentNumber,
                FirstName = student.FirstName,
                LastName = student.LastName,
                Email = student.Email

            };

            return View(studentModel);

        }
        [HttpPost]
        public IActionResult Edit(Student model)
        {
            if (ModelState.IsValid)
            {
                Student student = _students.GetStudent(model.Id);
                student.StudentNumber = model.StudentNumber;
                student.FirstName = model.FirstName;
                student.LastName = model.LastName;
                student.Email = model.Email;

                Student updateStudent = _students.Update(student);

                return RedirectToAction("Index");
            }

            return View(model);
        }



        // Delete: Courses/Delete

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var students = _students.GetStudent(id);

            return View(students);

        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirm(int id)
        {
            var students = _students.DeleteStudent(id);
            return RedirectToAction("Index");
        }

    }
}
    //{
    //    public class StudentsController : Controller
    //    {
    //        private readonly ApplicationDbContext _context;

    //        public StudentsController(ApplicationDbContext context)
    //        {
    //            _context = context;
    //        }

    //        // GET: Students
    //        public async Task<IActionResult> Index()
    //        {
    //            return View(await _context.Student.ToListAsync());
    //        }

    //        // GET: Students/Details/5
    //        public async Task<IActionResult> Details(int? id)
    //        {
    //            if (id == null)
    //            {
    //                return NotFound();
    //            }

    //            var student = await _context.Student
    //                .FirstOrDefaultAsync(m => m.Id == id);
    //            if (student == null)
    //            {
    //                return NotFound();
    //            }

    //            return View(student);
    //        }

    //        // GET: Students/Create
    //        public IActionResult Create()
    //        {
    //            return View();
    //        }

    //        // POST: Students/Create
    //        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
    //        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    //        [HttpPost]
    //        [ValidateAntiForgeryToken]
    //        public async Task<IActionResult> Create([Bind("Id,StudentNumber,FirstName,LastName,Email")] Student student)
    //        {
    //            if (ModelState.IsValid)
    //            {
    //                _context.Add(student);
    //                await _context.SaveChangesAsync();
    //                return RedirectToAction(nameof(Index));
    //            }
    //            return View(student);
    //        }

    //        // GET: Students/Edit/5
    //        public async Task<IActionResult> Edit(int? id)
    //        {
    //            if (id == null)
    //            {
    //                return NotFound();
    //            }

    //            var student = await _context.Student.FindAsync(id);
    //            if (student == null)
    //            {
    //                return NotFound();
    //            }
    //            return View(student);
    //        }

    //        // POST: Students/Edit/5
    //        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
    //        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    //        [HttpPost]
    //        [ValidateAntiForgeryToken]
    //        public async Task<IActionResult> Edit(int id, [Bind("Id,StudentNumber,FirstName,LastName,Email")] Student student)
    //        {
    //            if (id != student.Id)
    //            {
    //                return NotFound();
    //            }

    //            if (ModelState.IsValid)
    //            {
    //                try
    //                {
    //                    _context.Update(student);
    //                    await _context.SaveChangesAsync();
    //                }
    //                catch (DbUpdateConcurrencyException)
    //                {
    //                    if (!StudentExists(student.Id))
    //                    {
    //                        return NotFound();
    //                    }
    //                    else
    //                    {
    //                        throw;
    //                    }
    //                }
    //                return RedirectToAction(nameof(Index));
    //            }
    //            return View(student);
    //        }

    //        // GET: Students/Delete/5
    //        public async Task<IActionResult> Delete(int? id)
    //        {
    //            if (id == null)
    //            {
    //                return NotFound();
    //            }

    //            var student = await _context.Student
    //                .FirstOrDefaultAsync(m => m.Id == id);
    //            if (student == null)
    //            {
    //                return NotFound();
    //            }

    //            return View(student);
    //        }

    //        // POST: Students/Delete/5
    //        [HttpPost, ActionName("Delete")]
    //        [ValidateAntiForgeryToken]
    //        public async Task<IActionResult> DeleteConfirmed(int id)
    //        {
    //            var student = await _context.Student.FindAsync(id);
    //            _context.Student.Remove(student);
    //            await _context.SaveChangesAsync();
    //            return RedirectToAction(nameof(Index));
    //        }

    //        private bool StudentExists(int id)
    //        {
    //            return _context.Student.Any(e => e.Id == id);
    //        }
    //    }
    //}

