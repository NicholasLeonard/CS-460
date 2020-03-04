const randomNumber = Math.random(); // produces random number between 0 (including) and 1 (excluding)
const myRandomNumber = Math.random();

if(randomNumber > 0.7){
  alert(`Random number is bigger than 0.7: ${randomNumber}`);
}

const myNumArray = [2, 3, 4, 10, 65, 81, 100];

for(let i = 0; i < myNumArray.length; i++){
  console.log(myNumArray[i]);
}

for(const num of myNumArray){
  console.log(num);
}

for(let i = myNumArray.length - 1; i >= 0; i--){
  console.log(myNumArray[i]);
}

if(myRandomNumber > 0.7 && randomNumber > 0.7){
  alert(`Both of these numbers are greater than 0.7: ${myRandomNumber} or ${randomNumber}`);
} else if(myRandomNumber < 0.2 || randomNumber < 0.2){
  alert(`One of these numbers is less than 0.2: ${myRandomNumber} or ${randomNumber}`);
} else {
  alert(`None of the numbers passed the conditions.`);
}