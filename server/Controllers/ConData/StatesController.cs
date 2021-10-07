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

  [ODataRoutePrefix("odata/ConData/States")]
  [Route("mvc/odata/ConData/States")]
  public partial class StatesController : ODataController
  {
    private Data.ConDataContext context;

    public StatesController(Data.ConDataContext context)
    {
      this.context = context;
    }
    // GET /odata/ConData/States
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.ConData.State> GetStates()
    {
      var items = this.context.States.AsQueryable<Models.ConData.State>();
      this.OnStatesRead(ref items);

      return items;
    }

    partial void OnStatesRead(ref IQueryable<Models.ConData.State> items);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("{StateID}")]
    public SingleResult<State> GetState(int key)
    {
        var items = this.context.States.Where(i=>i.StateID == key);
        return SingleResult.Create(items);
    }
    partial void OnStateDeleted(Models.ConData.State item);
    partial void OnAfterStateDeleted(Models.ConData.State item);

    [HttpDelete("{StateID}")]
    public IActionResult DeleteState(int key)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var items = this.context.States
                .Where(i => i.StateID == key)
                .Include(i => i.StudentBiodata)
                .AsQueryable();

            items = EntityPatch.ApplyTo<Models.ConData.State>(Request, items);

            var item = items.FirstOrDefault();

            if (item == null)
            {
                return StatusCode((int)HttpStatusCode.PreconditionFailed);
            }

            this.OnStateDeleted(item);
            this.context.States.Remove(item);
            this.context.SaveChanges();
            this.OnAfterStateDeleted(item);

            return new NoContentResult();
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnStateUpdated(Models.ConData.State item);
    partial void OnAfterStateUpdated(Models.ConData.State item);

    [HttpPut("{StateID}")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PutState(int key, [FromBody]Models.ConData.State newItem)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var items = this.context.States
                .Where(i => i.StateID == key)
                .Include(i => i.StudentBiodata)
                .AsQueryable();

            items = EntityPatch.ApplyTo<Models.ConData.State>(Request, items);

            var item = items.FirstOrDefault();

            if (item == null)
            {
                return StatusCode((int)HttpStatusCode.PreconditionFailed);
            }

            this.OnStateUpdated(newItem);
            this.context.States.Update(newItem);
            this.context.SaveChanges();

            var itemToReturn = this.context.States.Where(i => i.StateID == key);
            this.OnAfterStateUpdated(newItem);
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    [HttpPatch("{StateID}")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PatchState(int key, [FromBody]Delta<Models.ConData.State> patch)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var items = this.context.States.Where(i => i.StateID == key);

            items = EntityPatch.ApplyTo<Models.ConData.State>(Request, items);

            var item = items.FirstOrDefault();

            if (item == null)
            {
                return StatusCode((int)HttpStatusCode.PreconditionFailed);
            }

            patch.Patch(item);

            this.OnStateUpdated(item);
            this.context.States.Update(item);
            this.context.SaveChanges();

            var itemToReturn = this.context.States.Where(i => i.StateID == key);
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnStateCreated(Models.ConData.State item);
    partial void OnAfterStateCreated(Models.ConData.State item);

    [HttpPost]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult Post([FromBody] Models.ConData.State item)
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

            this.OnStateCreated(item);
            this.context.States.Add(item);
            this.context.SaveChanges();

            return Created($"odata/ConData/States/{item.StateID}", item);
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }
  }
}
