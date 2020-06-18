using Rappi.Core.Entities;
using Rappi.Core.Interfaces;
using Rappi.Core.QueryFilters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rappi.Core.Services
{
    
    public class EmployeeService: IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<Employee> GetEmployeeByDocument(string document)
        {
            return await _employeeRepository.GetEmployeeByDocument(document);
        }

        public async Task<Employee> GetEmployeeByID(int id)
        {
            return await _employeeRepository.GetEmployeeByID(id);
        }

        public async Task<Employee> GetEmployeeByName(string firstName, string lastName)
        {
            return await _employeeRepository.GetEmployeeByName(firstName, lastName);
        }

        public IEnumerable<Employee> GetEmployees(EmployeeQueryFilter filters)
        {
            return  _employeeRepository.GetEmployees(filters);
        }

        public async Task SetEmployee(Employee employee)
        {
            await _employeeRepository.SetEmployee(employee);
        }

        public async Task UpdateEmployee(Employee employee)
        {
            await _employeeRepository.UpdateEmployee(employee);
        }

        public async Task DeleteEmployee(int id)
        {
            await _employeeRepository.DeleteEmployee(id);
        }
    }
}
