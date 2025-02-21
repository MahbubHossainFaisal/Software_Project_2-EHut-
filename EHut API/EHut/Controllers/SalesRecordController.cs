﻿ 
using BLL.Services;
using DAL.Models;
using EHut.Attribute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EHut.Controllers
{
    //[BasicAuthentication]
    [RoutePrefix("api/SalesRecords")]
    public class SalesRecordController : ApiController
    {
        SalesRecordServices srServices = new SalesRecordServices();
        [HttpGet, Route("")]
        public IHttpActionResult GetAll()
        {

            return Ok(srServices.GetAll());
        }

        [HttpGet, Route("{id}")]
        public IHttpActionResult Get(int id)
        {
            return Ok(srServices.Get(id));
        }

        [HttpGet, Route("GetNonDeliveredRecords/{id}")]
        public IHttpActionResult GetNonDeliveredRecords(int id)
        {
            var products= srServices.GetNonDeliveredRecors(id);
            if(products == null)
            {
                return Ok("No Pending Order in your Shop");
            }
            else
                return Ok(products);
        }

        [HttpGet, Route("GetRecordsByStatus/{id}/{status}")]
        public IHttpActionResult GetRecordsByStatus(int id,string status)
        {
            var products = srServices.GetRecordsByStatus(id,status);

            if (products == null)
            {
                return Ok("No Order in your Shop with "+status+" Status" );
            }
            else
                return Ok(products);
        }

        //[HttpPost, Route("", Name = "SalesRecordPath")]
        //public IHttpActionResult Create(SalesRecord  model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        srServices.Insert(model);
        //        string url = Url.Link("SalesRecordPath", new { id = model.SalesRecordId });
        //        return Created(url, model);

        //    }
        //    else
        //    {
        //        return StatusCode(HttpStatusCode.NoContent);
        //    }
        //}

        //[HttpPut, Route("{id}")]
        //public IHttpActionResult Edit([FromBody] SalesRecord  model, [FromUri] int id)
        //{

        //    if (ModelState.IsValid)
        //    {
        //         model.SalesRecordId = id;
        //        srServices.Update(model);
        //        return Ok("model");
        //    }
        //    else
        //        return StatusCode(HttpStatusCode.NoContent);
        //}

        [HttpDelete, Route("{id}")]
        public IHttpActionResult Delete(int id)
        {
            srServices.Delete(id);
            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}
