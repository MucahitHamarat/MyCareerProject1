function CallCategory() {
    //alert("sessizlik");
    $.ajax({
        url: "/AJAX/SubCategories",
        type: "GET",
        data: { "id": $(".trying").val() },
        success: function (gelenVeri) {

            $(".subcategories").empty();
            $(".subcategories").append("<option value='0'>Alt Kategoriler</option>");
            $.each(gelenVeri, function (index, item) {
                $(".subcategories").append("<option value='" + item.ID + "'>" + item.Name + "</option>");
            })
        },
        error: function (hata) { alert(hata.responseText) }
    });
} 

function CallCategory2() {
    //alert("sessizlik");
    $.ajax({
        url: "/AJAX/SubCategories2",
        type: "GET",
        data: { "id2": $(".trying2").val() },
        success: function (gelenVeri) {

            $(".subcategories2").empty();
            $(".subcategories2").append("<option value='0'>Alt Kategoriler</option>");
            $.each(gelenVeri, function (index, item) {
                $(".subcategories2").append("<option value='" + item.ID + "'>" + item.Name + "</option>");
            })
        },
        error: function (hata) { alert(hata.responseText) }
    });
} 
//burası ilana şehir ekleme kısmı// //burası ilana şehir ekleme kısmı//
 //burası ilana şehir ekleme kısmı// //burası ilana şehir ekleme kısmı//


function CallCategory2() {
    //alert("sessizlik");
    $.ajax({
        url: "/AJAX/SubCategories2",
        type: "GET",
        data: { "id2": $(".trying2").val() },
        success: function (gelenVeri) {

            $(".subcategories2").empty();
            $(".subcategories2").append("<option value='0'>Alt Kategoriler</option>");
            $.each(gelenVeri, function (index, item) {
                $(".subcategories2").append("<option value='" + item.ID + "'>" + item.Name + "</option>");
            })
        },
        error: function (hata) { alert(hata.responseText) }
    });
} 



