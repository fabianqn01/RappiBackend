using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rappi.Core.Interfaces;

namespace Rappi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypeIdentificationController : ControllerBase
    {
        private readonly ITypeIdentificationService _typeIdentificationService;

        public TypeIdentificationController(ITypeIdentificationService typeIdentificationService)
        {
            _typeIdentificationService = typeIdentificationService;
        }

        [HttpGet]
        public async Task<IActionResult> GetTypesIdentification()
        {
            var areas = await _typeIdentificationService.GetTypesIdentification();
            return Ok(areas);
        }
    }
}