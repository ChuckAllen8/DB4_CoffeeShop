// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

//
//background code
//
var canvas;
var ctx;
var desiredInterval;
var height;
var width;
var shipImg;
var shipX;
var shipY;
var shipDirectional;

function updateSize() {
    //todo: adjust canvas size to size of document body.
    var oldWidth = width;
    height = Math.max($(document).height(), $(window).height());
    width = Math.max($(document).width(), $(window).width());
    shipX = shipX + ((width - oldWidth)/2);
    canvas.setAttribute("width", width);
    canvas.setAttribute("height", height);
}

function updateBackground() {
    document.body.style.background = "url(" + canvas.toDataURL() + ") no-repeat fixed center center /cover";
}

function updateAnimation() {
    //todo: update locations and draw
    if (shipY > (height - shipImg.height)) {
        shipY = shipY - 3;
    }
    else {
        if (Math.floor(Math.random() * 10) < 1) {
            shipDirectional = -1 * shipDirectional;
        }
        shipX = shipX + shipDirectional;
    }
    ctx.drawImage(shipImg, shipX, shipY, shipImg.width, shipImg.height);
}

function prepareAnimation() {
    shipImg = document.getElementById("shipImage");;
    canvas = document.getElementById("background");
    ctx = canvas.getContext("2d");
    desiredInterval = 50;
    height = Math.max($(document).height(), $(window).height());
    width = Math.max($(document).width(), $(window).width());
    shipX = ((width / 2) - (shipImg.width / 2));
    shipY = height - 15;
    shipDirectional = 2;
}

//occurs when the document is ready, calls setInterval to make the updates happen every so often
$(document).ready(function () {
    prepareAnimation();
    setInterval(() => {
        updateSize();
        updateAnimation();
        updateBackground();
    }, desiredInterval);
});

//
//end background code
//



//
//validation code
//

$(document).on("change", "input[name=delivery]", function () {
    var test = $(this).val();
    if (test === "pickup") {
        $("#pickup").show();
        $("#delivery").hide();
    }
    else {
        $("#pickup").hide();
        $("#delivery").show();
    }
});

function checkForm(form) {
    //validate time on pickup to be in the future, validate address otherwise
    if (form.delivery.value === "pickup") {
        var d = new Date();
        var m = d.getMinutes();
        var h = d.getHours();
        if (h === '0') { h = 24 }
        if (h < "10") { h = "0" + h}
        var currentTime = h + ":" + m;
        if (form.time.value <= currentTime) {
            alert("Time must be in the future");
            return false;
        }
    }
    else {
        if (form.address1.value === "" || form.addressCity.value === "" || form.addressState.value === "" || form.addressZip.value === "") {
            alert("Please enter a complete address")
            return false;
        }
        var addressLine1 = form.address1.value.split(" ");
        if (addressLine1.length < 2) {
            alert("Address requires a street number and name")
            return false;
        }
        if (isNaN(parseInt(addressLine1[0]))) {
            alert("Address requires the street number first")
            return false;
        }

        if (isNaN(parseInt(form.addressZip.value))) {
            alert("Zip Code must be a valid number")
            return false;
        }
    }

    return true;
}

//
//end validation code
//


//code for miscellaneous functions
function Expand(id) {
    var section = document.getElementById(id);
    if (section.style.display === "none") {
        section.style.display = "inherit";
    }
    else {
        section.style.display = "none";
    }
}