using API_KhaiBaoYTe.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KhaiBaoYTe_DataLayer
{
    public class ThamSoDL
    {
        public IEnumerable<ThamSo> GetThamSoList()
        {
            using (DBContext dBContext = new DBContext())
            {
                return dBContext.GetThamSoList();
            }
        }

        public ThamSo GetThamSoByID(string id)
        {
            using (DBContext dBContext = new DBContext())
            {
                return dBContext.GetThamSoByID(id).FirstOrDefault();
            }
        }

        // POST: api/ThamSo
        // Thêm tham số 
        public bool PostThamSo(ThamSo thamso)
        {
            using (DBContext dBContext = new DBContext())
            {
                return dBContext.PostThamSo(thamso);
            }
        }

        // PUT: api/ThamSo/5 
        public bool PutThamSo(ThamSo thamso)
        {
            using (DBContext dBContext = new DBContext())
            {
                return dBContext.PutThamSo(thamso);
            }
        }

        // DELETE: api/ThamSo/5 
        public bool DeleteThamSo(string mathamso)
        {
            using (DBContext dBContext = new DBContext())
            {
                return dBContext.DeleteThamSo(mathamso);
            }
        }
    }
}
