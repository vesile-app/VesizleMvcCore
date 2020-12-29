var movieId = $('#favorite').attr("movie-id");
$.get("/Profile/IsFavorite/", { "movieId": movieId }).done(function (data) {
    if (data) {
        $('#favorite').attr("checked", "checked");
    }
}).fail(function () {
    //todo:toastify
    Toastify({
        text: data.message,
        backgroundColor: "red"
    }).showToast();
});

$('#favorite').click(function () {
    var checkBox = $(this);
    $.post("/Profile/AddFavorite",
        {
            "movieId": movieId
        }).done(function (data) {
            if (data.isSuccessful) {
                var h6 = document.createElement("h6");
                if (data.message.toLowerCase().includes("remove")) {
                    h6.innerHTML = "<i class=\"fas fa-trash-alt  mr-2 text-dark\"></i>" + data.message;
                } else {
                    h6.innerHTML = "<i class=\"fa fa-heart  mr-2 text-danger\"></i>" + data.message;
                }
                Toastify({
                    text: data.message,
                    stopOnFocus: true,
                    destination: "/Profile/Favorites",
                    newWindow: true,
                    offset: {
                        y: 50
                    },
                    node: h6
                }).showToast();
            } else {
                Toastify({
                    text: data.errors.map(e => e.description).join(" ,"),
                    backgroundColor: "red"
                }).showToast();
            }
        }).fail(function () {
            //todo:toastify
            Toastify({
                text: data.message,
                backgroundColor: "red"
            }).showToast();
        });

});

$.get("/Profile/IsWatchList/", { "movieId": movieId }).done(function (data) {
    if (data) {
        $('#watch').attr("checked", "checked");
    }
}).fail(function () {
    //todo:toastify
    Toastify({
        text: data.message,
        backgroundColor: "red",
        className: "bg-danger"
    }).showToast();
});

$('#watch').click(function () {
    var checkBox = $(this);
    $.post("/Profile/AddWatchList",
        {
            "movieId": movieId
        }).done(function (data) {
            if (data.isSuccessful) {
                var h6 = document.createElement("h6");
                if (data.message.toLowerCase().includes("remove")) {
                    h6.innerHTML = "<i class=\"fas fa-trash-alt mr-2 text-dark\"></i>" + data.message;
                } else {
                    h6.innerHTML = "<i class=\"fa fa-eye  mr-2 text-danger\"></i>" + data.message;
                }
                Toastify({
                    text: data.message,
                    stopOnFocus: true,
                    destination: "/Profile/WatchList",
                    newWindow: true,
                    offset: {
                        y: 50
                    },
                    node: h6
                }).showToast();
            } else {
                Toastify({
                    text: data.errors.map(e => e.description).join(" ,"),
                    backgroundColor: "red",
                    className: "bg-danger"
                }).showToast();
            }
        }).fail(function () {
            //todo:toastify
            Toastify({
                text: data.message,
                backgroundColor: "red",
                className: "bg-danger"
            }).showToast();
        });

});

$.get("/Profile/IsWatchedList/", { "movieId": movieId }).done(function (data) {
    if (data) {
        $('#watched').attr("checked", "checked");
    }
}).fail(function () {
    //todo:toastify
    Toastify({
        text: data.message,
        backgroundColor: "red",
        className: "bg-danger"
    }).showToast();
});

$('#watched').click(function () {
    var checkBox = $(this);
    $.post("/Profile/AddWatchedList",
        {
            "movieId": movieId
        }).done(function (data) {
            if (data.isSuccessful) {
                var h6 = document.createElement("h6");
                if (data.message.toLowerCase().includes("remove")) {
                    h6.innerHTML = "<i class=\"fas fa-trash-alt mr-2 text-dark\"></i>" + data.message;
                } else {
                    h6.innerHTML = "<i class=\"fa fa-ticket-alt  mr-2 text-danger\"></i>" + data.message;
                }
                Toastify({
                    text: data.message,
                    stopOnFocus: true,
                    destination: "/Profile/WatchedList",
                    newWindow: true,
                    offset: {
                        y: 50
                    },
                    node: h6
                }).showToast();
            } else {
                Toastify({
                    text: data.errors.map(e => e.description).join(" ,"),
                    backgroundColor: "red",
                    className: "bg-danger"
                }).showToast();
            }
        }).fail(function () {
            //todo:toastify
            Toastify({
                text: data.message,
                backgroundColor: "red",
                className: "bg-danger"
            }).showToast();
        });

});

