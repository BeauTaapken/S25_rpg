// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function setInfoText(infoText) {
    var textBar = document.getElementById("informationText");
    textBar.textContent = infoText;
}

function setInfoEmpty() {
    var textBar = document.getElementById("informationText");
    textBar.textContent = "";
}

function openModalWithData(modalname, name, description, requirement, reward) {
    $('#' + modalname).modal('toggle');
    $(".modal-header #questName").text(name);
    $(".modal-body #questDescription").text(description);
    $(".modal-body #questRequirement").text(requirement);
    $(".modal-body #questReward").text(reward);
}