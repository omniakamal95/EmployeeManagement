using Models.Entities;
using Shared.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Interfaces
{
    public interface IEmployeeService
    {
        ResultViewModel AddEmployee(AddEmployeeVM addEmployeeVM);
        ResultViewModel GetEmployeeById(int id);
        ResultListViewModel<Employee> GetAllEmployees();
        ResultViewModel UpdateEmployee(EditEmployeeVM editEmployeeVM);
        ResultViewModel DeleteEmployee(int id);
    }
}
