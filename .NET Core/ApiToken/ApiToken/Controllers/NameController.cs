﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiToken.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class NameController : ControllerBase
    {
        [HttpGet]
        [Route("GetNames")]
        public IActionResult GetNames()
        {
            return Ok(new List<string> { "Kiki","Brin"});
        }
    }
}
