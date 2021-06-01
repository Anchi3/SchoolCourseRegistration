using Microsoft.EntityFrameworkCore;
using SchoolCourseRegistration.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SchoolCourseRegistration.ViewModel;



namespace SchoolCourseRegistration.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        public DbSet<Course> Courses { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Registration> Registrations { get; set; }
  

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>().HasData(

                new Course()
                {
                    Id = 1,
                    CourseNumber = 1101,
                    CourseName = "Cryo 101",
                    Description = "Ice Basics",
                    Credits = 3
                },

                new Course()
                {
                    Id = 2,
                    CourseNumber = 2101,
                    CourseName = "Pyro 101",
                    Description = "Fire Basics",
                    Credits = 5
                },

                new Course()
                {
                    Id = 3,
                    CourseNumber = 3101,
                    CourseName = "Dendro 101",
                    Description = "Tree Basics",
                    Credits = 3
                }
                );

            modelBuilder.Entity<Student>().HasData(

                new Student()
                {
                    Id = 1,
                    StudentNumber = 2101,
                    FirstName = "Ted",
                    LastName = "Mosby",
                    Email = "ted@mosby.ca"
                },

                new Student()
                {
                    Id = 2,
                    StudentNumber = 2102,
                    FirstName = "Marshall",
                    LastName = "Eriksen",
                    Email = "marshall@lawyered.ca"
                },

                new Student()
                {
                   Id = 3,
                   StudentNumber = 2103,
                   FirstName = "Barney",
                   LastName = "Stinson",
                   Email = "barney@pleas.ca"
                }
                );

            modelBuilder.Entity<Instructor>().HasData(

                new Instructor()
                {
                    Id = 1,
                    FirstName = "Arya",
                    LastName = "Stark",
                    Email = "arya@stark.ca"
                },

                new Instructor()
                {
                    Id = 2,
                    FirstName = "Danaerys",
                    LastName = "Targaryen",
                    Email = "dany@drogo.ca"
                },

                new Instructor()
                {
                    Id = 3,
                    FirstName = "Margaery",
                    LastName = "Tyrell",
                    Email = "margaery@tyrell.ca"
                }
                );

            modelBuilder.Entity<Registration>().HasData(

                new Registration()
                {
                    Id = 1,
                    RegistrationType = "Part Time",
                    StudentId = 1,
                    CourseId = 1101,
                    InstructorId = 1
                },

                new Registration()
                {
                    Id = 2,
                    RegistrationType = "Full Time",
                    StudentId = 2,
                    CourseId = 2101,
                    InstructorId = 2
                },

                new Registration()
                {
                    Id = 3,
                    RegistrationType = "Part Time",
                    StudentId = 3,
                    CourseId = 3101,
                    InstructorId = 3
                },

                new Registration()
                { 
                    Id = 4,
                    RegistrationType = "Full Time",
                    StudentId = 4,
                    CourseId = 2101,
                    InstructorId = 2
                }

                );

            base.OnModelCreating(modelBuilder);

        }
  

        public DbSet<SchoolCourseRegistration.Models.Student> Student { get; set; }
        public DbSet<SchoolCourseRegistration.Models.Course> Course { get; set; }
        public DbSet<SchoolCourseRegistration.Models.Instructor> Instructor { get; set; }
        public DbSet<SchoolCourseRegistration.Models.Registration> Registration { get; set; }

        public DbSet<SchoolCourseRegistration.ViewModel.CourseViewModel> CourseViewModel { get; set; }
        public DbSet<SchoolCourseRegistration.ViewModel.StudentViewModel> StudentViewModel { get; set; }
        public DbSet<SchoolCourseRegistration.ViewModel.InstructorViewModel> InstructorViewModel { get; set; }
        public DbSet<SchoolCourseRegistration.Models.StudentCourse> StudentCourse { get; set; }
        public DbSet<SchoolCourseRegistration.ViewModel.RegistrationViewModel> RegistrationViewModel { get; set; }

    }
}
