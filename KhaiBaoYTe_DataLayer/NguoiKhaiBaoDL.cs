using API_KhaiBaoYTe.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 
namespace KhaiBaoYTe_DataLayer
{
    public class NguoiKhaiBaoDL
    {
        public IEnumerable<NguoiKhaiBao> GetNguoiKhaiBaoList()
        { 
            using (DBContext dBContext = new DBContext())
            {
                return dBContext.GetNguoiKhaiBaoList();
            }
        }

        //------
        public IEnumerable<NguoiKhaiBao> TimKiemNguoiKhaiBao(String keyword)
        {
            using (DBContext dBContext = new DBContext())
            {
                return dBContext.TimKiemNguoiKhaiBao(keyword);
            }
        }

        //----
        public NguoiKhaiBao GetNguoiKhaiBaoByID(String id)
        {
            using (DBContext dBContext = new DBContext())
            {
                return dBContext.GetNguoiKhaiBaoByID(id).FirstOrDefault();
            }
        }

        //----
        public bool PostThemNguoiKhai(NguoiKhaiBao nguoikhaibao)
        {
            using (DBContext dBContext = new DBContext())
            {
                return dBContext.PostThemNguoiKhai(nguoikhaibao);
            }
        }

        //----
        public bool PutCapNhatNguoiKhai(NguoiKhaiBao nguoikhaibao)
        {
            using (DBContext dBContext = new DBContext())
            {
                return dBContext.PutCapNhatNguoiKhai(nguoikhaibao);
            }
        }

        //---
        public bool DeleteNguoiKhai(string manguoikhai)
        {
            using (DBContext dBContext = new DBContext())
            {
                return dBContext.DeleteNguoiKhai(manguoikhai);
            }
        }
    }
}
