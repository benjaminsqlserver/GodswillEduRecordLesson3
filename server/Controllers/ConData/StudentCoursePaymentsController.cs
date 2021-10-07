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

  [ODataRoutePrefix("odata/ConData/StudentCoursePayments")]
  [Route("mvc/odata/ConData/StudentCoursePayments")]
  public partial class StudentCoursePaymentsController : ODataController
  {
    private Data.ConDataContext context;

    public StudentCoursePaymentsController(Data.ConDataContext context)
    {
      this.context = context;
    }
    // GET /odata/ConData/StudentCoursePayments
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.ConData.StudentCoursePayment> GetStudentCoursePayments()
    {
      var items = this.context.StudentCoursePayments.AsQueryable<Models.ConData.StudentCoursePayment>();
      this.OnStudentCoursePaymentsRead(ref items);

      return items;
    }

    partial void OnStudentCoursePaymentsRead(ref IQueryable<Models.ConData.StudentCoursePayment> items);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("{PaymentID}")]
    public SingleResult<StudentCoursePayment> GetStudentCoursePayment(Int64 key)
    {
        var items = this.context.StudentCoursePayments.Where(i=>i.PaymentID == key);
        return SingleResult.Create(items);
    }
    partial void OnStudentCoursePaymentDeleted(Models.ConData.StudentCoursePayment item);
    partial void OnAfterStudentCoursePaymentDeleted(Models.ConData.StudentCoursePayment item);

    [HttpDelete("{PaymentID}")]
    public IActionResult DeleteStudentCoursePayment(Int64 key)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var items = this.context.StudentCoursePayments
                .Where(i => i.PaymentID == key)
                .AsQueryable();

            items = EntityPatch.ApplyTo<Models.ConData.StudentCoursePayment>(Request, items);

            var item = items.FirstOrDefault();

            if (item == null)
            {
                return StatusCode((int)HttpStatusCode.PreconditionFailed);
            }

            this.OnStudentCoursePaymentDeleted(item);
            this.context.StudentCoursePayments.Remove(item);
            this.context.SaveChanges();
            this.OnAfterStudentCoursePaymentDeleted(item);

            return new NoContentResult();
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnStudentCoursePaymentUpdated(Models.ConData.StudentCoursePayment item);
    partial void OnAfterStudentCoursePaymentUpdated(Models.ConData.StudentCoursePayment item);

    [HttpPut("{PaymentID}")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PutStudentCoursePayment(Int64 key, [FromBody]Models.ConData.StudentCoursePayment newItem)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var items = this.context.StudentCoursePayments
                .Where(i => i.PaymentID == key)
                .AsQueryable();

            items = EntityPatch.ApplyTo<Models.ConData.StudentCoursePayment>(Request, items);

            var item = items.FirstOrDefault();

            if (item == null)
            {
                return StatusCode((int)HttpStatusCode.PreconditionFailed);
            }

            this.OnStudentCoursePaymentUpdated(newItem);
            this.context.StudentCoursePayments.Update(newItem);
            this.context.SaveChanges();

            var itemToReturn = this.context.StudentCoursePayments.Where(i => i.PaymentID == key);
            Request.QueryString = Request.QueryString.Add("$expand", "StudentBiodatum,SchoolCourse");
            this.OnAfterStudentCoursePaymentUpdated(newItem);
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    [HttpPatch("{PaymentID}")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PatchStudentCoursePayment(Int64 key, [FromBody]Delta<Models.ConData.StudentCoursePayment> patch)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var items = this.context.StudentCoursePayments.Where(i => i.PaymentID == key);

            items = EntityPatch.ApplyTo<Models.ConData.StudentCoursePayment>(Request, items);

            var item = items.FirstOrDefault();

            if (item == null)
            {
                return StatusCode((int)HttpStatusCode.PreconditionFailed);
            }

            patch.Patch(item);

            this.OnStudentCoursePaymentUpdated(item);
            this.context.StudentCoursePayments.Update(item);
            this.context.SaveChanges();

            var itemToReturn = this.context.StudentCoursePayments.Where(i => i.PaymentID == key);
            Request.QueryString = Request.QueryString.Add("$expand", "StudentBiodatum,SchoolCourse");
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnStudentCoursePaymentCreated(Models.ConData.StudentCoursePayment item);
    partial void OnAfterStudentCoursePaymentCreated(Models.ConData.StudentCoursePayment item);

    [HttpPost]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult Post([FromBody] Models.ConData.StudentCoursePayment item)
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

            this.OnStudentCoursePaymentCreated(item);
            this.context.StudentCoursePayments.Add(item);
            this.context.SaveChanges();

            var key = item.PaymentID;

            var itemToReturn = this.context.StudentCoursePayments.Where(i => i.PaymentID == key);

            Request.QueryString = Request.QueryString.Add("$expand", "StudentBiodatum,SchoolCourse");

            this.OnAfterStudentCoursePaymentCreated(item);

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
