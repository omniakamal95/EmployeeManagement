using Shared.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Interfaces
{
    public interface IDepartmentService
    {
        ResultViewModel GetAllDepartments();
    }
}
