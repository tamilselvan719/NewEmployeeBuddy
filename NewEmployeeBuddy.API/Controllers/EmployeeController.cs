using NewEmployeeBuddy.API.Filters;
using NewEmployeeBuddy.Data.Service;
using NewEmployeeBuddy.Entities.DataTransferObjects.Employee;
using System;
using System.Diagnostics;
using System.Web.Http;

namespace NewEmployeeBuddy.API.Controllers
{
    [RoutePrefix("api/employee")]
    public class EmployeeController : ApiController
    {
        #region Properties
        private readonly INEBService _service;
        #endregion

        #region Constructor
        /// <summary>
        /// Parameterized Constructor: 
        /// Used when someone access this controller by passing the INEBService() instance
        /// </summary>
        /// <param name="repository"></param>
        public EmployeeController(INEBService service)
        {
            _service = service;
        }

        /// <summary>
        /// Default Constructor:
        /// Used by default or if no overload constructor is called
        /// </summary>
        public EmployeeController() 
        {
            _service = new NEBService();
        }
        #endregion

        #region Action Methods
        [HttpGet]
        [ActionName("GetAll") Route("GetAll")]
        public IHttpActionResult Get()
        {
            try
            {
                var allEmployees = _service.GetAllEmployees();
                return Ok(allEmployees);
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
        [ActionName("GetById") Route("GetById")]
        public IHttpActionResult Get(Guid employeeId)
        {
            try
            {
                if (!Guid.Equals(employeeId, Guid.Empty))
                {
                    var employee = _service.GetEmployeeByID(employeeId);
                    
                    if (employee != null)
                        return Ok(employee);
                    else
                        return NotFound();
                }
                else
                {
                    return BadRequest("The Employee ID is invalid");
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
        [ActionName("Add") Route("Add")]
        [ModelValidator]
        public IHttpActionResult Post([FromBody] EmployeeDTO employee)
        {
            try
            {
                if (employee == null)
                    return BadRequest();

                    _service.AddEmployee(employee);
                    return Created("Employee Created Successfully.", true);
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
        [ActionName("Delete") Route("Delete")]
        [ModelValidator]
        public IHttpActionResult Delete([FromBody] EmployeeDTO employee)
        {
            try
            {
                if (employee != null)
                {
                    _service.DeleteEmployee(employee);
                    return Ok(true);
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
        [ActionName("DeleteById") Route("DeleteById")]
        public IHttpActionResult Delete(Guid employeeID)
        {
            try
            {
                if (!Guid.Equals(employeeID, Guid.Empty))
                {
                    _service.DeleteEmployeeByID(employeeID);
                    return Ok(true);
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
        [ActionName("Update") Route("Update")]
        [ModelValidator]
        [System.Web.Mvc.ValidateAntiForgeryToken]
        public IHttpActionResult Put([FromBody] EmployeeDTO employee)
        {
            try
            {
                if (employee != null)
                {
                    _service.UpdateEmployee(employee);
                    return Ok(true);
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
        #endregion
    }
}
