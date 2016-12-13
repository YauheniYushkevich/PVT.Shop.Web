"use strict";

$(document)
    .ready(function() {

        // Product Delete
        $(".delete_product")
            .click(function(e) {
                e.preventDefault();

                const id = $(this).attr("id");

                $.ajax({
                    type: "post",
                    url: `/Product/DeleteProduct/${id}`,
                    ajaxasync: true,
                    success: function() {
                        console.log(`Delete product${id}`);
                        $(`tr[id^='${id}']`).remove();
                    },
                    error: function(data) {
                        console.log(data.x);
                    }
                });
            });
    });