using API_KhaiBaoYTe.Entities;
using KhaiBaoYTe_DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KhaiBaoYTe_BusinessLayer
{
    public class ToKhaiBL
    {
        /// ------------GET TỜ KHAI  ------------------
        public IEnumerable<ToKhai> GetToKhaiList()
        {
            var toKhaiDL = new ToKhaiDL();
            var toKhaiList = toKhaiDL.GetToKhaiList();
            return toKhaiList;
        }
        /// ------------TÌM KIẾM TỜ KHAI  ------------------
        public IEnumerable<ToKhai> TimKiemToKhai(String keyword)
        {
            var toKhaiDL = new ToKhaiDL();
            var toKhaiList = toKhaiDL.TimKiemToKhai(keyword);
            return toKhaiList;
        }

        /// ------------THÊM TỜ KHAI  ------------------
        public bool PostToKhai(ToKhai tokhai)
        {
            var toKhaiDL = new ToKhaiDL();
            var toKhai = toKhaiDL.PostToKhai(tokhai);
            return toKhai;
        }

        /// ------------XOÁ TỜ KHAI  ------------------
        public bool DeleteToKhai(string matokhai)
        {
            var toKhaiDL = new ToKhaiDL();
            var toKhai = toKhaiDL.DeleteToKhai(matokhai);
            return toKhai;
        }
    }
}
