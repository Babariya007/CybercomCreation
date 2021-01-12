// first we create function

// if we write property in object then use (:) and if use create new property then you can use (=)

var profile = {
	firstName : "Abhay",
	lastName : "Babariya",
	job : "Webdeveloper",
	DOB : 1975,
	calculateAge: function () {
		console.log(this);  //this show all property

		console.log(this.DOB); //Here show only DOB property
	}
}

profile.calculateAge(2020);

var Meet = {
	firstName : "Meet",
	lastName : "Babariya",
	DOB : 2000
}

Meet.calculateAge = profile.calculateAge;
Meet.calculateAge();						// Here show Meet DOB