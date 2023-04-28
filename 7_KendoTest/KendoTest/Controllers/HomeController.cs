using KendoTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using KendoTest.ViewModel;


namespace KendoTest.Controllers
{
    public class HomeController : Controller
    {
        ThucTapEntities ctx = new ThucTapEntities();
        public ActionResult Index()
        {
            return View(); 
        }

        [HttpPost]
        public ActionResult LoadListSv([DataSourceRequest] DataSourceRequest request)
        {

            var listSv = ctx.TBLSinhViens.ToList();
            List<SinhVienViewModel> sv = new List<SinhVienViewModel>();
            foreach (var item in listSv)
            {
                sv.Add(new SinhVienViewModel() { Masv = item.Masv, Hotensv = item.Hotensv, Namsinh = item.Namsinh, Quequan = item.Quequan, Makhoa = item.Makhoa, });

            }
            return Json(sv.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }
        public ActionResult EditSv(int? maSv)
        {
            var editSv = ctx.TBLSinhViens.Where(x => x.Masv == maSv).FirstOrDefault();
            return View(editSv);
        }

        [HttpPost]
        public ActionResult EditSv(TBLSinhVien model)
        {
            var entity = ctx.TBLSinhViens.Where(x => x.Masv == model.Masv).FirstOrDefault();
            entity.Hotensv = model.Hotensv;
            entity.Namsinh = model.Namsinh;
            entity.Makhoa = model.Makhoa;
            entity.Quequan = model.Quequan;
            ctx.SaveChanges();
            return RedirectToAction("Index");
        }
      
        //[HttpPost]
        public ActionResult DeleteSv(int? maSv)
        {
            var entity = ctx.TBLSinhViens.Where(x => x.Masv == maSv).FirstOrDefault();
            ctx.TBLSinhViens.Remove(entity);
            ctx.SaveChanges();
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
