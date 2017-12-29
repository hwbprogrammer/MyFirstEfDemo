
using HWB.Framework.Models;
using MyFirst.Data.Dto;
using MyFirst.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyFirstEFAndMvcDemo.Controllers
{
    public class ProductController : Controller
    {
        public readonly IProductService _Product ;
        public ProductController( IProductService product)
        {
            this._Product = product;
        }
        // GET: Product
        public ActionResult Index()
        {
           
            return View();
        }
        public JsonResult GetProductInfo()
        {
            var model = _Product.GetProductInfo();
            var total = model.Count;
            var rows = model.ToList();
            return Json(new {total = total, rows = rows },JsonRequestBehavior.AllowGet);
        }
        public ViewResult AddOrEditProduct(ProductModel model)
        {
            var objRet = _Product.GetSingleProduct(model);
           return View(objRet);
        }
        public JsonResult SaveProductInfo(ProductModel model)
        {
            ReturnJson result = _Product.SaveProductInfo(model);
            return Json(result);
        }

        public JsonResult DelProductInfo(List<string> idList)
        {
            return Json(_Product.DelProductInfo(idList));
        }

        
    }
}