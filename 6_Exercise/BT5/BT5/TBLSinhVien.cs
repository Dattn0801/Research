//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BT5
{
    using System;
    using System.Collections.Generic;
    
    public partial class TBLSinhVien
    {
        public int Masv { get; set; }
        public string Hotensv { get; set; }
        public string Makhoa { get; set; }
        public Nullable<int> Namsinh { get; set; }
        public string Quequan { get; set; }
    
        public virtual TBLKhoa TBLKhoa { get; set; }
    }
}
