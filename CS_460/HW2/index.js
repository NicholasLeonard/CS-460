$(document).ready(function(){
    $("#countme").submit(clr_tble);
    $("#countme").submit(getString); //start calculation once the form is submitted.
    $("#reset").click(clr_tble); //this is to clear the table from a previous entry or a reset.
});

//used to clear previous results
function clr_tble(){
    $("#tableHere").empty();
}

//used to get the data from the text area for parsing and counting. Returns false so form works.
function getString(){
        var content = $.trim($("#parser").val());
        console.log(content);//test string input
        count(content);//used to total letters
        return false;//prevents form from automatically submitting and resetting
    }

//used to prep for calculation
function count(content){
    //converts string to lowercase characters for comparison
    var content = content.toLocaleLowerCase();
    console.log(content + " lower_case_str");//used for testing

    //gets the length of the string for loop
    length = content.length;
    console.log(length + " length_of_string")//used for testing

    //array to hold totals of letter counts
    var tallies = [];
    for(i=0; i<26; i++){
        tallies.push(0);
    }
    
    console.log(tallies.length + " num_of_elements");//testing lenght of tallies
    console.log(content.charAt(0) + " first_letter");//testing that content.charAt() was working

    // loop provides work for tallying letters
    for(i = 0; i < length; i++){
        console.log("test_for_loop");//making sure loop is working
        var char = content.charAt(i); //used to get individual letters from input string for comparison
        console.log(char + " test_of_char"); //confirming that char is getting letters

        switch (char){ //used to provide 26 comparisons for english letters
            default:    //this way nonletter characters are skipped.
                break;               
            case "a"://add comment to webpage for empty tally array
                tallies[0] = tallies[0] + 1;
                break;
            case "b":
                tallies[1] = tallies[1] + 1;
                break;
            case "c":
                tallies[2] = tallies[2] + 1;
                break;
            case "d":
                tallies[3] = tallies[3] + 1;
                break;
            case "e":
                tallies[4] = tallies[4] + 1;
                break;
            case "f":
                tallies[5] = tallies[5] + 1;
                break;
            case "g":
                tallies[6] = tallies[6] + 1;
                break;
            case "h":
                tallies[7] = tallies[7] + 1;
                break;
            case "i":
                tallies[8] = tallies[8] + 1;
                break;
            case "j":
                tallies[9] = tallies[9] + 1;
                break;
            case "k":
                tallies[10] = tallies[10] + 1;
                break;
            case "l":
                tallies[11] = tallies[11] + 1;
                break;
            case "m":
                tallies[12] = tallies[12] + 1;
                break;
            case "n":
                tallies[13] = tallies[13] + 1;
                break;
            case "o":
                tallies[14] = tallies[14] + 1;
                break;
            case "p":
                tallies[15] = tallies[15] + 1;
                break;
            case "q":
                tallies[16] = tallies[16] + 1;
                break;
            case "r":
                tallies[17] = tallies[17] + 1;
                break;
            case "s":
                tallies[18] = tallies[18] + 1;
                break;
            case "t":
                tallies[19] = tallies[19] + 1;
                break;
            case "u":
                tallies[20] = tallies[20] + 1;
                break;
            case "v":
                tallies[21] = tallies[21] + 1;
                break;
            case "w":
                tallies[22] = tallies[22] + 1;
                break;
            case "x":
                tallies[23] = tallies[23] + 1;
                break;
            case "y":
                tallies[24] = tallies[24] + 1;
                break;
            case "z":
                tallies[25] = tallies[25] + 1;
                break;                    
        }
    }
    console.log(tallies + " tallies of letters"); //confirming final tallies

    genTable(tallies);//used to make the result table
};

//used to generate the table with tally totals.
function genTable(tallies){

    //jquery to create initial outline of table
    $("#tableHere").append('<p>Here are your totals.</p>', '<table class="table table-bordered table-condensed" id="tallytble">');
    $("#tallytble").append("<tr id='hdrw'>");
    $("#tallytble").append("<tr id='drw'");
    
    //array containing headers for table
    var headers = ['A','B','C','D','E','F','G','H','I','J','K','L','M','N','O','P','Q','R','S','T','U','V','W','X','Y','Z'];

    console.log(headers + " headers_for_table");//testing headers for array

    //loop for populating result table
    for(i=0; i < tallies.length; i++){
        if(tallies[i]>0){
            $("#hdrw").append("<th class='have'>"+ headers[i] +"</th>");
            $("#drw").append("<td class='have'>"+ tallies[i] +"</td>");
        }else{
            $("#hdrw").append("<th>"+ headers[i] + "</th>");
            $("#drw").append("<td>"+tallies[i]+"</td>"); 
        }      
    }
};