using MVCwithWebAPI.Data;
using MVCwithWebAPI.Models;
using MVCwithWebAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MVCwithWebAPI.Controllers
{
    public class AccountsController : Controller
    {
        private readonly IUserRepository _userRepository;

        public AccountsController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(User model)
        {
            try
            {
                bool isValidUser = _userRepository.IsValidUser(model.UserName, model.Password);
                //bool IsValidUser = context.Users.Any(user => user.UserName.ToLower() ==
                //     model.UserName.ToLower() && user.Password == model.Password);
                if (isValidUser)
                {
                    FormsAuthentication.SetAuthCookie(model.UserName, false);
                    return RedirectToAction("Index", "Employees");
                }
                ModelState.AddModelError("", "invalid Username or Password");
                return View();
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = "Error: " + ex.InnerException?.Message ?? ex.Message;
                return View("Error");
            }
        }
        public ActionResult Signup()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Signup(User model)
        {
            try
            {
                //using (SqlDbContext context = new SqlDbContext())
                //{
                //    context.Users.Add(model);
                //    context.SaveChanges();
                //}
                _userRepository.AddUser(model);
                return RedirectToAction("Login");
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = "Error: " + ex.InnerException?.Message ?? ex.Message;
                return View("Error");
            }
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}