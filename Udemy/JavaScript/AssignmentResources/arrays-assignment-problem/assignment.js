const myArrayOfNums = [2, 1, 5, 15, 10, 22, 6, 2, 1];

const myNumsGreaterThen5 = myArrayOfNums.filter(val => val > 5);
const myNumsAsObjects = myArrayOfNums.map(val => ({number: val}));
const myNumsMultiplied = myArrayOfNums.reduce((prevVal, curVal) => prevVal * curVal, 1);

console.log(myNumsGreaterThen5, myNumsAsObjects, myNumsMultiplied);

const findMax = (...vals) => Math.max(...vals);

console.log(findMax(...myArrayOfNums));

const findMaxAndMin = (...vals) => maxAndMin = [Math.max(...vals), Math.min(...vals)];

const [max, min] = findMaxAndMin(...myArrayOfNums);
console.log(max, min);

const uniqueList = new Set(myArrayOfNums);

console.log(uniqueList);