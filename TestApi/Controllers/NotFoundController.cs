﻿using System.Web.Http;

namespace TestApi.Controllers
{
    public class NotFoundController : ApiController
    {
        [HttpGet, HttpPost, HttpPut, HttpDelete, HttpHead, HttpOptions, AcceptVerbs("PATCH")]
        public IHttpActionResult ErrorNotFound()
        {
            return NotFound();
        }
    }
}