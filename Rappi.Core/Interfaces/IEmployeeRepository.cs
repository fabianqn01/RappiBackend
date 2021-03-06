﻿using Rappi.Core.Entities;
using Rappi.Core.QueryFilters;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Rappi.Core.Interfaces
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> GetEmployees(EmployeeQueryFilter filters);

        Task<Employee> GetEmployeeByID(int id);

        Task<Employee> GetEmployeeByDocument(string document);

        Task<Employee> GetEmployeeByName(string firstName, string lastName);

        Task SetEmployee(Employee id);

        Task UpdateEmployee(Employee id);

        Task DeleteEmployee(int id);
    }
}
