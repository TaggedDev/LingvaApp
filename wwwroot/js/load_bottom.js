let iterator = 0;
let inputs_values = ["", "", "", "", ""];
window.addEventListener('scroll', () => {
    const scrollableSpace = document.documentElement.scrollHeight - window.innerHeight;
    if (Math.ceil(scrollableSpace) === window.scrollY) {
        var inputs = document.querySelector("form").children;
        var i_lang = inputs[0].value;
        var i_level = inputs[1].value;
        var i_author = inputs[2].value;
        var i_tags = inputs[3].value;

        if (inputs_values[0] == i_lang && inputs_values[1] == i_level && inputs_values[2] == i_author && inputs_values[3] == i_tags) {
            iterator += 1;
        } else {
            inputs_values[0] = i_lang;
            inputs_values[1] = i_level;
            inputs_values[2] = i_author;
            inputs_values[3] = i_tags;
            iterator = 1;
        }

        $.ajax({
            type: "POST",
            url: "/Articles/ReturnBottomArticles",
            data: {
                lang: i_lang,
                level: i_level,
                author: i_author,
                tags: i_tags,
                index: iterator
            },
            success: function (data) {
                var elem = $("#articles");
                $(data).appendTo(elem);
            },
            error: function (data) {
                console.log(data);
            }
        })
    }
})