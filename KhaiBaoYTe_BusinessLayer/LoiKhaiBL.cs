using API_KhaiBaoYTe.Entities;
using KhaiBaoYTe_DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KhaiBaoYTe_BusinessLayer
{
    public class LoiKhaiBL
    {
        public IEnumerable<LoiKhai> GetLoiKhaiList()
        {
            var loiKhaiDL = new LoiKhaiDL();
            var loiKhaiList = loiKhaiDL.GetLoiKhaiList();
            return loiKhaiList;
        }

        /// ------------THÊM TỜ KHAI  ------------------
        public bool PostLoiKhai(LoiKhai loikhai)
        {
            var loiKhaiDL = new LoiKhaiDL();
            var loiKhai = loiKhaiDL.PostLoiKhai(loikhai);
            return loiKhai;
        }
        /// ------------THÊM TỜ KHAI  ------------------
        public bool DeleteLoiKhai(string maloikhai)
        {
            var loiKhaiDL = new LoiKhaiDL();
            var loiKhai = loiKhaiDL.DeleteLoiKhai(maloikhai);
            return loiKhai;
        }
    }
}
