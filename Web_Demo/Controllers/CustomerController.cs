using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Web_Demo.Models;

namespace Web_Demo.Controllers
{
    public class CustomerController : ApiController
    {
        DXCDBContext db = new DXCDBContext();
        [HttpGet]
        public IEnumerable<customer> Get()
        {
            return db.customers.ToList();
        }



        [HttpGet]



        public customer get(int id)
        {
            var data = db.customers.FirstOrDefault(c => c.Id == id);
            return data;
        }





        [HttpPost]
        public IHttpActionResult post(customer newcustomer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("not a valid model");
            }



            db.customers.Add(newcustomer);
            db.SaveChanges();
            return Ok();
        }
        [HttpPut]
        public IHttpActionResult put(customer modifiedobj)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("not a valid model");
            }



            var existingcustomer = db.customers.FirstOrDefault(c => c.Id == modifiedobj.Id);
            if (existingcustomer != null)
            {
                existingcustomer.customername = modifiedobj.customername;
                existingcustomer.city = modifiedobj.city;
                db.SaveChanges();
            }
            else
            {
                return NotFound();
            }
            return Ok();
        }



        [HttpDelete]
        public IHttpActionResult delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("not a valid model");
            }
            var existingcustomer = db.customers.FirstOrDefault(c => c.Id == id);
            if (existingcustomer != null)
            {
                db.customers.Remove(existingcustomer);
                db.SaveChanges();
            }
            else
            {
                return NotFound();
            }
            return Ok();
        }


      
    }
}
