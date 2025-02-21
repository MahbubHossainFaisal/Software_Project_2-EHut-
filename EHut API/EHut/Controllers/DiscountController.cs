﻿ 
using BLL.Services;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EHut.Controllers
{
    [RoutePrefix("api/Discounts")]
    public class DiscountController : ApiController
    {
        DiscountServices discountServices = new DiscountServices();
        [HttpGet, Route("")]
        public IHttpActionResult GetAll()
        {

            return Ok(discountServices.GetAll());
        }

        [HttpGet, Route("{id}")]
        public IHttpActionResult Get(int id)
        {
            return Ok(discountServices.Get(id));
        }

        [HttpPost, Route("", Name = "DiscountPath")]
        public IHttpActionResult Create(Discount  model)
        {
            if (ModelState.IsValid)
            {
                discountServices.Insert(model);
                string url = Url.Link("DiscountPath", new { id = model.DiscountId });
                return Created(url, model);
              
            }
            else
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
        }

        [HttpPut, Route("{id}")]
        public IHttpActionResult Edit([FromBody] Discount  model, [FromUri] int id)
        {

            if (ModelState.IsValid)
            {
                 model.DiscountId = id;
                discountServices.Update(model);
                return Ok("model");
            }
            else
                return StatusCode(HttpStatusCode.NoContent);
        }

        [HttpDelete, Route("{id}")]
        public IHttpActionResult Delete(int id)
        {
            discountServices.Delete(id);
            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}
