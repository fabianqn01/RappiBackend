using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Rappi.Core.Entities;
using Rappi.Core.Interfaces;
using Rappi.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rappi.Infrastructure.Repositories
{
    
    public class EmployeeRepository: IEmployeeRepository
    {
        
        //inyecccion de dependencias pra el contexto de base de datos, lo inyectamos por constructor
        private readonly RAPPIContext _context;

        public EmployeeRepository(RAPPIContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            var employees = await _context.Employee.FromSqlRaw<Employee>("getEmployees").ToListAsync();
            return employees;
        }

        public async Task<Employee> GetEmployeeByID(int id)
        {
            var employee = await _context.Employee.FromSqlRaw("getEmployeeByID {0}", id).ToListAsync(); 
            var solo = employee.FirstOrDefault();
            return solo;
        }

        public async Task<Employee> GetEmployeeByDocument(string numberDocument)
        {
            
            var employee = await _context.Employee.FromSqlRaw("getEmployeeByDocument {0}",numberDocument).ToListAsync();
            var solo = employee.FirstOrDefault();
            return solo;
        }

        public async Task<Employee> GetEmployeeByName(string firstName, string lastName)
        {

            var employee = await _context.Employee.FromSqlRaw("getEmployeeByName {0},{1}", firstName, lastName).ToListAsync();
            var solo = employee.FirstOrDefault();
            return solo;
        }

        public async Task SetEmployee(Employee employee)
        {
            await _context.Employee.FromSqlRaw("insertEmployee {0},{1},{2},{3},{4},{5}", 
                employee.IdTypeIdentification, 
                employee.NumberDocument, 
                employee.FirstName, 
                employee.LastName,
                employee.IdSubArea,
                DateTime.Now).ToListAsync();
        }

        public async Task UpdateEmployee(Employee employee)
        {
            await _context.Employee.FromSqlRaw("updateEmployee {0},{1},{2},{3},{4},{5},{6}",
                employee.IdEmployee,
                employee.IdTypeIdentification,
                employee.NumberDocument,
                employee.FirstName,
                employee.LastName,
                employee.IdSubArea,
                DateTime.Now).ToListAsync();
        }

        public async Task DeleteEmployee(int id)
        {
            await _context.Employee.FromSqlRaw("deleteEmployee {0}",id).ToListAsync();
        }



    }
}
