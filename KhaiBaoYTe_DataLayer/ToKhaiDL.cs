using API_KhaiBaoYTe.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KhaiBaoYTe_DataLayer
{
    public class ToKhaiDL
    {
        /// ------------GET TỜ KHAI  ------------------
        public IEnumerable<ToKhai> GetToKhaiList()
        {
            using (DBContext dBContext = new DBContext())
            {
                return dBContext.GetToKhaiList();
            }
        }
        /// ------------TÌM KIẾM TỜ KHAI  ------------------
        public IEnumerable<ToKhai> TimKiemToKhai(String keyword)
        {
            using (DBContext dBContext = new DBContext())
            {
                return dBContext.TimKiemToKhai(keyword);
            }
        }

        /// ------------THÊM TỜ KHAI  ------------------
        public bool PostToKhai(ToKhai tokhai)
        {
            using (DBContext dBContext = new DBContext())
            {
                return dBContext.PostToKhai(tokhai);
            }
        }

        /// ------------XOÁ TỜ KHAI  ------------------
        public bool DeleteToKhai(string matokhai)
        {
            using (DBContext dBContext = new DBContext())
            {
                return dBContext.DeleteToKhai(matokhai);
            }
        }
    }
}
