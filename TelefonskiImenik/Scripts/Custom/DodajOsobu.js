$(document).ready(function () {

    $("#slika").change(function () {                //funkcija koja ispisuje naziv slike
        $("#slikaTekst").text(this.files[0].name);
    });

    $("#btn1").click(function () {
        var osoba = new Object();
        osoba.Ime = $("#ime").val();
        osoba.Prezime = $("#prezime").val();
        osoba.Grad = $("#grad").val();
        osoba.Opis = $("#opis").val();
        osoba.Slika = slikabo;
        $.ajax({
            url: "api/Kontakt/DodajOsobu",
            type: "POST",
            datatype: 'json',
            contentType: "application/json",
            data: JSON.stringify(osoba),
            success: function (data) {
                alert('Uspješno spremljeno');

            }
        });
    });
});

var slikabo;

var handleFileSelect = function (evt) {
    var files = evt.target.files;
    var file = files[0];

    if (files && file) {
        var reader = new FileReader();

        reader.onload = function (readerEvt) {
            var binaryString = readerEvt.target.result;
            slikabo = btoa(binaryString);
        };

        reader.readAsBinaryString(file);
    }
};

if (window.File && window.FileReader && window.FileList && window.Blob) {
    document.getElementById('slika').addEventListener('change', handleFileSelect, false);
}