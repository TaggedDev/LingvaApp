function filter_articles() {
    var inputs = document.querySelector("form").children;
    var i_lang = inputs[0].value;
    var i_level = inputs[1].value;
    $.ajax({
        type: "POST",
        url: "/Articles/ReturnFiltersResult",
        data: {
            lang: i_lang,
            level: i_level
        },
        success: function (data) {
            $("#articles_content").html(data);
            
        },
        error: function (data) {
            console.log(data);
        }
    })
}