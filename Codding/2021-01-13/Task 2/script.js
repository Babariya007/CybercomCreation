/* Here we initiaze john and mark object and get values */

var john = {
  name: 'John',
  mass: '62',
  height: '5.6',
  calBMI: function(){
    this.bmi = this.mass / Math.pow(this.height,2); //calculte BMI
  }
}

var mark = {
  name: 'Mark',
  mass: '73',
  height: '5.2',
  calBMI: function(){
    this.bmi = this.mass / Math.pow(this.height,2); //calculte BMI
  }
}

/*Here we cell the methos*/
john.calBMI();
mark.calBMI();


/*Here we calculete the higest BMI*/
if(mark.bmi > john.bmi) {
  console.log(mark.name + ' BMI is Higher : ' + mark.bmi);
}
else  if (mark.bmi < john.bmi) {
  console.log(john.name + ' BMI is Higher : ' + john.bmi);
} 
else {
  console.log(mark.name + ' and ' + john.name + ' BMI are same : ' + mark.bmi);
}
