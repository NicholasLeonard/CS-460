class Course {
  #coursePrice;
  constructor(title, length, price){
    this.courseTitle = title;
    this.courseLength = length;
    this.coursePrice = price;
  }

  set coursePrice(price){
    if(price < 0){
      throw 'Invalid Input';
    }
    else{
      this.#coursePrice = price;
    }
  }

  get coursePrice(){
    return `$${this.#coursePrice}`;
  }

  courseValue(){
    const value = this.courseLength/this.#coursePrice;
    return value;
  }

  courseSummary(){
    const summary = `Title: ${this.courseTitle}
    Length: ${this.courseLength}
    Cost: ${this.coursePrice}`;

    return summary;
  }
}

class PracticalCourse extends Course{
  constructor(title, length, price, exercises){
    super(title, length, price);
    this.totalCourseExercises = exercises;
  }

  numOfExercises(){
    return this.totalCourseExercises;
  }
}

class TheoreticalCourse extends Course{
  publish(){
    console.log('This is a theoretical course publication.');
  }
}

const course1 = new Course('Geography', 10, 200);
const course2 = new Course('Beginning Math', 12, 100);
console.log(course1, course2);


console.log(course1.courseValue(), course1.courseSummary());
console.log(course2.courseValue(), course2.courseSummary());

const course3 = new PracticalCourse('How to Write', 10, 50, 4);
const course4 = new TheoreticalCourse('The Philosophy of the Universe', 12, 100);

console.log(course3.courseValue(), course3.courseSummary(), course3.numOfExercises());
console.log(course4.courseValue(), course4.courseSummary());
course4.publish();