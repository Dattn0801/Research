using KendoTest.Models;
using KendoTest.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KendoTest.Services
{
    public class HuongDanServices
    {
        ThucTapEntities ctx = new ThucTapEntities();

        public List<HuongDanViewModel> loadList()
        {
            var lst = ctx.TBLHuongDans.ToList();
            List<HuongDanViewModel> k = new List<HuongDanViewModel>();
            if (lst != null && lst.Any())
            {
                foreach (var item in lst)
                {
                  
                    var sinhVien = ctx.TBLSinhViens.Where(x => x.Masv == item.Masv).FirstOrDefault();
                    var deTai = ctx.TBLDeTais.Where(x=>x.Madt == item.Madt).FirstOrDefault();
                    var giangVien = ctx.TBLGiangViens.Where(x => x.Magv == item.Magv).FirstOrDefault();
                    k.Add(new HuongDanViewModel()
                    {
                        Id = item.Id,
                        Tensv = sinhVien.Hotensv,
                        Tendt = deTai.Tendt,
                        Tengv = giangVien.Hotengv,
                        Masv = item.Masv,
                        Madt = item.Madt,
                        Magv = item.Magv,
                        KetQua = item.KetQua,
                    });
                }
            }
            return k;
        }

        public void createHD(TBLHuongDan model)
        {
            if (model != null)
            {
                ctx.TBLHuongDans.Add(model);
            }
            ctx.SaveChanges();
        }
        public TBLHuongDan editHD(TBLHuongDan model)
        {
            var e = ctx.TBLHuongDans.Where(x => x.Masv == model.Masv).FirstOrDefault();
            e.Madt = model.Madt.Trim();
            e.Magv = model.Magv;
            e.KetQua = model.KetQua;     
            ctx.SaveChanges();
            return model;
        }

        public void deleteHD(int? maHD)
        {
            var entity = ctx.TBLHuongDans.Where(x => x.Id == maHD).FirstOrDefault();
            ctx.TBLHuongDans.Remove(entity);
            ctx.SaveChanges();
        }

        public TBLHuongDan getHD(int? maHD)
        {
            var khoa = ctx.TBLHuongDans.Where(x => x.Id == maHD).FirstOrDefault();
            return khoa;
        }

        //list sinh vien
        public List<TBLSinhVien> ListSinhVien()
        {
            return ctx.TBLSinhViens.ToList();
        }

        //list giang vien
        public List<TBLGiangVien> ListGiangVien()
        {
            return ctx.TBLGiangViens.ToList();  
        }

        //list detai
        public List<TBLDeTai> ListDeTai()
        {
            return ctx.TBLDeTais.ToList();
        }
    }
}