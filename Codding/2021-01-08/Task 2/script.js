var markMass = prompt("Enter Mark Mass: ");
var markHeight = prompt("Enter Mark Height: ");

var johnMass = prompt("Enter John Mass: ");
var johnHeight = prompt("Enter John Height: ");

var markBMI, johnBMI;

markBMI = markMass / (markHeight * markHeight);
johnBMI = johnMass / (johnHeight * johnHeight);

var checkGretterBMI = markBMI > johnBMI;

console.log("Is MArk's BMI higher then John's ? " + checkGretterBMI);