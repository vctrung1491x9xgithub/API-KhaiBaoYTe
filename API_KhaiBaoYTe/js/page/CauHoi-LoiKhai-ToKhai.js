
$(document).ready(function () {
    //load dữ liệu:
    cauHoiJS = new CauHoiJS();
    toiKhaiLoiKhaiJS = new ToKhaiLoiKhaiJS();
})

/**
 * Object JS quản lý các sự kiện cho trang danh mục câu hỏi. 
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
        var me = this;
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
        //
        $("#btnNhomA").on("click", function () {
            var a = "http://localhost:63750/api/DanhMucCauHoi/CauHoiNhomA";
            alert("API:  " + a);
            me.selectCauHoi(a);
        });

        //
        $("#btnNhomB").on("click", function () {
            var b = "http://localhost:63750/api/DanhMucCauHoi/CauHoiNhomB";
            alert("API: " + b);
            me.selectCauHoi(b); 
        });
        //
        $("#btnNhomC").on("click", function () {
            var c = "http://localhost:63750/api/DanhMucCauHoi/CauHoiNhomC";
            alert("API:" + c);
            me.selectCauHoi(c);
        });
    }

    
    //------------- SELECT CÂU HỎI THEO NHÓM -------
    selectCauHoi(url) {
        try {
            $.ajax({
                url: url,
                method: "GET",
                // data: "", Truyền qua body request
                dataType: "json",
                contentType: "application/json",
            }).done(function (res) {
                if (res) {
                    // Đọc dữ liệu và gen dữ liệu với HTML:
                    $('table#tbListCauHoi tbody').empty();
                    $.each(res, function (index, item) {
                        var CauHoiInfoHTML = $(`<tr class='grid-row'>
                                                <td class='grid-cell-inner'>`+ item['MaCauHoi'] + `</td>
                                                <td class='grid-cell-inner'>`+ item['TenCauHoi'] + `</td>
                                                <td class='grid-cell-inner'>`+ item['NoiDung'] + `</td>
                                                <td class='grid-cell-inner'>`+ item['NhomCauHoi'] + `</td>
                                                <td class='grid-cell-inner'>`+ item['TrangThai'] + `</td>
                                                <td class='grid-cell-inner'>`+ item['MaDonVi'] + `</td>
                                            </tr>`);
                        
                        $('table#tbListCauHoi tbody').append(CauHoiInfoHTML);
                    })
                    // Mặc định chọn bản ghi đầu tiên có trong danh sách:
                    $('table#tbListCauHoi tbody tr').first().addClass('row-selected');
                }
            }).fail(function (response) {
                alert("Có lỗi xảy ra");
            })
        } catch (e) { console.log(e); }
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
    toolbarItemOnClick(sender) {
        try {
            var me = this;
            var formMode = sender.data;
            switch (formMode) {
                case Enum.FormMode.Add:
                    this.FormMode = Enum.FormMode.Add; 
                    // set giá trị mặc định cho các control nhập liệu"
                    $("#frmDialogDetail input").val("");
                    $('#txtMaCauHoi').val("CH" + me.generateID(5));
                    $('#txtMaDonVi').empty();
                    me.loadDonVi();
                    $("#frmDialogDetail").show(); 
                    $("#frmDialogDetail input[type='checkbox']").prop("checked", false);
                    $('#txtTenCauHoi').focus();
                    $('.default-select').prop('selected', true);
                    break;
                case Enum.FormMode.Edit:
                    this.FormMode = Enum.FormMode.Edit;
                    var rowSelected = $('tr.row-selected');
                    if (rowSelected && rowSelected.length == 1) {
                        var maCauHoi = $('tr.row-selected').children()[0].textContent;
                        this.MaThamSo = maCauHoi;
                        $.ajax({
                            url: "http://localhost:63750/api/DanhMucCauHoi/CauHoiID/" + maCauHoi,
                            method: "GET",
                            //data: {},
                            dataType: "json",
                            contentType: "application/json",
                        }).done(function (res) {
                            // Thực hiện binding dữ liệu lên form chi tiết:
                            var cauHoi = res;
                            $('#txtMaCauHoi').val(cauHoi['MaCauHoi']);
                            $('#txtTenCauHoi').val(cauHoi['TenCauHoi']);
                            $('#txtNoiDungCauHoi').val(cauHoi['NoiDung']);
                            $('#txtNhomCauHoi').val(cauHoi['NhomCauHoi']);
                            $('#txtTrangThai').val(cauHoi['TrangThai']);
                            $('#txtMaDonVi').val(cauHoi['MaDonVi']);
                        }).fail(function () {
                            alert("Lỗi");
                            });
                        $('#txtMaDonVi').empty();
                        me.loadDonVi();
                        $("#frmDialogDetail").show();
                        $('#frmDialogDetai input')[0].focus();
                    }
                    break;
                case Enum.FormMode.Delete:
                    var rowSelected = $('tr.row-selected');
                    if (rowSelected && rowSelected.length == 1) {
                        var maCauHoi = $('tr.row-selected').children()[0].textContent;
                        alert("Xoá câu hỏi: " + $('tr.row-selected').children()[1].textContent);
                        $.ajax({
                            url: "http://localhost:63750/api/DanhMucCauHoi/Delete/" + maCauHoi,
                            method: "DELETE",
                        }).done(function (res) {
                            // Thực hiện Load lại form
                            me.loadData();
                        }).fail(function () {
                            alert("Lỗi");
                        });
                    }
                    break;
                case Enum.FormMode.Search:
                    var maCauHoi = $('.txtsearch').val();
                    var url = "";
                    maCauHoi == "" ? url = "http://localhost:63750/api/DanhMucCauHoi"
                                : url = "http://localhost:63750/api/DanhMucCauHoi/TimKiem/" + maCauHoi;
                    try {
                        $.ajax({
                            url: url,
                            method: "GET",
                            // data: "", Truyền qua body request
                            dataType: "json",
                            contentType: "application/json",
                        }).done(function (res) {
                            if (res) {
                                // Đọc dữ liệu và gen dữ liệu với HTML:
                                $('table#tbListCauHoi tbody').empty();
                                $.each(res, function (index, item) {
                                    var CauHoiInfoHTML = $(`<tr class='grid-row'>
                                                <td class='grid-cell-inner'>`+ item['MaCauHoi'] + `</td>
                                                <td class='grid-cell-inner'>`+ item['TenCauHoi'] + `</td>
                                                <td class='grid-cell-inner'>`+ item['NoiDung'] + `</td>
                                                <td class='grid-cell-inner'>`+ item['NhomCauHoi'] + `</td>
                                                <td class='grid-cell-inner'>`+ item['TrangThai'] + `</td>
                                                <td class='grid-cell-inner'>`+ item['MaDonVi'] + `</td>
                                            </tr>`);
                                    
                                    $('table#tbListCauHoi tbody').append(CauHoiInfoHTML);
                                })
                                // Mặc định chọn bản ghi đầu tiên có trong danh sách:
                                $('table#tbListCauHoi tbody tr').first().addClass('row-selected');
                            }
                        }).fail(function (response) {
                            alert("Có lỗi xảy ra");
                        }) 
                    } catch (e) { console.log(e); }
                    break; 
                default:
            } 
        } catch (e) { } 
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
    //TODO: rowOnDbClick (đang làm dở)
    rowOnDbClick(sender) {
        $("#frmDialogDetail").show();
    }

    /**
    * Load dữ liệu 
    * */
    loadData() {
        try {
            $('table#tbListCauHoi tbody').empty();
            $.ajax({
                url: "http://localhost:63750/api/DanhMucCauHoi",
                method: "GET",
                // data: "", Truyền qua body request
                dataType: "json",
                contentType: "application/json",
            }).done(function (response) {
                if (response) {
                    // Đọc dữ liệu và gen dữ liệu từng câu hỏi với HTML:
                    $.each(response, function (index, item) {
                        var cauHoiInfoHTML = $(`<tr class='grid-row'>
                                <td class='grid-cell-inner'>`+ item['MaCauHoi'] + `</td>
                                <td class='grid-cell-inner'>`+ item['TenCauHoi'] + `</td>
                                <td class='grid-cell-inner'>`+ item['NoiDung'] + `</td>
                                <td class='grid-cell-inner'>`+ item['NhomCauHoi'] + `</td>
                                <td class='grid-cell-inner'>`+ item['TrangThai'] + `</td>
                                <td class='grid-cell-inner'>`+ item['MaDonVi'] + `</td>
                            </tr>`);
                       
                        $('table#tbListCauHoi tbody').append(cauHoiInfoHTML);
                    })
                    // Mặc định chọn bản ghi đầu tiên có trong danh sách:
                    $('table#tbListCauHoi tbody tr').first().addClass('row-selected');
                }
            }).fail(function (response) {
                alert("Có lỗi xảy ra");
            })

        } catch (e) {
            console.log(e);
        } 
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
     * Lưu dữ liệu 
     * */
    saveData(sender, a, b, c) {
        //debugger;
        var me = this;
        // Lấy dữ liệu được nhập từ các input:
        var maCauHoi = $("#txtMaCauHoi").val(),
            tenCauHoi = $("#txtTenCauHoi").val(),
            noiDung = $("#txtNoiDungCauHoi").val(),
            nhomCauHoi = $("#txtNhomCauHoi").val(),
            trangThai = $("#txtTrangThai").val(),
            maDonVi = $("#txtMaDonVi").val()
        // Từ các dữ liệu thu thập được thì build thành object câu hỏi
        var CauHoi = {
            MaCauHoi: maCauHoi,
            TenCauHoi: tenCauHoi,
            NoiDung: noiDung,
            NhomCauHoi: nhomCauHoi,
            TrangThai: trangThai,
            MaDonVi: maDonVi
        };
        if (me.FormMode == Enum.FormMode.Add) { 
            // Lưu dữ liệu vào database:
            $.ajax({
                url: "http://localhost:63750/api/DanhMucCauHoi/Add",
                method: "POST",
                data: JSON.stringify(CauHoi),
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
                url: "http://localhost:63750/api/DanhMucCauHoi/Update",
                method: "PUT",
                data: JSON.stringify(CauHoi),
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


/**
 * Object JS quản lý các sự kiện cho trang danh mục lời khai tờ khai. 
 * */
class ToKhaiLoiKhaiJS {
    constructor() {
        try {
            var me = this;
            me.loadData();
            me.loadNguoiKhai();
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
        //$("#btnAdd").click(this.showDialog);
        // $("#btnAddToKhai").on("click", Enum.FormMode.Add, this.toolbarItemOnClick.bind(this));
        $("#btnAddLoiKhai").on("click", Enum.FormMode.Add, this.toolbarItemOnClick.bind(this));
        $("#btnDeleteToKhai").on("click", Enum.FormMode.DeleteToKhai, this.toolbarItemOnClick.bind(this));
        //$("#btnDeleteLoiKhai").on("click", Enum.FormMode.Deleteloikhai, this.toolbarItemOnClick.bind(this)); // code không ăn
        //$("#btnSearchToKhai").on("click", Enum.FormMode.Search, this.toolbarItemOnClick.bind(this)); // code không ăn
        //$("#btnEdit").click(this.showDialog);// code không ăn
        $("#btnCancelLoiKhai").click(this.btnCloseOnClick);
        $("#btnCloseHeaderLoiKhai").click(this.btnCloseHeaderOnClick);

        $("#btnSaveLoiKhai").click(this.saveData.bind(this));


        $("table").on("click", "tbody tr", this.rowOnClick);
        $("table").on("dbclick", "tbody tr", this.rowOnDbClick);

        $("#btnSearchToKhai").on("click", function () {
            var maToKhai = $('.txtsearchToKhai').val();
            var url = "";
            maToKhai != "" ? url = "http://localhost:63750/api/DanhMucToKhai/TimKiem/" + maToKhai
                : url = "http://localhost:63750/api/DanhMucToKhai"; 
            try {
                $.ajax({
                    url: url,
                    method: "GET",
                    // data: "", Truyền qua body request
                    dataType: "json",
                    contentType: "application/json",
                }).done(function (res) {
                    if (res) {
                        // Đọc dữ liệu và gen dữ liệu với HTML:
                        $('table#tbListToKhai tbody').empty();
                        $.each(res, function (index, item) {
                            var ToKhaiInfoHTML = $(`<tr class='grid-row'>
                                                <td class='grid-cell-inner'>`+ item['MaToKhai'] + `</td>
                                                <td class='grid-cell-inner'>`+ item['ThoiGianKhai'] + `</td>
                                                <td class='grid-cell-inner'>`+ item['MaNguoiKhai'] + `</td>
                                            </tr>`);
                            
                            $('table#tbListToKhai tbody').append(ToKhaiInfoHTML);
                        })
                        // Mặc định chọn bản ghi đầu tiên có trong danh sách:
                        $('table#tbListToKhai tbody tr').first().addClass('row-selected');
                    }
                }).fail(function (response) {
                    alert("Có lỗi xảy ra");
                })
            } catch (e) { console.log(e); }
        });
    }
     
    

    toolbarItemOnClick(sender) {
        try {
            var me = this;
            var formMode = sender.data;
            switch (formMode) {
              
                // --Lời khai---
                case Enum.FormMode.Add:
                    this.FormMode = Enum.FormMode.Add;
                    $("#frmDialogLoiKhai").show();
                    // set giá trị mặc định cho các control nhập liệu"
                    $("#frmDialogLoiKhai input").val("");
                    $("#frmDialogLoiKhai input[type='checkbox']").prop("checked", false);
                    $('#txtLoiKhaiBao').focus();
                    break;
                //----DELETE-TO-KHAI
                case Enum.FormMode.DeleteToKhai:
                    var rowSelected = $('#tbListToKhai tr.row-selected');
                    if (rowSelected && rowSelected.length == 1) {
                        var maToKhai = $('#tbListToKhai tr.row-selected').children()[0].textContent;
                        alert("Xoá tờ khai: " + maToKhai);
                        $.ajax({
                            url: "http://localhost:63750/api/DanhMucToKhai/Delete/" + maToKhai,
                            method: "DELETE",
                        }).done(function (res) {
                            // Thực hiện binding dữ liệu lên form chi tiết:
                            me.loadData();
                        }).fail(function () {
                            alert("Lỗi");
                        });
                    } else {
                        alert("Chọn tờ khai muốn xoá");
                    }
                    break;
                    //----DELETE-LOI-KHAI
                    /*case Enum.FormMode.Deleteloikhai:
                        var rowSelected = $('#tbListLoiKhai tr.row-selected');
                        if (rowSelected && rowSelected.length == 1) {
                            var maLoiKhai = $('#tbListLoiKhai tr.row-selected').children()[0].textContent;
                            alert("Xoá lời khai: " + maLoiKhai);
                            $.ajax({
                                url: "http://localhost:63750/api/DanhMucLoiKhai/Delete/" + maLoiKhai,
                                method: "DELETE",
                            }).done(function (res) {
                                // Thực hiện binding dữ liệu lên form chi tiết:
                                me.loadData();
                            }).fail(function () {
                                alert("Lỗi");
                            });
                        }
                        break;
                        */
                case Enum.FormMode.Search:
                    
                    break;
                default:
            } 
        } catch (e) {  } 
    }

    /**
    * Sự kiện khi click button đóng dưới footer của Dialog 
    * */
    btnCloseOnClick() {
        $("#frmDialogLoiKhai").hide();
    } 
    /**
    * Sự kiện khi click Đóng trên tiêu đề của Dialog 
    * */
    btnCloseHeaderOnClick() {
        $("#frmDialogLoiKhai").hide();
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
            //---TỜ KHAI---
            $('table#tbListToKhai tbody').empty();
            $.ajax({
                url: "http://localhost:63750/api/DanhMucToKhai",
                method: "GET",
                // data: "", Truyền qua body request
                dataType: "json",
                contentType: "application/json",
            }).done(function (response) {
                if (response) {
                    // Đọc dữ liệu và gen dữ liệu từng khách hàng với HTML:
                    $.each(response, function (index, item) {
                        var ToKhaiInfoHTML = $(`<tr class='grid-row'>
                                <td class='grid-cell-inner'>`+ item['MaToKhai'] + `</td>
                                <td class='grid-cell-inner'>`+ item['ThoiGianKhai'] + `</td>
                                <td class='grid-cell-inner'>`+ item['MaNguoiKhai'] + `</td> 
                            </tr>`);
                        
                        $('table#tbListToKhai tbody').append(ToKhaiInfoHTML);
                    })
                    // Mặc định chọn bản ghi đầu tiên có trong danh sách:
                    $('table#tbListToKhai tbody tr').first().addClass('row-selected');
                }
            }).fail(function (response) {
                alert("Có lỗi xảy ra");
                })

            //---LỜI KHAI---
            $('table#tbListLoiKhai tbody').empty();
            $.ajax({
                url: "http://localhost:63750/api/DanhMucLoiKhai",
                method: "GET",
                // data: "", Truyền qua body request
                dataType: "json",
                contentType: "application/json",
            }).done(function (response) {
                if (response) {
                    // Đọc dữ liệu và gen dữ liệu từng lời khai với HTML:
                    $.each(response, function (index, item) {
                        var LoiKhaiInfoHTML = $(`<tr class='grid-row'>
                                <td class='grid-cell-inner'>`+ item['MaLoiKhai'] + `</td>
                                <td class='grid-cell-inner'>`+ item['LoiKhaiBao'] + `</td>
                                <td class='grid-cell-inner'>`+ item['MaCauHoi'] + `</td>
                                <td class='grid-cell-inner'>`+ item['MaToKhai'] + `</td>
                            </tr>`);
                       
                        $('table#tbListLoiKhai tbody').append(LoiKhaiInfoHTML);
                    })
                    // Mặc định chọn bản ghi đầu tiên có trong danh sách:
                    $('table#tbListLoiKhai tbody tr').first().addClass('row-selected');
                }
            }).fail(function (response) {
                alert("Có lỗi xảy ra ");
            })

        } catch (e) {
            console.log(e);
        }
        //---CÂU HỎI---
        try {
            $.ajax({
                url: "http://localhost:63750/api/DanhMucCauHoi",
                method: "GET",
                // data: "", Truyền qua body request
                dataType: "json",
                contentType: "application/json",
            }).done(function (res) {
                if (res) {
                    // Đọc dữ liệu và gen dữ liệu với HTML:
                    $.each(res, function (index, item) {
                        var CauHoiInfoHTML = $(`<option value="`+ item['MaCauHoi'] + `">` + item['NoiDung'] + `</td>`);
                      
                        $('#txtMaCauHoi_LoiKhai').append(CauHoiInfoHTML);
                    })
                   
                }
            }).fail(function (response) {
                alert("Có lỗi xảy ra");
            })

        } catch (e) {
            console.log(e);
        }
    }
    //-----LOAD NGƯỜI KHAI----
    loadNguoiKhai() { 
        try {
            $.ajax({
                url: "http://localhost:63750/api/NguoiKhaiBao",
                method: "GET",
                // data: "", Truyền qua body request
                dataType: "json",
                contentType: "application/json",
            }).done(function (res) {
                if (res) {
                    // Đọc dữ liệu và gen dữ liệu với HTML:
                    $.each(res, function (index, item) {
                        var NguoiKhaiInfoHTML = $(`<option value="` + item['MaNguoiKhai'] + `">` + item['TenNguoiKhai'] + `</td>`);
                       
                        $('#txtNguoiKhai').append(NguoiKhaiInfoHTML);
                    })
                    // Mặc định chọn bản ghi đầu tiên có trong danh sách: 
                }
            }).fail(function (response) {
                alert("Có lỗi xảy ra");
            }) 
        } catch (e) { console.log(e); }
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
    /**
     * Lưu dữ liệu
     * */
    saveData(sender, a, b, c) {
        //debugger;
        var me = this;
        // Lấy dữ liệu được nhập từ các input:
        var maLoiKhai = "LK" + me.generateID(5),//$("#txtMaLoiKhai").val(),
            loiKhaiBao = $("#txtLoiKhaiBao").val(),
            maCauHoi = $("#txtMaCauHoi_LoiKhai").val(),
            maToKhai = "TK" + me.generateID(5), //$("#txtMaToKhai_LoiKhai").val()
            maNguoiKhai = $("#txtNguoiKhai").val()
        // Từ các dữ liệu thu thập được thì build thành object loikhai
        var LoiKhai = {
            MaLoiKhai: maLoiKhai,
            LoiKhaiBao: loiKhaiBao,
            MaCauHoi: maCauHoi,
            MaToKhai: maToKhai
        };
        var ToKhai = {
            MaToKhai: maToKhai,
            MaNguoiKhai: maNguoiKhai
        }
        if (me.FormMode == Enum.FormMode.Add) {
            // Lưu dữ liệu vào database:
            $.ajax({
                url: "http://localhost:63750/api/DanhMucToKhai/Add",
                method: "POST",
                data: JSON.stringify(ToKhai),
                dataType: "json",
                contentType: "application/json"
            }).done(function (res) {
                // Thêm lời khai thành công thì sẽ thêm tờ khai
                // Lưu dữ liệu vào database:
                $.ajax({
                    url: "http://localhost:63750/api/DanhMucLoiKhai/Add",
                    method: "POST",
                    data: JSON.stringify(LoiKhai),
                    dataType: "json",
                    contentType: "application/json"
                }).done(function (res) {
                    // Hiển thị thông báo cất thành công/ thất bại:
                    alert("Thêm thành công!");
                    // Đóng/ ẩn Form:
                    $("#frmDialogLoiKhai").hide();
                    // load lại dữ liệu
                    me.loadData();
                }).fail(function (res) {
                    debugger
                });
            }).fail(function (res) {
                debugger
            });
        } else if (me.FormMode == Enum.FormMode.Edit) {
            // Lưu dữ liệu vào database:
            $.ajax({
                url: "http://localhost:63750/api/DanhMucCauHoi/Update",
                method: "PUT",
                data: JSON.stringify(CauHoi),
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
