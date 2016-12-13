"use strict";

function AddProperty() {

    var propertiesContainer = $("tbody[class=properties]");

    var properties = propertiesContainer[0].children;
    var newPropertyId = 0;
    if (properties.length !== 0) {
        newPropertyId = +(properties[properties.length - 1].id) + 1;
    }
    
    propertiesContainer.append(
        '<tr id="' + newPropertyId + '" title="New Property">' +
            "<td>" +
                '<input data-val="true" data-val-number="The field Id must be a number." data-val-required="The Id field is required." id="property_Id" name="property.Id" type="hidden" value="0" />' +
                '<input class="text-box single-line" data-val="true" data-val-required="Property name field is empty" id="property_Name" name="property.Name" type="text" value="" />'+
                '<span class="field-validation-valid" data-valmsg-for="property.Name" data-valmsg-replace="true"></span>' +
            "</td>" +
            '<td><textarea cols="20" id="property_Description" name="property.Description" rows="2"></textarea></td>' +
            "<td>" +
                '<a href="#" id="' + newPropertyId + '" onclick="DeleteProperty(event)"  class="btn btn-danger delete_property">Delete Property</a>' +
            "</td>" +
        "</tr>"
    );

}

function DeleteProperty(event) {

    var numberOfProperty = event.target.id;

    $("tr[id^=" + numberOfProperty + "]").remove();

    console.log(numberOfProperty);
}

$(".loaderbtn").click(function () {
    console.log("Loading");
    $(".loader").css("display", "block");
    $(".loaderscreen").css("display", "block");
});