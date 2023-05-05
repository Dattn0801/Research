using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KendoTest.Models;
using KendoTest.ViewModel;

namespace KendoTest.Services
{
    public class SinhVienService
    {
        ThucTapEntities ctx = new ThucTapEntities();
        public List<SinhVienViewModel> loadSinhVien()
        {
            var listSv = ctx.TBLSinhViens.ToList();
            List<SinhVienViewModel> sv = new List<SinhVienViewModel>();
            if (listSv != null && listSv.Any())
            {
                foreach (var item in listSv)
                {
                    sv.Add(new SinhVienViewModel()
                    {
                        Masv = item.Masv,
                        Hotensv = item.Hotensv,
                        Namsinh = item.Namsinh,
                        Quequan = item.Quequan,
                        Makhoa = item.Makhoa,
                    });
                }
            }
            return sv;
        }


        public TBLSinhVien getSinhVien(int? maSv)
        {
            var sv = ctx.TBLSinhViens.Where(x => x.Masv == maSv).FirstOrDefault();
            return sv;
        }
        public TBLSinhVien editSinhVien(TBLSinhVien model)
        {
            var entity = ctx.TBLSinhViens.Where(x => x.Masv == model.Masv).FirstOrDefault();
            entity.Hotensv = model.Hotensv;
            entity.Namsinh = model.Namsinh;
            entity.Makhoa = model.Makhoa;
            entity.Quequan = model.Quequan;
            ctx.SaveChanges();
            return model;
        }
        public TBLSinhVien deleteSinhVien(int? maSv)
        {
            var entity = ctx.TBLSinhViens.Where(x => x.Masv == maSv).FirstOrDefault();
            ctx.TBLSinhViens.Remove(entity);
            ctx.SaveChanges();
            return entity;
        }
    }

}