const task1 = document.getElementById('task-1');
const task1Again = document.querySelector('#task-1');

task1Again.style.color = 'white';
task1Again.style.backgroundColor = 'black';

const titleChange1 = document.querySelector('title');
const titleChange2 = document.head.querySelector('title');

titleChange2.textContent = 'Assignment - Solved!';

const h1 = document.body.querySelector('h1');
h1.textContent = 'Assignment - Solved!';