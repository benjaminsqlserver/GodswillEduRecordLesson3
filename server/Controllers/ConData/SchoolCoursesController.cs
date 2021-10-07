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

  [ODataRoutePrefix("odata/ConData/SchoolCourses")]
  [Route("mvc/odata/ConData/SchoolCourses")]
  public partial class SchoolCoursesController : ODataController
  {
    private Data.ConDataContext context;

    public SchoolCoursesController(Data.ConDataContext context)
    {
      this.context = context;
    }
    // GET /odata/ConData/SchoolCourses
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.ConData.SchoolCourse> GetSchoolCourses()
    {
      var items = this.context.SchoolCourses.AsQueryable<Models.ConData.SchoolCourse>();
      this.OnSchoolCoursesRead(ref items);

      return items;
    }

    partial void OnSchoolCoursesRead(ref IQueryable<Models.ConData.SchoolCourse> items);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("{CourseOfStudyID}")]
    public SingleResult<SchoolCourse> GetSchoolCourse(int key)
    {
        var items = this.context.SchoolCourses.Where(i=>i.CourseOfStudyID == key);
        return SingleResult.Create(items);
    }
    partial void OnSchoolCourseDeleted(Models.ConData.SchoolCourse item);
    partial void OnAfterSchoolCourseDeleted(Models.ConData.SchoolCourse item);

    [HttpDelete("{CourseOfStudyID}")]
    public IActionResult DeleteSchoolCourse(int key)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var items = this.context.SchoolCourses
                .Where(i => i.CourseOfStudyID == key)
                .Include(i => i.StudentCourseRegistrations)
                .Include(i => i.StudentCoursePayments)
                .AsQueryable();

            items = EntityPatch.ApplyTo<Models.ConData.SchoolCourse>(Request, items);

            var item = items.FirstOrDefault();

            if (item == null)
            {
                return StatusCode((int)HttpStatusCode.PreconditionFailed);
            }

            this.OnSchoolCourseDeleted(item);
            this.context.SchoolCourses.Remove(item);
            this.context.SaveChanges();
            this.OnAfterSchoolCourseDeleted(item);

            return new NoContentResult();
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnSchoolCourseUpdated(Models.ConData.SchoolCourse item);
    partial void OnAfterSchoolCourseUpdated(Models.ConData.SchoolCourse item);

    [HttpPut("{CourseOfStudyID}")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PutSchoolCourse(int key, [FromBody]Models.ConData.SchoolCourse newItem)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var items = this.context.SchoolCourses
                .Where(i => i.CourseOfStudyID == key)
                .Include(i => i.StudentCourseRegistrations)
                .Include(i => i.StudentCoursePayments)
                .AsQueryable();

            items = EntityPatch.ApplyTo<Models.ConData.SchoolCourse>(Request, items);

            var item = items.FirstOrDefault();

            if (item == null)
            {
                return StatusCode((int)HttpStatusCode.PreconditionFailed);
            }

            this.OnSchoolCourseUpdated(newItem);
            this.context.SchoolCourses.Update(newItem);
            this.context.SaveChanges();

            var itemToReturn = this.context.SchoolCourses.Where(i => i.CourseOfStudyID == key);
            this.OnAfterSchoolCourseUpdated(newItem);
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    [HttpPatch("{CourseOfStudyID}")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PatchSchoolCourse(int key, [FromBody]Delta<Models.ConData.SchoolCourse> patch)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var items = this.context.SchoolCourses.Where(i => i.CourseOfStudyID == key);

            items = EntityPatch.ApplyTo<Models.ConData.SchoolCourse>(Request, items);

            var item = items.FirstOrDefault();

            if (item == null)
            {
                return StatusCode((int)HttpStatusCode.PreconditionFailed);
            }

            patch.Patch(item);

            this.OnSchoolCourseUpdated(item);
            this.context.SchoolCourses.Update(item);
            this.context.SaveChanges();

            var itemToReturn = this.context.SchoolCourses.Where(i => i.CourseOfStudyID == key);
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnSchoolCourseCreated(Models.ConData.SchoolCourse item);
    partial void OnAfterSchoolCourseCreated(Models.ConData.SchoolCourse item);

    [HttpPost]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult Post([FromBody] Models.ConData.SchoolCourse item)
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

            this.OnSchoolCourseCreated(item);
            this.context.SchoolCourses.Add(item);
            this.context.SaveChanges();

            return Created($"odata/ConData/SchoolCourses/{item.CourseOfStudyID}", item);
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }
  }
}
