using System;
using System.Net;
using System.Data;
using System.Linq;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.AspNet.OData.Query;



namespace GodswillEduRecord.Controllers.ConData
{
  using Models;
  using Data;
  using Models.ConData;

  [ODataRoutePrefix("odata/ConData/StudentCourseRegistrations")]
  [Route("mvc/odata/ConData/StudentCourseRegistrations")]
  public partial class StudentCourseRegistrationsController : ODataController
  {
    private Data.ConDataContext context;

    public StudentCourseRegistrationsController(Data.ConDataContext context)
    {
      this.context = context;
    }
    // GET /odata/ConData/StudentCourseRegistrations
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.ConData.StudentCourseRegistration> GetStudentCourseRegistrations()
    {
      var items = this.context.StudentCourseRegistrations.AsQueryable<Models.ConData.StudentCourseRegistration>();
      this.OnStudentCourseRegistrationsRead(ref items);

      return items;
    }

    partial void OnStudentCourseRegistrationsRead(ref IQueryable<Models.ConData.StudentCourseRegistration> items);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("{CourseRegistrationID}")]
    public SingleResult<StudentCourseRegistration> GetStudentCourseRegistration(Int64 key)
    {
        var items = this.context.StudentCourseRegistrations.Where(i=>i.CourseRegistrationID == key);
        return SingleResult.Create(items);
    }
    partial void OnStudentCourseRegistrationDeleted(Models.ConData.StudentCourseRegistration item);
    partial void OnAfterStudentCourseRegistrationDeleted(Models.ConData.StudentCourseRegistration item);

    [HttpDelete("{CourseRegistrationID}")]
    public IActionResult DeleteStudentCourseRegistration(Int64 key)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var items = this.context.StudentCourseRegistrations
                .Where(i => i.CourseRegistrationID == key)
                .AsQueryable();

            items = EntityPatch.ApplyTo<Models.ConData.StudentCourseRegistration>(Request, items);

            var item = items.FirstOrDefault();

            if (item == null)
            {
                return StatusCode((int)HttpStatusCode.PreconditionFailed);
            }

            this.OnStudentCourseRegistrationDeleted(item);
            this.context.StudentCourseRegistrations.Remove(item);
            this.context.SaveChanges();
            this.OnAfterStudentCourseRegistrationDeleted(item);

            return new NoContentResult();
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnStudentCourseRegistrationUpdated(Models.ConData.StudentCourseRegistration item);
    partial void OnAfterStudentCourseRegistrationUpdated(Models.ConData.StudentCourseRegistration item);

    [HttpPut("{CourseRegistrationID}")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PutStudentCourseRegistration(Int64 key, [FromBody]Models.ConData.StudentCourseRegistration newItem)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var items = this.context.StudentCourseRegistrations
                .Where(i => i.CourseRegistrationID == key)
                .AsQueryable();

            items = EntityPatch.ApplyTo<Models.ConData.StudentCourseRegistration>(Request, items);

            var item = items.FirstOrDefault();

            if (item == null)
            {
                return StatusCode((int)HttpStatusCode.PreconditionFailed);
            }

            this.OnStudentCourseRegistrationUpdated(newItem);
            this.context.StudentCourseRegistrations.Update(newItem);
            this.context.SaveChanges();

            var itemToReturn = this.context.StudentCourseRegistrations.Where(i => i.CourseRegistrationID == key);
            Request.QueryString = Request.QueryString.Add("$expand", "StudentBiodatum,SchoolCourse,StudySession");
            this.OnAfterStudentCourseRegistrationUpdated(newItem);
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    [HttpPatch("{CourseRegistrationID}")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PatchStudentCourseRegistration(Int64 key, [FromBody]Delta<Models.ConData.StudentCourseRegistration> patch)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var items = this.context.StudentCourseRegistrations.Where(i => i.CourseRegistrationID == key);

            items = EntityPatch.ApplyTo<Models.ConData.StudentCourseRegistration>(Request, items);

            var item = items.FirstOrDefault();

            if (item == null)
            {
                return StatusCode((int)HttpStatusCode.PreconditionFailed);
            }

            patch.Patch(item);

            this.OnStudentCourseRegistrationUpdated(item);
            this.context.StudentCourseRegistrations.Update(item);
            this.context.SaveChanges();

            var itemToReturn = this.context.StudentCourseRegistrations.Where(i => i.CourseRegistrationID == key);
            Request.QueryString = Request.QueryString.Add("$expand", "StudentBiodatum,SchoolCourse,StudySession");
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnStudentCourseRegistrationCreated(Models.ConData.StudentCourseRegistration item);
    partial void OnAfterStudentCourseRegistrationCreated(Models.ConData.StudentCourseRegistration item);

    [HttpPost]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult Post([FromBody] Models.ConData.StudentCourseRegistration item)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (item == null)
            {
                return BadRequest();
            }

            this.OnStudentCourseRegistrationCreated(item);
            this.context.StudentCourseRegistrations.Add(item);
            this.context.SaveChanges();

            var key = item.CourseRegistrationID;

            var itemToReturn = this.context.StudentCourseRegistrations.Where(i => i.CourseRegistrationID == key);

            Request.QueryString = Request.QueryString.Add("$expand", "StudentBiodatum,SchoolCourse,StudySession");

            this.OnAfterStudentCourseRegistrationCreated(item);

            return new ObjectResult(SingleResult.Create(itemToReturn))
            {
                StatusCode = 201
            };
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }
  }
}
