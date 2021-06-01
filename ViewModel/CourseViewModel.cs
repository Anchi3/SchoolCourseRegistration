using SchoolCourseRegistration.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolCourseRegistration.ViewModel
{
    public class CourseViewModel
    {
        public int Id { get; set; }
        [ForeignKey("CourseID")]
        public Course Course { get; set; }

        public string PageTitle { get; set; }
    }

}
