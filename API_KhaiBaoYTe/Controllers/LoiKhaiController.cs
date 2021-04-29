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
    [RoutePrefix("api/DanhMucLoiKhai")]
    public class LoiKhaiController : ApiController
    { 
        // Lấy toàn bộ danh sách Lời khai

        [HttpGet]
        [Route("")]
        public IEnumerable<LoiKhai> GetLoiKhaiList()
        {
            try
            {
                var loiKhaiBL = new LoiKhaiBL();
                var loiKhaiList = loiKhaiBL.GetLoiKhaiList();
                return loiKhaiList;
            }
            catch (Exception)
            {
                throw;
            }
        }
       
        [HttpPost]
        [Route("Add")]
        public bool PostLoiKhai([FromBody]LoiKhai loikhai)
        {
            try
            {
                var loiKhaiBL = new LoiKhaiBL();
                var loiKhai = loiKhaiBL.PostLoiKhai(loikhai);
                return loiKhai;
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// ------------XOÁ LỜI KHAI  ------------------
        [HttpDelete]
        [Route("Delete/{maloikhai}")]
        public bool DeleteLoiKhai(string maloikhai)
        {
            try
            {
                var loiKhaiBL = new LoiKhaiBL();
                var loiKhai = loiKhaiBL.DeleteLoiKhai(maloikhai);
                return loiKhai;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
