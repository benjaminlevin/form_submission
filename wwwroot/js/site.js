$(document).ready(function(){
    // no functions
});

$("#submit").click(function(e){
    e.preventDefault();
    var first = $('input[name="FirstName"]').val();
    var last = $('input[name="LastName"]').val();
    var age = $('input[name="Age"]').val();
    var email = $('input[name="Email"]').val();
    var password = $('input[name="Password"]').val();
    $.post('/submit', { FirstName: first, LastName: last, Age: age, Email: email, Age: age, Password: password }, (result) => {
        $("#errors").html(""); //reset error messages
        if(result == "Success")
        {
            $("#errors").html("<h1>Successfully Registered!</h1>");
            $("#main").html("");
            $("#title").html("Success!");
        }
        else
        {
            var str = "";
            var i = 0;
            str += "<ul>";
            while(i<result.length)
            {
                if(result[i].errors[0] == undefined)
                {
                    str += "";
                }
                else
                {
                    str += "<li>";
                    str += result[i].errors[0].errorMessage;
                    str += "</li>";
                }
                i++;
            }
            str += "</ul>";
            $("#errors").html(str);
        }
    }
)
});