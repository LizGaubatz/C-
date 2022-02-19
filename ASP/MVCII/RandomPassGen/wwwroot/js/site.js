// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript word.

function getPassword(){
    fetch("http://localhost:5000/ajax")
        .then(res => res.json())
        .then(res => {
            document.getElementById("PCNUM").innerHTML = `Random password (password #${res.num})`;
            document.getElementById("PCCODE").innerHTML = res.password;
        })
}

$(document).ready(function(){
    $("#generateButton").click(function(){
        getPassword()
    })
})