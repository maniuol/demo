using Demo.Models;
using Demo.Pocos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Demo.Repository
{
    public interface IDepartmentRepository
    {
        Department GetDepartment(int id);
        List<ViewModalDepartment> GetDepartments();
        int AddDepartment(DepartmentPocos department);
        void UpdateDepartment(DepartmentPocos department);
        void DeleteDepartment(int id);
        bool HasUser(int id);
    }
}