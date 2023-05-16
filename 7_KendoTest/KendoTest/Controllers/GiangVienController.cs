using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using KendoTest.Models;
using KendoTest.Services;
using KendoTest.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;

namespace KendoTest.Controllers
{
    public class GiangVienController : Controller
    {
        GiangVienServices gvService = new GiangVienServices();

        //list
        public ActionResult LoadList([DataSourceRequest] DataSourceRequest request,ParamGiangVien param)
        {
           
            var listSV = gvService.loadList(param);
            return Json(listSV.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

        //create
        public ActionResult CreateGV()
        {
            var listKhoa = gvService.ListKhoa();
            ViewBag.ListKhoa = new SelectList(listKhoa, "MaKhoa", "Tenkhoa");
            return View("CreateGV");
        }
        [HttpPost]
        public ActionResult CreateGV(TBLGiangVien model)
        {
            gvService.CreateGV(model);

            //var listKhoa = svService.ListKhoa();
            //ViewBag.ListKhoa = new SelectList(listKhoa, "MaKhoa", "Tenkhoa");
            return RedirectToAction("Index");
        }

        //update
        public ActionResult EditGV(int? maGV)
        {
            var editSv = gvService.getOneGV(maGV);
            var listKhoa = gvService.ListKhoa();
            ViewBag.ListKhoa = new SelectList(listKhoa, "MaKhoa", "Tenkhoa");
            return View(editSv);
        }

        [HttpPost]
        public ActionResult EditGV(TBLGiangVien model)
        {
            gvService.editGV(model);
            return RedirectToAction("Index");
        }

        //delete
        public ActionResult DeleteGV(int? maGV)
        {
            gvService.deleteGV(maGV);
            return RedirectToAction("Index");
        }

        public ActionResult Index()
        {
            var listKhoa = gvService.ListKhoa();
            ViewBag.ListKhoa = new SelectList(listKhoa, "Makhoa", "Tenkhoa");
            return View();
        }
    }
}