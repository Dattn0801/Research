using KendoTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KendoTest.ViewModel
{
    public class DetaiViewModel
    {
        public string Madt { get; set; }
        public string Tendt { get; set; }
        public Nullable<int> Kinhphi { get; set; }
        public string Noithuctap { get; set; }
        public virtual ICollection<TBLHuongDan> TBLHuongDans { get; set; }
    }
}