// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


var canvas;
var ctx;
var desiredInterval = 100;
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
    if (Math.floor(Math.random() * 10) < 2) {
        shipDirectional = -1 * shipDirectional;
    }
    shipX = shipX + shipDirectional;
    ctx.drawImage(shipImg, shipX, shipY, shipImg.width, shipImg.height);
}

function prepareAnimation() {
    shipImg = document.getElementById("shipImage");;
    canvas = document.getElementById("background");
    ctx = canvas.getContext("2d");
    desiredInterval = 100;
    height = Math.max($(document).height(), $(window).height());
    width = Math.max($(document).width(), $(window).width());
    shipX = ((width / 2) - (shipImg.width / 2));
    shipY = (height - shipImg.height);
    shipDirectional = 3;
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