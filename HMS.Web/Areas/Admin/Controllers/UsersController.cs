using BLL.Services;
using BLL.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HMS.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class UsersController : Controller
    {
        private IApplicationUserService _userService;

        public UsersController(IApplicationUserService userService)
        {
            _userService = userService;
        }

        public IActionResult Index(int PageNumber = 1, int PageSize = 10)
        {
            return View(_userService.GetAll(PageNumber, PageSize));
        }

        public IActionResult AllDoctors(int PageNumber = 1, int PageSize = 10)
        {
            return View(_userService.GetAllDoctor(PageNumber, PageSize));
        }

        [HttpGet]
        public IActionResult Edit(string id)
        {
            var user = _userService.GetById(id);
            return View(user);
        }

        [HttpPost]
        public IActionResult Edit(ApplicationUserViewModel vm)
        {
            _userService.Update(vm);
            return RedirectToAction("Index");
        }

        public IActionResult Details(string id)
        {
            var user = _userService.GetById(id);
            return View(user);
        }

        [HttpGet]
        public IActionResult Delete(string id)
        {
            var user = _userService.GetById(id);
            return View(user);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(string id)
        {
            _userService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}