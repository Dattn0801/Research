using KendoTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KendoTest.ViewModel;
using System.Web.Mvc;
using System.Data.Entity.Validation;

namespace KendoTest.Services
{
    public class KhoaServices
    {
        ThucTapEntities ctx = new ThucTapEntities();

        //listkhoa
        public List<KhoaViewModel> loadListKhoa()
        {
            var lst = ctx.TBLKhoas.ToList();
            List<KhoaViewModel> k = new List<KhoaViewModel>();
            if (lst != null && lst.Any())
            {
                foreach (var item in lst)
                {
                    k.Add(new KhoaViewModel()
                    {
                        Makhoa = item.Makhoa,
                        Tenkhoa = item.Tenkhoa,
                        Dienthoai = item.Dienthoai,
                    });
                }
            }
            return k;
        }     

        //createkhoa
        public void CreateKhoa(TBLKhoa model)
        {
            if (model != null)
            {
                ctx.TBLKhoas.Add(model);
            }
            ctx.SaveChanges();
        }
        public TBLKhoa editKhoa(TBLKhoa model)
        {
         
                var entity = ctx.TBLKhoas.Where(x => x.Makhoa == model.Makhoa).FirstOrDefault();
                entity.Tenkhoa = model.Tenkhoa;
                entity.Dienthoai = model.Dienthoai;
                ctx.SaveChanges();

            return model;
        }

        public void deleteKhoa(string maKhoa)
        {
            var entity = ctx.TBLKhoas.Where(x => x.Makhoa == maKhoa).FirstOrDefault();
            ctx.TBLKhoas.Remove(entity);
            ctx.SaveChanges();
        }    
        
        public TBLKhoa getKhoa(string maKhoa)
        {
            var  khoa = ctx.TBLKhoas.Where(x  => x.Makhoa == maKhoa).FirstOrDefault();
            return khoa;
        }      
    }
}