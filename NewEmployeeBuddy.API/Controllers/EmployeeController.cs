using NewEmployeeBuddy.API.Filters;
using NewEmployeeBuddy.Common.DataTransferObjects;
using NewEmployeeBuddy.Data;
using NewEmployeeBuddy.Data.RepositoryPattern;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Web.Http;

namespace NewEmployeeBuddy.API.Controllers
{
    [RoutePrefix("api/employee")]
    public class EmployeeController : ApiController
    {
        //Replace with an IOC container (Instance created using Unity Container at UnityConfig.cs in App_Start)
        private readonly IRepository<NewEmployee> _repository;

        /// <summary>
        /// Parameterised Constructor: 
        /// Used when someone access this controller by passing the IRepository<NewEmployee> instance
        /// </summary>
        /// <param name="repository"></param>
        public EmployeeController(IRepository<NewEmployee> repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Default Constructor:
        /// Used by default or if no overload constructor is called
        /// </summary>
        public EmployeeController() 
        {
            this._repository = new EmpRepository(new NewEmployeeDbContext());
        }

        [HttpGet]
        [ActionName("GetAll")]
        public IHttpActionResult Get()
        {
            try
            {
                var response = new List<Employee>();
                Employee empResponse;
                var allEmployees = _repository.GetAll();
                foreach (var employee in allEmployees)
                {
                    if (employee.IsActive)
                    {
                        empResponse = new Employee();
                        empResponse.Id = employee.Id;
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
                return Ok(response);
            }
            catch (Exception ex)
            {
#if DEBUG
                Debug.Write(ex.Message);
                return InternalServerError(ex);
#endif
                //return InternalServerError();
            }
        }

        [HttpGet]
        [ActionName("GetById")]
        public IHttpActionResult Get(string phoneNumber)
        {
            try
            {
                if (!string.IsNullOrEmpty(phoneNumber))
                {
                    var employee = _repository.GetById(phoneNumber);
                    if (employee != null && employee.IsActive)
                    {
                        Employee empResponse = new Employee();
                        empResponse.Id = employee.Id;
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
                        return Ok(empResponse);
                    }
                    else
                        return BadRequest("Client not active");
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
#if DEBUG
                Debug.Write(ex.Message);
                return InternalServerError(ex);
#endif
                //return InternalServerError();
            }
            
        }

        [HttpPost]
        [ActionName("Add")]
        [ModelValidator]
        public IHttpActionResult Post([FromBody] Employee employee)
        {
            try
            {
                var result = false;
                if (employee != null)
                {
                    var emp = new NewEmployee();
                    emp.Id = Guid.NewGuid();
                    emp.FirstName = employee.FirstName;
                    emp.MiddleName = employee.MiddleName;
                    emp.LastName = employee.LastName;
                    emp.Gender = employee.Gender;
                    emp.DateOfBirth = Convert.ToDateTime(employee.DateOfBirth);
                    emp.PhoneNumber = employee.PhoneNumber;
                    emp.MobileNumber = employee.MobileNumber;
                    emp.EmailAddress = employee.EmailAddress;
                    emp.Address = employee.Address;
                    emp.PinCode = employee.PinCode;
                    emp.City = employee.City;
                    emp.State = employee.State;
                    emp.Country = employee.Country;
                    emp.IsActive = true;
                    emp.Id = Guid.NewGuid();
                    emp.CreatedBy = "System";
                    emp.CreatedOn = DateTime.Now;
                    emp.UpdatedBy = "";
                    emp.UpdatedOn = DateTime.Now;
                    result = _repository.Add(emp);
                    return Created("Database", result);
                }
                else
                {
                    return BadRequest();
                }

            }
            catch (Exception ex)
            {
#if DEBUG
                Debug.Write(ex.Message);
                return InternalServerError(ex);
#endif
                //return InternalServerError();
            }
        }

        [HttpDelete]
        [ActionName("Delete")]
        [ModelValidator]
        public IHttpActionResult Delete([FromBody] Employee employee)
        {
            try
            {
                var result = false;
                if (employee != null)
                {
                    var emp = new NewEmployee();
                    emp.Id = employee.Id;
                    emp.FirstName = employee.FirstName;
                    emp.MiddleName = employee.MiddleName;
                    emp.LastName = employee.LastName;
                    emp.Gender = employee.Gender;
                    emp.DateOfBirth = employee.DateOfBirth;
                    emp.PhoneNumber = employee.PhoneNumber;
                    emp.MobileNumber = employee.MobileNumber;
                    emp.EmailAddress = employee.EmailAddress;
                    emp.Address = employee.Address;
                    emp.PinCode = employee.PinCode;
                    emp.City = employee.City;
                    emp.State = employee.State;
                    emp.Country = employee.Country;
                    emp.IsActive = true;
                    emp.Id = Guid.NewGuid();
                    emp.CreatedBy = "System";
                    emp.CreatedOn = DateTime.Now;
                    emp.UpdatedBy = "";
                    emp.UpdatedOn = DateTime.Now;
                    result = _repository.Delete(emp);
                    return Ok(result);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
#if DEBUG
                Debug.Write(ex.Message);
                return InternalServerError(ex);
#endif
                //return InternalServerError();
            }
        }

        [HttpDelete]
        [ActionName("DeleteById")]
        public IHttpActionResult Delete(string phoneNumber)
        {
            try
            {
                var response = false;
                if (!string.IsNullOrEmpty(phoneNumber))
                {
                    response = _repository.DeleteById(phoneNumber);
                    return Ok(response);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
#if DEBUG
                Debug.Write(ex.Message);
                return InternalServerError(ex);
#endif
                //return InternalServerError();
            }
        }

        [HttpPut]
        [ActionName("Update")]
        [ModelValidator]
        public IHttpActionResult Put([FromBody] Employee employee)
        {
            try
            {
                var result = false;
                if (employee != null)
                {
                    var emp = new NewEmployee();
                    //emp.Id = employee.Id;
                    emp.FirstName = employee.FirstName;
                    emp.MiddleName = employee.MiddleName;
                    emp.LastName = employee.LastName;
                    emp.Gender = employee.Gender;
                    emp.DateOfBirth = Convert.ToDateTime(employee.DateOfBirth);
                    emp.PhoneNumber = employee.PhoneNumber;
                    emp.MobileNumber = employee.MobileNumber;
                    emp.EmailAddress = employee.EmailAddress;
                    emp.Address = employee.Address;
                    emp.PinCode = employee.PinCode;
                    emp.City = employee.City;
                    emp.State = employee.State;
                    emp.Country = employee.Country;
                    result = _repository.Update(emp);
                    return Ok(result);
                }
                else
                {
                    return BadRequest();
                }

            }
            catch (Exception ex)
            {
#if DEBUG
                Debug.Write(ex.Message);
                return InternalServerError(ex);
#endif
                //return InternalServerError();
            }
        }
    }
}
