using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using KendoTest.Models;
using KendoTest.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;

namespace KendoTest.Controllers
{
    public class HuongDanController : Controller
    {
        HuongDanServices huongdanService =  new HuongDanServices();
        public ActionResult Index()
        {
            return View();
        }

        //list
        public ActionResult LoadList([DataSourceRequest] DataSourceRequest request)
        {
            var list = huongdanService.loadList();
            
            return Json(list.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }


        public ActionResult CreateHD()
        {
            //sinh vien
            var listSV = huongdanService.ListSinhVien();
            ViewBag.ListSV = new SelectList(listSV, "Masv", "Hotensv");
            //detai
            var listDT = huongdanService.ListDeTai();
            ViewBag.ListDT = new SelectList(listDT, "Madt", "Tendt");
            //giang vien
            var listGV = huongdanService.ListGiangVien();
            ViewBag.ListGV = new SelectList(listGV, "Magv", "Hotengv");
            return View("CreateHD");
        }
        [HttpPost]
        public ActionResult CreateHD(TBLHuongDan model)
        {
            huongdanService.createHD(model);
            //var listKhoa = svService.ListKhoa();
            //ViewBag.ListKhoa = new SelectList(listKhoa, "MaKhoa", "Tenkhoa");
            return RedirectToAction("Index");
        }

        public ActionResult EditHD(int? maHD)
        {
            var hd = huongdanService.getHD(maHD);

            //sinh vien
            var listSV = huongdanService.ListSinhVien();
            ViewBag.ListSV = new SelectList(listSV, "Masv", "Hotensv");
            //detai
            var listDT = huongdanService.ListDeTai();
            ViewBag.ListDT = new SelectList(listDT, "Madt", "Tendt");
            //giang vien
            var listGV = huongdanService.ListGiangVien();
            ViewBag.ListGV = new SelectList(listGV, "Magv", "Hotengv");
            return View(hd);
        }

        [HttpPost]
        public ActionResult EditHD(TBLHuongDan model)
        {
            huongdanService.editHD(model);
            return RedirectToAction("Index");
        }

        //[HttpPost]
        public ActionResult DeleteHD(int? maHD)
        {
            huongdanService.deleteHD(maHD);
            return RedirectToAction("Index");
        }


    }
}