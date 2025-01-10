using AppDomainCore.Contract.User;
using AppDomainCore.Entities;
using Microsoft.AspNetCore.Mvc;

namespace AppEndPointMvc.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserAppService _userAppService;

        public UserController(IUserAppService userAppService)
        {
            _userAppService = userAppService;
        }

        public IActionResult List()
        {
            try
            {
                var users = _userAppService.GetAll();
                return View(users);
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(User newUser)
        {
            try
            {
                _userAppService.Create(newUser);
                TempData["SuccessMessage"] = "کاربر با موفقیت ایجاد شد";
                return RedirectToAction("List");
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = "خطا در ساخت کاربر";
            }

            return View(newUser);
        }


        [HttpGet]
        public IActionResult Update(int id)
        {
            try
            {
                var user = _userAppService.GetById(id);
                return View(user);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = "خطا در نمایش کاربر";
                return View();
            }
        }

        [HttpPost]
        public IActionResult Update(int id, User updatedUser)
        {

            try
            {
                _userAppService.Update(id, updatedUser);
                TempData["SuccessMessage"] = "کاربر با موفقیت آپدیت شد";
                return RedirectToAction("List");
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = "خطادر اپدیت کاربر";
            }

            return View(updatedUser);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            try
            {
                var user = _userAppService.GetById(id);
                return View(user);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = "خطانمایش کاربرر";
                return View();
            }
        }

        [HttpPost]
        public IActionResult Deletec(int id)
        {
            try
            {
                _userAppService.Delete(id);
                TempData["SuccessMessage"] = "کاربر با موفقیت حذف شد";
                return RedirectToAction("List");
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = "خطا در حذف کاربر";
                return RedirectToAction("List");
            }
        }




        [HttpGet]
        public IActionResult Search(string search)
        {
            if (search == null)
            {
                ViewBag.ErrorMessage = "خطا";
                return View("List");
            }
            try
            {
                var users = _userAppService.Search(search);  

                return View("List", users);  
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = "خطا در جستجو";
                return View("List"); 
            }
        }


        public IActionResult Profile(int id)
        {
            try
            {
                var user = _userAppService.GetById(id);
                return View(user);
            }
            catch (Exception ex)
            {
                return View();
            }
        }
    }
}
