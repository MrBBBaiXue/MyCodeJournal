using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecliptae.Api.Controllers
{

    
    [ApiController]
    [Route("[controller]")]
    public class ApiVersionController : ControllerBase
    {
        public static string VersionString = "v1.00";

        private readonly ILogger<ApiVersionController> _logger;

        public ApiVersionController(ILogger<ApiVersionController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public string Get()
        {
            _logger.Log(LogLevel.Information,"Called ApiVersion Controller! ok with that.");
            return VersionString;
        }
    }

}