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

  [ODataRoutePrefix("odata/ConData/StudentBiodata")]
  [Route("mvc/odata/ConData/StudentBiodata")]
  public partial class StudentBiodataController : ODataController
  {
    private Data.ConDataContext context;

    public StudentBiodataController(Data.ConDataContext context)
    {
      this.context = context;
    }
    // GET /odata/ConData/StudentBiodata
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.ConData.StudentBiodatum> GetStudentBiodata()
    {
      var items = this.context.StudentBiodata.AsQueryable<Models.ConData.StudentBiodatum>();
      this.OnStudentBiodataRead(ref items);

      return items;
    }

    partial void OnStudentBiodataRead(ref IQueryable<Models.ConData.StudentBiodatum> items);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("{BiodataID}")]
    public SingleResult<StudentBiodatum> GetStudentBiodatum(Int64 key)
    {
        var items = this.context.StudentBiodata.Where(i=>i.BiodataID == key);
        return SingleResult.Create(items);
    }
    partial void OnStudentBiodatumDeleted(Models.ConData.StudentBiodatum item);
    partial void OnAfterStudentBiodatumDeleted(Models.ConData.StudentBiodatum item);

    [HttpDelete("{BiodataID}")]
    public IActionResult DeleteStudentBiodatum(Int64 key)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var items = this.context.StudentBiodata
                .Where(i => i.BiodataID == key)
                .Include(i => i.StudentEducationHistories)
                .Include(i => i.NextOfKins)
                .Include(i => i.StudentCourseRegistrations)
                .Include(i => i.StudentCoursePayments)
                .AsQueryable();

            items = EntityPatch.ApplyTo<Models.ConData.StudentBiodatum>(Request, items);

            var item = items.FirstOrDefault();

            if (item == null)
            {
                return StatusCode((int)HttpStatusCode.PreconditionFailed);
            }

            this.OnStudentBiodatumDeleted(item);
            this.context.StudentBiodata.Remove(item);
            this.context.SaveChanges();
            this.OnAfterStudentBiodatumDeleted(item);

            return new NoContentResult();
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnStudentBiodatumUpdated(Models.ConData.StudentBiodatum item);
    partial void OnAfterStudentBiodatumUpdated(Models.ConData.StudentBiodatum item);

    [HttpPut("{BiodataID}")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PutStudentBiodatum(Int64 key, [FromBody]Models.ConData.StudentBiodatum newItem)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var items = this.context.StudentBiodata
                .Where(i => i.BiodataID == key)
                .Include(i => i.StudentEducationHistories)
                .Include(i => i.NextOfKins)
                .Include(i => i.StudentCourseRegistrations)
                .Include(i => i.StudentCoursePayments)
                .AsQueryable();

            items = EntityPatch.ApplyTo<Models.ConData.StudentBiodatum>(Request, items);

            var item = items.FirstOrDefault();

            if (item == null)
            {
                return StatusCode((int)HttpStatusCode.PreconditionFailed);
            }

            this.OnStudentBiodatumUpdated(newItem);
            this.context.StudentBiodata.Update(newItem);
            this.context.SaveChanges();

            var itemToReturn = this.context.StudentBiodata.Where(i => i.BiodataID == key);
            Request.QueryString = Request.QueryString.Add("$expand", "Gender,State");
            this.OnAfterStudentBiodatumUpdated(newItem);
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    [HttpPatch("{BiodataID}")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PatchStudentBiodatum(Int64 key, [FromBody]Delta<Models.ConData.StudentBiodatum> patch)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var items = this.context.StudentBiodata.Where(i => i.BiodataID == key);

            items = EntityPatch.ApplyTo<Models.ConData.StudentBiodatum>(Request, items);

            var item = items.FirstOrDefault();

            if (item == null)
            {
                return StatusCode((int)HttpStatusCode.PreconditionFailed);
            }

            patch.Patch(item);

            this.OnStudentBiodatumUpdated(item);
            this.context.StudentBiodata.Update(item);
            this.context.SaveChanges();

            var itemToReturn = this.context.StudentBiodata.Where(i => i.BiodataID == key);
            Request.QueryString = Request.QueryString.Add("$expand", "Gender,State");
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnStudentBiodatumCreated(Models.ConData.StudentBiodatum item);
    partial void OnAfterStudentBiodatumCreated(Models.ConData.StudentBiodatum item);

    [HttpPost]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult Post([FromBody] Models.ConData.StudentBiodatum item)
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

            this.OnStudentBiodatumCreated(item);
            this.context.StudentBiodata.Add(item);
            this.context.SaveChanges();

            var key = item.BiodataID;

            var itemToReturn = this.context.StudentBiodata.Where(i => i.BiodataID == key);

            Request.QueryString = Request.QueryString.Add("$expand", "Gender,State");

            this.OnAfterStudentBiodatumCreated(item);

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
