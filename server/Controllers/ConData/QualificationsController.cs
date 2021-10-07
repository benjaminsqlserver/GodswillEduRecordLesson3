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

  [ODataRoutePrefix("odata/ConData/Qualifications")]
  [Route("mvc/odata/ConData/Qualifications")]
  public partial class QualificationsController : ODataController
  {
    private Data.ConDataContext context;

    public QualificationsController(Data.ConDataContext context)
    {
      this.context = context;
    }
    // GET /odata/ConData/Qualifications
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.ConData.Qualification> GetQualifications()
    {
      var items = this.context.Qualifications.AsQueryable<Models.ConData.Qualification>();
      this.OnQualificationsRead(ref items);

      return items;
    }

    partial void OnQualificationsRead(ref IQueryable<Models.ConData.Qualification> items);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("{QualificationID}")]
    public SingleResult<Qualification> GetQualification(int key)
    {
        var items = this.context.Qualifications.Where(i=>i.QualificationID == key);
        return SingleResult.Create(items);
    }
    partial void OnQualificationDeleted(Models.ConData.Qualification item);
    partial void OnAfterQualificationDeleted(Models.ConData.Qualification item);

    [HttpDelete("{QualificationID}")]
    public IActionResult DeleteQualification(int key)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var items = this.context.Qualifications
                .Where(i => i.QualificationID == key)
                .Include(i => i.StudentEducationHistories)
                .AsQueryable();

            items = EntityPatch.ApplyTo<Models.ConData.Qualification>(Request, items);

            var item = items.FirstOrDefault();

            if (item == null)
            {
                return StatusCode((int)HttpStatusCode.PreconditionFailed);
            }

            this.OnQualificationDeleted(item);
            this.context.Qualifications.Remove(item);
            this.context.SaveChanges();
            this.OnAfterQualificationDeleted(item);

            return new NoContentResult();
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnQualificationUpdated(Models.ConData.Qualification item);
    partial void OnAfterQualificationUpdated(Models.ConData.Qualification item);

    [HttpPut("{QualificationID}")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PutQualification(int key, [FromBody]Models.ConData.Qualification newItem)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var items = this.context.Qualifications
                .Where(i => i.QualificationID == key)
                .Include(i => i.StudentEducationHistories)
                .AsQueryable();

            items = EntityPatch.ApplyTo<Models.ConData.Qualification>(Request, items);

            var item = items.FirstOrDefault();

            if (item == null)
            {
                return StatusCode((int)HttpStatusCode.PreconditionFailed);
            }

            this.OnQualificationUpdated(newItem);
            this.context.Qualifications.Update(newItem);
            this.context.SaveChanges();

            var itemToReturn = this.context.Qualifications.Where(i => i.QualificationID == key);
            this.OnAfterQualificationUpdated(newItem);
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    [HttpPatch("{QualificationID}")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PatchQualification(int key, [FromBody]Delta<Models.ConData.Qualification> patch)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var items = this.context.Qualifications.Where(i => i.QualificationID == key);

            items = EntityPatch.ApplyTo<Models.ConData.Qualification>(Request, items);

            var item = items.FirstOrDefault();

            if (item == null)
            {
                return StatusCode((int)HttpStatusCode.PreconditionFailed);
            }

            patch.Patch(item);

            this.OnQualificationUpdated(item);
            this.context.Qualifications.Update(item);
            this.context.SaveChanges();

            var itemToReturn = this.context.Qualifications.Where(i => i.QualificationID == key);
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnQualificationCreated(Models.ConData.Qualification item);
    partial void OnAfterQualificationCreated(Models.ConData.Qualification item);

    [HttpPost]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult Post([FromBody] Models.ConData.Qualification item)
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

            this.OnQualificationCreated(item);
            this.context.Qualifications.Add(item);
            this.context.SaveChanges();

            return Created($"odata/ConData/Qualifications/{item.QualificationID}", item);
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }
  }
}
