﻿using KendoTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using KendoTest.ViewModel;
using KendoTest.Services;
using System.Data.Entity.Validation;

namespace KendoTest.Controllers
{
    public class HomeController : Controller
    {
        SinhVienService svService = new SinhVienService();

        public ActionResult Index()
        {
            var listKhoa = svService.ListKhoa();
            ViewBag.ListKhoa = new SelectList(listKhoa, "MaKhoa", "Tenkhoa");
            return View();
        }
     
        public ActionResult LoadListSv([DataSourceRequest] DataSourceRequest request, ParamSinhVien param)
        {
            var listSV = svService.LoadSinhVien(param);
            return Json(listSV.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }
       
        public ActionResult EditSv(int? maSv)
        {
            var editSv = svService.GetSinhVien(maSv);
            var listKhoa = svService.ListKhoa();
            ViewBag.ListKhoa = new SelectList(listKhoa, "MaKhoa", "Tenkhoa");
            return View(editSv);
        }

        [HttpPost]
        public ActionResult EditSv(TBLSinhVien model)
        {
            svService.EditSinhVien(model);
            return RedirectToAction("Index");
        }

        //[HttpPost]
        public ActionResult DeleteSv(int? maSv)
        {
            svService.DeleteSinhVien(maSv);
            return RedirectToAction("Index");
        }

        public ActionResult createSv()
        {
            var listKhoa = svService.ListKhoa();
            ViewBag.ListKhoa = new SelectList(listKhoa, "MaKhoa", "Tenkhoa");
            return View("CreateSv");
        }
        
        [HttpPost]
        public ActionResult CreateSv(TBLSinhVien model)
        {
            svService.CreateSinhVien(model);
            return RedirectToAction("Index");
        }


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }
    }
}
