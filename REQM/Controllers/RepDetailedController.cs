using REQM.Domain;
using REQM.Helper;
using REQM.Models;
using REQM.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;


namespace REQM.Controllers
{
    public class RepDetailedController : Controller
    {

        private RepDetailedService DBCRUD = new RepDetailedService();

        // GET: RepDetailed
        [Authentication]
        public ActionResult Index()
        {
            return View();
        }

        [Authentication]
        public ActionResult Create()
        {
            return View();
        }

        [ValidateInput(false)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authentication]
        public ActionResult Create(RepDetailedModel repDetailed)
        {
            if (ModelState.IsValid)
            {

                repDetailed.ProductId = Guid.NewGuid().ToString();
                repDetailed.CreateAt = DateTime.Now;
                string userId = HttpContext.Session["UserId"] as string;
                repDetailed.UserId = userId;
                //将Models类转换成Domain类
                RepDetailed toEntity = repDetailed.ToEntity();
                DBCRUD.Create(toEntity);
                return RedirectToAction("Details", "ProductInfo",repDetailed.ProductId);
            }
            ModelState.AddModelError("", "");
            return View(repDetailed);
        }

    }
}