
$(document).ready(function () {
    //load dữ liệu:
    thamSoJS = new CauHoiJS();
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
                    // set giá trị mặc định cho các control nhập liệu"
                    $("#frmDialogDetail input").val("");
                    $("#frmDialogDetail input[type='checkbox']").prop("checked", false);
                    $('#txtMaThamSo').val("TS" + me.generateID(5));
                    $("#frmDialogDetail").show();
                    $('#txtTenThamSo').focus();
                    $('.default-select').prop('selected', true);
                    break;
                case Enum.FormMode.Edit:
                    this.FormMode = Enum.FormMode.Edit;
                    var rowSelected = $('tr.row-selected');
                    if (rowSelected && rowSelected.length == 1) {
                        var maThamSo = $('tr.row-selected').children()[0].textContent;
                        this.MaThamSo = maThamSo;
                        $.ajax({
                            url: "http://localhost:63750/api/DanhMucThamSo/ThamSo/" + maThamSo,
                            method: "GET",
                            //data: {},
                            dataType: "json",
                            contentType: "application/json",
                        }).done(function (res) {
                            // Thực hiện binding dữ liệu lên form chi tiết:
                            var thamSo = res;
                            $('#txtMaThamSo').val(thamSo['MaThamSo']);
                            $('#txtTenThamSo').val(thamSo['TenThamSo']);
                            $('#txtGiaTri').val(thamSo['GiaTri']);
                            $('#txtMaDonVi').val(thamSo['MaDonVi']);
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
                        var maThamSo = $('tr.row-selected').children()[0].textContent;
                        alert("Xoá " + $('tr.row-selected').children()[1].textContent);
                        $.ajax({
                            url: "http://localhost:63750/api/DanhMucThamSo/Delete/" + maThamSo,
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
                    maThamSo = $('.txtsearch').val();
                    alert(maThamSo);
                    $.ajax({
                        url: "http://localhost:63750/api/DanhMucDonVi/Delete/" + maThamSo,
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
            $('table#tbListThamSo tbody').empty();
            $.ajax({
                url: "http://localhost:63750/api/DanhMucThamSo",
                method: "GET",
                // data: "", Truyền qua body request
                dataType: "json",
                contentType: "application/json",
            }).done(function (response) {
                if (response) {
                    // Đọc dữ liệu và gen dữ liệu từng tham số với HTML:
                    $.each(response, function (index, item) {
                        var thamSoInfoHTML = $(`<tr class='grid-row'>
                                <td class='grid-cell-inner'>`+ item['MaThamSo'] + `</td>
                                <td class='grid-cell-inner'>`+ item['TenThamSo'] + `</td>
                                <td class='grid-cell-inner'>`+ item['GiaTri'] + `</td>
                                <td class='grid-cell-inner'>`+ item['MaDonVi'] + `</td>
                            </tr>`);
                       
                        $('table#tbListThamSo tbody').append(thamSoInfoHTML); 
                    })
                    // Mặc định chọn bản ghi đầu tiên có trong danh sách:
                    $('table#tbListThamSo tbody tr').first().addClass('row-selected');
                }
            }).fail(function (response) {
                alert("Có lỗi xảy ra");
            })

        } catch (e) {
            console.log(e);
        }

    }
    // Load đơn vị
    loadDonVi() { 
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
        var maThamSo = $("#txtMaThamSo").val(),
            tenThamSo = $("#txtTenThamSo").val(),
            giaTri = $("#txtGiaTri").val(),
            maDonVi = $("#txtMaDonVi").val()
        // Từ các dữ liệu thu thập được thì build thành object tham số
        var ThamSo = {
                MaThamSo: maThamSo,
                TenThamSo: tenThamSo,
                GiaTri: giaTri,
                MaDonVi: maDonVi
        };
        
        if (me.FormMode == Enum.FormMode.Add) { 
            // Lưu dữ liệu vào database:
            $.ajax({
                url: "http://localhost:63750/api/DanhMucThamSo/Add",
                method: "POST",
                data: JSON.stringify(ThamSo),
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
                url: "http://localhost:63750/api/DanhMucThamSo/Update",
                method: "PUT",
                data: JSON.stringify(ThamSo),
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
