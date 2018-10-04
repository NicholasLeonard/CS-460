/*$(document).ready(function(){
    $("#countme").click(function (){
        var content = $.trim($("#parser").val());
            console.log("this part works atleast");
    });


    
});*/
/*$(document).ready(function(){

    $("#calc").click(getString);
});*/
$(document).ready(function(){
    $("#countme").submit(getString);
});

function getString(){
        var content = $.trim($("#parser").val());
        console.log(content);
        return false;
    }