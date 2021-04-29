using API_KhaiBaoYTe.Entities;
using KhaiBaoYTe_DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KhaiBaoYTe_BusinessLayer
{
    public class ThamSoBL
    {
        public IEnumerable<ThamSo> GetThamSoList()
        {
            var thamSoDL = new ThamSoDL();
            var thamSo = thamSoDL.GetThamSoList();
            return thamSo;
        }
        // Get tham số by id
        public ThamSo GetThamSoByID(string id)
        {
            var thamSoDL = new ThamSoDL();
            var thamSo = thamSoDL.GetThamSoByID(id);
            return thamSo;
        }

        // POST: api/ThamSo
        // Thêm tham số 
        public bool PostThamSo(ThamSo thamso)
        {
            var thamSoDL = new ThamSoDL();
            var thamSo = thamSoDL.PostThamSo(thamso);
            return thamSo;
        }

        // PUT: api/ThamSo/5 
        public bool PutThamSo(ThamSo thamso)
        { 
            var thamSoDL = new ThamSoDL();
            var thamSo = thamSoDL.PutThamSo(thamso);
            return thamSo;
        }

        // DELETE: api/ThamSo/5 
        public bool DeleteThamSo(string mathamso)
        { 
            var thamSoDL = new ThamSoDL();
            var thamSo = thamSoDL.DeleteThamSo(mathamso);
            return thamSo;
        }
    }
}
