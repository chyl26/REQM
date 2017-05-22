using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using REQM.Domain;
using REQM.Service;
using REQM.Helper;

namespace REQM.Controllers
{
    public class AccountController : Controller
    {
        private UserService userCRUD = new UserService();
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 注销
        /// </summary>
        /// <returns></returns>
        public ActionResult Logoff()
        {
            Session.Clear();//清空
            return RedirectToAction("Login", "Account");
        }
        /// <summary>
        /// 登陆
        /// </summary>
        /// <returns></returns>
        public ActionResult Login()
        {
            return View();
        }
        /// <summary>
        /// 登陆方法（Post表单）
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult login(User user)
        {
            if (ModelState.IsValid)
            {
                user.PasswordHash = PasswordHelper.GetMd5HashStr(user.PasswordHash);
                User user1 = userCRUD.CheckUser(user);
                if (user1 != null)
                {
                    //保存session
                    HttpContext.Session["UserID"] = user1.UserID;
                    Session["User"] = user1;
                    //string userID = HttpContext.Session["UserID"] as string;
                    return RedirectToAction("Index");
                }
            }
            return View("Login");
        }
        /// <summary>
        /// 注册方法（Post表单）
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Register(User user)
        {
            return RedirectToAction("Login", "Account");

        }

        /// <summary>
        /// 注册
        /// </summary>
        /// <returns></returns>
        public ActionResult Register()
        {
            return View();
        }
    }
}