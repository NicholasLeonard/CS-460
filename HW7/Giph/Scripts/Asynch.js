$("#textbox").keydown(function (event) {
    var keyName = event.key;
    //var input = $("#textbox").val().toString();
    
    console.log(input);
   // console.log(keyName);
    if (keyName === " ") {
        var input = $("#textbox").val().toString();
        console.log(input);
        var inputSub = input.split(" ");
        console.log(inputSub);
        //console.log("Spacebar pressed");
    } else {
       // console.log("No space");
    }
});