using Data.Repository;
using Models.Entities;
using Services.Interfaces;
using Shared.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services
{
    public class DepartmentsService : IDepartmentService
    {
        private readonly IGenericRepository<Department> _departmentRepository;
        public DepartmentsService(IGenericRepository<Department> departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }
        public ResultViewModel GetAllDepartments()
        {
            ResultListViewModel<Department> result = new ResultListViewModel<Department>()
            {
                Message = "An Error Occured While Getting Departments",
                Success = false
            };
            List<Department> departments = _departmentRepository.GetAllAsQueryable().ToList();
            if (departments != null)
            {
                result.ReturnObjectList = departments;
                result.Success = true;
                result.Message = "Departments Retrieved Successfully";
            }
            return result;
        }
    }
}
