$(document).ready(function () {
    $("#btn1").click(function () {
        var broj = new Object();
        broj.OsobaId = $("#osobaId").val();
        broj.BrojTipId = $("#brojTipId").val();
        broj.Broj = $("#broj").val();
        broj.Opis = $("#opis").val();
        $.ajax({
            url: "/api/Kontakt/DodajBroj",
            processData: false,
            type: "POST",
            datatype: 'json',
            contentType: "application/json",
            data: JSON.stringify(broj),
            success: function (data) {
                alert('Uspješno spremljeno!'),
                    window.location.href = "/KontaktMVC/DodajBroj";
            },
            error: function (data) {
                alert('Nešto je pošlo po krivu, molim pokušaj ponovno!'),
                    window.setTimeout(window.location.reload.bind(window.location), 300);
            }
        });
    });
});