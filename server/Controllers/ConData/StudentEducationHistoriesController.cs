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

  [ODataRoutePrefix("odata/ConData/StudentEducationHistories")]
  [Route("mvc/odata/ConData/StudentEducationHistories")]
  public partial class StudentEducationHistoriesController : ODataController
  {
    private Data.ConDataContext context;

    public StudentEducationHistoriesController(Data.ConDataContext context)
    {
      this.context = context;
    }
    // GET /odata/ConData/StudentEducationHistories
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.ConData.StudentEducationHistory> GetStudentEducationHistories()
    {
      var items = this.context.StudentEducationHistories.AsQueryable<Models.ConData.StudentEducationHistory>();
      this.OnStudentEducationHistoriesRead(ref items);

      return items;
    }

    partial void OnStudentEducationHistoriesRead(ref IQueryable<Models.ConData.StudentEducationHistory> items);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("{EducationRecordID}")]
    public SingleResult<StudentEducationHistory> GetStudentEducationHistory(Int64 key)
    {
        var items = this.context.StudentEducationHistories.Where(i=>i.EducationRecordID == key);
        return SingleResult.Create(items);
    }
    partial void OnStudentEducationHistoryDeleted(Models.ConData.StudentEducationHistory item);
    partial void OnAfterStudentEducationHistoryDeleted(Models.ConData.StudentEducationHistory item);

    [HttpDelete("{EducationRecordID}")]
    public IActionResult DeleteStudentEducationHistory(Int64 key)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var items = this.context.StudentEducationHistories
                .Where(i => i.EducationRecordID == key)
                .AsQueryable();

            items = EntityPatch.ApplyTo<Models.ConData.StudentEducationHistory>(Request, items);

            var item = items.FirstOrDefault();

            if (item == null)
            {
                return StatusCode((int)HttpStatusCode.PreconditionFailed);
            }

            this.OnStudentEducationHistoryDeleted(item);
            this.context.StudentEducationHistories.Remove(item);
            this.context.SaveChanges();
            this.OnAfterStudentEducationHistoryDeleted(item);

            return new NoContentResult();
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnStudentEducationHistoryUpdated(Models.ConData.StudentEducationHistory item);
    partial void OnAfterStudentEducationHistoryUpdated(Models.ConData.StudentEducationHistory item);

    [HttpPut("{EducationRecordID}")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PutStudentEducationHistory(Int64 key, [FromBody]Models.ConData.StudentEducationHistory newItem)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var items = this.context.StudentEducationHistories
                .Where(i => i.EducationRecordID == key)
                .AsQueryable();

            items = EntityPatch.ApplyTo<Models.ConData.StudentEducationHistory>(Request, items);

            var item = items.FirstOrDefault();

            if (item == null)
            {
                return StatusCode((int)HttpStatusCode.PreconditionFailed);
            }

            this.OnStudentEducationHistoryUpdated(newItem);
            this.context.StudentEducationHistories.Update(newItem);
            this.context.SaveChanges();

            var itemToReturn = this.context.StudentEducationHistories.Where(i => i.EducationRecordID == key);
            Request.QueryString = Request.QueryString.Add("$expand", "StudentBiodatum,Qualification");
            this.OnAfterStudentEducationHistoryUpdated(newItem);
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    [HttpPatch("{EducationRecordID}")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PatchStudentEducationHistory(Int64 key, [FromBody]Delta<Models.ConData.StudentEducationHistory> patch)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var items = this.context.StudentEducationHistories.Where(i => i.EducationRecordID == key);

            items = EntityPatch.ApplyTo<Models.ConData.StudentEducationHistory>(Request, items);

            var item = items.FirstOrDefault();

            if (item == null)
            {
                return StatusCode((int)HttpStatusCode.PreconditionFailed);
            }

            patch.Patch(item);

            this.OnStudentEducationHistoryUpdated(item);
            this.context.StudentEducationHistories.Update(item);
            this.context.SaveChanges();

            var itemToReturn = this.context.StudentEducationHistories.Where(i => i.EducationRecordID == key);
            Request.QueryString = Request.QueryString.Add("$expand", "StudentBiodatum,Qualification");
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnStudentEducationHistoryCreated(Models.ConData.StudentEducationHistory item);
    partial void OnAfterStudentEducationHistoryCreated(Models.ConData.StudentEducationHistory item);

    [HttpPost]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult Post([FromBody] Models.ConData.StudentEducationHistory item)
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

            this.OnStudentEducationHistoryCreated(item);
            this.context.StudentEducationHistories.Add(item);
            this.context.SaveChanges();

            var key = item.EducationRecordID;

            var itemToReturn = this.context.StudentEducationHistories.Where(i => i.EducationRecordID == key);

            Request.QueryString = Request.QueryString.Add("$expand", "StudentBiodatum,Qualification");

            this.OnAfterStudentEducationHistoryCreated(item);

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
