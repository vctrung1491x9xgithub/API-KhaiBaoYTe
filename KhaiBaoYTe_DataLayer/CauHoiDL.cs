using API_KhaiBaoYTe.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KhaiBaoYTe_DataLayer
{
    public class CauHoiDL
    {
        /// ------------GET CÂU HỎI------------------
        public IEnumerable<CauHoi> GetCauHoiList()
        {
            using (DBContext dBContext = new DBContext())
            {
                return dBContext.GetCauHoiList();
            }
        }
        /// ------------GET CÂU HỎI NHÓM A------------------
        public IEnumerable<CauHoi> GetCauHoiNhomA()
        {
            using (DBContext dBContext = new DBContext())
            {
                return dBContext.GetCauHoiNhomA();
            }
        }
        /// ------------GET CÂU HỎI NHÓM B------------------
        public IEnumerable<CauHoi> GetCauHoiNhomB()
        {
            using (DBContext dBContext = new DBContext())
            {
                return dBContext.GetCauHoiNhomB();
            }
        }
        /// ------------GET CÂU HỎI NHÓM C------------------
        public IEnumerable<CauHoi> GetCauHoiNhomC()
        {
            using (DBContext dBContext = new DBContext())
            {
                return dBContext.GetCauHoiNhomC();
            }
        }
        /// ------------TÌM KIẾM CÂU HỎI BY KEYWORD------------------
        public IEnumerable<CauHoi> TimKiemCauHoi(String keyword)
        {
            using (DBContext dBContext = new DBContext())
            {
                return dBContext.TimKiemCauHoi(keyword);
            }
        }
        /// ------------TÌM KIẾM CÂU HỎI BY ID------------------
        public CauHoi GetCauHoiByID(String id)
        {
            using (DBContext dBContext = new DBContext())
            {
                return dBContext.GetCauHoiByID(id).FirstOrDefault();
            }
        }
        /// ------------THÊM CÂU HỎI  ------------------
        public bool PostCauHoi(CauHoi cauhoi)
        {
            using (DBContext dBContext = new DBContext())
            {
                return dBContext.PostCauHoi(cauhoi);
            }
        }

        /// ------------CẬP NHẬT CÂU HỎI------------------
        /// 
        public bool PutCauHoi(CauHoi cauhoi)
        {
            using (DBContext dBContext = new DBContext())
            {
                return dBContext.PutCauHoi(cauhoi);
            }
        }

        /// ------------XOÁ CÂU HỎI  ------------------
        /// 
        public bool DeleteCauHoi(string macauhoi)
        {
            using (DBContext dBContext = new DBContext())
            {
                return dBContext.DeleteCauHoi(macauhoi);
            }
        }
    }
}
