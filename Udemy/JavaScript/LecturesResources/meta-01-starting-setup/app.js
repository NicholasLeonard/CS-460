// Library land
const uid = Symbol();
console.log(uid);

const user = {
  // id: 'p1',
  [uid]: 'p1',
  name: 'Max',
  age: 30
};

user[uid] = 'p3';

// app land => Using the library

user.id = 'p2'; // this should not be possible!

console.log(user[Symbol('uid')]);
console.log(Symbol('uid') === Symbol('uid'));
console.log(user.toString());

const company = {
  // curEmployee: 0,
  employess: ['Max', 'Manu', 'Anna'],
  // next() {
  //   if (this.curEmployee >= this.employess.length) {
  //     return { value: this.curEmployee, done: true }
  //   }
  //   const returnValue = { value: this.emplyees[0], done: false };
  //   this.curEmployee++;
  //   return returnValue;
  // },
  [Symbol.iterator]: function* employeeGenerator() {
    // let employee = company.next();

    // while (!employee.done) {
    //   yield employee.value;
    //   employee = employee.next();
    // }
    let currentEmployee = 0;
    while (currentEmployee < this.employess.length) {
      yield this.employess[currentEmployee];
      currentEmployee++;
    }
  }
};

// let employee = company.next();

// while (!employee.done) {
//   console.log(employee.value);
//   employee = employee.next();
// }

for (const employee of company) {
  console.log(employee);
}

console.log([...company]);
// const it = company.getEmployee();

// console.log(it.next());
// console.log(it.next());
// console.log(it.next());
// console.log(it.next());
// console.log(it.next());