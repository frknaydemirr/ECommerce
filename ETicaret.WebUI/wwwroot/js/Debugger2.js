$(document).ready(function () {

    $(".add-to-favorites").click(function (e) {
        e.preventDefault();

        var productId = $(this).data("id");

        // AJAX ile sepete ekle
        $.ajax({
            url: '/Cart/Add',
            type: 'POST',
            dataType: 'json',
            data: { ProductId: productId },
            success: function (data) {
                // debugger; // Başarılı response geldiğinde durmak istersen buraya koyabilirsin
                if (data.success) {
                    // Sepet sayısını güncelle
                    $("#cartCount").text(data.cartCount);

                    Swal.fire({
                        icon: 'success',
                        title: 'Başarılı!',
                        text: `"${data.productName}" favoriye eklendi.`,
                        confirmButtonText: 'Tamam'
                    });
                } else {
                    console.warn("AJAX response hatası:", data);
                    Swal.fire({
                        icon: 'error',
                        title: 'Hata!',
                        text: data.message || 'Ürün favoriye eklenemedi.'
                    });
                }
            },
            error: function (xhr, status, error) {
                debugger; // Hata olduğunda kod burada durur
                console.error("AJAX Hata Detayları:");
                console.error("Status:", status);
                console.error("Error:", error);
                console.error("Response Text:", xhr.responseText);
                console.error("XHR Object:", xhr);

                Swal.fire({
                    icon: 'error',
                    text: `"${data.productName}" favoriye eklenirken bir hata oluştu!`,
                    text: 'Lütfen tekrar deneyin.'
                });
            }
        });
    });

});
