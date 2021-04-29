using API_KhaiBaoYTe.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KhaiBaoYTe_DataLayer
{
    public class NguoiDungDL
    {
        public IEnumerable<NguoiDung> GetNguoiDungList()
        {
            using (DBContext dBContext = new DBContext())
            {
                return dBContext.GetNguoiDungList();
            }
        }
        // Get người dùng by taikhoan
        public NguoiDung GetNguoiDungByTaiKhoan(string taikhoan)
        {
            using (DBContext dBContext = new DBContext())
            {
                return dBContext.GetNguoiDungByTaiKhoan(taikhoan).FirstOrDefault();
            }
        }
        /// ------------KIỂM TRA NGƯỜI DÙNG------------------
        // GET: api/NguoiDung/5 
        public bool KiemTraNguoiDung(String taikhoan, string matkhau)
        {
            using (DBContext dBContext = new DBContext())
            {
                return dBContext.KiemTraNguoiDung(taikhoan, matkhau);
            }
        }
        /// ------------TÌM KIẾM NGƯỜI DÙNG------------------
        public IEnumerable<NguoiDung> TimKiemNguoiDung(string keyword)
        {
            using (DBContext dBContext = new DBContext())
            {
                return dBContext.TimKiemNguoiDung(keyword);
            }
        }
        /// ------------THÊM NGƯỜI DÙNG------------------
        // POST: api/NguoiDung 
        public bool PostNguoiDung(NguoiDung nguoidung)
        {
            using (DBContext dBContext = new DBContext())
            {
                return dBContext.PostNguoiDung(nguoidung);
            }
        }

        /// ------------CẬP NHẬT NGƯỜI DÙNG------------------
        // PUT: api/NguoiDung/5 
        public bool PutNguoiDung(NguoiDung taikhoan)
        {
            using (DBContext dBContext = new DBContext())
            {
                return dBContext.PutNguoiDung(taikhoan);
            }
        }

        /// ------------XOÁ NGƯỜI DÙNG------------------
        // DELETE: api/NguoiDung/5 
        public bool DeleteNguoiDung(string taikhoan)
        {
            using (DBContext dBContext = new DBContext())
            {
                return dBContext.DeleteNguoiDung(taikhoan);
            }
        }
    }
}
