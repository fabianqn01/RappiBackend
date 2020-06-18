using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rappi.Core.Entities;
using Rappi.Core.Interfaces;
using Rappi.Infrastructure.Repositories;

namespace Rappi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        
        public async Task<IActionResult> GetEmployees()
        {

            var employees = await _employeeService.GetEmployees();
            return Ok(employees);
        }

        [HttpGet("GetEmployeeByID/{id}")]                           
        public async Task<IActionResult> GetEmployeeByID(int id)
        {
            var employee = await _employeeService.GetEmployeeByID(id);
            return Ok(employee);
        }

        [HttpGet("GetEmployeeByDocument/{document}")]
        public async Task<IActionResult> GetEmployeeByDocument(string document)
        {
            var employee = await _employeeService.GetEmployeeByDocument(document);
            return Ok(employee);
        }

        [HttpGet("GetEmployeeByName/{firstName}/{lastName}")]
        public async Task<IActionResult> GetEmployeeByDocument(string firstName, string lastName)
        {
            var employee = await _employeeService.GetEmployeeByName(firstName, lastName);
            return Ok(employee);
        }

        [HttpPost]
        public async Task SetEmployee(Employee employee)
        {
            await _employeeService.SetEmployee(employee);
        }

        [HttpPut]
        public async Task UpdateEmployee(Employee employee)
        {
            await _employeeService.UpdateEmployee(employee);
        }

        [HttpDelete("{id}")]
        public async Task DeleteEmployee(int id)
        {
            await _employeeService.DeleteEmployee(id);
        }
    }
}