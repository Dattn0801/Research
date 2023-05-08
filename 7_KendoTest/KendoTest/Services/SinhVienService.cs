using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
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
            try
            {
                var entity = ctx.TBLSinhViens.Where(x => x.Masv == model.Masv).FirstOrDefault();
                entity.Hotensv = model.Hotensv;
                entity.Namsinh = model.Namsinh;
                entity.Makhoa = model.Makhoa;
                entity.Quequan = model.Quequan;
                ctx.SaveChanges();
                return model;
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    var name = eve.Entry.Entity.GetType().Name;
                    var state = eve.Entry.State;
                    foreach (var ve in eve.ValidationErrors)
                    {
                        var propertyName = eve.Entry.Entity.GetType().Name;
                        var errorMessage = eve.Entry.State;
                    }
                }
                throw;
            }

        }
        public TBLSinhVien deleteSinhVien(int? maSv)
        {
            var entity = ctx.TBLSinhViens.Where(x => x.Masv == maSv).FirstOrDefault();
            ctx.TBLSinhViens.Remove(entity);
            ctx.SaveChanges();
            return entity;
        }

        public void createSinhVien(TBLSinhVien model)
        {
            {
            if (model != null)
                ctx.TBLSinhViens.Add(model);
                ctx.SaveChanges();
            }
        }
        public List<TBLKhoa> ListKhoa()
        {
           // var listKhoa = ctx.TBLKhoas.ToList();
           // return listKhoa;
            return ctx.TBLKhoas.ToList();
        }
    }

}