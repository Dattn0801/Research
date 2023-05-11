using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Xml.Linq;
using KendoTest.Models;
using KendoTest.ViewModel;

namespace KendoTest.Services
{
    public class SinhVienService
    {
        ThucTapEntities ctx = new ThucTapEntities();
        public List<SinhVienViewModel> loadSinhVien(string hoTenSinhVien, int? namSinh, string queQuan, string TenKhoa, string maKhoa)
        {
            //var listSv = ctx.TBLSinhViens.ToList();
            var listSv = ctx.TBLSinhViens.AsQueryable();

            if (!string.IsNullOrEmpty(hoTenSinhVien))
            {
                listSv = listSv.Where(l => l.Hotensv.Contains(hoTenSinhVien));
            }

            if (!string.IsNullOrEmpty(queQuan))
            {
                listSv = listSv.Where(l => l.Quequan.Contains(queQuan));
            }
            if (namSinh != null)
            {
                listSv = listSv.Where(l => l.Namsinh == namSinh);
            }

            if (!string.IsNullOrEmpty(maKhoa))
            {
                //var khoa = ctx.TBLKhoas.FirstOrDefault(x => x.Tenkhoa == TenKhoa);
                maKhoa = maKhoa.Trim();
                listSv = listSv.Where(l => l.Makhoa.Contains(maKhoa));
            }
            listSv.ToList();
            
            List<SinhVienViewModel> sv = new List<SinhVienViewModel>();
            if (listSv != null && listSv.Any())
            {
                foreach (var item in listSv)
                {

                    var khoa = ctx.TBLKhoas.FirstOrDefault(x => x.Makhoa == item.Makhoa);
                    sv.Add(new SinhVienViewModel()
                    {
                        Masv = item.Masv,
                        Hotensv = item.Hotensv,
                        Namsinh = item.Namsinh,
                        Quequan = item.Quequan,
                        Makhoa = item.Makhoa,
                        Tenkhoa = khoa.Tenkhoa,
                    });
                }
            }
            return sv;
        }
        public List<SinhVienViewModel> searchSinhVien(string hoTenSinhVien,int? namSinh,string queQuan, string TenKhoa)
        {
            var listSv = ctx.TBLSinhViens.ToList();
            List<SinhVienViewModel> sv = new List<SinhVienViewModel>();
            if (listSv != null && listSv.Any())
            {
                foreach (var item in listSv)
                {
                    var khoa = ctx.TBLKhoas.FirstOrDefault(x => x.Makhoa == item.Makhoa);
                    sv.Add(new SinhVienViewModel()
                    {
                        Masv = item.Masv,
                        Hotensv = item.Hotensv,
                        Namsinh = item.Namsinh,
                        Quequan = item.Quequan,
                        Makhoa = item.Makhoa,
                        Tenkhoa = khoa.Tenkhoa,
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