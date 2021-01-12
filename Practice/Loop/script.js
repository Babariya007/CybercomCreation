// Here first Even number progream

console.log("Even Number")
for (var i = 1; i <=20; i += 2) {
	console.log(i);
}


console.log("\n\nNumber is Even Odd");
// Check number is even or odd

var number = prompt("Enter number:");
if (number %2 ==0) {
	console.log(number + " is Even Number");
} else {
	console.log(number + " is Odd Number");
}

// Get value using array
console.log("\n\n");
var Jeel = ['Jeel', 2010, 'Student'];

for(var i =0; i < Jeel.length; i++) {
	console.log(Jeel[i]);
}