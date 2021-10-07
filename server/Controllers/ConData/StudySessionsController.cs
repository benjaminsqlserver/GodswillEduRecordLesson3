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

  [ODataRoutePrefix("odata/ConData/StudySessions")]
  [Route("mvc/odata/ConData/StudySessions")]
  public partial class StudySessionsController : ODataController
  {
    private Data.ConDataContext context;

    public StudySessionsController(Data.ConDataContext context)
    {
      this.context = context;
    }
    // GET /odata/ConData/StudySessions
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.ConData.StudySession> GetStudySessions()
    {
      var items = this.context.StudySessions.AsQueryable<Models.ConData.StudySession>();
      this.OnStudySessionsRead(ref items);

      return items;
    }

    partial void OnStudySessionsRead(ref IQueryable<Models.ConData.StudySession> items);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("{StudySessionID}")]
    public SingleResult<StudySession> GetStudySession(int key)
    {
        var items = this.context.StudySessions.Where(i=>i.StudySessionID == key);
        return SingleResult.Create(items);
    }
    partial void OnStudySessionDeleted(Models.ConData.StudySession item);
    partial void OnAfterStudySessionDeleted(Models.ConData.StudySession item);

    [HttpDelete("{StudySessionID}")]
    public IActionResult DeleteStudySession(int key)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var items = this.context.StudySessions
                .Where(i => i.StudySessionID == key)
                .Include(i => i.StudentCourseRegistrations)
                .AsQueryable();

            items = EntityPatch.ApplyTo<Models.ConData.StudySession>(Request, items);

            var item = items.FirstOrDefault();

            if (item == null)
            {
                return StatusCode((int)HttpStatusCode.PreconditionFailed);
            }

            this.OnStudySessionDeleted(item);
            this.context.StudySessions.Remove(item);
            this.context.SaveChanges();
            this.OnAfterStudySessionDeleted(item);

            return new NoContentResult();
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnStudySessionUpdated(Models.ConData.StudySession item);
    partial void OnAfterStudySessionUpdated(Models.ConData.StudySession item);

    [HttpPut("{StudySessionID}")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PutStudySession(int key, [FromBody]Models.ConData.StudySession newItem)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var items = this.context.StudySessions
                .Where(i => i.StudySessionID == key)
                .Include(i => i.StudentCourseRegistrations)
                .AsQueryable();

            items = EntityPatch.ApplyTo<Models.ConData.StudySession>(Request, items);

            var item = items.FirstOrDefault();

            if (item == null)
            {
                return StatusCode((int)HttpStatusCode.PreconditionFailed);
            }

            this.OnStudySessionUpdated(newItem);
            this.context.StudySessions.Update(newItem);
            this.context.SaveChanges();

            var itemToReturn = this.context.StudySessions.Where(i => i.StudySessionID == key);
            this.OnAfterStudySessionUpdated(newItem);
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    [HttpPatch("{StudySessionID}")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PatchStudySession(int key, [FromBody]Delta<Models.ConData.StudySession> patch)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var items = this.context.StudySessions.Where(i => i.StudySessionID == key);

            items = EntityPatch.ApplyTo<Models.ConData.StudySession>(Request, items);

            var item = items.FirstOrDefault();

            if (item == null)
            {
                return StatusCode((int)HttpStatusCode.PreconditionFailed);
            }

            patch.Patch(item);

            this.OnStudySessionUpdated(item);
            this.context.StudySessions.Update(item);
            this.context.SaveChanges();

            var itemToReturn = this.context.StudySessions.Where(i => i.StudySessionID == key);
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnStudySessionCreated(Models.ConData.StudySession item);
    partial void OnAfterStudySessionCreated(Models.ConData.StudySession item);

    [HttpPost]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult Post([FromBody] Models.ConData.StudySession item)
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

            this.OnStudySessionCreated(item);
            this.context.StudySessions.Add(item);
            this.context.SaveChanges();

            return Created($"odata/ConData/StudySessions/{item.StudySessionID}", item);
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }
  }
}
