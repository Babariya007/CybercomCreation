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

    if (localStorage.getItem('userarr')) {
        userarr = JSON.parse(localStorage.getItem('userarr'));
    }
}


function getAge(dob) {
    var diff_ms = Date.now() - dob.getTime();
    var age_dt = new Date(diff_ms);

    return Math.abs(age_dt.getUTCFullYear() - 2021);

}
document.getElementById('age').innerHTML = getAge(new Date(userBirthday));