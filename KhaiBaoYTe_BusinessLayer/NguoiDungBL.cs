using API_KhaiBaoYTe.Entities;
using KhaiBaoYTe_DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KhaiBaoYTe_BusinessLayer
{
    public class NguoiDungBL
    {
        public IEnumerable<NguoiDung> GetNguoiDungList()
        {
            var nguoiDungDL = new NguoiDungDL();
            var nguoiDung = nguoiDungDL.GetNguoiDungList();
            return nguoiDung;
        }
        // -------------GE NGƯỜI DÙNG THEO TIKHOAN-----------
        public NguoiDung GetNguoiDungByTaiKhoan(string taikhoan)
        {
            var nguoiDungDL = new NguoiDungDL();
            var nguoiDung = nguoiDungDL.GetNguoiDungByTaiKhoan(taikhoan);
            return nguoiDung;
        }

        /// ------------KIỂM TRA NGƯỜI DÙNG------------------
        // GET: api/NguoiDung/5 
        public bool KiemTraNguoiDung(String taikhoan, string matkhau)
        {
            var nguoiDungDL = new NguoiDungDL();
            var nguoiDung = nguoiDungDL.KiemTraNguoiDung(taikhoan, matkhau);
            return nguoiDung;
        }
        public IEnumerable<NguoiDung> TimKiemNguoiDung(string keyword)
        {
            var nguoiDungDL = new NguoiDungDL();
            var nguoiDung = nguoiDungDL.TimKiemNguoiDung(keyword);
            return nguoiDung;
        }
        /// ------------THÊM NGƯỜI DÙNG------------------
        // POST: api/NguoiDung 
        public bool PostNguoiDung(NguoiDung nguoidung)
        {
            var nguoiDungDL = new NguoiDungDL();
            var nguoiDung = nguoiDungDL.PostNguoiDung(nguoidung);
            return nguoiDung;
        }

        /// ------------CẬP NHẬT NGƯỜI DÙNG------------------
        // PUT: api/NguoiDung/5 
        public bool PutNguoiDung(NguoiDung taikhoan)
        {
            var nguoiDungDL = new NguoiDungDL();
            var nguoiDung = nguoiDungDL.PutNguoiDung(taikhoan);
            return nguoiDung;
        }

        /// ------------XOÁ NGƯỜI DÙNG------------------
        // DELETE: api/NguoiDung/5 
        public bool DeleteNguoiDung(string taikhoan)
        {
            var nguoiDungDL = new NguoiDungDL();
            var nguoiDung = nguoiDungDL.DeleteNguoiDung(taikhoan);
            return nguoiDung;
        }
    }
}
