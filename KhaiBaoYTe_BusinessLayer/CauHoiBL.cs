using API_KhaiBaoYTe.Entities;
using KhaiBaoYTe_DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KhaiBaoYTe_BusinessLayer
{
    public class CauHoiBL
    {
        /// ------------GET CÂU HỎI------------------
        public IEnumerable<CauHoi> GetCauHoiList()
        {
            var cauHoiDL = new CauHoiDL();
            var cauHoiList = cauHoiDL.GetCauHoiList();
            return cauHoiList;
        }
        ///-------------GET CÂU HỎI NHÓM A---------------------
        public IEnumerable<CauHoi> GetCauHoiNhomA()
        {
            var cauHoiDL = new CauHoiDL();
            var cauHoiList = cauHoiDL.GetCauHoiNhomA();
            return cauHoiList;
        }
        ///-------------GET CÂU HỎI NHÓM B---------------------
        public IEnumerable<CauHoi> GetCauHoiNhomB()
        {
            var cauHoiDL = new CauHoiDL();
            var cauHoiList = cauHoiDL.GetCauHoiNhomB();
            return cauHoiList;
        }
        ///-------------GET CÂU HỎI NHÓM B---------------------
        public IEnumerable<CauHoi> GetCauHoiNhomC()
        {
            var cauHoiDL = new CauHoiDL();
            var cauHoiList = cauHoiDL.GetCauHoiNhomC();
            return cauHoiList;
        }
        /// ------------TÌM KIẾM CÂU HỎI BY KEYWORD------------
        public IEnumerable<CauHoi> TimKiemCauHoi(String keyword)
        {
            var cauHoiDL = new CauHoiDL();
            var cauHoiList = cauHoiDL.TimKiemCauHoi(keyword);
            return cauHoiList;
        }
        /// ------------TÌM KIẾM CÂU HỎI BY ID------------------
        public CauHoi GetCauHoiByID(String id)
        {
            using (DBContext dBContext = new DBContext())
            {
                var cauHoiDL = new CauHoiDL();
                var cauHoi = cauHoiDL.GetCauHoiByID(id);
                return cauHoi;
            }
        }
        /// ------------THÊM CÂU HỎI  ------------------
        public bool PostCauHoi(CauHoi cauhoi)
        {
            var cauHoiDL = new CauHoiDL();
            var cauHoi = cauHoiDL.PostCauHoi(cauhoi);
            return cauHoi;
        }

        /// ------------CẬP NHẬT CÂU HỎI------------------
        /// 
        public bool PutCauHoi(CauHoi cauhoi)
        {
            var cauHoiDL = new CauHoiDL();
            var cauHoi = cauHoiDL.PutCauHoi(cauhoi);
            return cauHoi;
        }

        /// ------------XOÁ CÂU HỎI  ------------------
        /// 
        public bool DeleteCauHoi(string macauhoi)
        {
            var cauHoiDL = new CauHoiDL();
            var cauHoi = cauHoiDL.DeleteCauHoi(macauhoi);
            return cauHoi;
        }
    }
}
