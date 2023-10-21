(function () {
    window.addEventListener("load", function () {
        setTimeout(function () {
            var logo = document.getElementsByClassName('link');
            logo[0].href = "http://www.itnuevolaredo.edu.mx/pages/ofertaIngenieriaSistemasComputacionales";
            logo[0].target = "_blank";

            logo[0].children[0].alt = "web-api-simposium";
            logo[0].children[0].src = "../swagger-ui/logo-isc.jpg";
        });
    });
})();