﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace Pandora.NetStandard.Core.Bases
{
    [Route("api/v{v:apiVersion}/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public abstract class ApiBaseController : ControllerBase
    {
        protected readonly ILogger _logger;

        public ApiBaseController(ILogger logger)
        {
            _logger = logger;
            _logger?.LogInformation($"Application Starting : {DateTime.UtcNow}");
        }
    }
}