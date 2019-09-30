using Demo.Models;
using Demo.Pocos;
using Demo.Repository;
using System.Net;
using System.Web.Mvc;

namespace Demo.Controllers
{
    public class UserController : Controller
    {
        private IUserRepository _userRepository;
        private IDepartmentRepository _departmentRepository;

        public UserController(IUserRepository userRepository, IDepartmentRepository departmentRepository)
        {
            _userRepository = userRepository;
            _departmentRepository = departmentRepository;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SaveUser()
        {
            ViewBag.DepartmentList = new SelectList(_departmentRepository.GetDepartments(), "Id", "Description");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult SaveUser(UserPocos user)
        {
            _userRepository.AddUser(user);

            return Json(Url.Action("UserList","User"));
        }

        public ActionResult EditUser(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = _userRepository.GetUser(id);
            if (user==null)
            {
                return HttpNotFound();
            }
            ViewBag.DepartmentId = new SelectList(_departmentRepository.GetDepartments(), "Id", "Description", user.DepartmentId);
            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult EditUser(UserPocos user)
        {
            _userRepository.UpdateUser(user);
            return Json(Url.Action("UserList", "User"));
        }

        public ActionResult UserList()
        {
            return View(_userRepository.GetUsers());
        }

        public JsonResult DeleteUser(int id)
        {       
            _userRepository.DeleteUser(id);
            return Json("1", JsonRequestBehavior.AllowGet);
        }
    }
}