using Data.Repository;
using Microsoft.EntityFrameworkCore;
using Models.Entities;
using Services.Interfaces;
using Shared.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IGenericRepository<Employee> _employeeRepository;
        private readonly IGenericRepository<Department> _departmentRepository;


        public EmployeeService(IGenericRepository<Employee> employeeRepository, IGenericRepository<Department> departmentRepository)
        {
            _employeeRepository = employeeRepository;
            _departmentRepository = departmentRepository;
        }
        public ResultViewModel AddEmployee(AddEmployeeVM addEmployeeVM)
        {
            ResultViewModel result = new ResultViewModel()
            {
                Message = "An Error Occured While Adding Employee",
                Success = false

            };
            Employee employee = new Employee()
            {
                Name = addEmployeeVM.Name,
                DepartmentId = addEmployeeVM.DepartmentId
            };
            _employeeRepository.Add(employee);
            if (_employeeRepository.SaveChanges())
            {
                result.Success = true;
                result.Message = "Employee Added Successfully";
            }
            return result;
        }

        public ResultViewModel DeleteEmployee(int id)
        {
            ResultViewModel result = new ResultViewModel()
            {
                Message = "An Error Occured While Deleting Employee",
                Success = false

            };
            var employee = _employeeRepository.Get(id);
            if (employee != null)
            {
                _employeeRepository.Delete(employee);
                if (_employeeRepository.SaveChanges())
                {
                    result.Message = "Employee Deleted Successfully";
                    result.Success = true;
                }
            }

            return result;
        }

        public ResultListViewModel<Employee> GetAllEmployees()
        {
            ResultListViewModel<Employee> result = new ResultListViewModel<Employee>()
            {
                Message = "An Error Occured While Getting Employees",
                Success = false
            };
            List<Employee> employees = _employeeRepository.GetAllAsQueryable().Include(a=>a.Department).ToList();
            if (employees != null)
            {
                result.ReturnObjectList = employees;
                result.Success = true;
                result.Message = "Employees Retrieved Successfully";
            }
            return result;
        }

        public ResultViewModel GetEmployeeById(int id)
        {
            ResultViewModel result = new ResultViewModel()
            {
                Message = "An Error Occured While Getting Employee",
                Success = false
            };
            var employee = _employeeRepository.GetAsQueryable().Where(a => a.Id == id).Include(a => a.Department).FirstOrDefault();
            if (employee != null)
            {
                result.ReturnObject = employee;
                result.Success = true;
                result.Message = "Employee Retrieved Successfully";
            }
            return result;
        }

        public ResultViewModel UpdateEmployee(EditEmployeeVM editEmployeeVM)
        {
            ResultViewModel result = new ResultViewModel()
            {
                Message = "An Error Occured While Updating Employee",
                Success = false
            };
            var employee = _employeeRepository.GetAsQueryable().Where(a => a.Id == editEmployeeVM.Id).FirstOrDefault();
            if (employee != null)
            {
                employee.Name = editEmployeeVM.Name;
                employee.DepartmentId = editEmployeeVM.DepartmentId;
                _employeeRepository.Update(employee);
                if (_employeeRepository.SaveChanges())
                {
                    result.Message = "Employee Updated Successfully";
                    result.Success = true;
                }

            }
            else
            {
                result.Message = "No Employee Found";
            }
            return result;
        }
    }
}
