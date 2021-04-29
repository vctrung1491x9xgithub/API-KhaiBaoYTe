
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.SqlClient; 
using KhaiBaoYTe_BusinessLayer;
using API_KhaiBaoYTe.Entities;

namespace API_KhaiBaoYTe.Controllers
{
   [RoutePrefix("api/NguoiKhaiBao")]
    public class NguoiKhaiBaoController : ApiController
    {
        // GET: api/NguoiKhaiBao
        [HttpGet]
        [Route("")]
        public IEnumerable<NguoiKhaiBao> GetNguoiKhaiBaoList()
        {
           try
            {
                var nguoiKhaiBaoBL = new NguoiKhaiBaoBL();
                return nguoiKhaiBaoBL.GetNguoiKhaiBaoList();
            } catch(Exception)
            {
                throw;
            }
        }

        // GET: api/NguoiKhaiBao/5
        [HttpGet]
        [Route("TimKiem/{keyword}")]
        public IEnumerable<NguoiKhaiBao> TimKiemNguoiKhaiBao(String keyword)
        {
            try
            {
                var nguoiKhaiBaoBL = new NguoiKhaiBaoBL();
                return nguoiKhaiBaoBL.TimKiemNguoiKhaiBao(keyword);
            }
            catch (Exception)
            {
                throw;
            }
        }
        /*
         *
         */
        // GET: api/NguoiKhaiBao/5
        [HttpGet] 
        [Route("GetNguoiKhaiBao/{id}")]
        public NguoiKhaiBao GetNguoiKhaiBaoByID(String id)
        {
            try
            {
                var nguoiKhaiBaoBL = new NguoiKhaiBaoBL();
                return nguoiKhaiBaoBL.GetNguoiKhaiBaoByID(id);
            }
            catch (Exception)
            {
                throw;
            }
        }


        // POST: api/NguoiKhaiBao
        [HttpPost]
        [Route("Add")]
        public bool PostThemNguoiKhai([FromBody]NguoiKhaiBao nguoikhaibao)
        {
            try
            {
                var nguoiKhaiBaoBL = new NguoiKhaiBaoBL();
                return nguoiKhaiBaoBL.InsertNguoiKhaiBao(nguoikhaibao);
            }
            catch (Exception)
            {
                throw;
            }
        }

        // PUT: api/NguoiKhaiBao/5
        // Cập Nhật Người Khai Báo
        [HttpPut]
        [Route("Update")]
        public bool PutCapNhatNguoiKhai([FromBody]NguoiKhaiBao nguoikhaibao)
        {
            try
            {
                var nguoiKhaiBaoBL = new NguoiKhaiBaoBL();
                return nguoiKhaiBaoBL.PutCapNhatNguoiKhai(nguoikhaibao);
            }
            catch (Exception)
            {
                throw;
            }
        }

        // DELETE: api/NguoiKhaiBao/5
        [HttpDelete]
        [Route("Delete/{manguoikhai}")]
        public bool DeleteNguoiKhai(string manguoikhai)
        {
            try
            {
                var nguoiKhaiBaoBL = new NguoiKhaiBaoBL();
                return nguoiKhaiBaoBL.DeleteNguoiKhaiBao(manguoikhai);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
