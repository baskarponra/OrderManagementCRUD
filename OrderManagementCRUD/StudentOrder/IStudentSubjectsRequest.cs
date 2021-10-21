using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OrderManagementCRUD.Models;

namespace OrderManagementCRUD.StudentOrder
{
    interface IStudentSubjectsRequest
    {
        Task<int> GetSubjectsForCourseID(int iCourseID);
    }
}
