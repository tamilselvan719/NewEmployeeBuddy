﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace NewEmployeeBuddy.Data.RepositoryPattern
{
    /// <summary>
    /// CRUD operations for New Employee table using Generic Repository Pattern
    /// </summary>
    public class EmployeeRepository : IRepository<NewEmployee>
    {
        /// <summary>
        /// Constructor Injection
        /// </summary>
        private NewEmployeeDbContext _dbContext;
        public EmployeeRepository(NewEmployeeDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// To add a new record in New Employee table
        /// </summary>
        /// <param name="entity">The instance of New Employee class</param>
        /// <returns>Returns a bool flag, either true or false</returns>
        public bool Add(NewEmployee entity)
        {
            var result = false;
            try
            {
                if (entity != null)
                {
                    _dbContext.NewEmployeeDetails.Add(entity);
                    Save();
                    result = true;
                }
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }

        /// <summary>
        /// To delete a record from the New Employee table
        /// </summary>
        /// <param name="entity">The instance of New Employee class</param>
        /// <returns>Returns a bool flag, either true or false</returns>
        public bool Delete(NewEmployee entity)
        {
            var result = false;
            try
            {
                if (entity != null)
                {
                    var employee = _dbContext.NewEmployeeDetails.FirstOrDefault(emp => emp.PhoneNumber == entity.PhoneNumber);
                    _dbContext.NewEmployeeDetails.Remove(employee);
                    Save();
                    result = true;
                }
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }

        /// <summary>
        /// To delete a record using Phone Number in the New Employee table
        /// </summary>
        /// <param name="phoneNumber">Primary Key of the row (Phone Number)</param>
        /// <returns>Returns a bool flag, either true or false</returns>
        public bool DeleteById(string id)
        {
            var result = false;
            try
            {
                if (!string.IsNullOrEmpty(id))
                {
                    NewEmployee record = _dbContext.NewEmployeeDetails.Find(id);
                    _dbContext.NewEmployeeDetails.Remove(record);
                    Save();
                    result = true;
                }
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }

        /// <summary>
        /// To get all data from New Employee table
        /// </summary>
        /// <returns>An IQuerable List of NewEmployee</returns>
        public IEnumerable<NewEmployee> GetAll()
        {
            var result = new List<NewEmployee>();
            try
            {
                result = _dbContext.NewEmployeeDetails.ToList();
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }

        /// <summary>
        /// To get a single record using Phone Number from New Employee table
        /// </summary>
        /// <param name="phoneNumber">Primary Key of the row (Phone Number)</param>
        /// <returns>Returns a NewEmployee row matching the passing ID</returns>
        public NewEmployee GetById(string id)
        {
            var result = new NewEmployee();
            try
            {
                if (!string.IsNullOrEmpty(id))
                {
                    result = _dbContext.NewEmployeeDetails.Find(id);
                }
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }

        /// <summary>
        /// To update a record in New Employee table
        /// </summary>
        /// <param name="entity">The instance of New Employee class</param>
        /// <returns>Returns a bool flag, either true or false</returns>
        public bool Update(NewEmployee entity)
        {
            var result = false;
            try
            {
                if (entity != null)
                {
                    var employee = _dbContext.NewEmployeeDetails.FirstOrDefault(emp => emp.PhoneNumber == entity.PhoneNumber);
                    if (employee != null)
                    {
                        //Mapping the entities coming from HttpRequest with Database entities

                        //Null - Coalescing Operator
                        employee.FirstName = employee.FirstName ?? "John";

                        //Conditional Operator
                        employee.FirstName = (!string.IsNullOrEmpty(entity.FirstName)) ? entity.FirstName : employee.FirstName;
                        employee.MiddleName = (!string.IsNullOrEmpty(entity.MiddleName)) ? entity.MiddleName : employee.MiddleName;
                        employee.LastName = (!string.IsNullOrEmpty(entity.LastName)) ? entity.LastName : employee.LastName;
                        employee.Gender = (!string.IsNullOrEmpty(entity.Gender)) ? entity.Gender : employee.Gender;
                        employee.DateOfBirth = (!(entity.DateOfBirth.Equals(DateTime.MinValue))) ? entity.DateOfBirth : employee.DateOfBirth;
                        employee.PhoneNumber = (!string.IsNullOrEmpty(entity.PhoneNumber)) ? entity.PhoneNumber : employee.PhoneNumber;
                        employee.MobileNumber = (!string.IsNullOrEmpty(entity.MobileNumber)) ? entity.MobileNumber : employee.MobileNumber;
                        employee.EmailAddress = (!string.IsNullOrEmpty(entity.EmailAddress)) ? entity.EmailAddress : employee.EmailAddress;
                        employee.Address = (!string.IsNullOrEmpty(entity.Address)) ? entity.Address : employee.Address;
                        employee.PinCode = (!string.IsNullOrEmpty(entity.PinCode)) ? entity.PinCode : employee.PinCode;
                        employee.City = (!string.IsNullOrEmpty(entity.City)) ? entity.City : employee.City;
                        employee.State = (!string.IsNullOrEmpty(entity.State)) ? entity.State : employee.State;
                        employee.Country = (!string.IsNullOrEmpty(entity.Country)) ? entity.Country : employee.Country;
                        employee.IsActive = (!entity.IsActive.Equals(null)) ? entity.IsActive : employee.IsActive;
                        employee.Id = (entity.Id != Guid.Empty) ? entity.Id : employee.Id;
                        employee.CreatedBy = (!string.IsNullOrEmpty(entity.CreatedBy)) ? entity.CreatedBy : employee.CreatedBy;
                        employee.CreatedOn = (!(entity.CreatedOn.Equals(DateTime.MinValue))) ? entity.CreatedOn : employee.CreatedOn;
                        employee.UpdatedBy = (!string.IsNullOrEmpty(entity.UpdatedBy)) ? entity.UpdatedBy : employee.UpdatedBy;
                        employee.UpdatedOn = DateTime.Now;

                        _dbContext.Entry(employee).State = EntityState.Modified;
                        Save();
                        result = true;
                    }
                    else
                    {
                        result = false;
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }

        /// <summary>
        /// To save the changes 
        /// </summary>
        public void Save()
        {
            _dbContext.SaveChanges();
        }

        /// <summary>
        /// Disposable Pattern - It is used to dispose open connections / unused reference type objects
        /// </summary>
        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            //Prevent the GC from calling Object.Finalize on an
            //object that does not require it
            GC.SuppressFinalize(this);
        }
    }
}
