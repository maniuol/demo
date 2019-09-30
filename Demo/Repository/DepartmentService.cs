using Demo.Models;
using Demo.Pocos;
using System.Collections.Generic;
using System.Linq;

namespace Demo.Repository
{
    public class DepartmentService : IDepartmentRepository
    {
        public int AddDepartment(DepartmentPocos department)
        {
            using (DemoDbEntities db = new DemoDbEntities())
            {
                Department newdepartment = new Department()
                {
                    Description = department.Description,
                    Address = department.Address,
                    Active = department.active
                };

                db.Departments.Add(newdepartment);
                db.SaveChanges();
                return newdepartment.Id;
            }
        }

        public void DeleteDepartment(int id)
        {
            using (DemoDbEntities db = new DemoDbEntities())
            {
                db.Departments.Remove(db.Departments.FirstOrDefault(z => z.Id == id));
                db.SaveChanges();
            }
        }

        public Department GetDepartment(int id)
        {
            using (DemoDbEntities db = new DemoDbEntities())
            {
                return db.Departments.Find(id);
            }
        }

        public List<ViewModalDepartment> GetDepartments()
        {
            List<ViewModalDepartment> vmDepartment = new List<ViewModalDepartment>() { };

            using (DemoDbEntities db = new DemoDbEntities())
            {
                var query = (from i in db.Departments select new { i.Id, i.Description, i.Address, i.Active, TotalUsers = (from io in db.Users where io.DepartmentId == i.Id select new { io.DepartmentId }).Count() }).ToList();
                foreach (var item in query)
                {
                    vmDepartment.Add(new ViewModalDepartment()
                    {

                        Id = item.Id,
                        Description = item.Description,
                        Address = item.Address,
                        Active = item.Active,
                        TotalUsers = item.TotalUsers,
                    });
                }

                return vmDepartment;
            }
        }

        public void UpdateDepartment(DepartmentPocos department)
        {
            using (DemoDbEntities db = new DemoDbEntities())
            {
                Department olddepartment = db.Departments.Find(department.Id);
                olddepartment.Address = department.Address;
                olddepartment.Description = department.Description;
                olddepartment.Active = department.active;
                db.SaveChanges();
            }
        }

        public bool HasUser(int id)
        {
            using (DemoDbEntities db = new DemoDbEntities())
            {
                return db.Users.Any(z => z.DepartmentId == id);
            }

        }
    }
}