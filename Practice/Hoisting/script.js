// Hoisting

function calAge(year) {
	console.log(2020 - year);
}

calAge(1947);


// if we first initialize x=5 then declere x then it's also working in js

x = 5;

console.log("x = " + x);

var x;

//if first print value x then we declere and initialize value then its show undefined

console.log(y);
var y = 10;
console.log(y);
