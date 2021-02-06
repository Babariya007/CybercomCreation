function getInfo() {
    var name = document.getElementById("name").value;
    var email = document.getElementById("email").value;
    var pwd = document.getElementById("pwd").value;
    var conpwd = document.getElementById("conpwd").value;
    var city = document.getElementById("city").value;
    var state = document.getElementById("state").value;

    var userData = {
        Name: name,
        Email: email,
        Password: pwd,
        ConfirmPassword: conpwd,
        City: city,
        State: state
    }

    if (pwd === conpwd) {
        window.localStorage.setItem(email, JSON.stringify(userData));
        window.location.href = "/Login.html";
    } else {
        alert("Please check Password !!!");
    }
}