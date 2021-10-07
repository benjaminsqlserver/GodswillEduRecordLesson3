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

  [ODataRoutePrefix("odata/ConData/NextOfKins")]
  [Route("mvc/odata/ConData/NextOfKins")]
  public partial class NextOfKinsController : ODataController
  {
    private Data.ConDataContext context;

    public NextOfKinsController(Data.ConDataContext context)
    {
      this.context = context;
    }
    // GET /odata/ConData/NextOfKins
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.ConData.NextOfKin> GetNextOfKins()
    {
      var items = this.context.NextOfKins.AsQueryable<Models.ConData.NextOfKin>();
      this.OnNextOfKinsRead(ref items);

      return items;
    }

    partial void OnNextOfKinsRead(ref IQueryable<Models.ConData.NextOfKin> items);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("{NextOfKinID}")]
    public SingleResult<NextOfKin> GetNextOfKin(Int64 key)
    {
        var items = this.context.NextOfKins.Where(i=>i.NextOfKinID == key);
        return SingleResult.Create(items);
    }
    partial void OnNextOfKinDeleted(Models.ConData.NextOfKin item);
    partial void OnAfterNextOfKinDeleted(Models.ConData.NextOfKin item);

    [HttpDelete("{NextOfKinID}")]
    public IActionResult DeleteNextOfKin(Int64 key)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var items = this.context.NextOfKins
                .Where(i => i.NextOfKinID == key)
                .AsQueryable();

            items = EntityPatch.ApplyTo<Models.ConData.NextOfKin>(Request, items);

            var item = items.FirstOrDefault();

            if (item == null)
            {
                return StatusCode((int)HttpStatusCode.PreconditionFailed);
            }

            this.OnNextOfKinDeleted(item);
            this.context.NextOfKins.Remove(item);
            this.context.SaveChanges();
            this.OnAfterNextOfKinDeleted(item);

            return new NoContentResult();
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnNextOfKinUpdated(Models.ConData.NextOfKin item);
    partial void OnAfterNextOfKinUpdated(Models.ConData.NextOfKin item);

    [HttpPut("{NextOfKinID}")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PutNextOfKin(Int64 key, [FromBody]Models.ConData.NextOfKin newItem)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var items = this.context.NextOfKins
                .Where(i => i.NextOfKinID == key)
                .AsQueryable();

            items = EntityPatch.ApplyTo<Models.ConData.NextOfKin>(Request, items);

            var item = items.FirstOrDefault();

            if (item == null)
            {
                return StatusCode((int)HttpStatusCode.PreconditionFailed);
            }

            this.OnNextOfKinUpdated(newItem);
            this.context.NextOfKins.Update(newItem);
            this.context.SaveChanges();

            var itemToReturn = this.context.NextOfKins.Where(i => i.NextOfKinID == key);
            Request.QueryString = Request.QueryString.Add("$expand", "StudentBiodatum,Relationship");
            this.OnAfterNextOfKinUpdated(newItem);
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    [HttpPatch("{NextOfKinID}")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PatchNextOfKin(Int64 key, [FromBody]Delta<Models.ConData.NextOfKin> patch)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var items = this.context.NextOfKins.Where(i => i.NextOfKinID == key);

            items = EntityPatch.ApplyTo<Models.ConData.NextOfKin>(Request, items);

            var item = items.FirstOrDefault();

            if (item == null)
            {
                return StatusCode((int)HttpStatusCode.PreconditionFailed);
            }

            patch.Patch(item);

            this.OnNextOfKinUpdated(item);
            this.context.NextOfKins.Update(item);
            this.context.SaveChanges();

            var itemToReturn = this.context.NextOfKins.Where(i => i.NextOfKinID == key);
            Request.QueryString = Request.QueryString.Add("$expand", "StudentBiodatum,Relationship");
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnNextOfKinCreated(Models.ConData.NextOfKin item);
    partial void OnAfterNextOfKinCreated(Models.ConData.NextOfKin item);

    [HttpPost]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult Post([FromBody] Models.ConData.NextOfKin item)
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

            this.OnNextOfKinCreated(item);
            this.context.NextOfKins.Add(item);
            this.context.SaveChanges();

            var key = item.NextOfKinID;

            var itemToReturn = this.context.NextOfKins.Where(i => i.NextOfKinID == key);

            Request.QueryString = Request.QueryString.Add("$expand", "StudentBiodatum,Relationship");

            this.OnAfterNextOfKinCreated(item);

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
