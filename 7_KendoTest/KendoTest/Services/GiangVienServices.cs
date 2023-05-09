using KendoTest.Models;
using KendoTest.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KendoTest.Services
{
    public class GiangVienServices
    {
        ThucTapEntities ctx = new ThucTapEntities();
        public List<GiangVienViewModel> loadList()
        {
            var lst = ctx.TBLGiangViens.ToList();
            List<GiangVienViewModel> k = new List<GiangVienViewModel>();
            if (lst != null && lst.Any())
            {
                foreach (var item in lst)
                {
                    k.Add(new GiangVienViewModel()
                    {
                        Magv = item.Magv,
                        Hotengv = item.Hotengv,
                        Luong = item.Luong,                     
                        Makhoa = item.Makhoa,                      
                    });
                }
            }
            return k;
        }

        //createkhoa
        public void CreateGV(TBLGiangVien model)
        {
            if (model != null)
            {
                ctx.TBLGiangViens.Add(model);
            }
            ctx.SaveChanges();
        }
        public TBLGiangVien editGV(TBLGiangVien model)
        {
            var e = ctx.TBLGiangViens.Where(x => x.Magv == model.Magv).FirstOrDefault();     
            e.Hotengv = model.Hotengv.Trim();
            e.Luong = model.Luong;
            e.Makhoa = model.Makhoa.Trim();   
            ctx.SaveChanges();
            return model;
        }

        public void deleteGV(int? maGV)
        {
            var entity = ctx.TBLGiangViens.Where(x => x.Magv == maGV).FirstOrDefault();
            ctx.TBLGiangViens.Remove(entity);
            ctx.SaveChanges();
        }

        public TBLGiangVien getOneGV(int? maGV)
        {
            var khoa = ctx.TBLGiangViens.Where(x => x.Magv == maGV).FirstOrDefault();
            return khoa;
        }

        //list khoa
        public List<TBLKhoa> ListKhoa()
        {
            // var listKhoa = ctx.TBLKhoas.ToList();
            // return listKhoa;
            return ctx.TBLKhoas.ToList();
        }
    }
}