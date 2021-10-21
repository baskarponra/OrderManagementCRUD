using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace OrderManagementCRUD.Models
{

    public class SelectedSubjects
    {
        public int StudentId { get; set; }
        public string CourseID { get; set; }
        public bool SubjectID { get; set; }
        public bool NAME { get; set; }
    }
   
}