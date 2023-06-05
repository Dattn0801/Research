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
using System.Web.UI.WebControls;

namespace KendoTest.Controllers
{
    public class HuongDanController : Controller
    {
        HuongDanServices huongdanService = new HuongDanServices();
        SinhVienService sinhVienService = new SinhVienService();    
        public ActionResult Index()
        {
            var listDT = huongdanService.ListDeTai();
            ViewBag.ListDT = new SelectList(listDT, "Madt", "Tendt");
            var listGV = huongdanService.ListGiangVien();
            ViewBag.ListGV = new SelectList(listGV, "Magv", "Hotengv");
            return View();
        }

        //list
        [HttpPost]
        public ActionResult LoadList([DataSourceRequest] DataSourceRequest request,ParamHuongDan param)
        {
            var list = huongdanService.loadList(param);
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
        //[HttpPost]
        //public ActionResult CreateHDT(TBLHuongDan model)
        //{
        //    huongdanService.createHD(model);
        //    //var listKhoa = svService.ListKhoa();
        //    //ViewBag.ListKhoa = new SelectList(listKhoa, "MaKhoa", "Tenkhoa");
        //    return RedirectToAction("Index");
        //}

        [HttpPost]
        public ActionResult CreateHD(AddUpdateGVHuongDan model)
        {

              if (model == null || model.MaSV == null || string.IsNullOrEmpty(model.MaDT) || model.MaGV.GetValueOrDefault(0) == 0 || !model.KetQua.HasValue)
            {
                return Json(model);
            }
            huongdanService.createHD(model);
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

        public ActionResult GetTen(int?[] arrID)
        {
            var listSV = huongdanService.ListSV();
            var lstGetTenSV = new List<ParamHuongDan>();
            if (arrID!= null)
            {
                var lstStrID = arrID.ToList();
                lstGetTenSV = listSV.Where(x => lstStrID.Contains(x.Masv)).Select(p => new ParamHuongDan {HoTen = p.Hotensv}).ToList();
                Session["listSV"] = arrID;
            }
            
            return Json(lstGetTenSV.Select(p=>new ParamHuongDan { MaSV = p.MaSV, HoTen = p.HoTen}),JsonRequestBehavior.AllowGet);
        }

    }
}