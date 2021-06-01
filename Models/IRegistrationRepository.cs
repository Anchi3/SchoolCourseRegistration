using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolCourseRegistration.Models
{
    public interface IRegistrationRepository
    {
        IEnumerable<Course> GetAllCourses();
        Course GetCourse(int Id);
        Course AddCourse(Course course);
        Course DeleteCourse(int Id);
        Course Update(Course courseEdit);



        IEnumerable<Student> GetAllStudents();
        Student GetStudent(int Id);
        Student AddStudent(Student student);
        Student DeleteStudent(int Id);
        Student Update(Student studentEdit);



        IEnumerable<Instructor> GetAllInstructors();
        Instructor GetInstructor(int Id);
        Instructor AddInstructor(Instructor instructor);
        Instructor DeleteInstructor(int Id);
        Instructor Update(Instructor instructorEdit);


        IEnumerable<Registration> GetAllRegistrations();
        Registration GetRegistration(int Id);
        Registration AddRegistration(Registration registration);
        Registration DeleteRegistration(int Id);
        Registration Update(Registration registrationEdit);
       



    }
}
