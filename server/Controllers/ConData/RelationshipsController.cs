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

  [ODataRoutePrefix("odata/ConData/Relationships")]
  [Route("mvc/odata/ConData/Relationships")]
  public partial class RelationshipsController : ODataController
  {
    private Data.ConDataContext context;

    public RelationshipsController(Data.ConDataContext context)
    {
      this.context = context;
    }
    // GET /odata/ConData/Relationships
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.ConData.Relationship> GetRelationships()
    {
      var items = this.context.Relationships.AsQueryable<Models.ConData.Relationship>();
      this.OnRelationshipsRead(ref items);

      return items;
    }

    partial void OnRelationshipsRead(ref IQueryable<Models.ConData.Relationship> items);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("{RelationshipID}")]
    public SingleResult<Relationship> GetRelationship(int key)
    {
        var items = this.context.Relationships.Where(i=>i.RelationshipID == key);
        return SingleResult.Create(items);
    }
    partial void OnRelationshipDeleted(Models.ConData.Relationship item);
    partial void OnAfterRelationshipDeleted(Models.ConData.Relationship item);

    [HttpDelete("{RelationshipID}")]
    public IActionResult DeleteRelationship(int key)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var items = this.context.Relationships
                .Where(i => i.RelationshipID == key)
                .Include(i => i.NextOfKins)
                .AsQueryable();

            items = EntityPatch.ApplyTo<Models.ConData.Relationship>(Request, items);

            var item = items.FirstOrDefault();

            if (item == null)
            {
                return StatusCode((int)HttpStatusCode.PreconditionFailed);
            }

            this.OnRelationshipDeleted(item);
            this.context.Relationships.Remove(item);
            this.context.SaveChanges();
            this.OnAfterRelationshipDeleted(item);

            return new NoContentResult();
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnRelationshipUpdated(Models.ConData.Relationship item);
    partial void OnAfterRelationshipUpdated(Models.ConData.Relationship item);

    [HttpPut("{RelationshipID}")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PutRelationship(int key, [FromBody]Models.ConData.Relationship newItem)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var items = this.context.Relationships
                .Where(i => i.RelationshipID == key)
                .Include(i => i.NextOfKins)
                .AsQueryable();

            items = EntityPatch.ApplyTo<Models.ConData.Relationship>(Request, items);

            var item = items.FirstOrDefault();

            if (item == null)
            {
                return StatusCode((int)HttpStatusCode.PreconditionFailed);
            }

            this.OnRelationshipUpdated(newItem);
            this.context.Relationships.Update(newItem);
            this.context.SaveChanges();

            var itemToReturn = this.context.Relationships.Where(i => i.RelationshipID == key);
            this.OnAfterRelationshipUpdated(newItem);
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    [HttpPatch("{RelationshipID}")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PatchRelationship(int key, [FromBody]Delta<Models.ConData.Relationship> patch)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var items = this.context.Relationships.Where(i => i.RelationshipID == key);

            items = EntityPatch.ApplyTo<Models.ConData.Relationship>(Request, items);

            var item = items.FirstOrDefault();

            if (item == null)
            {
                return StatusCode((int)HttpStatusCode.PreconditionFailed);
            }

            patch.Patch(item);

            this.OnRelationshipUpdated(item);
            this.context.Relationships.Update(item);
            this.context.SaveChanges();

            var itemToReturn = this.context.Relationships.Where(i => i.RelationshipID == key);
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnRelationshipCreated(Models.ConData.Relationship item);
    partial void OnAfterRelationshipCreated(Models.ConData.Relationship item);

    [HttpPost]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult Post([FromBody] Models.ConData.Relationship item)
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

            this.OnRelationshipCreated(item);
            this.context.Relationships.Add(item);
            this.context.SaveChanges();

            return Created($"odata/ConData/Relationships/{item.RelationshipID}", item);
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }
  }
}
