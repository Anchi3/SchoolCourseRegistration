using SchoolCourseRegistration.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolCourseRegistration.Models
{
    public class SQLRegistrationRepository : IRegistrationRepository
    {
        private readonly ApplicationDbContext _context;
        
        public SQLRegistrationRepository(ApplicationDbContext Context)
        {
            this._context = Context;
        }

        //ADD(Create)
        public Course AddCourse(Course course)
        {
            if (course == null)
                throw new ArgumentNullException(nameof(course));
            Course newCourse = new Course();
            newCourse.Id = course.Id;
            newCourse.CourseNumber = course.CourseNumber;
            newCourse.CourseName = course.CourseName;
            newCourse.Description = course.Description;
            newCourse.Credits = course.Credits;
            _context.Courses.Add(newCourse);
            _context.SaveChanges();
            return course;
        }

        public Instructor AddInstructor(Instructor instructor)
        {
            if (instructor == null)
                throw new ArgumentNullException(nameof(instructor));
            Instructor newInstructor = new Instructor();
            newInstructor.Id = instructor.Id;
            newInstructor.FirstName = instructor.FirstName;
            newInstructor.LastName = instructor.LastName;
            newInstructor.Email = instructor.Email;
            _context.Instructors.Add(newInstructor);
            _context.SaveChanges();
            return instructor;
        }

        public Registration AddRegistration(Registration registration)
        {
            if (registration == null)
                throw new ArgumentNullException(nameof(registration));
            Registration newRegistration = new Registration();
            newRegistration.Id = registration.Id;
            newRegistration.RegistrationType = registration.RegistrationType;
            newRegistration.StudentId = registration.StudentId;
            newRegistration.CourseId = registration.CourseId;
            newRegistration.InstructorId = registration.InstructorId;
            _context.Registrations.Add(newRegistration);
            _context.SaveChanges();
            return registration;
        }

        public Student AddStudent(Student student)
        {
            if (student == null)
                throw new ArgumentNullException(nameof(student));
            Student newStudent = new Student();
            newStudent.Id = student.Id;
            newStudent.StudentNumber = student.StudentNumber;
            newStudent.FirstName = student.FirstName;
            newStudent.LastName = student.LastName;
            newStudent.Email = student.Email;
            _context.Students.Add(newStudent);
            _context.SaveChanges();
            return student;
        }


        //DELETE
        public Course DeleteCourse(int Id)
        {
                if (Id == 0)
                    throw new ArgumentNullException(nameof(Id));

                Course coursedelete = _context.Courses.Find(Id);

                _context.Courses.Remove(coursedelete);
                _context.SaveChanges();

                return coursedelete;
        }
    

        public Instructor DeleteInstructor(int Id)
        {
            if (Id == 0)
                throw new ArgumentNullException(nameof(Id));

            Instructor instructordelete = _context.Instructors.Find(Id);

            _context.Instructors.Remove(instructordelete);
            _context.SaveChanges();

            return instructordelete;
        }

        public Registration DeleteRegistration(int Id)
        {
            if (Id == 0)
                throw new ArgumentNullException(nameof(Id));

            Registration registrationdelete = _context.Registrations.Find(Id);

            _context.Registrations.Remove(registrationdelete);
            _context.SaveChanges();

            return registrationdelete;
        }

        public Student DeleteStudent(int Id)
        {
            if (Id == 0)
                throw new ArgumentNullException(nameof(Id));

            Student studentdelete = _context.Students.Find(Id);

            _context.Students.Remove(studentdelete);
            _context.SaveChanges();

            return studentdelete;
        }

        //GET ALL(List)
        public IEnumerable<Course> GetAllCourses()
        {
            return _context.Courses;
        }

        public IEnumerable<Instructor> GetAllInstructors()
        {
            return _context.Instructors;
        }

        public IEnumerable<Registration> GetAllRegistrations()
        {
            return _context.Registrations;
        }

        public IEnumerable<Student> GetAllStudents()
        {
            return _context.Students;
        }

        //GET(Read Details)
        public Course GetCourse(int Id)
        {
            return _context.Courses.Find(Id);
        }

        public Instructor GetInstructor(int Id)
        {
            return _context.Instructors.Find(Id);
        }

        public Registration GetRegistration(int Id)
        {
            return _context.Registrations.Find(Id);
        }

        public Student GetStudent(int Id)
        {
            return _context.Students.Find(Id);
        }


        //UPDATE(Edit)
        public Course Update(Course courseEdit)
        {
            var course = _context.Courses.Attach(courseEdit);
            course.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return courseEdit;

        }

        public Student Update(Student studentEdit)
        {
            var student = _context.Students.Attach(studentEdit);
            student.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return studentEdit;
        }

        public Instructor Update(Instructor instructorEdit)
        {
            var instructor = _context.Instructors.Attach(instructorEdit);
            instructor.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return instructorEdit;
        }

        public Registration Update(Registration registrationEdit)
        {
            var registration = _context.Registrations.Attach(registrationEdit);
            registration.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return registrationEdit;
        }
      
    }
}
