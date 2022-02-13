function load_likes(article_id) {
    $.ajax({
        type: "POST",
        url: "/Articles/GetLikes",
        async: false,
        data: {
            id: article_id
        },
        success: function (data) {
            $("#likes").html(data);
            set_isLiked_status();
        },
        error: function (data) {
            console.log(data);
        }
    })

    function set_isLiked_status() {
        $.ajax({
            type: "POST",
            url: "/Articles/IsLiked",
            data: {
                id: article_id
            },
            success: function (data) {
                if (data === true) {
                    $("#like_icon").addClass("liked");
                    $("#like_icon").attr("src", "/assets/like_green.svg");
                }
            },
            error: function (data) {
                console.log(data);
            }
        })
    }
}

function add_like(article_id) {
    if ($("#like_icon").hasClass("liked")) {
        $.ajax({
            type: "POST",
            url: "/Articles/RemoveLike",
            data: {
                id: article_id
            },
            success: function (data) {
                $("#like_icon").removeClass("liked");
                $("#like_icon").attr("src", "/assets/like_black.svg");
                console.log("Success 2");
                var likes_span = $("#likes");
                var likes = parseInt(likes_span.text());
                likes_span.text(likes - 1);
            },
            error: function (data) {
                console.log(data);
            }
        })
    } else {
        $.ajax({
            type: "POST",
            url: "/Articles/AddLike",
            data: {
                id: article_id
            },
            success: function (data) {
                $("#like_icon").addClass("liked");
                $("#like_icon").attr("src", "/assets/like_green.svg");
                console.log("Success 1");
                var likes_span = $("#likes");
                var likes = parseInt(likes_span.text());
                likes_span.text(likes + 1);
            },
            error: function (data) {
                console.log(data);
            }
        })
    }
    
}