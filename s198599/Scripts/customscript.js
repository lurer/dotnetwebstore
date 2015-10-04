//Fellesfunksjon for å oppdatere innholdet i handlekurver
function updateBasket(myBasket) {
    var Items = myBasket["Items"];
    $('#numItemsInCart').text(" " + Items.length);
    $('#priceItemsInCart').text(" " + myBasket["PriceOfCart"]);
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
        },
        error: function (xhr, ajaxOptions, thrownError) {
            alert("Temp debugging. Adding Item ot Cart Failed" + thrownError);
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
            alert("Temp debug: " + thrownError);
        }
    });

}
