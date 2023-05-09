using KendoTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KendoTest.ViewModel
{
    public class GiangVienViewModel
    {
        public int Magv { get; set; }
        public string Hotengv { get; set; }
        public Nullable<decimal> Luong { get; set; }
        public string Makhoa { get; set; }

        public virtual TBLKhoa TBLKhoa { get; set; }
        public virtual ICollection<TBLHuongDan> TBLHuongDans { get; set; }
    }
}