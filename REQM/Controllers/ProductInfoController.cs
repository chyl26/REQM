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
    public class ProductInfoController : Controller
    {
        private ProductInfoService productInfoCRUD = new ProductInfoService();

        // GET: ProductInfo
        [Authentication]
        public ActionResult Index()
        {
            return View(productInfoCRUD.GetProducts());
        }

        [Authentication]
        public ActionResult Details(string Id)
        {
            if (Id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductInfo product = productInfoCRUD.GetProductById(Id);
            return View(product.ToModel());
        }
        [Authentication]
        public ActionResult Create()
        {
            return View();
        }
        /// <summary>
        /// 产品立项
        /// </summary>
        /// <param name="product">立项信息</param>
        /// <returns></returns>
        [ValidateInput(false)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authentication]
        public ActionResult Create(ProductInfoModel productInfoModel)
        {
            if (ModelState.IsValid)
            {
                productInfoModel.ProductId = Guid.NewGuid().ToString();
                productInfoModel.CreateAt = DateTime.Now;
                string userId = HttpContext.Session["UserId"] as string;
                productInfoModel.UserId = userId;
                //将Models类转换成Domain类
                ProductInfo product = productInfoModel.ToEntity();
                productInfoCRUD.Create(product);
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "");
            return View(productInfoModel);
        }
        [Authentication]
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductInfo product = productInfoCRUD.GetProductById(id);


            return View("Edit", product.ToModel());
        }

        [ValidateInput(false)]
        [HttpPost]
        [Authentication]
        public ActionResult Edit(ProductInfoModel productInfoModel)
        {
            if (ModelState.IsValid)
            {
                ProductInfo product = productInfoModel.ToEntity();
                productInfoCRUD.Update(product);
                return RedirectToAction("Index");
            }
            return View(productInfoModel);
        }
        [Authentication]
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            productInfoCRUD.Delete(id);
            return RedirectToAction("Index");
        }
        [Authentication]
        public ActionResult Document(string Id)
        {
            if (Id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductInfo product = productInfoCRUD.GetProductById(Id);
            return View(product.ToModel());
        }
    }
}