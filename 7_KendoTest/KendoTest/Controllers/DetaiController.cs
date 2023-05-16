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

namespace KendoTest.Controllers
{
    public class DetaiController : Controller
    {
        DetaiServices detaiServices = new DetaiServices();

        public ActionResult Index()
        {
            return View();
        }
        //list
        public ActionResult LoadList([DataSourceRequest] DataSourceRequest request,ParamDeTai param)
        {
            var list = detaiServices.LoadList(param);
            return Json(list.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

        //create
        public ActionResult CreateDT()
        {
            return View("CreateDT");
        }

        [HttpPost]
        public ActionResult CreateDT(TBLDeTai model)
        {
            detaiServices.createDT(model);
            return RedirectToAction("Index");
        }

        //update
        public ActionResult EditDT(string maDT)
        {
            var dt = detaiServices.getDT(maDT);
            return View(dt);
        }

        [HttpPost]
        public ActionResult EditDT(TBLDeTai model)
        {
            detaiServices.editDT(model);
            return RedirectToAction("Index");
        }

        //delete
        public ActionResult DeleteDT(string maDT)
        {
            detaiServices.deleteDT(maDT);
            return RedirectToAction("Index");
        }
     

    }
}