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
    [RoutePrefix("api/DanhMucCauHoi")]
    public class CauHoiController : ApiController
    {
        // Lấy toàn bộ danh sách Câu hỏi
       
        [HttpGet]
        [Route("")]
        public IEnumerable<CauHoi> GetCauHoiList()
        {
            try
            {
                var cauHoiBL = new CauHoiBL();
                var cauHoiList = cauHoiBL.GetCauHoiList();
                return cauHoiList;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //-------GET CÂU HỎI NHÓM A
        [HttpGet]
        [Route("CauHoiNhomA")]
        public IEnumerable<CauHoi> GetCauHoiNhomA()
        {
            try
            {
                var cauHoiBL = new CauHoiBL();
                var cauHoiList = cauHoiBL.GetCauHoiNhomA();
                return cauHoiList;
            }
            catch (Exception)
            {
                throw;
            }
        }
        //-------GET CÂU HỎI NHÓM B
        [HttpGet]
        [Route("CauHoiNhomB")]
        public IEnumerable<CauHoi> GetCauHoiNhomB()
        {
            try
            {
                var cauHoiBL = new CauHoiBL();
                var cauHoiList = cauHoiBL.GetCauHoiNhomB();
                return cauHoiList;
            }
            catch (Exception)
            {
                throw;
            }
        }
        //-------GET CÂU HỎI NHÓM C
        [HttpGet]
        [Route("CauHoiNhomC")]
        public IEnumerable<CauHoi> GetCauHoiNhomC()
        {
            try
            {
                var cauHoiBL = new CauHoiBL();
                var cauHoiList = cauHoiBL.GetCauHoiNhomC();
                return cauHoiList;
            }
            catch (Exception)
            {
                throw;
            }
        }
        //-------
        [HttpGet]
        [Route("TimKiem/{keyword}")]
        public IEnumerable<CauHoi> TimKiemCauHoi(String keyword)
        {
            try
            {
                var cauHoiBL = new CauHoiBL();
                var cauHoiList = cauHoiBL.TimKiemCauHoi(keyword);
                return cauHoiList;
            }
            catch (Exception)
            {
                throw;
            }
        }
        // GET: 
        [HttpGet]
        [Route("CauHoiID/{id}")]
        public CauHoi GetCauHoiByID(String id)
        {
            try
            {
                var cauHoiBL = new CauHoiBL();
                return cauHoiBL.GetCauHoiByID(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        [Route("Add")]
        public bool PostCauHoi([FromBody]CauHoi cauhoi)
        {
            try
            {
                var cauHoiBL = new CauHoiBL();
                var cauHoi = cauHoiBL.PostCauHoi(cauhoi);
                return cauHoi;
            }
            catch (Exception)
            {
                throw;
            }
        }

        // PUT: api/NguoiDung/5
        [HttpPut]
        [Route("Update")]
        public bool PutCauHoi([FromBody]CauHoi cauhoi)
        {
            try
            {
                var cauHoiBL = new CauHoiBL();
                var cauHoi = cauHoiBL.PutCauHoi(cauhoi);
                return cauHoi;
            }
            catch (Exception)
            {
                throw;
            }
        }

        // DELETE: api/NguoiDung/5
        [HttpDelete]
        [Route("Delete/{macauhoi}")]
        public bool DeleteCauHoi(string macauhoi)
        {
            try
            {
                var cauHoiBL = new CauHoiBL();
                var cauHoi = cauHoiBL.DeleteCauHoi(macauhoi);
                return cauHoi;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
