using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BT5
{
    internal class Program
    {

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            //using (var ctx = new ThucTapEntities())
            //{
            //    var sv = ctx.TBLSinhViens.ToList();
            //    foreach (var item in sv)
            //    {
            //        Console.WriteLine(item.Hotensv);
            //    }
            //}
            using (var ctx = new ThucTapEntities())
            {
                var sinhVien = from sv in ctx.TBLSinhViens
                               join hd in ctx.TBLHuongDans
                               on sv.Masv equals hd.Masv
                               where hd.KetQua == 0
                               select new { sv.Masv, sv.Hotensv };
                Console.WriteLine("1. Sinh vien co diem tt = 0");
                sinhVien.ToList().ForEach(s => Console.WriteLine("Ma sv{0}   Ho ten {1}", s.Masv, s.Hotensv));
            }
            using (var ctx = new ThucTapEntities())
            {
                var thucTap = from tt in ctx.TBLHuongDans
                              select tt;

                Console.WriteLine("2. Đếm số lượng sinh viên thực thập " + thucTap.Count());
            }

            using (var ctx = new ThucTapEntities())
            {
                var sinhVien = from sv in ctx.TBLSinhViens
                               select new { sv.Hotensv };
                Console.WriteLine("3. In ra màn hình danh sách HoTen sinh viên ");
                sinhVien.ToList().ForEach(sv => Console.WriteLine("hoten:   " + sv.Hotensv));

            }

        
            using (var ctx = new ThucTapEntities())
            {
                var sinhVien = new TBLSinhVien
                {
                    Masv = 105,
                    Hotensv = "Ngô Nhật Long",
                    Namsinh = 1993,
                    Makhoa = "Bio",
                    Quequan = "Vung Tau"
                };
                ctx.TBLSinhViens.Add(sinhVien);
                ctx.SaveChanges();
                Console.WriteLine("4.Đã thêm một sinh viên tên: Ngô Nhật Long/Bio/1993/Vung Tau ");
            }
            
            using (var ctx = new ThucTapEntities())
            {
                var sinhVien = ctx.TBLSinhViens.FirstOrDefault(sv => sv.Hotensv == "Tran Khac Trong");
                if (sinhVien!= null)
                {
                    sinhVien.Namsinh = 2018;
                    sinhVien.Quequan = "Ha Nam";
                    ctx.SaveChanges();
                    Console.WriteLine("5.Đã cập nhật sinh viên Tran Khac Trong năm sinh 2018, Quê quán Ha nam ");

                }
            }

            using (var ctx = new ThucTapEntities())
            {
                var detai = ctx.TBLDeTais.FirstOrDefault(dt => dt.Madt == "Dt03");
                if (detai != null)
                {
                    ctx.TBLDeTais.Remove(detai);
                    ctx.SaveChanges();
                    Console.WriteLine("6.Đã Xóa đề tài 'Dt03'");
                }
            }

            using ( var ctx = new ThucTapEntities())
            {
                var sinhVienTheoDeTai = from hd in ctx.TBLHuongDans
                                        group hd by hd.Madt into g
                                        select new { maDeTai = g.Key, CountSv = g.Count() };
                Console.WriteLine("7. Đếm số lượng sinh viên của mỗi đề tài ");
                foreach (var i in sinhVienTheoDeTai)
                {
                    Console.WriteLine("Đề tài: {0},  Số lượng sv tham gia: {1}",i.maDeTai,i.CountSv);
                }
            }
         
           
            Console.ReadKey();
        }
    }
}
