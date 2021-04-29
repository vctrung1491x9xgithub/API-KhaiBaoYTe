
$(document).ready(function () {
    //load dữ liệu:
    nguoiDungJS = new CauHoiJS();
})

/**
 * Object JS quản lý các sự kiện cho trang danh mục tham số. 
 * */
class CauHoiJS {
    constructor() {
        try {
            var me = this;
            me.loadData();
            me.loadDonVi();
            me.initEvent();
            me.FormMode = null;
        } catch (e) {
            console.log(e);
        }

    }

    /**
     * Thực hiện gán các sự kiện cho các thành phần trong trang
     * */
    initEvent() {
        $("#btnAdd").on("click", Enum.FormMode.Add, this.toolbarItemOnClick.bind(this));
        $("#btnEdit").on("click", Enum.FormMode.Edit, this.toolbarItemOnClick.bind(this));
        $("#btnDelete").on("click", Enum.FormMode.Delete, this.toolbarItemOnClick.bind(this));
        $("#btnSearch").on("click", Enum.FormMode.Search, this.toolbarItemOnClick.bind(this));

        $("#btnCancelDialog").click(this.btnCloseOnClick);
        $("#btnCloseHeader").click(this.btnCloseHeaderOnClick);

        $("#btnSaveDetail").click(this.saveData.bind(this));


        $("table").on("click", "tbody tr", this.rowOnClick);
        $("table").on("dbclick", "tbody tr", this.rowOnDbClick);
    }

   
    /**
  * RANDOM MÃ 
  */
    generateID(n) {
        var str = "";
        var possible = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        for (var i = 0; i < n; i++) {
            str += possible.charAt(Math.floor(Math.random() * possible.length));
        }
        return str;
    }
    //-----------------------------------------------------------------------------
           
    toolbarItemOnClick(sender) {
        try {
            var me = this;
            var formMode = sender.data;
            switch (formMode) {
                case Enum.FormMode.Add:
                    this.FormMode = Enum.FormMode.Add;
                    $("#frmDialogDetail").show();
                    // set giá trị mặc định cho các control nhập liệu"
                    $('#txtTaiKhoan').prop('disabled', false);
                    $("#frmDialogDetail input").val("");
                    $("#frmDialogDetail input[type='checkbox']").prop("checked", false);
                    $('#txtTaiKhoan').focus();
                    $('.default-select').prop('selected', true);
                    break;
                case Enum.FormMode.Edit:
                    this.FormMode = Enum.FormMode.Edit;
                    var rowSelected = $('tr.row-selected');
                    if (rowSelected && rowSelected.length == 1) {
                        var taiKhoan = $('tr.row-selected').children()[0].textContent;
                        $('#txtTaiKhoan').prop('disabled', true);
                        this.TaiKhoan = taiKhoan;
                        $.ajax({
                            url: "http://localhost:63750/api/DanhMucNguoiDung/NguoiDung/" + taiKhoan,
                            method: "GET",
                            //data: {},
                            dataType: "json",
                            contentType: "application/json",
                        }).done(function (res) {
                            // Thực hiện binding dữ liệu lên form chi tiết:
                            var nguoiDung = res;
                            $('#txtTaiKhoan').val(nguoiDung['TaiKhoan']);
                            $('#txtMatKhau').val(nguoiDung['MatKhau']);
                            for (var i = 0; i < document.getElementById("selectVaiTro").options.length; i++) {
                                if (document.getElementById("selectVaiTro").options[i].text == nguoiDung['VaiTro']) {
                                    document.getElementById("selectVaiTro").options[i].selected = true;
                                } else {
                                    document.getElementById("selectVaiTro").options[i].selected = false;
                                }
                            }

                            $('#txtMaDonVi').val(nguoiDung['MaDonVi']);
                        }).fail(function () {
                            alert("Lỗi");
                        });
                        $("#frmDialogDetail").show();
                        $('#frmDialogDetai input')[0].focus();
                    }
                    break;
                case Enum.FormMode.Delete:
                    var rowSelected = $('tr.row-selected');
                    if (rowSelected && rowSelected.length == 1) {
                        var taiKhoan = $('tr.row-selected').children()[0].textContent;
                        alert("Xoá " + taiKhoan);
                        $.ajax({
                            url: "http://localhost:63750/api/DanhMucNguoiDung/Delete/" + taiKhoan,
                            method: "DELETE",
                        }).done(function (res) {
                            // Thực hiện binding dữ liệu lên form chi tiết:
                            me.loadData();
                        }).fail(function () {
                            alert("Lỗi");
                        });
                    }
                    break;
                case Enum.FormMode.Search:
                    taiKhoan = $('.txtsearch').val();
                    alert(taiKhoan);
                    $.ajax({
                        url: "http://localhost:63750/api/DanhMucDonVi/Delete/" + taiKhoan,
                        method: "DELETE",
                    }).done(function (res) {
                        // Thực hiện binding dữ liệu lên form chi tiết:
                        me.loadData();
                    }).fail(function () {
                        alert("Lỗi");
                    });
                    break;
                default:
            }

        } catch (e) {

        }

    } 
    /**
    * Sự kiện khi click button đóng dưới footer của Dialog 
    * */
    btnCloseOnClick() {
        $("#frmDialogDetail").hide();
    }

