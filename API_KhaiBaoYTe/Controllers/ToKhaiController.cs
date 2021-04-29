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
    [RoutePrefix("api/DanhMucToKhai")]
    public class ToKhaiController : ApiController
    {
        // Lấy toàn bộ danh sách Tờ khai

        [HttpGet]
        [Route("")]
        public IEnumerable<ToKhai> GetToKhaiList()
        {
            try
            {
                var toKhaiBL = new ToKhaiBL();
                var loiKhaiList = toKhaiBL.GetToKhaiList();
                return loiKhaiList;
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet]
        [Route("TimKiem/{keyword}")]
        public IEnumerable<ToKhai> TimKiemToKhai(String keyword)
        {
            try
            {
                var toKhaiBL = new ToKhaiBL();
                var loiKhaiList = toKhaiBL.TimKiemToKhai(keyword);
                return loiKhaiList;
            }
            catch (Exception)
            {
                throw;
            }
        } 

        [HttpPost]
        [Route("Add")]
        public bool PostToKhai([FromBody]ToKhai tokhai)
        {
            try
            {
                var toKhaiBL = new ToKhaiBL();
                var loiKhai = toKhaiBL.PostToKhai(tokhai);
                return loiKhai;
            }
            catch (Exception)
            {
                throw;
            }
        }

        
        [HttpDelete]
        [Route("Delete/{matokhai}")]
        public bool DeleteToKhai(string matokhai)
        {
            try
            {
                var toKhaiBL = new ToKhaiBL();
                var loiKhai = toKhaiBL.DeleteToKhai(matokhai);
                return loiKhai;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}