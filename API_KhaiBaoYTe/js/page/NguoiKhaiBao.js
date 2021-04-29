
$(document).ready(function () {
    //load dữ liệu:
   nguoiKhaiBaoJs = new NguoiKhaiBaoJS();
})

/**
 * Object JS quản lý các sự kiện cho trang danh mục NguoiKhaiBao.
 * */
class NguoiKhaiBaoJS {
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
        //$("#btnAdd").click(this.showDialog);
        $("#btnAdd").on("click", Enum.FormMode.Add, this.toolbarItemOnClick.bind(this));
        $("#btnEdit").on("click", Enum.FormMode.Edit, this.toolbarItemOnClick.bind(this));
        $("#btnDelete").on("click", Enum.FormMode.Delete, this.toolbarItemOnClick.bind(this));
        $("#btnSearch").on("click", Enum.FormMode.Search, this.toolbarItemOnClick.bind(this));
        //$("#btnEdit").click(this.showDialog);
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
                    $('#txtMaNguoiKhai').val("NK" + me.generateID(5));
                    $("#frmDialogDetail").show();
                    $('#txtTenNguoiKhai').focus();
                    break;
                case Enum.FormMode.Edit:
                    this.FormMode = Enum.FormMode.Edit;
                    var rowSelected = $('tr.row-selected');
                    if (rowSelected && rowSelected.length == 1) {
                        var maNguoiKhaiBao = $('tr.row-selected').children()[0].textContent;
                        this.MaNguoiKhaiBao = maNguoiKhaiBao; 
                        $.ajax({
                            url: "http://localhost:63750/api/NguoiKhaiBao/GetNguoiKhaiBao/" + maNguoiKhaiBao,
                            method: "GET",
                            //data: {},
                            dataType: "json",
                            contentType: "application/json",
                        }).done(function (res) {
                            // Thực hiện binding dữ liệu lên form chi tiết:
                            var nguoiKhaiBao = res;
                            $('#txtMaNguoiKhai').val(nguoiKhaiBao['MaNguoiKhai']);
                            $('#txtTenNguoiKhai').val(nguoiKhaiBao['TenNguoiKhai']);   
                            $("#dtNgaySinh").val(nguoiKhaiBao['NgaySinh']);
                            $('#txtSoDienThoai').val(nguoiKhaiBao['SDT']);
                            $('#txtDiaChi').val(nguoiKhaiBao['NoiOHienNay']); 
                        }).fail(function () {
                            alert("Lỗi");
                        });
                        $("#frmDialogDetail").show();
                        $('#frmDialogDetai input')[0].focus();
                    }
                case Enum.FormMode.Delete:
                    var rowSelected = $('tr.row-selected');
                    if (rowSelected && rowSelected.length == 1) {
                        var maNguoiKhaiBao = $('tr.row-selected').children()[0].textContent;
                        alert("Xoá " + $('tr.row-selected').children()[1].textContent);
                        $.ajax({
                            url: "http://localhost:63750/api/NguoiKhaiBao/Delete/" + maNguoiKhaiBao,
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
                    maNguoiKhaiBao = $('.txtsearch').val();
                    try {
                        $.ajax({
                            url: "http://localhost:63750/api/NguoiKhaiBao/TimKiem/" + maNguoiKhaiBao,
                            method: "GET",
                            // data: "", Truyền qua body request
                            dataType: "json",
                            contentType: "application/json",
                        }).done(function (res) {
                            if (res) {
                                // Đọc dữ liệu và gen dữ liệu với HTML:
                                $('table#tbListNguoiKhaiBao tbody').empty();
                                $.each(res, function (index, item) {
                                    console.log(item['MaNguoiKhai']);
                                    var NguoiKhaiBaoInfoHTML = $(`<tr class='grid-row'>
                                                <td class='grid-cell-inner'>`+ item['MaNguoiKhai'] + `</td>
                                                <td class='grid-cell-inner'>`+ item['TenNguoiKhai'] + `</td>
                                                <td class='grid-cell-inner'>`+ item['NgaySinh'] + `</td> 
                                                <td class='grid-cell-inner'>`+ item['SDT'] + `</td> 
                                                <td class='grid-cell-inner'>`+ (item['NoiOHienNay'] || '') + `</td> 
                                            </tr>`);
                                    
                                    $('table#tbListNguoiKhaiBao tbody').append(NguoiKhaiBaoInfoHTML);
                                })
                                // Mặc định chọn bản ghi đầu tiên có trong danh sách:
                                $('table#tbListNguoiKhaiBao tbody tr').first().addClass('row-selected');
                            }
                        }).fail(function (response) {
                            alert("Có lỗi xảy ra");
                        })

                    } catch (e) {
                        console.log(e);
                    }
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
            $('table#tbListNguoiKhaiBao tbody').empty();
            $.ajax({
                url: "http://localhost:63750/api/NguoiKhaiBao",
                method: "GET",
                // data: "", Truyền qua body request
                dataType: "json",
                contentType: "application/json",
            }).done(function (response) {
                if (response) {
                    // Đọc dữ liệu và gen dữ liệu từng người khai báo với HTML:
                    $.each(response, function (index, item) {
                        var nguoiKhaiBaoInfoHTML = $(`<tr class='grid-row'>
                                <td class='grid-cell-inner'>`+ item['MaNguoiKhai'] + `</td>
                                <td class='grid-cell-inner'>`+ item['TenNguoiKhai'] + `</td>
                                <td class='grid-cell-inner'>`+ item['NgaySinh'] + `</td> 
                                <td class='grid-cell-inner'>`+ item['SDT'] + `</td> 
                                <td class='grid-cell-inner'>`+ (item['NoiOHienNay'] || '') + `</td> 
                            </tr>`);
                       
                        $('table#tbListNguoiKhaiBao tbody').append(nguoiKhaiBaoInfoHTML); 
                    })
                    // Mặc định chọn bản ghi đầu tiên có trong danh sách:
                    $('table#tbListNguoiKhaiBao tbody tr').first().addClass('row-selected');
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
         var    maNguoiKhai = $("#txtMaNguoiKhai").val(),
                tenNguoiKhai = $("#txtTenNguoiKhai").val(),
                ngaySinh = $("#dtNgaySinh").val(),
                soDienThoai = $("#txtSoDienThoai").val(),
                diaChi = $("#txtDiaChi").val()

        // Từ các dữ liệu thu thập được thì build thành object nguoi khai bao
        var NguoiKhaiBao = {
                    MaNguoiKhai: maNguoiKhai,
                    TenNguoiKhai: tenNguoiKhai,
                    NgaySinh: new Date(ngaySinh),
                    SDT: soDienThoai,
                    NoiOHienNay: diaChi
        };
        
        if (me.FormMode == Enum.FormMode.Add) { 
            // Lưu dữ liệu vào database:
            $.ajax({
                url: "http://localhost:63750/api/NguoiKhaiBao/Add",
                method: "POST",
                data: JSON.stringify(NguoiKhaiBao),
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
                url: "http://localhost:63750/api/NguoiKhaiBao/Update",
                method: "PUT",
                data: JSON.stringify(NguoiKhaiBao),
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
