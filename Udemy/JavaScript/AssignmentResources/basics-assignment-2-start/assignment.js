const task3Element = document.getElementById('task-3');

function firstAlert(){
    alert('Hello World from first alert!');
}

function secondAlert(name1){
    alert(name1);
}

function combineThreeStrings(string1, string2, string3){
    const combinedString = `${string1} ${string2} ${string3}`;
    return combinedString;
}

firstAlert();
secondAlert('Nicholas');

task3Element.addEventListener('click', firstAlert);

alert(combineThreeStrings('Hello', 'kind', 'world from third alert!'));