    /**
    * Sự kiện khi click Đóng trên tiêu đề của Dialog 
    * */
    btnCloseHeaderOnClick() {
        $("#frmDialogDetail").hide();
    }

    /**
    * Sự kiện khi click chọn 1 dòng trong table 
    * */
    rowOnClick(sender) {
        this.classList.add("row-selected");
        $(this).siblings().removeClass("row-selected");

    } 


    /**
    * Load dữ liệu 
    * */
    loadData() {
        try {
            $('table#tbListNguoiDung tbody').empty();
            $.ajax({
                url: "http://localhost:63750/api/DanhMucNguoiDung",
                method: "GET",
                // data: "", Truyền qua body request
                dataType: "json",
                contentType: "application/json",
            }).done(function (response) {
                if (response) {
                    // Đọc dữ liệu và gen dữ liệu từng người dùng với HTML:
                    $.each(response, function (index, item) {
                        var nguoiDungInfoHTML = $(`<tr class='grid-row'>
                                <td class='grid-cell-inner'>`+ item['TaiKhoan'] + `</td>
                                <td class='grid-cell-inner'>`+ item['MatKhau'] + `</td>
                                <td class='grid-cell-inner'>`+ item['VaiTro'] + `</td>
                                <td class='grid-cell-inner'>`+ item['MaDonVi'] + `</td>
                            </tr>`);
                      
                        $('table#tbListNguoiDung tbody').append(nguoiDungInfoHTML); 
                    })
                    // Mặc định chọn bản ghi đầu tiên có trong danh sách:
                    $('table#tbListNguoiDung tbody tr').first().addClass('row-selected');
                }
            }).fail(function (response) {
                alert("Có lỗi xảy ra");
            })

        } catch (e) {  console.log(e); } 
    }
    loadDonVi() {
        // Load đơn vị
        try {
            $.ajax({
                url: "http://localhost:63750/api/DanhMucDonVi",
                method: "GET",
                // data: "", Truyền qua body request
                dataType: "json",
                contentType: "application/json",
            }).done(function (res) {
                if (res) {
                    // Đọc dữ liệu và gen dữ liệu với HTML:
                    $('#txtMaDonVi').append('<option value="" class="default-select">---Chọn đơn vị---</option>');
                    $.each(res, function (index, item) {
                        var DonViInfoHTML = $(`<option value="` + item['MaDonVi'] + `">` + item['TenDonVi'] + `</td>`);
                     
                        $('#txtMaDonVi').append(DonViInfoHTML);
                    })
                    
                }
            }).fail(function (response) {
                alert("Có lỗi xảy ra");
            })
        } catch (e) {
            console.log(e);
        }
    }
    /**
     * Cất dữ liệu 
     * */
    saveData(sender, a, b, c) { 
        //debugger;
        var me = this;
        // Lấy dữ liệu được nhập từ các input:
        var taiKhoan = $("#txtTaiKhoan").val(),
            matKhau = $("#txtMatKhau").val(),
            vaiTro = $("#selectVaiTro").val(),
            maDonVi = $("#txtMaDonVi").val()
        // Từ các dữ liệu thu thập được thì build thành object nguoidung
        var NguoiDung = {
                TaiKhoan: taiKhoan,
                MatKhau: matKhau,
                VaiTro: vaiTro,
                MaDonVi: maDonVi
        };
        
        if (me.FormMode == Enum.FormMode.Add) { 
            // Lưu dữ liệu vào database:
            $.ajax({
                url: "http://localhost:63750/api/DanhMucNguoiDung/Add",
                method: "POST",
                data: JSON.stringify(NguoiDung),
                dataType: "json",
                contentType: "application/json"
            }).done(function (res) {
                // Hiển thị thông báo cất thành công/ thất bại:
                alert("Thêm thành công!")
                // Đóng/ ẩn Form:
                $("#frmDialogDetail").hide();
                // load lại dữ liệu
                me.loadData();
            }).fail(function (res) {
                debugger
            });
       } else if (me.FormMode == Enum.FormMode.Edit) {
            // Lưu dữ liệu vào database:
            $.ajax({
                url: "http://localhost:63750/api/DanhMucNguoiDung/Update",
                method: "PUT",
                data: JSON.stringify(NguoiDung),
                dataType: "json",
                contentType: "application/json"
            }).done(function (res) {
                // Hiển thị thông báo cất thành công/ thất bại:
                alert("Cập nhật thành công!")
                // Đóng/ ẩn Form:
                $("#frmDialogDetail").hide();
                // load lại dữ liệu
                me.loadData();
            }).fail(function (res) {
                debugger
            });
        }
        
    }
}
