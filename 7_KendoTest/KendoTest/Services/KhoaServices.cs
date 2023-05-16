using KendoTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KendoTest.ViewModel;
using System.Web.Mvc;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Web.DynamicData;

namespace KendoTest.Services
{
    public class KhoaServices
    {
        ThucTapEntities ctx = new ThucTapEntities();

        //listkhoa
        public List<KhoaViewModel> LoadListKhoa(ParamKhoa param)
        {
            var listKhoa = ctx.SP_KHOA_GetAllKhoa(param.MaKhoa,param.TenKhoa,param.DienThoai).ToList();
            List<KhoaViewModel> result = new List<KhoaViewModel>();
            if (listKhoa != null && listKhoa.Count>0 )
            {
                result = listKhoa.Select(m => new KhoaViewModel {
                Makhoa = m.Makhoa.Trim(),
                Tenkhoa =m.Tenkhoa.Trim(),
                Dienthoai  = m.Dienthoai.Trim()
                }).ToList();
            }
            return result;

            //var listKhoa = ctx.TBLKhoas.ToList();
            //var result = listKhoa.Select(x => new KhoaViewModel
            //{
            //    Makhoa = x.Makhoa.Trim(),
            //    Tenkhoa = x.Tenkhoa.Trim(),
            //    Dienthoai = x.Dienthoai.Trim(),
            //}).ToList();

            //if (result != null && result.Count > 0)
            //{
            //    if (!string.IsNullOrEmpty(maKhoa) || !string.IsNullOrEmpty(tenKhoa) || !string.IsNullOrEmpty(soDienThoai))
            //    {
            //        result = result.Where(x => x.Makhoa.Contains(maKhoa) && x.Tenkhoa.Contains(tenKhoa) && x.Dienthoai.Contains(soDienThoai)).ToList();
            //    }
            //}           
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