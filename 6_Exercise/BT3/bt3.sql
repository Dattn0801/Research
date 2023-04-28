
use ThucTap;

--I
--1.Đưa ra thông tin gồm mã số, họ tênvà tên khoa của tất cả các giảng viên 

--select  Magv, Hotengv, k.Tenkhoa
--from TBLGiangVien as gv
--join  TBLKhoa as k on gv.Makhoa = k.Makhoa



--2.Đưa ra thông tin gồm mã số, họ tên và tên khoa của các giảng viên của khoa ‘DIA LY va QLTN

--select  Magv, Hotengv, k.Tenkhoa
--from TBLGiangVien as gv
--join  TBLKhoa as k on gv.Makhoa = k.Makhoa
--where k.Tenkhoa = 'DIA LY va QLTN'



--3.Cho biết số sinh viên của khoa ‘CONG NGHE SINH HOC’ 

--select  count(*) as SoSinhVienCongNgheSinhHoc
--from TBLSinhVien as sv
--join  TBLKhoa as k on sv.Makhoa = k.Makhoa
--where k.Tenkhoa = 'CONG NGHE SINH HOC'



--4.Đưa ra danh sách gồm mã số, họ tên và tuổi của các sinh viên khoa ‘TOAN’

--select  Masv,Hotensv ,YEAR(CURRENT_TIMESTAMP) - sv.Namsinh as tuoi
--from TBLSinhVien as sv
--join  TBLKhoa as k on sv.Makhoa = k.Makhoa
--where k.Tenkhoa = 'TOAN'



--5.Cho biết số giảng viên của khoa ‘CONG NGHE SINH HOC’ 

--select  count (*) as Sogv
--from TBLSinhVien as sv
--join  TBLKhoa as k on sv.Makhoa = k.Makhoa
--where k.Tenkhoa = 'CONG NGHE SINH HOC'



--6.Cho biết thông tin về sinh viên không tham gia thực tập 

--select sv.Masv,sv.Hotensv,sv.Namsinh,sv.Quequan,sv.Makhoa
--from TBLHuongDan as hd
--join TBLSinhVien as sv on sv.Masv = hd.Masv
--where hd.KetQua IS NULL

--select * from TBLHuongDan


--7.Đưa ra mã khoa, tên khoa và số giảng viên của mỗi khoa 
--select k.Makhoa,k.Tenkhoa, count(gv.Hotengv) as 'So giang vien'
--from TBLKhoa k
--left join TBLGiangVien  gv on k.Makhoa =  gv.Makhoa 
--group by k.Makhoa, k.Tenkhoa



--8.Cho biết số điện thoại của khoa mà sinh viên có tên ‘Le van son’ đang theo học 

--select k.Dienthoai
--from TBLKhoa k 
--join TBLSinhVien sv on  k.Makhoa = sv.Makhoa
--where sv.Hotensv = 'Le van son'


--II

--1.Cho biết mã số và tên của các đề tài do giảng viên ‘Tran son’ hướng dẫn 

--select  dt.Madt , dt.Tendt
--from TBLHuongDan hd
--join TBLGiangVien gv on gv.Magv = hd.Magv
--join TBLDeTai dt on dt.Madt = hd.Madt
--where  gv.Hotengv = 'Tran son'



--2.Cho biết tên đề tài không có sinh viên nào thực tập 

--select *
--from TBLDeTai 
--where Madt not in (select Madt   from TBLHuongDan)


--3.Cho biết mã số, họ tên, tên khoa của các giảng viên hướng dẫn từ 3 sinh viên trở lên(ko có kq mới đúng). 
--select hd.Magv, k.Tenkhoa , count (hd.Masv) as HuongDanSv
--from TBLHuongDan hd
--inner join TBLGiangVien gv on gv.Magv = hd.Magv
--join TBLKhoa k on k.Makhoa = gv.Makhoa
--group by hd.Magv, k.Tenkhoa
--having count(hd.Masv) >= 3
 

 
--4.Cho biết mã số, tên đề tài của đề tài có kinh phí cao nhất 

--select Madt, Tendt
--from TBLDeTai 
--where Kinhphi >= all (select Kinhphi from TBLDeTai)



--5.Cho biết mã số và tên các đề tài có nhiều hơn 2 sinh viên tham gia thực tập 

--select dt.Madt,dt.Tendt, count(hd.Masv) as sinhvienthuctapdetai
--from TBLDeTai  dt
--join TBLHuongDan  hd on dt.Madt = hd.Madt
--group by  dt.Madt,dt.Tendt
--having count (hd.Masv) > 2



--6. Đưa ra mã số, họ tên và điểm của các sinh viên khoa ‘DIALY và QLTN’ 

--select sv.Masv,sv.Hotensv, hd.KetQua
--from TBLSinhVien sv
--join TBLKhoa k on k.Makhoa = sv.Makhoa
--join TBLHuongDan hd on hd.Masv = sv.Masv
--where k.Tenkhoa = 'Dia ly va QLTN'


--7.Đưa ra tên khoa, số lượng sinh viên của mỗi khoa 

--select k.Tenkhoa, count (sv.Masv) as SoLuongSv
--from TBLKhoa k
--join TBLSinhVien sv on sv.Makhoa = k.Makhoa
--group by k.Tenkhoa


--8.Cho biết thông tin về các sinh viên thực tập tại quê nhà  (Nghe An)

--select sv.Masv,sv.Hotensv
--from TBLHuongDan tt
--join TBLDeTai dt on dt.Madt = tt.Madt
--join TBLSinhVien sv on sv.Masv = tt.Masv 
--where sv.Quequan = dt.Noithuctap



--9.Hãy cho biết thông tin về những sinh viên chưa có điểm thực tập 

--select sv.Hotensv,sv.Masv,sv.Namsinh,sv.Quequan,sv.Makhoa
--from TBLHuongDan tt
--join TBLSinhVien sv on sv.Masv = tt.Masv 
--where tt.KetQua is null

--10.Đưa ra danh sách gồm mã số, họ tên các sinh viên có điểm thực tập bằng 0

--select sv.Hotensv,sv.Masv,sv.Namsinh,sv.Quequan,sv.Makhoa, tt.KetQua
--from TBLHuongDan tt
--join TBLSinhVien sv on sv.Masv = tt.Masv 
--where tt.KetQua  = 0

