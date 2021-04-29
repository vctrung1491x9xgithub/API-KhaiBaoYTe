using API_KhaiBaoYTe.Entities;
using KhaiBaoYTe_BusinessLayer;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API_KhaiBaoYTe.Controllers
{
    [RoutePrefix("api/DanhMucThamSo")]
    public class ThamSoController : ApiController
    {
        // GET: api/ThamSo
        [HttpGet]
        [Route("")]
        public IEnumerable<ThamSo> GetThamSoList()
        {
            try
            {
                var thamSoBL = new ThamSoBL();
                var thamSo = thamSoBL.GetThamSoList();
                return thamSo;
            }
            catch (Exception)
            {
                throw;
            }
        }
        // GET Tham số ID
        [Route("ThamSo/{id}")]
        public ThamSo GetThamSoByID(string id)
        {
            try
            {
                var thamSoBL = new ThamSoBL();
                var thamSo = thamSoBL.GetThamSoByID(id);
                return thamSo;
            }
            catch (Exception)
            {
                throw;
            }
        }

        
        // Thêm tham số
        [HttpPost]
        [Route("Add")]
        public bool PostThamSo([FromBody]ThamSo thamso)
        { 
            try
            {
                var thamSoBL = new ThamSoBL();
                var thamSo = thamSoBL.PostThamSo(thamso);
                return thamSo;
            }
            catch (Exception)
            {
                throw;
            }
        }

        // PUT: api/ThamSo/5
        [HttpPut]
        [Route("Update")]
        public bool PutThamSo([FromBody]ThamSo thamso)
        {
            try
            {
                var thamSoBL = new ThamSoBL();
                var thamSo = thamSoBL.PutThamSo(thamso);
                return thamSo;
            }
            catch (Exception)
            {
                throw;
            }
        }

        // DELETE: api/ThamSo/5
        [HttpDelete]
        [Route("Delete/{mathamso}")]
        public bool DeleteThamSo(string mathamso)
        {
            try
            {
                var thamSoBL = new ThamSoBL();
                var thamSo = thamSoBL.DeleteThamSo(mathamso);
                return thamSo;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
