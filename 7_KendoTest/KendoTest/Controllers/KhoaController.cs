using Kendo.Mvc.UI;
using KendoTest.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kendo.Mvc.Extensions;
using System.Web.Services.Description;
using KendoTest.Models;
using KendoTest.ViewModel;

namespace KendoTest.Controllers
{
    public class KhoaController : Controller
    {
        KhoaServices khoaServices = new KhoaServices();

        public ActionResult Index()
        {
            return View();
        }
        //list
        public ActionResult LoadListKhoa([DataSourceRequest] DataSourceRequest request,ParamKhoa param)
        {
            //if (string.IsNullOrEmpty(maKhoa))
            //{
            //    return Json(new { Error = "01", Message = "Vui long nhap truong bat buoc" });
            //}
            var listKhoa = khoaServices.LoadListKhoa(param);
            return Json(listKhoa.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

        //edit
        public ActionResult EditKhoa(string maKhoa)
        {
            var editKhoa = khoaServices.getKhoa(maKhoa);          
            return View(editKhoa);
        }

        [HttpPost]
        public ActionResult EditKhoa(TBLKhoa model)
        {
            khoaServices.editKhoa(model);
            return RedirectToAction("Index");
        }

        //delete
        public ActionResult DeleteKhoa(string maKhoa)
        {
            khoaServices.deleteKhoa(maKhoa);
            return RedirectToAction("Index");
        }

        //create
        public ActionResult CreateKhoa()
        {
            return View("CreateKhoa");
        }

        [HttpPost]
        public ActionResult CreateKhoa(TBLKhoa model)
        {
            khoaServices.CreateKhoa(model);
            return RedirectToAction("Index");
        }


    }
}