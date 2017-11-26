$(document).ready(function () {
    $("#btn1").click(function () {
        var broj = new Object();
        broj.OsobaId = $("#osobaId").val();
        broj.BrojTipId = $("#brojTipId").val();
        broj.Broj = $("#broj").val();
        broj.Opis = $("#opis").val();
        $.ajax({
            url: "/api/Kontakt/DodajBroj",
            type: "POST",
            datatype: 'json',
            contentType: "application/json",
            data: JSON.stringify(broj),
            success: function (data) {
                alert('Uspješno spremljeno');
            } 
        });
    });
});