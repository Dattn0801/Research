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

        public List<HuongDanViewModel> loadList(ParamHuongDan param)
        {
            var listDT = ctx.SP_HD_GetAllHuongDanDeTai(param.TenSV,param.MaGV,param.MaDT,param.KetQua).ToList();
            List<HuongDanViewModel> result = new List<HuongDanViewModel>();
            if (listDT != null && listDT.Count > 0)
            {
                result = listDT.Select(m => new HuongDanViewModel
                {
                    Id = m.Id,
                    Tensv = m.Hotensv,
                    Tengv = m.Hotengv,
                    Tendt = m.Tendt,
                    KetQua = m.KetQua
               
                }).ToList();
            }
            return result;
        }

        public void createHD(AddUpdateGVHuongDan model)
        {
            //var listSV = model.MaSV.ToList();
            //foreach(var item in listSV)
            //{
            //    ctx.SP_HD_AddEditHuongDanDeTai(null, item, model.MaGV, model.MaDT, model.KetQua);
            //}
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

        public List<SP_SV_GetAllSinhVien_Result> ListSV()
        {
            return ctx.SP_SV_GetAllSinhVien(null, null, null, null, null, null).ToList();
        }
    }
}