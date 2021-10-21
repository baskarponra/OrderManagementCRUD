using OrderManagementCRUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderManagementCRUD.CourseSubjectsData
{
    public interface ISubjectData 
    {
        List<Subject> GetSubjects();
        Subject GetSubject(int Id);
       // Subject AddSubject(Subject subject);
        //void DeleteSubject(Subject subject);
        //Subject EditSubject(Subject subject);

        void GetCoursesJSONReceivedFromQueue(string message);
        
    }
}


//namespace OrderManagementCRUD.CourseSubjectsData
//{
//    public interface ICourseSubjectAPI
//    {
//        List<Subject> GetCoursesJSONReceivedFromQueue(string message);

//    }
//}
