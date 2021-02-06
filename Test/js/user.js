//New User
var array = [];

function newUser() {
    var userName = document.getElementById('name').value;
    var userEmail = document.getElementById('email').value;
    var userPassword = document.getElementById('pwd').value;
    var userBirthday = document.getElementById('birthdate').value;

    var userData = {
        Name: userName,
        Email: userEmail,
        Password: userPassword,
        Birthday: userBirthday
    }

    if (localStorage.getItem('array')) {
        userarr = JSON.parse(localStorage.getItem('array'));
    }

    array.push(userData);
    localStorage.setItem("User", JSON.stringify(array));
}


function getAge(dob) {
    var diff_ms = Date.now() - dob.getTime();
    var age_dt = new Date(diff_ms);

    return Math.abs(age_dt.getUTCFullYear() - 2021);

}
document.getElementById('age').innerHTML = getAge(new Date(userBirthday));


//Update User
function updateUser() {
    var updateUser = JSON.parse(localStorage.getItem('User'));
    updateUser.forEach(function(obj) {
        document.getElementById('name').value = obj.Name;
        document.getElementById('email').value = obj.Email;
        document.getElementById('pwd').value = obj.Password;
        document.getElementById('birthdate').value = obj.Birthday;
        document.getElementById('btnAddUser').innerHTML = "Update User";
    });
}

//Fech User
function fechUser() {
    var array = localStorage.getItem('User');
    var dataitems = JSON.parse(array);

    array = dataitems;
    document.write(`<table class="table">`);
    document.write(`<thead class="thead-dark">`);
    document.write(`<tr>`);
    document.write(`<th scope="col">Name</th>
    <th scope="col">Email</th>
    <th scope="col">Password</th>
    <th scope="col">Birthdate</th>
    <th scope="col">Age</th>
    <th scope="col">Action</th>
    </tr>
    <tbody>
    <tr>`);

    for (var i = 0; i < array.length; i++) {
        document.write('<td>' + array[i].name + '</td>');
        document.write('<td>' + array[i].email + '</td>');
        document.write('<td>' + array[i].pswd + '</td>');
        document.write('<td>' + array[i].birthdate + '</td>');
        document.write('<td>' + getAge(array[i].birthdate) + '</td>');
        document.write('<td><button type="button" class="btn btn-primary" onclick="updateUser()"> Update </button></td>');
        document.write('<td><button type="button" class="btn btn-danger" onclick="deleteUser()"> Delete </button></td>');
        document.write('</tr>');
        document.write('</tbody>');
        document.write('</thead>');
        document.write('</table>');

    }
}
document.getElememtById('userTable').innerHTML = fechUser();


//Delete User
function deleteUser() {
    var userData = JSON.parse(localStorage.getItem('User'));
    userData.forEach(function(obj) {
        localStorage.removeItem(obj.Name);
    });
}