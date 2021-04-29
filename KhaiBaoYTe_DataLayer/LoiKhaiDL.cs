using API_KhaiBaoYTe.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KhaiBaoYTe_DataLayer
{
    public class LoiKhaiDL
    {
        public IEnumerable<LoiKhai> GetLoiKhaiList()
        {
            using (DBContext dBContext = new DBContext())
            {
                return dBContext.GetLoiKhaiList();
            }
        }

        /// ------------THÊM TỜ KHAI  ------------------
        public bool PostLoiKhai(LoiKhai loikhai)
        {
            using (DBContext dBContext = new DBContext())
            {
                return dBContext.PostLoiKhai(loikhai);
            }
        }
        /// ------------THÊM TỜ KHAI  ------------------
        public bool DeleteLoiKhai(string maloikhai)
        {
            using (DBContext dBContext = new DBContext())
            {
                return dBContext.DeleteLoiKhai(maloikhai);
            }
        }
    }
}
