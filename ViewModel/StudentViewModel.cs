using SchoolCourseRegistration.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolCourseRegistration.ViewModel
{
    public class StudentViewModel
    {
        public int Id { get; set; }
        [ForeignKey("StudentID")]
        public Student Student { get; set; }

        public string PageTitle { get; set; }
    }
}
