using NewEmployeeBuddy.Data.Entities.Employee;
using NewEmployeeBuddy.Data.UnitOfWork;
using NewEmployeeBuddy.Entities.DataTransferObjects.Employee;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace NewEmployeeBuddy.Data.Service
{
    public class NEBService: INEBService
    {
        #region Properties
        //Replace with an IOC container (Instance created using Unity Container at UnityConfig.cs in App_Start)
        private readonly IUnitOfWork _unitOfWork;
        #endregion

        #region Constructor
        public NEBService()
        {
            _unitOfWork = new UnitOfWork.UnitOfWork();
        }

        public NEBService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        #endregion

        #region Employee Methods
        public bool AddEmployee(EmployeeDTO employee)
        {
            try
            {
                var result = false;
                if (employee == null)
                    return result;

                var addEmployee = new Employee();
                addEmployee.EmployeeId = employee.EmployeeId;
                addEmployee.FirstName = employee.FirstName;
                addEmployee.MiddleName = employee.MiddleName;
                addEmployee.LastName = employee.LastName;
                addEmployee.DateOfBirth = employee.DateOfBirth;
                addEmployee.Gender = employee.Gender;
                //To link only the Payroll ID with result                --- [Lazy Loading]
                addEmployee.PayrollId = employee.Payroll.PayrollId;
                //To link only the Contact ID with result                --- [Lazy Loading]
                addEmployee.ContactId = employee.Contact.ContactId;
                //To link only the Address ID with result                --- [Lazy Loading]
                addEmployee.AddressId = employee.Address.AddressId;

                //Default Values
                addEmployee.IsActive = true;
                addEmployee.CreatedBy = "System";
                addEmployee.CreatedOn = DateTime.Now;
                addEmployee.UpdatedBy = "System";
                addEmployee.UpdatedOn = DateTime.MinValue;

                result = _unitOfWork.Employee.AddEmployeeDetails(addEmployee);
                _unitOfWork.Save();
                return result;
            }
            catch (Exception ex)
            {
#if DEBUG
                Debug.Write(ex.Message);
                throw ex;
#endif
                //throw ex;
            }
        }

        public bool DeleteEmployee(EmployeeDTO employee)
        {
            try
            {
                var result = false;
                if (employee == null)
                    return result;

                var deleteEmployee = new Employee();
                deleteEmployee.EmployeeId = employee.EmployeeId;
                deleteEmployee.FirstName = employee.FirstName;
                deleteEmployee.MiddleName = employee.MiddleName;
                deleteEmployee.LastName = employee.LastName;
                deleteEmployee.DateOfBirth = employee.DateOfBirth;
                deleteEmployee.Gender = employee.Gender;
                //To link only the Payroll ID with result                --- [Lazy Loading]
                deleteEmployee.PayrollId = employee.Payroll.PayrollId;
                //To link only the Contact ID with result                --- [Lazy Loading]
                deleteEmployee.ContactId = employee.Contact.ContactId;
                //To link only the Address ID with result                --- [Lazy Loading]
                deleteEmployee.AddressId = employee.Address.AddressId;

                 result = _unitOfWork.Employee.DeleteEmployeeDetails(deleteEmployee);
                _unitOfWork.Save();
                return result;
            }
            catch (Exception ex)
            {
#if DEBUG
                Debug.Write(ex.Message);
                throw ex;
#endif
                //throw ex;
            }
        }

        public bool DeleteEmployeeByID(Guid employeeID)
        {
            try
            {
                var result = false;
                if (employeeID == Guid.Empty)
                    return result;

                 result = _unitOfWork.Employee.DeleteEmployeeDetailsByID(employeeID);
                _unitOfWork.Save();
                return result;
            }
            catch (Exception ex)
            {
#if DEBUG
                Debug.Write(ex.Message);
                throw ex;
#endif
                //throw ex;
            }
        }

        public IEnumerable<EmployeeDTO> GetAllEmployees()
        {
            try
            {
                var response = new List<EmployeeDTO>();
                EmployeeDTO empResponse;
                Payroll payroll;
                Address address;
                Contact contact;
                var allEmployees = _unitOfWork.Employee.GetAllEmployees();
                if (allEmployees == null)
                    return response;

                foreach (var employee in allEmployees)
                {
                    if (employee.IsActive)
                    {
                        empResponse = new EmployeeDTO();

                        //Code Refactoring using AutoMapper
                        //EmployeeDTO empResponse = new EmployeeDTO();
                        //empResponse = Mapper.Map<Employee, EmployeeDTO>(employee);

                        empResponse.EmployeeId = employee.EmployeeId;
                        empResponse.FirstName = employee.FirstName;
                        empResponse.MiddleName = employee.MiddleName;
                        empResponse.LastName = employee.LastName;
                        empResponse.DateOfBirth = employee.DateOfBirth;
                        empResponse.Gender = employee.Gender;

                        //To fetch Payroll details [Refactor it into a function]
                        payroll = _unitOfWork.Employee.GetPayrollDetails(employee.PayrollId);
                        empResponse.Payroll.PayrollId = payroll.PayrollId;
                        empResponse.Payroll.BasicPay = payroll.BasicPay;
                        empResponse.Payroll.FlexiblePay = payroll.FlexiblePay;
                        empResponse.Payroll.PFContribution = payroll.PFContribution;
                        empResponse.Payroll.Allowances = payroll.Allowances;
                        empResponse.Payroll.TotalPay = payroll.TotalPay;

                        //To fetch Contact details [Refactor it into a function]
                        contact = _unitOfWork.Employee.GetContactDetails(employee.ContactId);
                        empResponse.Contact.ContactId = contact.ContactId;
                        empResponse.Contact.Landline = contact.Landline;
                        empResponse.Contact.Mobile = contact.Mobile;
                        empResponse.Contact.Fax = contact.Fax;
                        empResponse.Contact.EmailAddress = contact.EmailAddress;

                        //To fetch Address details [Refactor it into a function]
                        address = _unitOfWork.Employee.GetAddressDetails(employee.AddressId);
                        empResponse.Address.AddressId = address.AddressId;
                        empResponse.Address.House = address.House;
                        empResponse.Address.Ward = address.Ward;
                        empResponse.Address.Street = address.Street;
                        empResponse.Address.City = address.City;
                        empResponse.Address.State = address.State;
                        empResponse.Address.Country = address.Country;
                        empResponse.Address.PinCode = address.PinCode;
                        empResponse.Address.AreaCode = address.AreaCode;
                        empResponse.Address.Landmark = address.Landmark;

                        response.Add(empResponse);
                    }
                }
                return response;
            }
            catch (Exception ex)
            {
#if DEBUG
                Debug.Write(ex.Message);
                throw ex;
#endif
                //throw ex;
            }
        }

        public EmployeeDTO GetEmployeeByID(Guid employeeID)
        {
            try
            {
                EmployeeDTO empResponse = new EmployeeDTO();
                var employee = _unitOfWork.Employee.GetEmployeeDetailsByID(employeeID);
                if (employee == null)
                    return empResponse;

                if (employee.IsActive)
                {
                    //Code Refactoring using AutoMapper
                    //EmployeeDTO empResponse = new EmployeeDTO();
                    //empResponse = Mapper.Map<Employee, EmployeeDTO>(employee);

                    empResponse.EmployeeId = employee.EmployeeId;
                    empResponse.FirstName = employee.FirstName;
                    empResponse.MiddleName = employee.MiddleName;
                    empResponse.LastName = employee.LastName;
                    empResponse.DateOfBirth = employee.DateOfBirth;
                    empResponse.Gender = employee.Gender;

                    //To link only the Payroll ID with result                --- [Lazy Loading]
                    empResponse.Payroll.PayrollId = employee.PayrollId;

                    //To link only the Contact ID with result                --- [Lazy Loading]
                    empResponse.Contact.ContactId = employee.ContactId;
                    
                    //To link only the Address ID with result                --- [Lazy Loading]
                    empResponse.Address.AddressId = employee.AddressId;
                }
                return empResponse;
            }
            catch (Exception ex)
            {
#if DEBUG
                Debug.Write(ex.Message);
                throw ex;
#endif
                //throw ex;
            }
        }

        public bool UpdateEmployee(EmployeeDTO employee)
        {
            try
            {
                var result = false;
                if (employee == null)
                    return result;

                var updateEmployee = new Employee();
                updateEmployee.EmployeeId = employee.EmployeeId;
                updateEmployee.FirstName = employee.FirstName;
                updateEmployee.MiddleName = employee.MiddleName;
                updateEmployee.LastName = employee.LastName;
                updateEmployee.DateOfBirth = employee.DateOfBirth;
                updateEmployee.Gender = employee.Gender;
                //To link only the Payroll ID with result                --- [Lazy Loading]
                updateEmployee.PayrollId = employee.Payroll.PayrollId;
                //To link only the Contact ID with result                --- [Lazy Loading]
                updateEmployee.ContactId = employee.Contact.ContactId;
                //To link only the Address ID with result                --- [Lazy Loading]
                updateEmployee.AddressId = employee.Address.AddressId;

                result = _unitOfWork.Employee.UpdateEmployeeDetails(updateEmployee);
                _unitOfWork.Save();
                return result;
            }
            catch (Exception ex)
            {
#if DEBUG
                Debug.Write(ex.Message);
                throw ex;
#endif
                //throw ex;
            }
        }
        #endregion
    }
}
