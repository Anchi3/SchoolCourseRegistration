using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolCourseRegistration.Models
{
    public class StudentCourse
    {
        [Key]
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int CourseId { get; set; }
    }
}
