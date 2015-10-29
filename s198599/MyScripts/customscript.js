




//Fellesfunksjon for å oppdatere innholdet i handlekurver
function updateBasket(myBasket) {
    var Items = myBasket["Items"];
    $('#numItemsInCart').text(" " + Items.length);
    $('#priceItemsInCart').text(" " + myBasket["PriceOfCart"]);
}

function deleteSessionMessage() {
    var id = document.getElementById("information_bar");
    id.className = "alert hidden";
    id.innerHTML = "";
}

function slideInfoBarUp() {
    $('#information_bar').slideUp(1000);
}

//Skal fade ut Session-meldingen, og slette div'en 3 sek. etterpå
function fadeOutSessionMessage() {
    if ($('#information_bar') != null) {
        setTimeout(deleteSessionMessage, 5000);
        setTimeout(slideInfoBarUp, 2000);
    }
}

//Hjelpemetode for å oppdatere status etter CRUD
function feedbackMessage(type, message) {

    var div_info = document.getElementById("information_bar");
    if (!div_info) {
        div_info = document.createElement("div");
        div_info.id = "information_bar";
        div_info.className = "alert";
    }
    div_info.appendChild(document.createTextNode(message));
    switch (type) {
        case "SUCCESS":
            div_info.className = "alert alert-success";
            break;
        case "INFO":
            div_info.className = "alert alert-info";
            break;
        case "FAIL":
            div_info.className = "alert alert-danger";
            break;
    }
    $('#information_area').append(div_info);
    fadeOutSessionMessage();

}



//Når man trykker på "Kjøp" skal denne kjøres. Den oppdaterer handlekurven etterpå
function buyItem(itemId) {
   
    var myurl = "AddItemToCart";
    $.ajax({
        url: myurl,
        data: { 'id': itemId },
        type: "post",
        cache: false,
        success: function (myBasket) {
            updateBasket(myBasket);
            feedbackMessage("SUCCESS", "The product is added to your shopping cart!");
        },
        error: function (xhr, ajaxOptions, thrownError) {
            feedbackMessage("FAIL", "Something went wrong. The Item is not added to your shopping cart!");
        }
    });

}

//Kjører hver gang man kommer inn på Produktsidene    
function getUpdatedBasket(myurl) {
    $.ajax({
        url: myurl,
        type: "POST",
        cache: false,
        success: function (myBasket) {
            updateBasket(myBasket);
        },
        error: function (xhr, ajaxOptions, thrownError) {
            feedbackMessage("FAIL","Something went wrong. Your shopping cart is not updated");
        }
    });

}



function display_order_detail_modal(orderJson) {
    var modal = $('#orderDetailModal');
    var items = orderJson.Items;
    var orderItemsDiv = $('#orderItems');
    var tmp = new Date(parseInt(orderJson.DateTime.substr(6)));
    var newDate = tmp.toUTCString();

    var tblstr = "<table class='table table-responsive table-condensed table-striped'><tr>";
    tblstr += "<th>Amount</th>";
    tblstr += "<th>Item Code</th>";
    tblstr += "<th>Description</th>";
    tblstr += "<th>Price</th></tr>";
    
    for (var i = 0; i < orderJson.Items.length; i++) {

        tblstr += "<tr>";
            tblstr += "<td>" + items[i].Amount + "</td>";
            tblstr += "<td>" + items[i].Item.ItemCode + "</td>";
            tblstr += "<td>" + items[i].Item.ItemDesc + "</td>";
            tblstr += "<td> NOK " + items[i].Item.Price.toFixed(2) + "</td>";
        tblstr += "</tr>"
    }
    
    tblstr += "</table>";

    $('#orderHeading').text(orderJson.OrderNumber);
    $('#orderDate').text(newDate);
    $('#orderTotal').text("NOK " + orderJson.OrderPriceTotal.toFixed(2));
    $('#orderItems').html(tblstr);

    modal.modal('show');
    
}


//////////////////////////////////////////////////////////////////////
/////////    Item-metoder ///////////////
//////////////////////////////////////////////////////////////////////





function getCategories(itemList) {

    $.ajax({
        type: "GET",
        cache: false,
        //url: '@Url.Action("getCategoryNameList", "ItemCategories")',
        url: 'ItemCategories/getCategoryNameList',
        success: function (categoryList) {
            writeItemListResult(itemList, categoryList);
        },
        error: function (err) {
            feedbackMessage("FAIL", "The Category field might be inaccurate!");
        }
    });
}

function getItems() {

    $.ajax({
        type: "GET",
        cache: false,
        //url: '@Url.Action("GetItemsAsJson", "Item")',
        url: 'Item/GetItemsAsJson',
        success: function (itemList) {
            getCategories(itemList);
        },
        error: function (err) {
            feedbackMessage("FAIL", "We are so sorry, but the products could not be loaded from the database!");
        }
    });
}

function editItem(id) {
    
    window.location.href = 'Item/Edit/'+id;

}

function deleteItem(id) {
    var form = $('#_AjaxAntiForgeryForm');
    var token = $('input[name="__RequestVerificationToken"]', form).val();

    $.ajax({
        type: "POST",
        cache: false,
        data: {
            __RequestVerificationToken: token,
            'id': id
        },
        //url: '@Url.Action("Delete", "Item")',
        url: 'Item/Delete',
        success: function () {
            getItems();
            feedbackMessage("SUCCESS", "The item is deleted from the database");
        },
        error: function (err) {
            feedbackMessage("FAIL", "Something went wrong. We can not determine if the deletions was successful!");
        }
    })
}




function writeItemListResult(itemList, categoryList) {


    var output = "";
    output += "<table class='table'>";
    output += "<tr>";
    output += "<th>Item Code</th>";
    output += "<th>Description</th>";
    output += "<th>In stock</th>";
    output += "<th>Price</th>";
    output += "<th>Category</th>";
    output += "<th>Image Path</th>";
    output += "<th></th>";

    output += "</tr>";
    for (var i = 0; i < itemList.length; i++) {
        output += "<tr>";
        output += "<td>" + itemList[i].ItemCode + "</td>";
        output += "<td>" + itemList[i].ItemDesc + "</td>";
        output += "<td>" + itemList[i].InStock + "</td>";
        output += "<td>" + itemList[i].Price + "</td>";
        output += "<td>";
        var name;
        for (var j = 0; j < categoryList.length; j++) {
            if (itemList[i].Category == categoryList[j].CategoryId) {
                name = categoryList[j].CategoryName;
                break;
            }
        }
        output += name;
        output += "</td>";
        output += "<td>" + itemList[i].ImgPath + "</td>";
        output += "<td>";
        output += '<a href="" onclick="editItem(' + itemList[i].ItemID + '); return false;" class="btn btn-warning btn-sm linkBtnMargin">Edit</a>';
        output += '<a href="" onclick="deleteItem(' + itemList[i].ItemID + '); return false;" class="btn btn-danger btn-sm linkBtnMargin">Delete</a>';


        output += "</td>";
        output += "</tr>";
    }

    output += "</table>";

    $('#result').html(output);
}