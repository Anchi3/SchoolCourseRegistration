using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolCourseRegistration.Models
{
    public class Course
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int CourseNumber { get; set; }
        [Required]
        public string CourseName  { get; set; }
        public string Description { get; set; }
        public int Credits { get; set; }       
    }
}
