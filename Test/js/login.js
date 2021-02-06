function isValidAdmin() {
    var userEmail = document.getElementById("email").value;
    var password = document.getElementById("pwd").value;

    const adminUser = JSON.parse(window.localStorage.getItem(userEmail));
    const adminEmail = adminUser.Email;
    const adminPassword = adminUser.Password;

    if (userEmail != adminEmail && password != adminPassword) {
        alert("Incorect ID or Password");

    } else {
        window.location.href = "dashbord.html";
    }
}