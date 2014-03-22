// manual examples of calling the service

// http xml request
(function () {
    // xmlhttp = new ActiveXObject("Msmxl2.XMLHTTP");
    // xmlhttp = new ActiveXObject("Microsoft.XMLHTTP");
    // xmlhttp = window.createRequest(); 
    var xmlhttp = new XMLHttpRequest();
    xmlhttp.open("GET", "http://localhost:49676", true);
    xmlhttp.onreadystatechange = function() {
        if (xmlhttp.readyState == 4) {
            console.log(xmlhttp.responseText);
        }
    };
    xmlhttp.send(null);
})();


// JSONP
(function () {
    var url = "http://localhost:49676/home/jsonp",
        script = document.createElement('script');

    window.parseJson = function(response) {
        console.log(response);
    };

    script.setAttribute('src', url);
    document.getElementsByTagName('head')[0].appendChild(script);
})();