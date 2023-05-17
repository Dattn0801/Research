using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.ModelBinding;
using System.Xml.Linq;
using System.Xml.Schema;
using KendoTest.Models;
using KendoTest.ViewModel;

namespace KendoTest.Services
{
    public class SinhVienService
    {
        ThucTapEntities ctx = new ThucTapEntities();
        public List<SinhVienViewModel> LoadSinhVien(ParamSinhVien param)
        {
            var listSV = ctx.SP_SV_GetAllSinhVien(param.HoTen, param.NamSinh, param.QueQuan, param.TenKhoa, param.MaKhoa,param.MaSinhVien).ToList();
            List<SinhVienViewModel> sinhVien = new List<SinhVienViewModel>();
                            
            if(listSV != null && listSV.Count > 0)
            {
                sinhVien = listSV.Select(m => new SinhVienViewModel
                {
                    Hotensv = m.Hotensv,
                    Masv = m.Masv,
                    Namsinh = m.Namsinh,
                    Quequan = m.Quequan,
                    Tenkhoa = m.Tenkhoa,
                }).ToList();
            }
            return sinhVien;
        }

        public TBLSinhVien GetSinhVien(int? maSv)
        {
            var sv = ctx.TBLSinhViens.Where(x => x.Masv == maSv).FirstOrDefault();
            return sv;
        }
        public TBLSinhVien EditSinhVien(TBLSinhVien model)
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
        public TBLSinhVien DeleteSinhVien(int? maSv)
        {
            var entity = ctx.TBLSinhViens.Where(x => x.Masv == maSv).FirstOrDefault();
            ctx.TBLSinhViens.Remove(entity);
            ctx.SaveChanges();
            return entity;
        }

        public void CreateSinhVien(TBLSinhVien model)
        {
            {
            if (model != null)
                ctx.TBLSinhViens.Add(model);
                ctx.SaveChanges();
            }
        }
        public List<TBLKhoa> ListKhoa()
        {
            return ctx.TBLKhoas.ToList();
        }
    }

}