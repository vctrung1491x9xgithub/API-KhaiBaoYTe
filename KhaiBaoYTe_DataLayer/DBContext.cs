using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using API_KhaiBaoYTe.Entities;

namespace KhaiBaoYTe_DataLayer
{
    public class DBContext: IDisposable
    {
        SqlConnection sqlConnection;
        SqlCommand sqlCommand;

        public DBContext()
        {
            // Khởi tạo connection:
            string connectionString = @"Server=DESKTOP-AVASJMT\SQLEXPRESS;Database=DB_KhaiBaoYTe;User Id=sa;Password=vctrung";
            // Khởi tạo đối tượng Sql connection:
            sqlConnection = new SqlConnection(connectionString);
            // Đối tượng Sql command cho phép thao tác vói CSDL:
            sqlCommand = sqlConnection.CreateCommand();
            sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
        }


        //============DANH MỤC ĐƠN VỊ =======================
        //-----------GET DANH SÁCH ĐƠN VỊ--------------------
        public IEnumerable<DonVi> GetDonViList()
        {
            // Khai báo truy vấn:
            sqlCommand.CommandText = "dbo.Proc_GetDonVi";
            // Mở kết nối tới DB:
            sqlConnection.Open();
            // Thực thi công việc với DB:
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            // Xư lý dữ liệu trả về:
            while (sqlDataReader.Read())
            {
                var donVi = new DonVi();
                for (int i = 0; i < sqlDataReader.FieldCount; i++)
                {
                    // Lấy tên cột dữ liệu đang dọc:
                    var colName = sqlDataReader.GetName(i);
                    // Lấy giá trị cell đang đọc: 
                    var value = sqlDataReader.GetValue(i).ToString();
                    // Lấy ra property giống với tên cột đc khai báo ử trên:
                    var property = donVi.GetType().GetProperty(colName);
                    // Nếu có property tương ứng với tên cột thì gán dữ liệu tương ứng:
                    if (property != null)
                    {
                        property.SetValue(donVi, value);
                    }
                }
                // Thêm đối tượng khách hàng vừa build được vào list:
                yield return donVi;
            }
        }
         //-----------GET ĐƠN VỊ THEO ID-------------- 
        public IEnumerable<DonVi> GetDonViByID(String id)
        {
            // Khai báo truy vấn:
            sqlCommand.CommandText = "dbo.Proc_GetDonViByID";
            // Mở kết nối tới DB:
            sqlConnection.Open();
            // Gán Giá trị đầu vào:  
            sqlCommand.Parameters.AddWithValue("@MaDonVi", id);
            // Thực thi công việc với DB:
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            // Xư lý dữ liệu trả về:
            while (sqlDataReader.Read())
            {
                var donVi = new DonVi();
                for (int i = 0; i < sqlDataReader.FieldCount; i++)
                {
                    // Lấy tên cột dữ liệu đang dọc:
                    var colName = sqlDataReader.GetName(i);
                    // Lấy giá trị cell đang đọc: 
                    var value = sqlDataReader.GetValue(i);
                    // Lấy ra property giống với tên cột đc khai báo ử trên:
                    var property = donVi.GetType().GetProperty(colName);
                    // Nếu có property tương ứng với tên cột thì gán dữ liệu tương ứng:
                    if (property != null)
                    {
                        property.SetValue(donVi, value);
                    }
                }
                // Thêm đối tượng khách hàng vừa build được vào list: 
                yield return donVi;
            }
        }
        //-------------THÊM ĐƠN VỊ------------------------------
        public bool PostDonVi(DonVi donvi)
        {
            // Khai báo truy vấn:
            sqlCommand.CommandText = "dbo.Proc_InsertDonVi";
            // Gán giá trị đầu vào cho các tham số trong store:
            // Tự động tăng: Guid.NewGuid 
            sqlCommand.Parameters.AddWithValue("@MaDonVi", donvi.MaDonVi);
            sqlCommand.Parameters.AddWithValue("@TenDonVi", donvi.TenDonVi ?? string.Empty); 
            // Mở kết nối tới DB:
            sqlConnection.Open();
            // Thực thi công việc:
            var result = sqlCommand.ExecuteNonQuery();
            // Đóng kết nối: 
            sqlConnection.Close();
            if (result > 0)
            {
                return true;
            }
            return false;
        }
        //-------------CẬP NHẬT ĐƠN VỊ------------------------------
        public bool PutDonVi(DonVi donvi)
        {
            // Khai báo truy vấn:
            sqlCommand.CommandText = "dbo.Proc_UpdateDonVi";
            // Gán giá trị đầu vào cho các tham số trong store:
            // Tự động tăng: Guid.NewGuid 
            sqlCommand.Parameters.AddWithValue("@MaDonVi", donvi.MaDonVi);
            sqlCommand.Parameters.AddWithValue("@TenDonVi", donvi.TenDonVi); 
            // Mở kết nối tới DB:
            sqlConnection.Open();
            // Thực thi công việc:
            var result = sqlCommand.ExecuteNonQuery();
            // Đóng kết nối: 
            sqlConnection.Close();
            if (result > 0)
            {
                return true;
            }
            return false;
        }
        //-------------XOÁ ĐƠN VỊ------------------------------
        public bool DeleteDonVi(string madonvi)
        {
            // Khai báo truy vấn:
            sqlCommand.CommandText = "dbo.Proc_DeleteDonVi";
            // Gán giá trị đầu vào cho các tham số trong store:
            // Tự động tăng: Guid.NewGuid 
            sqlCommand.Parameters.AddWithValue("@MaDonVi", madonvi);
            // Mở kết nối tới DB:
            sqlConnection.Open();
            // Thực thi công việc:
            var result = sqlCommand.ExecuteNonQuery();
            // Đóng kết nối: 
            sqlConnection.Close();
            if (result > 0)
            {
                return true;
            }
            return false;

        }
        /// <summary>
        /// ============DANH MỤC THAM SỐ===================
        /// </summary>
        //-----------GET DANH SÁCH THAM SỐ -------------- 
        public IEnumerable<ThamSo> GetThamSoList()
        {
            // Khai báo truy vấn:
            sqlCommand.CommandText = "dbo.Proc_GetThamSo";
            // Mở kết nối tới DB:
            sqlConnection.Open();
            // Thực thi công việc với DB:
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            // Xư lý dữ liệu trả về:
            while (sqlDataReader.Read())
            {
                var thamSo = new ThamSo();
                for (int i = 0; i < sqlDataReader.FieldCount; i++)
                {
                    // Lấy tên cột dữ liệu đang dọc:
                    var colName = sqlDataReader.GetName(i);
                    // Lấy giá trị cell đang đọc: 
                    var value = sqlDataReader.GetValue(i).ToString();
                    // Lấy ra property giống với tên cột đc khai báo ử trên:
                    var property = thamSo.GetType().GetProperty(colName);
                    // Nếu có property tương ứng với tên cột thì gán dữ liệu tương ứng:
                    if (property != null)
                    {
                        property.SetValue(thamSo, value);
                    }
                }
                // Thêm đối tượng khách hàng vừa build được vào list:
                yield return thamSo;
            } 
        }
        //-----------GET THAM SỐ THEO ID-------------- 
        public IEnumerable<ThamSo> GetThamSoByID(String id)
        {
            // Khai báo truy vấn:
            sqlCommand.CommandText = "dbo.Proc_GetThamSoByID";
            // Mở kết nối tới DB:
            sqlConnection.Open();
            // Gán Giá trị đầu vào:  
            sqlCommand.Parameters.AddWithValue("@MaThamSo", id);
            // Thực thi công việc với DB:
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            // Xư lý dữ liệu trả về:
            while (sqlDataReader.Read())
            {
                var thamSo = new ThamSo();
                for (int i = 0; i < sqlDataReader.FieldCount; i++)
                {
                    // Lấy tên cột dữ liệu đang dọc:
                    var colName = sqlDataReader.GetName(i);
                    // Lấy giá trị cell đang đọc: 
                    var value = sqlDataReader.GetValue(i);
                    // Lấy ra property giống với tên cột đc khai báo ử trên:
                    var property = thamSo.GetType().GetProperty(colName);
                    // Nếu có property tương ứng với tên cột thì gán dữ liệu tương ứng:
                    if (property != null)
                    {
                        property.SetValue(thamSo, value);
                    }
                }
                // Thêm đối tượng khách hàng vừa build được vào list: 
                yield return thamSo;
            }
        }
        //---------ADD THAM SỐ------------------------------------
        // POST: api/ThamSo
        public bool PostThamSo(ThamSo thamso)
        {
            // Khai báo truy vấn:
            sqlCommand.CommandText = "dbo.Proc_InsertThamSo";
            // Gán giá trị đầu vào cho các tham số trong store:
            // Tự động tăng: Guid.NewGuid 
            sqlCommand.Parameters.AddWithValue("@MaThamSo", thamso.MaThamSo);
            sqlCommand.Parameters.AddWithValue("@TenThamSo", thamso.TenThamSo);
            sqlCommand.Parameters.AddWithValue("@GiaTri", thamso.GiaTri);
            sqlCommand.Parameters.AddWithValue("@MaDonVi", thamso.MaDonVi);
            // Mở kết nối tới DB:
            sqlConnection.Open();
            // Thực thi công việc:
            var result = sqlCommand.ExecuteNonQuery();
            // Đóng kết nối: 
            sqlConnection.Close();
            return true;
        }
        //---------CẬP NHẬT THAM SỐ------------------------------------
        // PUT: api/ThamSo/5
        public bool PutThamSo(ThamSo thamso)
        {
            // Khai báo truy vấn:
            sqlCommand.CommandText = "dbo.Proc_UpdateThamSo";
            // Gán giá trị đầu vào cho các tham số trong store:
            // Tự động tăng: Guid.NewGuid 
            sqlCommand.Parameters.AddWithValue("@MaThamSo", thamso.MaThamSo);
            sqlCommand.Parameters.AddWithValue("@TenThamSo", thamso.TenThamSo);
            sqlCommand.Parameters.AddWithValue("@GiaTri", thamso.GiaTri);
            sqlCommand.Parameters.AddWithValue("@MaDonVi", thamso.MaDonVi);
            // Mở kết nối tới DB:
            sqlConnection.Open();
            // Thực thi công việc:
            var result = sqlCommand.ExecuteNonQuery();
            // Đóng kết nối: 
            sqlConnection.Close();
            if (result > 0)
            {
                return true;
            }
            return false;
        }
        //---------XOÁ THAM SỐ------------------------------------
        // DELETE: api/ThamSo/5 
        public bool DeleteThamSo(string mathamso)
        {
            // Khai báo truy vấn:
            sqlCommand.CommandText = "dbo.Proc_DeleteThamSo";
            // Gán giá trị đầu vào cho các tham số trong store:
            // Tự động tăng: Guid.NewGuid 
            sqlCommand.Parameters.AddWithValue("@MaThamSo", mathamso);
            // Mở kết nối tới DB:
            sqlConnection.Open();
            // Thực thi công việc:
            var result = sqlCommand.ExecuteNonQuery();
            // Đóng kết nối: 
            sqlConnection.Close();
            if (result > 0)
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// ============DANH MỤC NGƯỜI DÙNG=======================
        /// </summary>
        /// ------------GET DANH SÁCH NGƯỜI DÙNG------------------
        public IEnumerable<NguoiDung> GetNguoiDungList()
        {
            // Khai báo truy vấn:
            sqlCommand.CommandText = "dbo.Proc_GetNguoiDung";
            // Mở kết nối tới DB:
            sqlConnection.Open();
            // Thực thi công việc với DB:
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            // Xư lý dữ liệu trả về:
            while (sqlDataReader.Read())
            {
                var nguoiDung = new NguoiDung();
                for (int i = 0; i < sqlDataReader.FieldCount; i++)
                {
                    // Lấy tên cột dữ liệu đang dọc:
                    var colName = sqlDataReader.GetName(i);
                    // Lấy giá trị cell đang đọc: 
                    var value = sqlDataReader.GetValue(i).ToString();
                    // Lấy ra property giống với tên cột đc khai báo ử trên:
                    var property = nguoiDung.GetType().GetProperty(colName);
                    // Nếu có property tương ứng với tên cột thì gán dữ liệu tương ứng:
                    if (property != null)
                    {
                        property.SetValue(nguoiDung, value);
                    }
                }
                // Thêm đối tượng khách hàng vừa build được vào list:
                yield return nguoiDung;
            } 
        }
        //-----------GET NGƯỜI DÙNG THEO ID-------------- 
        public IEnumerable<NguoiDung> GetNguoiDungByTaiKhoan(String taikhoan)
        {
            // Khai báo truy vấn:
            sqlCommand.CommandText = "dbo.Proc_GetNguoiDungByTaiKhoan";
            // Mở kết nối tới DB:
            sqlConnection.Open();
            // Gán Giá trị đầu vào:  
            sqlCommand.Parameters.AddWithValue("@TaiKhoan", taikhoan);
            // Thực thi công việc với DB:
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            // Xư lý dữ liệu trả về:
            while (sqlDataReader.Read())
            {
                var nguoiDung = new NguoiDung();
                for (int i = 0; i < sqlDataReader.FieldCount; i++)
                {
                    // Lấy tên cột dữ liệu đang dọc:
                    var colName = sqlDataReader.GetName(i);
                    // Lấy giá trị cell đang đọc: 
                    var value = sqlDataReader.GetValue(i);
                    // Lấy ra property giống với tên cột đc khai báo ử trên:
                    var property = nguoiDung.GetType().GetProperty(colName);
                    // Nếu có property tương ứng với tên cột thì gán dữ liệu tương ứng:
                    if (property != null)
                    {
                        property.SetValue(nguoiDung, value);
                    }
                }
                // Thêm đối tượng khách hàng vừa build được vào list: 
                yield return nguoiDung;
            }
        }
        /// ------------KIỂM TRA NGƯỜI DÙNG------------------
        // GET: api/NguoiDung/5 
        public bool KiemTraNguoiDung(String taikhoan, string matkhau)
        {  
            // Khai báo truy vấn:
            sqlCommand.CommandText = "dbo.Proc_GetNguoiDung_ByAccountNPassword";
            // Mở kết nối tới DB:
            sqlConnection.Open();
            // Gán Giá trị đầu vào:  
            sqlCommand.Parameters.AddWithValue("@TaiKhoan", taikhoan);
            sqlCommand.Parameters.AddWithValue("@MatKhau", matkhau); 
            // Thực thi công việc với DB:
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            // Xư lý dữ liệu trả về:
            while(sqlDataReader.Read())
            {
                if (sqlDataReader.FieldCount > 0)
                {
                    return true;
                }
            }
            // Đóng kết nối: 
            return false;
        }
        /// ------------THÊM NGƯỜI DÙNG------------------
        public IEnumerable<NguoiDung> TimKiemNguoiDung(string keyword)
        {
            // Khai báo truy vấn:
            sqlCommand.CommandText = "dbo.Proc_GetNguoiDung_ByTaiKhoan_ByDonVi_ByVaiTro";
            // Gán giá trị đầu vào cho các tham số trong store:
            // Tự động tăng: Guid.NewGuid 
            sqlCommand.Parameters.AddWithValue("@TaiKhoan", keyword);
            sqlCommand.Parameters.AddWithValue("@VaiTro", keyword);
            sqlCommand.Parameters.AddWithValue("@TenDonVi", keyword);
            // Mở kết nối tới DB:
            sqlConnection.Open();
            // Thực thi công việc với DB:
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            // Xư lý dữ liệu trả về:
            while (sqlDataReader.Read())
            {
                var nguoiDung = new NguoiDung();
                for (int i = 0; i < sqlDataReader.FieldCount; i++)
                {
                    // Lấy tên cột dữ liệu đang dọc:
                    var colName = sqlDataReader.GetName(i);
                    // Lấy giá trị cell đang đọc: 
                    var value = sqlDataReader.GetValue(i).ToString();
                    // Lấy ra property giống với tên cột đc khai báo ử trên:
                    var property = nguoiDung.GetType().GetProperty(colName);
                    // Nếu có property tương ứng với tên cột thì gán dữ liệu tương ứng:
                    if (property != null)
                    {
                        property.SetValue(nguoiDung, value);
                    }
                }
                // Thêm đối tượng khách hàng vừa build được vào list:
                yield return nguoiDung;
            }
        }
        /// ------------THÊM NGƯỜI DÙNG------------------
        // POST: api/NguoiDung 
        public bool PostNguoiDung(NguoiDung nguoidung)
        {  
            // Khai báo truy vấn:
            sqlCommand.CommandText = "dbo.Proc_InsertNguoiDung";
            // Gán giá trị đầu vào cho các tham số trong store:
            // Tự động tăng: Guid.NewGuid 
            sqlCommand.Parameters.AddWithValue("@TaiKhoan", nguoidung.TaiKhoan);
            sqlCommand.Parameters.AddWithValue("@MatKhau", nguoidung.MatKhau);
            sqlCommand.Parameters.AddWithValue("@VaiTro", nguoidung.VaiTro);
            sqlCommand.Parameters.AddWithValue("@MaDonVi", nguoidung.MaDonVi); 
            // Mở kết nối tới DB:
            sqlConnection.Open();
            // Thực thi công việc:
            var result = sqlCommand.ExecuteNonQuery();
            // Đóng kết nối: 
            sqlConnection.Close();
            if (result > 0)
            {
                return true;
            }
            return false;
        }

        /// ------------CẬP NHẬT NGƯỜI DÙNG------------------
        // PUT: api/NguoiDung/5 
        public bool PutNguoiDung(NguoiDung taikhoan)
        { 
            // Khai báo truy vấn:
            sqlCommand.CommandText = "dbo.Proc_UpdateNguoiDung";
            // Gán giá trị đầu vào cho các tham số trong store:
            // Tự động tăng: Guid.NewGuid 
            sqlCommand.Parameters.AddWithValue("@TaiKhoan", taikhoan.TaiKhoan);
            sqlCommand.Parameters.AddWithValue("@MatKhau", taikhoan.MatKhau);
            sqlCommand.Parameters.AddWithValue("@VaiTro", taikhoan.VaiTro);
            sqlCommand.Parameters.AddWithValue("@MaDonVi", taikhoan.MaDonVi);
            // Mở kết nối tới DB:
            sqlConnection.Open();
            // Thực thi công việc:
            var result = sqlCommand.ExecuteNonQuery();
            // Đóng kết nối: 
            sqlConnection.Close();
            if (result > 0)
            {
                return true;
            }
            return false; 
        }

        /// ------------XOÁ NGƯỜI DÙNG------------------
        // DELETE: api/NguoiDung/5 
        public bool DeleteNguoiDung(string taikhoan)
        { 
            // Khai báo truy vấn:
            sqlCommand.CommandText = "dbo.Proc_DeleteNguoiDung";
            // Gán giá trị đầu vào cho các tham số trong store:
            // Tự động tăng: Guid.NewGuid 
            sqlCommand.Parameters.AddWithValue("@TaiKhoan", taikhoan);
            // Mở kết nối tới DB:
            sqlConnection.Open();
            // Thực thi công việc:
            var result = sqlCommand.ExecuteNonQuery();
            // Đóng kết nối: 
            sqlConnection.Close();
            if (result > 0)
            {
                return true;
            }
            return false;
        }

        /// 
        /// <summary>
        /// ============DANH MỤC CÂU HỎI===================
        /// </summary>


        /// ------------GET CÂU HỎI------------------
        public IEnumerable<CauHoi> GetCauHoiList()
        { 
            // Khai báo truy vấn:
            sqlCommand.CommandText = "dbo.Proc_GetCauHoi";
            // Mở kết nối tới DB:
            sqlConnection.Open();
            // Thực thi công việc với DB:
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            // Xư lý dữ liệu trả về:
            while (sqlDataReader.Read())
            {
                var cauHoi = new CauHoi();
                for (int i = 0; i < sqlDataReader.FieldCount; i++)
                {
                    // Lấy tên cột dữ liệu đang dọc:
                    var colName = sqlDataReader.GetName(i);
                    // Lấy giá trị cell đang đọc: 
                    var value = sqlDataReader.GetValue(i).ToString();
                    // Lấy ra property giống với tên cột đc khai báo ử trên:
                    var property = cauHoi.GetType().GetProperty(colName);
                    // Nếu có property tương ứng với tên cột thì gán dữ liệu tương ứng:
                    if (property != null)
                    {
                        property.SetValue(cauHoi, value);
                    }
                }
                // Thêm đối tượng khách hàng vừa build được vào list:
                yield return cauHoi;
            }
        }

        /// ------------TÌM KIẾM CÂU HỎI BY KEYWORD------------------
        public IEnumerable<CauHoi> TimKiemCauHoi(String keyword)
        { 
            // Khai báo truy vấn:
            sqlCommand.CommandText = "dbo.Proc_GetCauHoi_ByName_ByNhom_ByTrangThai";
            // Mở kết nối tới DB:
            sqlConnection.Open();
            // Gán Giá trị đầu vào:  
            sqlCommand.Parameters.AddWithValue("@TenCauHoi", keyword);
            sqlCommand.Parameters.AddWithValue("@NhomCauHoi", keyword);
            sqlCommand.Parameters.AddWithValue("@TrangThai", keyword);
            // Thực thi công việc với DB:
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            // Xư lý dữ liệu trả về:
            while (sqlDataReader.Read())
            {
                var cauHoi = new CauHoi();
                for (int i = 0; i < sqlDataReader.FieldCount; i++)
                {
                    // Lấy tên cột dữ liệu đang dọc:
                    var colName = sqlDataReader.GetName(i);
                    // Lấy giá trị cell đang đọc: 
                    var value = sqlDataReader.GetValue(i).ToString();
                    // Lấy ra property giống với tên cột đc khai báo ử trên:
                    var property = cauHoi.GetType().GetProperty(colName);
                    // Nếu có property tương ứng với tên cột thì gán dữ liệu tương ứng:
                    if (property != null)
                    {
                        property.SetValue(cauHoi, value);
                    }
                }
                yield return cauHoi;
            }
        }
        //-----------GET CÂU HỎI THEO ID-------------- 
        public IEnumerable<CauHoi> GetCauHoiByID(String id)
        {
            // Khai báo truy vấn:
            sqlCommand.CommandText = "dbo.Proc_GetCauHoiByID";
            // Mở kết nối tới DB:
            sqlConnection.Open();
            // Gán Giá trị đầu vào:  
            sqlCommand.Parameters.AddWithValue("@MaCauHoi", id);
            // Thực thi công việc với DB:
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            // Xư lý dữ liệu trả về:
            while (sqlDataReader.Read())
            {
                var maCauHoi = new CauHoi();
                for (int i = 0; i < sqlDataReader.FieldCount; i++)
                {
                    // Lấy tên cột dữ liệu đang dọc:
                    var colName = sqlDataReader.GetName(i);
                    // Lấy giá trị cell đang đọc: 
                    var value = sqlDataReader.GetValue(i);
                    // Lấy ra property giống với tên cột đc khai báo ử trên:
                    var property = maCauHoi.GetType().GetProperty(colName);
                    // Nếu có property tương ứng với tên cột thì gán dữ liệu tương ứng:
                    if (property != null)
                    {
                        property.SetValue(maCauHoi, value);
                    }
                }
                // Thêm đối tượng khách hàng vừa build được vào list: 
                yield return maCauHoi;
            }
        }
        //-----------GET CÂU HỎI THEO NHÓM A-------------- 
        public IEnumerable<CauHoi> GetCauHoiNhomA()
        {
            // Khai báo truy vấn:
            sqlCommand.CommandText = "dbo.Proc_GetCauHoi_NhomA";
            // Mở kết nối tới DB:
            sqlConnection.Open();
            // Thực thi công việc với DB:
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            // Xư lý dữ liệu trả về:
            while (sqlDataReader.Read())
            {
                var cauHoi = new CauHoi();
                for (int i = 0; i < sqlDataReader.FieldCount; i++)
                {
                    // Lấy tên cột dữ liệu đang dọc:
                    var colName = sqlDataReader.GetName(i);
                    // Lấy giá trị cell đang đọc: 
                    var value = sqlDataReader.GetValue(i).ToString();
                    // Lấy ra property giống với tên cột đc khai báo ử trên:
                    var property = cauHoi.GetType().GetProperty(colName);
                    // Nếu có property tương ứng với tên cột thì gán dữ liệu tương ứng:
                    if (property != null)
                    {
                        property.SetValue(cauHoi, value);
                    }
                }
                // Thêm đối tượng khách hàng vừa build được vào list:
                yield return cauHoi;
            }
        }
        //-----------GET CÂU HỎI THEO NHÓM B-------------- 
        public IEnumerable<CauHoi> GetCauHoiNhomB()
        {
            // Khai báo truy vấn:
            sqlCommand.CommandText = "dbo.Proc_GetCauHoi_NhomB";
            // Mở kết nối tới DB:
            sqlConnection.Open();
            // Thực thi công việc với DB:
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            // Xư lý dữ liệu trả về:
            while (sqlDataReader.Read())
            {
                var cauHoi = new CauHoi();
                for (int i = 0; i < sqlDataReader.FieldCount; i++)
                {
                    // Lấy tên cột dữ liệu đang dọc:
                    var colName = sqlDataReader.GetName(i);
                    // Lấy giá trị cell đang đọc: 
                    var value = sqlDataReader.GetValue(i).ToString();
                    // Lấy ra property giống với tên cột đc khai báo ử trên:
                    var property = cauHoi.GetType().GetProperty(colName);
                    // Nếu có property tương ứng với tên cột thì gán dữ liệu tương ứng:
                    if (property != null)
                    {
                        property.SetValue(cauHoi, value);
                    }
                }
                // Thêm đối tượng khách hàng vừa build được vào list:
                yield return cauHoi;
            }
        }
        //-----------GET CÂU HỎI THEO NHÓM C-------------- 
        public IEnumerable<CauHoi> GetCauHoiNhomC()
        {
            // Khai báo truy vấn:
            sqlCommand.CommandText = "dbo.Proc_GetCauHoi_NhomC";
            // Mở kết nối tới DB:
            sqlConnection.Open();
            // Thực thi công việc với DB:
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            // Xư lý dữ liệu trả về:
            while (sqlDataReader.Read())
            {
                var cauHoi = new CauHoi();
                for (int i = 0; i < sqlDataReader.FieldCount; i++)
                {
                    // Lấy tên cột dữ liệu đang dọc:
                    var colName = sqlDataReader.GetName(i);
                    // Lấy giá trị cell đang đọc: 
                    var value = sqlDataReader.GetValue(i).ToString();
                    // Lấy ra property giống với tên cột đc khai báo ử trên:
                    var property = cauHoi.GetType().GetProperty(colName);
                    // Nếu có property tương ứng với tên cột thì gán dữ liệu tương ứng:
                    if (property != null)
                    {
                        property.SetValue(cauHoi, value);
                    }
                }
                // Thêm đối tượng khách hàng vừa build được vào list:
                yield return cauHoi;
            }
        }
        /// ------------THÊM CÂU HỎI  ------------------
        public bool PostCauHoi(CauHoi cauhoi)
        { 
            // Khai báo truy vấn:
            sqlCommand.CommandText = "dbo.Proc_InsertCauHoi";
            // Gán giá trị đầu vào cho các tham số trong store:
            // Tự động tăng: Guid.NewGuid 
            sqlCommand.Parameters.AddWithValue("@MaCauHoi", cauhoi.MaCauHoi);
            sqlCommand.Parameters.AddWithValue("@TenCauHoi", cauhoi.TenCauHoi);
            sqlCommand.Parameters.AddWithValue("@NoiDung", cauhoi.NoiDung);
            sqlCommand.Parameters.AddWithValue("@NhomCauHoi", cauhoi.NhomCauHoi);
            sqlCommand.Parameters.AddWithValue("@TrangThai", cauhoi.TrangThai);
            sqlCommand.Parameters.AddWithValue("@MaDonVi", cauhoi.MaDonVi);
            // Mở kết nối tới DB:
            sqlConnection.Open();
            // Thực thi công việc:
            var result = sqlCommand.ExecuteNonQuery();
            // Đóng kết nối: 
            sqlConnection.Close();
            if (result > 0)
            {
                return true;
            }
            return false;
        }

        /// ------------CẬP NHẬT CÂU HỎI------------------
        /// 
        public bool PutCauHoi(CauHoi cauhoi)
        {
            // Khai báo truy vấn:
            sqlCommand.CommandText = "dbo.Proc_UpdateCauHoi";
            // Gán giá trị đầu vào cho các tham số trong store:
            // Tự động tăng: Guid.NewGuid 
            sqlCommand.Parameters.AddWithValue("@MaCauHoi", cauhoi.MaCauHoi);
            sqlCommand.Parameters.AddWithValue("@TenCauHoi", cauhoi.TenCauHoi);
            sqlCommand.Parameters.AddWithValue("@NoiDung", cauhoi.NoiDung);
            sqlCommand.Parameters.AddWithValue("@NhomCauHoi", cauhoi.NhomCauHoi);
            sqlCommand.Parameters.AddWithValue("@TrangThai", cauhoi.TrangThai);
            sqlCommand.Parameters.AddWithValue("@MaDonVi", cauhoi.MaDonVi);
            // Mở kết nối tới DB:
            sqlConnection.Open();
            // Thực thi công việc:
            var result = sqlCommand.ExecuteNonQuery();
            // Đóng kết nối: 
            sqlConnection.Close();
            if (result > 0)
            {
                return true;
            }
            return false;
        }

        /// ------------XOÁ CÂU HỎI  ------------------
        /// 
        public bool DeleteCauHoi(string macauhoi)
        {
            // Khai báo truy vấn:
            sqlCommand.CommandText = "dbo.Proc_DeleteCauHoi";
            // Gán giá trị đầu vào cho các tham số trong store:
            // Tự động tăng: Guid.NewGuid 
            sqlCommand.Parameters.AddWithValue("@MaCauHoi", macauhoi);
            // Mở kết nối tới DB:
            sqlConnection.Open();
            // Thực thi công việc:
            var result = sqlCommand.ExecuteNonQuery();
            // Đóng kết nối: 
            sqlConnection.Close();
            if (result > 0)
            {
                return true;
            }
            return false;
        }

        /// 
        /// 
        /// <summary>
        /// ============DANH MỤC TỜ KHAI===================
        /// </summary>

        /// ------------GET TỜ KHAI  ------------------
        public IEnumerable<ToKhai> GetToKhaiList()
        {
            // Khai báo truy vấn:
            sqlCommand.CommandText = "dbo.Proc_GetToKhai";
            // Mở kết nối tới DB:
            sqlConnection.Open();
            // Thực thi công việc với DB:
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            // Xư lý dữ liệu trả về:
            while (sqlDataReader.Read())
            {
                var toKhai = new ToKhai();
                for (int i = 0; i < sqlDataReader.FieldCount; i++)
                {
                    // Lấy tên cột dữ liệu đang dọc:
                    var colName = sqlDataReader.GetName(i);
                    // Lấy giá trị cell đang đọc: 
                    var value = sqlDataReader.GetValue(i);
                    // Lấy ra property giống với tên cột đc khai báo ử trên:
                    var property = toKhai.GetType().GetProperty(colName);
                    // Nếu có property tương ứng với tên cột thì gán dữ liệu tương ứng:
                    if (property != null)
                    {
                        property.SetValue(toKhai, value);
                    }
                }
                // Thêm đối tượng khách hàng vừa build được vào list:
                yield return toKhai;
            }
        }
        /// ------------TÌM KIẾM TỜ KHAI  ------------------
        public IEnumerable<ToKhai> TimKiemToKhai(String keyword)
        {
            // Khai báo truy vấn:
            sqlCommand.CommandText = "dbo.Proc_GetToKhai_ByName";
            // Mở kết nối tới DB:
            sqlConnection.Open();
            // Gán Giá trị đầu vào:  
            sqlCommand.Parameters.AddWithValue("@TenNguoiKhai", keyword);
            // Thực thi công việc với DB:
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            // Xư lý dữ liệu trả về:
            while (sqlDataReader.Read())
            {
                var toKhai = new ToKhai();
                for (int i = 0; i < sqlDataReader.FieldCount; i++)
                {
                    // Lấy tên cột dữ liệu đang dọc:
                    var colName = sqlDataReader.GetName(i);
                    // Lấy giá trị cell đang đọc: 
                    var value = sqlDataReader.GetValue(i);
                    // Lấy ra property giống với tên cột đc khai báo ử trên:
                    var property = toKhai.GetType().GetProperty(colName);
                    // Nếu có property tương ứng với tên cột thì gán dữ liệu tương ứng:
                    if (property != null)
                    {
                        property.SetValue(toKhai, value);
                    }
                }
                yield return toKhai;
            }
        }

        /// ------------THÊM TỜ KHAI  ------------------
        public bool PostToKhai(ToKhai tokhai)
        {
            // Khai báo truy vấn:
            sqlCommand.CommandText = "dbo.Proc_InsertToKhai";
            // Gán giá trị đầu vào cho các tham số trong store:
            // Tự động tăng: Guid.NewGuid 
            sqlCommand.Parameters.AddWithValue("@MaToKhai", tokhai.MaToKhai);
            sqlCommand.Parameters.AddWithValue("@ThoiGianKhai", DateTime.UtcNow);
            sqlCommand.Parameters.AddWithValue("@MaNguoiKhai", tokhai.MaNguoiKhai);
            // Mở kết nối tới DB:
            sqlConnection.Open();
            // Thực thi công việc:
            var result = sqlCommand.ExecuteNonQuery();
            // Đóng kết nối: 
            sqlConnection.Close();
            if (result > 0)
            {
                return true;
            }
            return false;
        }
         
        /// ------------XOÁ TỜ KHAI  ------------------
        public bool DeleteToKhai(string matokhai)
        { 
            // Khai báo truy vấn:
            sqlCommand.CommandText = "dbo.Proc_DeleteToKhai";
            // Gán giá trị đầu vào cho các tham số trong store:
            // Tự động tăng: Guid.NewGuid 
            sqlCommand.Parameters.AddWithValue("@MaToKhai", matokhai);
            // Mở kết nối tới DB:
            sqlConnection.Open();
            // Thực thi công việc:
            var result = sqlCommand.ExecuteNonQuery();
            // Đóng kết nối: 
            sqlConnection.Close();
            if (result > 0)
            {
                return true;
            }
            return false;
        }
        /// 
        /// 
        /// <summary>
        /// ============DANH MỤC LỜI KHAI BÁO===================
        /// </summary> 
        /// ------------GET LỜI KHAI  ------------------
        public IEnumerable<LoiKhai> GetLoiKhaiList()
        {
            // Khai báo truy vấn:
            sqlCommand.CommandText = "dbo.Proc_GetLoiKhai";
            // Mở kết nối tới DB:
            sqlConnection.Open();
            // Thực thi công việc với DB:
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            // Xư lý dữ liệu trả về:
            while (sqlDataReader.Read())
            {
                var loiKhai = new LoiKhai();
                for (int i = 0; i < sqlDataReader.FieldCount; i++)
                {
                    // Lấy tên cột dữ liệu đang dọc:
                    var colName = sqlDataReader.GetName(i);
                    // Lấy giá trị cell đang đọc: 
                    var value = sqlDataReader.GetValue(i);
                    // Lấy ra property giống với tên cột đc khai báo ử trên:
                    var property = loiKhai.GetType().GetProperty(colName);
                    // Nếu có property tương ứng với tên cột thì gán dữ liệu tương ứng:
                    if (property != null)
                    {
                        property.SetValue(loiKhai, value);
                    }
                }
                // Thêm đối tượng khách hàng vừa build được vào list:
                yield return loiKhai;
            }
        }

        /// ------------THÊM LỜI KHAI  ------------------
        public bool PostLoiKhai(LoiKhai loikhai)
        { 
            // Khai báo truy vấn:
            sqlCommand.CommandText = "dbo.Proc_InsertLoiKhai";
            // Gán giá trị đầu vào cho các tham số trong store:
            // Tự động tăng: Guid.NewGuid 
            sqlCommand.Parameters.AddWithValue("@MaLoiKhai", loikhai.MaLoiKhai);
            sqlCommand.Parameters.AddWithValue("@LoiKhaiBao", loikhai.LoiKhaiBao);
            sqlCommand.Parameters.AddWithValue("@MaCauHoi", loikhai.MaCauHoi);
            sqlCommand.Parameters.AddWithValue("@MaToKhai", loikhai.MaToKhai);
            // Mở kết nối tới DB:
            sqlConnection.Open();
            // Thực thi công việc:
            var result = sqlCommand.ExecuteNonQuery();
            // Đóng kết nối: 
            sqlConnection.Close();
            if (result > 0)
            {
                return true;
            }
            return false;
        }
        /// ------------XOÁ LỜI KHAI  ------------------
        public bool DeleteLoiKhai(string maloikhai)
        {
            // Khai báo truy vấn:
            sqlCommand.CommandText = "dbo.Proc_DeleteLoiKhai";
            // Gán giá trị đầu vào cho các tham số trong store:
            // Tự động tăng: Guid.NewGuid 
            sqlCommand.Parameters.AddWithValue("@MaLoiKhai", maloikhai);
            // Mở kết nối tới DB:
            sqlConnection.Open();
            // Thực thi công việc:
            var result = sqlCommand.ExecuteNonQuery();
            // Đóng kết nối: 
            sqlConnection.Close();
            if (result > 0)
            {
                return true;
            }
            return false;
        }
        /// 
        /// 
        /// 
        /// <summary>
        /// ============DANH MỤC NGƯỜI KHAI BÁO===================
        /// </summary>
        /// <returns></returns>
        //-----------GET DANH SÁCH NGUỜI KHAI BÁO -------------- 
        public IEnumerable<NguoiKhaiBao> GetNguoiKhaiBaoList()
        {            // Khai báo truy vấn:
            sqlCommand.CommandText = "dbo.Proc_GetNguoiKhaiBao";
            // Mở kết nối tới DB:
            sqlConnection.Open();
            // Thực thi công việc với DB:
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            // Xư lý dữ liệu trả về:
            while (sqlDataReader.Read())
            {
                var nguoiKhaiBao = new NguoiKhaiBao();
                for (int i = 0; i < sqlDataReader.FieldCount; i++)
                {
                    // Lấy tên cột dữ liệu đang dọc:
                    var colName = sqlDataReader.GetName(i);
                    // Lấy giá trị cell đang đọc: 
                    var value = sqlDataReader.GetValue(i);
                    // Lấy ra property giống với tên cột đc khai báo ử trên:
                    var property = nguoiKhaiBao.GetType().GetProperty(colName);
                    // Nếu có property tương ứng với tên cột thì gán dữ liệu tương ứng:
                    if (property != null)
                    {
                        property.SetValue(nguoiKhaiBao, value);
                    }
                }
                yield return nguoiKhaiBao;
            }
        }

        //-----------TÌM KIẾM NGƯỜI KHAI BÁO-------------- 
        public IEnumerable<NguoiKhaiBao> TimKiemNguoiKhaiBao(String keyword)
        {
            // Khai báo truy vấn:
            sqlCommand.CommandText = "dbo.Proc_GetNguoiKhaiBao_ByName_ByNumberPhone_ByCity";
            // Mở kết nối tới DB:
            sqlConnection.Open();
            // Gán Giá trị đầu vào:  
            sqlCommand.Parameters.AddWithValue("@TenNguoiKhai", keyword);
            sqlCommand.Parameters.AddWithValue("@SDT", keyword);
            sqlCommand.Parameters.AddWithValue("@NoiOHienNay", keyword);
            // Thực thi công việc với DB:
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            // Xư lý dữ liệu trả về:
            while (sqlDataReader.Read())
            {
                var nguoiKhaiBao = new NguoiKhaiBao();
                for (int i = 0; i < sqlDataReader.FieldCount; i++)
                {
                    // Lấy tên cột dữ liệu đang dọc:
                    var colName = sqlDataReader.GetName(i);
                    // Lấy giá trị cell đang đọc: 
                    var value = sqlDataReader.GetValue(i);
                    // Lấy ra property giống với tên cột đc khai báo ử trên:
                    var property = nguoiKhaiBao.GetType().GetProperty(colName);
                    // Nếu có property tương ứng với tên cột thì gán dữ liệu tương ứng:
                    if (property != null)
                    {
                        property.SetValue(nguoiKhaiBao, value);
                    }
                }
                yield return nguoiKhaiBao;
            } 
        }
        //-----------GET NGUÒI KHAI BÁO THEO ID-------------- 
        public IEnumerable<NguoiKhaiBao> GetNguoiKhaiBaoByID(String id)
        {
            // Khai báo truy vấn:
            sqlCommand.CommandText = "dbo.Proc_GetNguoiKhaiBaoByID";
            // Mở kết nối tới DB:
            sqlConnection.Open();
            // Gán Giá trị đầu vào:  
            sqlCommand.Parameters.AddWithValue("@MaNguoiKhai", id);
            // Thực thi công việc với DB:
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            // Xư lý dữ liệu trả về:
            while (sqlDataReader.Read())
            {
                var nguoiKhaiBao = new NguoiKhaiBao();
                for (int i = 0; i < sqlDataReader.FieldCount; i++)
                {
                    // Lấy tên cột dữ liệu đang dọc:
                    var colName = sqlDataReader.GetName(i);
                    // Lấy giá trị cell đang đọc: 
                    var value = sqlDataReader.GetValue(i);
                    // Lấy ra property giống với tên cột đc khai báo ử trên:
                    var property = nguoiKhaiBao.GetType().GetProperty(colName);
                    // Nếu có property tương ứng với tên cột thì gán dữ liệu tương ứng:
                    if (property != null)
                    {
                        property.SetValue(nguoiKhaiBao, value);
                    }
                }
                // Thêm đối tượng khách hàng vừa build được vào list: 
                yield return nguoiKhaiBao;
            }
        }

        // ---------THÊM NGƯỜI KHAI BÁO------------
        public bool PostThemNguoiKhai(NguoiKhaiBao nguoikhaibao)
        {
            // Khai báo truy vấn:
            sqlCommand.CommandText = "dbo.Proc_InsertNguoiKhaiBao";
            // Gán giá trị đầu vào cho các tham số trong store:
            // Tự động tăng: Guid.NewGuid 
            sqlCommand.Parameters.AddWithValue("@MaNguoiKhai", nguoikhaibao.MaNguoiKhai);
            sqlCommand.Parameters.AddWithValue("@TenNguoiKhai", nguoikhaibao.TenNguoiKhai);
            sqlCommand.Parameters.AddWithValue("@NgaySinh", nguoikhaibao.NgaySinh);
            sqlCommand.Parameters.AddWithValue("@SDT", nguoikhaibao.SDT);
            sqlCommand.Parameters.AddWithValue("@NoiOHienNay", nguoikhaibao.NoiOHienNay);
            // Mở kết nối tới DB:
            sqlConnection.Open();
            // Thực thi công việc:
            var result = sqlCommand.ExecuteNonQuery();
            // Đóng kết nối: 
            if (result > 0)
            {
                return true;
            }
            return false;
        }
        //-----------CẬP NHẬT NGƯỜI KHAI BÁO--------
        public bool PutCapNhatNguoiKhai(NguoiKhaiBao nguoikhaibao)
        {
            // Khai báo truy vấn:
            sqlCommand.CommandText = "dbo.Proc_UpdateNguoiKhaiBao";
            // Gán giá trị đầu vào cho các tham số trong store:
            // Tự động tăng: Guid.NewGuid 
            sqlCommand.Parameters.AddWithValue("@MaNguoiKhai", nguoikhaibao.MaNguoiKhai);
            sqlCommand.Parameters.AddWithValue("@TenNguoiKhai", nguoikhaibao.TenNguoiKhai);
            sqlCommand.Parameters.AddWithValue("@NgaySinh", nguoikhaibao.NgaySinh);
            sqlCommand.Parameters.AddWithValue("@SDT", nguoikhaibao.SDT);
            sqlCommand.Parameters.AddWithValue("@NoiOHienNay", nguoikhaibao.NoiOHienNay);
            // Mở kết nối tới DB:
            sqlConnection.Open();
            // Thực thi công việc:
            var result = sqlCommand.ExecuteNonQuery();
            // Đóng kết nối: 
            if (result > 0)
            {
                return true;
            }
            return false;
        }

        //-----------XOÁ NGUÒI KHAI BÁO-------------- 
        public bool DeleteNguoiKhai(string manguoikhai)
        { 
            // Khai báo truy vấn:
            sqlCommand.CommandText = "dbo.Proc_DeleteNguoiKhaiBao";
            // Gán giá trị đầu vào cho các tham số trong store:
            // Tự động tăng: Guid.NewGuid 
            sqlCommand.Parameters.AddWithValue("@MaNguoiKhai", manguoikhai);
            // Mở kết nối tới DB:
            sqlConnection.Open();
            // Thực thi công việc:
            var result = sqlCommand.ExecuteNonQuery();
            // Đóng kết nối:  
            if (result > 0)
            {
                return true;
            }
            return false;
        }
        public void Dispose()
        {
            // Đóng kết nối:  
            sqlConnection.Close();
        }
    }
}
