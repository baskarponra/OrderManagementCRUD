using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderManagementCRUD.CourseSubjectsData;
using OrderManagementCRUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Plain.RabbitMQ;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using System.Net.Http;

namespace OrderManagementCRUD.Controllers
{
     
    public class SubjectsController : ControllerBase
    {
        private ISubjectData _subjectData;
        public SubjectsController(ISubjectData subjectData)
        {
            _subjectData = subjectData;
        }

       
        [HttpGet]
        [Route("api/[Controller]")]
        public IActionResult GetSubjects()
        {
            return Ok(_subjectData.GetSubjects());
        }

        [HttpGet]
        [Route("api/[Controller]/{id}")]
        public IActionResult GetSubject(int Id)
        {
            var subject = _subjectData.GetSubject(Id);
            if (subject != null)
            {
                return Ok(subject);
            }
            return NotFound($"Subject with id:{Id} was not found");
        }

        

        [AllowAnonymous]
        [Route("GetSubjectsForCourseIDExt")]
        [HttpGet]
        public async Task<IActionResult> GetSubjectsForCourseIDExt(int CourseID)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:8080/");
                using (HttpResponseMessage response = await client.GetAsync("course/{CourseID}"))
                {
                    var responseContent = response.Content.ReadAsStringAsync().Result;
                    response.EnsureSuccessStatusCode();
                    return Ok(responseContent);
                }
            }
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("GetCoursesJSONReceivedFromQueue")]
        public IActionResult GetCoursesJSONReceivedFromQueue(string str)
        {
            _subjectData.GetCoursesJSONReceivedFromQueue(str);
            return Ok();
        }
        //[HttpPost]
        //[Route("api/[Controller]")]
        //public IActionResult AddSubject(Subject subject)
        //{
        //    _subjectData.AddSubject(subject);
        //    return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + subject.Id,
        //        subject);
        //}


        //[HttpDelete]
        //[Route("api/[Controller]/{id}")]
        //public IActionResult DeleteSubject(Guid id)
        //{
        //    var subject = _subjectData.GetSubject(id);
        //    if (subject != null)
        //    {
        //        _subjectData.DeleteSubject(subject);
        //        return Ok();
        //    }
        //    return NotFound($"Subject with id:{id} was not found");
        //}

        //[HttpPatch]
        //[Route("api/[Controller]/{id}")]
        //public IActionResult EditSubject(Guid id, Subject subject)
        //{
        //    var existingSubject = _subjectData.GetSubject(id);
        //    if (existingSubject != null)
        //    {
        //        subject.Id = existingSubject.Id;
        //        _subjectData.EditSubject(subject);

        //    }
        //    return Ok(subject);
        //}
    }
}
