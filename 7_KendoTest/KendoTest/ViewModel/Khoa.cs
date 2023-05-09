using KendoTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KendoTest.ViewModel
{
    public class KhoaViewModel
    {
        public string Makhoa { get; set; }
        public string Tenkhoa { get; set; }
        public string Dienthoai { get; set; }
        public virtual ICollection<TBLGiangVien> TBLGiangViens { get; set; }
        public virtual ICollection<TBLSinhVien> TBLSinhViens { get; set; }
    }
}