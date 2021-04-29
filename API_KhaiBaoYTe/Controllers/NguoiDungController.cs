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
    [RoutePrefix("api/DanhMucNguoiDung")]
    public class NguoiDungController : ApiController
    {
        // Lấy toàn bộ danh sách người dùng
        // GET: api/NguoiDung
        [HttpGet]
        [Route("")]
        public IEnumerable<NguoiDung> GetNguoiDungList()
        {
            try
            {
                var nguoiDungBL = new NguoiDungBL();
                var nguoiDungList = nguoiDungBL.GetNguoiDungList();
                return nguoiDungList;
            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpGet]
        [Route("NguoiDung/{taikhoan}")]
        // Get nguoi dùng by Taikhoan
        public NguoiDung GetNguoiDungByTaiKhoan(string taikhoan)
        {
            try
            {
                var nguoiDungBL = new NguoiDungBL();
                var nguoiDung = nguoiDungBL.GetNguoiDungByTaiKhoan(taikhoan);
                return nguoiDung;
            }
            catch (Exception)
            {
                throw;
            }
        }
        // GET: api/NguoiDung/5
        [HttpGet]
        [Route("KiemTra/{taikhoan}/{matkhau}")]
        public bool KiemTraNguoiDung(String taikhoan, string matkhau)
        {
            try
            {
                var nguoiDungBL = new NguoiDungBL();
                var nguoiDungCheck = nguoiDungBL.KiemTraNguoiDung(taikhoan, matkhau);
                return nguoiDungCheck;
            }
            catch (Exception)
            {
                throw;
            }
        }

        // GET: api/NguoiDung/5
        [HttpGet]
        [Route("TimKiem/{keyword}")]
        public IEnumerable<NguoiDung> TimKiemNguoiDung(string keyword)
        {
            try
            {
                var nguoiDungBL = new NguoiDungBL();
                var nguoiDung = nguoiDungBL.TimKiemNguoiDung(keyword);
                return nguoiDung;
            }
            catch (Exception)
            {
                throw;
            }
        }

        // POST: api/NguoiDung
        [HttpPost]
        [Route("Add")]
        public bool PostNguoiDung([FromBody]NguoiDung nguoidung)
        { 
            try
            {
                var nguoiDungBL = new NguoiDungBL();
                var nguoiDung = nguoiDungBL.PostNguoiDung(nguoidung);
                return nguoiDung;
            }
            catch (Exception)
            {
                throw;
            }
        }

        // PUT: api/NguoiDung/5
        // Cập nhật tài khoản người dùng
        [HttpPut]
        [Route("Update")]
        public bool PutNguoiDung([FromBody]NguoiDung taikhoan)
        {
            try
            {
                var nguoiDungBL = new NguoiDungBL();
                var nguoiDung = nguoiDungBL.PutNguoiDung(taikhoan);
                return nguoiDung;
            }
            catch (Exception)
            {
                throw;
            }
        }

        // DELETE: api/NguoiDung/5
        [HttpDelete]
        [Route("Delete/{taikhoan}")]
        public bool DeleteNguoiDung(string taikhoan)
        {
            try
            {
                var nguoiDungBL = new NguoiDungBL();
                var nguoiDung = nguoiDungBL.DeleteNguoiDung(taikhoan);
                return nguoiDung;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
