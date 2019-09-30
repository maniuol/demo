using Demo.Pocos;
using Demo.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Demo.Controllers
{
    public class DepartmentController : Controller
    {
        private IDepartmentRepository _departmentRepository;

        public DepartmentController(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult DepartmentList()
        {
            return View(_departmentRepository.GetDepartments());
        }
        public ActionResult AddDepartment()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult AddDepartment(DepartmentPocos department)
        {
            _departmentRepository.AddDepartment(department);
            return Json(Url.Action("DepartmentList", "Department"));
        }

        public ActionResult EditDepartment(int id)
        {
           
            return View(_departmentRepository.GetDepartment(id));
        }
        [HttpPost]
        public JsonResult EditDepartment(DepartmentPocos department)
        {
            _departmentRepository.UpdateDepartment(department);
            return Json(Url.Action("DepartmentList", "Department"));
        }
        public JsonResult DeleteDepartment(int id)
        {
                if (!_departmentRepository.HasUser(id))
                {
                    _departmentRepository.DeleteDepartment(id);
                    return Json("1", JsonRequestBehavior.AllowGet);
                }
                return Json("Assigned", JsonRequestBehavior.AllowGet);   
        }
    }
}