using KendoTest.Models;
using KendoTest.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KendoTest.Services
{
    public class DetaiServices
    {
        ThucTapEntities ctx = new ThucTapEntities();

        public List<DetaiViewModel> LoadList(ParamDeTai param)
        {
            var listDeTai = ctx.SP_DT_GetAllDeTai(param.MaDT,param.TenDT, param.KinhPhi, param.NoiThucTap).ToList();
            List<DetaiViewModel> result = new List<DetaiViewModel>();

            if (listDeTai != null && listDeTai.Count > 0)
            {
                result = listDeTai.Select(m => new DetaiViewModel
                {
                    Madt = m.Madt,
                    Tendt = m.Tendt,
                    Kinhphi = m.Kinhphi,
                    Noithuctap = m.Noithuctap
                }).ToList();
            }
            return result;

            //var lst = ctx.TBLDeTais.ToList();
            //List<DetaiViewModel> k = new List<DetaiViewModel>();
            //if (lst != null && lst.Any())
            //{
            //    foreach (var item in lst)
            //    {
            //        k.Add(new DetaiViewModel()
            //        {
            //            Madt = item.Madt,
            //            Tendt = item.Tendt,
            //            Kinhphi = item.Kinhphi,
            //            Noithuctap = item.Noithuctap,
            //        });
            //    }
            //}
            //return k;
        }

        //createkhoa
        public void createDT(TBLDeTai model)
        {
            if (model != null)
            {
                ctx.TBLDeTais.Add(model);
            }
            ctx.SaveChanges();
        }
        public TBLDeTai editDT(TBLDeTai model)
        {
            var e = ctx.TBLDeTais.Where(x => x.Madt == model.Madt).FirstOrDefault();           
            e.Tendt = model.Tendt.Trim();
            e.Kinhphi = model.Kinhphi;
            e.Noithuctap = model.Noithuctap.Trim();
            ctx.SaveChanges();
            return model;
        }

        public void deleteDT(string maDT)
        {
            var entity = ctx.TBLDeTais.Where(x => x.Madt == maDT).FirstOrDefault();
            ctx.TBLDeTais.Remove(entity);
            ctx.SaveChanges();
        }

        public TBLDeTai getDT(string maDT)
        {
            var khoa = ctx.TBLDeTais.Where(x => x.Madt == maDT).FirstOrDefault();
            return khoa;
        }
    }
}