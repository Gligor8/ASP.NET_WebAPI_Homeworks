﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi_Notes1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        // GET: api/<UsersController>
        [HttpGet]
        public ActionResult <IEnumerable<string>> Get()
        {
            return StatusCode(StatusCodes.Status200OK, StaticDB.Users);
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            try
            {
                if (id < 0)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, "ID cannot be lower than zero.")
                }

                if (id >= StaticDB.Users.Count)
                {
                    return StatusCode(StatusCodes.Status404NotFound);
                }

                return StatusCode(200, StaticDB.Users[id]);
            }
            catch 
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Server Error");
            }
        }

        [HttpGet("{id}/users/{userId}")]
        public ActionResult<string> GetPath(int id, int userId)
        {
            string announcement = $"User with id {StaticDB.Users[id]} is userd by user {userId}";
            return StatusCode(200, announcement);
        }

        // POST api/<UsersController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
