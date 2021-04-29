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
    [RoutePrefix("api/DanhMucDonVi")]
    public class DonViController : ApiController
    {
        // GET: api/DonVi
        [HttpGet]
        [Route("")]
        public IEnumerable<DonVi> GetDonViList()
        {
            try
            {
                var donViBL = new DonViBL();
                var donViList = donViBL.GetDonViList();
                return donViList;
            }
            catch (Exception)
            {
                throw;
            }
        }

        // GET: api/DanhMucDonVi
        [Route("DonVi/{id}")]
        public DonVi GetDonViByID(string id)
        {
            try
            {
                var donViBL = new DonViBL();
                var donVi = donViBL.GetDonViByID(id);
                return donVi;
            }
            catch (Exception)
            {
                throw;
            }
        }

        // POST: api/DonVi
        [HttpPost]
        [Route("Add")]
        public bool PostDonVi([FromBody]DonVi donvi)
        {
            try
            {
                var donViBL = new DonViBL();
                var donVi = donViBL.PostDonVi(donvi);
                return donVi;
            }
            catch (Exception)
            {
                throw;
            }
        }

        // PUT: api/DonVi/5
        [HttpPut]
        [Route("Update")]
        public bool PutDonVi([FromBody]DonVi donvi)
        {
            try
            {
                var donViBL = new DonViBL();
                var donVi = donViBL.PutDonVi(donvi);
                return donVi;
            }
            catch (Exception)
            {
                throw;
            }
        }

        // DELETE: api/DonVi/5
        [HttpDelete]
        [Route("Delete/{madonvi}")]
        public bool DeleteDonVi(string madonvi)
        {
            try
            {
                var donViBL = new DonViBL();
                var donVi = donViBL.DeleteDonVi(madonvi);
                return donVi;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
