//Fellesfunksjon for å oppdatere innholdet i handlekurver
function updateBasket(myBasket) {
    var Items = myBasket["Items"];
    $('#numItemsInCart').text(" " + Items.length);
    $('#priceItemsInCart').text(" " + myBasket["PriceOfCart"]);
}

function deleteSessionMessageDiv() {
    var parent = document.getElementById("information_area");
    while (parent.firstChild) {
        parent.removeChild(parent.firstChild);
    }
}

//Skal fade ut Session-meldingen, og slette div'en 3 sek. etterpå
function fadeOutSessionMessage() {
    if ($('#information_bar') != null) {
        $('#information_bar').fadeOut(3000);
        setTimeout(deleteSessionMessageDiv, 3000);
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
        case "success":
            div_info.className = div_info.className + " alert-success";
            break;
        case "info":
            div_info.className = div_info.className + " alert-info";
            break;
        case "fail":
            div_info.className = div_info.className + " alert-danger";
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
            feedbackMessage("success", "The product is added to your shopping cart!");
        },
        error: function (xhr, ajaxOptions, thrownError) {
            feedbackMessage("fail", "Something went wrong. The Item is not added to your shopping cart!");
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
            feedbackMessage("fail","Something went wrong. Your shopping cart is not updated");
        }
    });

}
