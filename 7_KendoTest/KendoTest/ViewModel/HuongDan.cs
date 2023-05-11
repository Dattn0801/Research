using KendoTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KendoTest.ViewModel
{
    public class HuongDanViewModel
    {
        public int? Masv { get; set; }
        public int Id { get; set; }
        public string Tensv { get; set; }
        public string Tendt { get; set; }
        public string Tengv { get; set; }
        public string Madt { get; set; }
        public Nullable<int> Magv { get; set; }
        public Nullable<decimal> KetQua { get; set; }

        public virtual TBLDeTai TBLDeTai { get; set; }
        public virtual TBLGiangVien TBLGiangVien { get; set; }
    }
}