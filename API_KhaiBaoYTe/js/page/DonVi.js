
$(document).ready(function () {
    //load dữ liệu:
    donViJs = new DonViJS();
})

/**
 * Object JS quản lý các sự kiện cho trang danh mục Đơn vị.
 * */
class DonViJS {
    constructor() {
        try {
            var me = this;
            me.loadData();
            me.initEvent();
            me.FormMode = null;
        } catch (e) {

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
                    $('#txtMaDonVi').val("DV" + me.generateID(5));
                   
                    $("#frmDialogDetail").show(); 
                    $('#txtTenDonVi').focus();
                    break;
                case Enum.FormMode.Edit:
                    this.FormMode = Enum.FormMode.Edit;
                    var rowSelected = $('tr.row-selected');
                    if (rowSelected && rowSelected.length == 1) {
                        var maDonVi = $('tr.row-selected').children()[0].textContent;
                        this.MaDonVi = maDonVi;
                        $.ajax({
                            url: "http://localhost:63750/api/DanhMucDonVi/DonVi/" + maDonVi,
                            method: "GET",
                            //data: {},
                            dataType: "json",
                            contentType: "application/json",
                        }).done(function (res) {
                            // Thực hiện binding dữ liệu lên form chi tiết:
                            var donVi = res;
                            $('#txtMaDonVi').val(donVi['MaDonVi']);
                            $('#txtTenDonVi').val(donVi['TenDonVi']);
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
                        var maDonVi = $('tr.row-selected').children()[0].textContent;
                        alert("Xoá " + $('tr.row-selected').children()[1].textContent);
                        $.ajax({
                            url: "http://localhost:63750/api/DanhMucDonVi/Delete/" + maDonVi,
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
                    alert("Đang cập nhật");
                    break;
                default:
            }

        } catch (e) {   } 
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
            $('table#tbListDonVi tbody').empty();
            $.ajax({
                url: "http://localhost:63750/api/DanhMucDonVi",
                method: "GET",
                // data: "", Truyền qua body request
                dataType: "json",
                contentType: "application/json",
            }).done(function (response) {
                if (response) {
                    // Đọc dữ liệu và gen dữ liệu từng đơn vị với HTML:
                    $.each(response, function (index, item) {
                        var donViInfoHTML = $(`<tr class='grid-row'>
                                <td class='grid-cell-inner'>`+ item['MaDonVi'] + `</td>
                                <td class='grid-cell-inner'>`+ item['TenDonVi'] + `</td>
                                
                            </tr>`);
                       
                        $('table#tbListDonVi tbody').append(donViInfoHTML); 
                    })
                    // Mặc định chọn bản ghi đầu tiên có trong danh sách:
                    $('table#tbListDonVi tbody tr').first().addClass('row-selected');
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
         var    maDonVi = $("#txtMaDonVi").val(),
                tenDonVi = $("#txtTenDonVi").val()
        // Từ các dữ liệu thu thập được thì build thành object don vi
        var DonVi = {
                MaDonVi: maDonVi,
                TenDonVi: tenDonVi,
                    
        };
        
        if (me.FormMode == Enum.FormMode.Add) { 
            // Lưu dữ liệu vào database:
            $.ajax({
                url: "http://localhost:63750/api/DanhMucDonVi/Add",
                method: "POST",
                data: JSON.stringify(DonVi),
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
                url: "http://localhost:63750/api/DanhMucDonVi/Update",
                method: "PUT",
                data: JSON.stringify(DonVi),
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
