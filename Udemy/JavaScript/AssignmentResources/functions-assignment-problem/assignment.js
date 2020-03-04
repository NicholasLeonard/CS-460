const sayHello = name => console.log('Hi ' + name);
sayHello('Max');

const sayHelloWith2 = (name, greeting = 'Welcome ') => console.log(greeting + name);
sayHelloWith2("What's up, ", 'Max');

const sayHelloWithNone = () => console.log('Something said with no arguments Max.');
sayHelloWithNone();

const sayHelloWithReturn = name => `This is from a return statement ${name}.`;

console.log(sayHelloWithReturn('Max'));

sayHelloWith2('Max');

const stringMessage = () => console.log('No empty strings! Huray!');
const isNotEmpty = value => value !== '';
const checkInput = (stringHandler,...myStrings) => {
  if(myStrings.every(isNotEmpty)){
    stringHandler();
  }else{
    console.log("Call back didn't execute. You screwed up!");
  }
};
checkInput(stringMessage, 'hope', 'you', 'got', 'this');