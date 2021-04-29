
using API_KhaiBaoYTe.Entities; 
using KhaiBaoYTe_DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 
namespace KhaiBaoYTe_BusinessLayer
{
    public class NguoiKhaiBaoBL
    {
        public IEnumerable<NguoiKhaiBao> GetNguoiKhaiBaoList()
        {

            var nguoiKhaiBaoDL = new NguoiKhaiBaoDL();
            var nguoiKhaiBao = nguoiKhaiBaoDL.GetNguoiKhaiBaoList();
            return nguoiKhaiBao;
        }

        public IEnumerable<NguoiKhaiBao> TimKiemNguoiKhaiBao(String keyword)
        {
            var nguoiKhaiBaoDL = new NguoiKhaiBaoDL();
            var nguoiKhaiBao = nguoiKhaiBaoDL.TimKiemNguoiKhaiBao(keyword);
            return nguoiKhaiBao;
        }

        public NguoiKhaiBao GetNguoiKhaiBaoByID(String manguoikhai)
        {
            var nguoiKhaiBaoDL = new NguoiKhaiBaoDL();
            var nguoiKhaiBao = nguoiKhaiBaoDL.GetNguoiKhaiBaoByID(manguoikhai);
            return nguoiKhaiBao;
        }

        public bool InsertNguoiKhaiBao(NguoiKhaiBao nguoikhaibao)
        {
            var nguoiKhaiBaoDL = new NguoiKhaiBaoDL(); 
            return nguoiKhaiBaoDL.PostThemNguoiKhai(nguoikhaibao);
        }

        public bool PutCapNhatNguoiKhai(NguoiKhaiBao nguoikhaibao)
        {
            var nguoiKhaiBaoDL = new NguoiKhaiBaoDL();
            return nguoiKhaiBaoDL.PutCapNhatNguoiKhai(nguoikhaibao);
        }

        public bool DeleteNguoiKhaiBao(string manguoikhai)
        {
            var nguoiKhaiBaoDL = new NguoiKhaiBaoDL();
            return nguoiKhaiBaoDL.DeleteNguoiKhai(manguoikhai);
        }
    }
}
