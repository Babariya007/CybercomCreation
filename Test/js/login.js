function isValidAdmin() {
    var email = document.getElementById("email").value;
    var password = document.getElementById("pwd").value;

    const adminUser = JSON.parse(window.localStorage.getItem(email));
    const adminEmail = adminUser.email;
    const adminPassword = adminUser.password;

    if (email == adminEmail && password == adminPassword) {
        window.location.href = "dashbord.html"
    } else {
        alert("Incorect ID or Password");
    }
}