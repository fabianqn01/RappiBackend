using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rappi.Core.Interfaces;

namespace Rappi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AreaController : ControllerBase
    {
        private readonly IAreaService _areaService;
        public AreaController(IAreaService areaService)
        {
            _areaService = areaService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAreas()
        {

            var areas = await _areaService.GetAreas();
            return Ok(areas);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSubAreas(int id)
        {

            var subAreas = await _areaService.GetSubAreasByArea(id);
            return Ok(subAreas);
        }

        [HttpGet("GetSubAreaByID/{id}")]
        public async Task<IActionResult> GetSubAreaByID(int id)
        {
            var subArea = await _areaService.GetSubAreaByID(id);
            return Ok(subArea);
        }


    }
}