﻿using NewEmployeeBuddy.Data;
using NewEmployeeBuddy.Data.RepositoryPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using NewEmployeeBuddy.Common.DataTransferObjects;

namespace NewEmployeeBuddy.API.Controllers
{
    public class EmployeeController : ApiController
    {
        private static readonly NewEmployeeDbContext _context = new NewEmployeeDbContext();
        private readonly IRepository<NewEmployee> _repository;

        public EmployeeController()
        {
            this._repository = new EmployeeRepository(_context);
        }

        [HttpGet]
        [ActionName("GetAllEmployees")]
        public IEnumerable<EmployeeResponse> Get()
        {
            var response = new List<EmployeeResponse>();
            EmployeeResponse empResponse;
            try
            {
                var allEmployees = _repository.GetAll();
                foreach (var employee in allEmployees)
                {
                    if (employee.IsActive)
                    {
                        empResponse = new EmployeeResponse();
                        empResponse.JoinerID = employee.JoinerID;
                        empResponse.FirstName = employee.FirstName;
                        empResponse.MiddleName = employee.MiddleName;
                        empResponse.LastName = employee.LastName;
                        empResponse.Gender = employee.Gender;
                        empResponse.DateOfBirth = employee.DateOfBirth;
                        empResponse.PhoneNumber = employee.PhoneNumber;
                        empResponse.MobileNumber = employee.MobileNumber;
                        empResponse.EmailAddress = employee.EmailAddress;
                        empResponse.Address = employee.Address;
                        empResponse.PinCode = employee.PinCode;
                        empResponse.City = employee.City;
                        empResponse.State = employee.State;
                        empResponse.Country = employee.Country;
                        response.Add(empResponse);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
            return response;
        }
    }
}