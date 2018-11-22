window.onload = function () {
    var rio = document.getElementById("rio");
    var rio2 = document.getElementById("rio2");

    rio.onclick = function () {
        mudarFonte('rio');
    }
    rio2.onclick = function () {
        mudarFonte('rio2');
    }

}
function mudarText(nome) {
    if (nome == 'rio') {
        document.getElementById('rev').innerHTML = '7 dez, 2018';
        document.getElementById('de').innerHTML = 'De Viracopos - Aeroporto Internacional de Campinas (VCP)';
        document.getElementById('para').innerHTML = 'Para Arturo Merino Benitez (SCL)';
    }
    else if (nome == 'rio2') {
        document.getElementById('rev').innerHTML = '72222 dez, 2018';
        document.getElementById('de').innerHTML = 'De Viracopos - Aeroporto Internacional de Campinas (VCP)';
        document.getElementById('para').innerHTML = 'Para Arturo Merino Benitez (SCL)';
    }
}