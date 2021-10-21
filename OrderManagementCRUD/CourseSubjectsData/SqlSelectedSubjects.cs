using OrderManagementCRUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Text;
using System.IO;
using System.Net;


namespace OrderManagementCRUD.CourseSubjectsData  
{
    public class SqlSelectedSubjects : ISubjectData
    {
        private SubjectContext _subjectContext;
        public SqlSelectedSubjects(SubjectContext subjectContext)
        {
            _subjectContext = subjectContext;
        }
        public Subject GetSubject(int Id)
        {
            var subject = _subjectContext.Subjects.Find(Id);
            return subject;
             
        }

        public List<Subject> GetSubjects()
        {
            return _subjectContext.Subjects.ToList();
        }

        public void GetCoursesJSONReceivedFromQueue(string message)
        {
            string messageJson = File.ReadAllText(@"Sample.json"); ;
            Course result = JsonConvert.DeserializeObject<Course>(messageJson);
            
            List<Subject> listofSubjects = new List<Subject> (result.Subjects);
            foreach (var item in listofSubjects)
            {
                Subject sub = new Subject();
                sub.guid = new Guid(); 
                sub.Id = item.Id;
                sub.Name = item.Name;
                sub.SemesterOffered = item.SemesterOffered;
                sub.IsScheduled = item.IsScheduled;
                sub.Core = item.Core;
                sub.CourseId = result.Id;
                sub.CourseName = result.Name;
                _subjectContext.Subjects.Add(sub);
              //  _subjectContext.Subjects.Update(sub);
                
            }
            _subjectContext.SaveChanges();
        }

        



        //public Subject AddSubject(Subject subject)
        //{
        //    //subject.Id = suGuid.NewGuid();
        //    _subjectContext.Subjects.Add(subject);
        //    _subjectContext.SaveChanges();
        //    return subject;
        //}

        //public void DeleteSubject(Subject subject)
        //{       
        //    _subjectContext.Subjects.Remove(subject);
        //    _subjectContext.SaveChanges();
        //}

        //public Subject EditSubject(Subject subject)
        //{
        //    var existingsubject = _subjectContext.Subjects.Find(subject.Id);
        //    if(existingsubject !=null)
        //    {
        //        _subjectContext.Subjects.Update(subject);
        //        _subjectContext.SaveChanges();
        //    }
        //    return subject;
        //}
        //public void GetSubjectsForCourseIDExt()
        //{

        //    [AllowAnonymous]
        //    [Route("CallAPI")]
        //    [HttpGet]
        //    public async Task<IActionResult> CallAPI()
        //    {
        //        using (var clilent = new HttpClient())
        //        {
        //            client.BaseAddress = new Uri("https://jsonplaceholder.typicode.com/");
        //            using (HttpResponseMessage response = await client.GetAsync("/1"))
        //            {
        //                var responseContent = response.Content.ReadAsStringAsync().Result;
        //                response.EnsureSuccessStatusCode();
        //                return Ok(responseContent);
        //            }
        //        }
        //    }



        //    //string exturl = String.Format("");
        //    //WebRequest requestObjGet = WebRequest.Create(exturl);
        //    //requestObjGet.Method = "GET";
        //    //HttpWebResponse responseObjGet = null;
        //    //responseObjGet = (HttpWebResponse)requestObjGet.GetResponse();
        //    //string strresult = null;

        //    //using (Stream stream = responseObjGet.GetResponseStream())
        //    //{
        //    //    StreamReader sr = new StreamReader(stream);
        //    //    strresult = sr.ReadToEnd();
        //    //    sr.Close();
        //    //}
        //    //=============================================================================
        //    string strUrl = String.Format("http://localhost:8080/course/{courseId}");
        //    WebRequest requestObjPost = WebRequest.Create(strUrl);
        //    requestObjPost.ContentType = "application/json";
        //    string postData = "";
        //    using (var streamWriter = new StreamWriter(requestObjPost.GetRequestStream()))
        //    {
        //        streamWriter.Write(postData);
        //        streamWriter.Flush();
        //        streamWriter.Close();

        //        var httpResponse = (HttpWebResponse)requestObjPost.GetResponse();
        //        using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
        //        {
        //            var resultfromExternal = StreamReader.ReadToEnd();
        //        }

        //    }
        //}
    }
}
