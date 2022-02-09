function filter_articles() {
    var inputs = document.querySelector("form").children;
    var i_lang = inputs[0].value;
    var i_level = inputs[1].value;
    var i_author = inputs[2].value;
    var i_tags = inputs[3].value;
    $.ajax({
        type: "POST",
        url: "/Articles/ReturnFiltersResult",
        data: {
            lang: i_lang,
            level: i_level,
            author: i_author,
            tags: i_tags
        },
        success: function (data) {
            $("#articles").html(data);
            
        },
        error: function (data) {
            console.log(data);
        }
    })
}