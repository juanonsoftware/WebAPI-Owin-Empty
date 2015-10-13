﻿using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Web.Http;
using Rabbit.SimpleInjectorDemo.Services;
using WebApiExternalAuth.Models;

namespace WebApiExternalAuth.Controllers
{
    public class ValuesController : ApiController
    {
        private readonly IListingService _listingService;

        public ValuesController(IListingService listingService)
        {
            _listingService = listingService;
        }

        // GET api/values
        public dynamic Get()
        {
            LoginData data = null;

            if (User.Identity.IsAuthenticated)
            {
                data = LoginData.FromIdentity(User.Identity as ClaimsIdentity);
            }

            return new
                {
                    Data = data,
                    Mics = new List<string> { "value1", "value2" }
                };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value" + id;
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
            Console.WriteLine(value);
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
            Console.WriteLine(id + value);
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
            Console.WriteLine(id);
        }
    }
}