// Hoisting

// function calAge(year) {
// 	console.log(2020 - year);
// }

// calAge(1947);


// if we first initialize x=5 then declere x then it's also working in js

// x = 5;

// console.log("x = " + x);

// var x;

//if first print value x then we declere and initialize value then its show undefined

// console.log(y);
// var y = 10;
// console.log(y);


let userList = ['Elon', 'Tesla'];
let passwordList = ['1234', '4321']

localStorage.setItem('User', JSON.stringify(userList));
let user = JSON.parse(localStorage.getItem('User'));
let password = localStorage.setItem('Password', JSON.stringify(passwordList));

// const username = user.split('o');
// const str = username
// username = split[1];

user.forEach(e => {
    document.getElementById('lbl').innerHTML = e;
});

// foreach(let i in user.length) {
//     document.getElementById('lbl').innerHTML = `<table>
//      <tr>
//      <td>Name</td>
//      <td>${user[i]}</td> 
//      </tr> 
//      </table>`;

// }

// function btnCheck(userName) {
//     if (user === userName) {
//         document.getElementById('lbl').innerHTML = "Sign in";
//     } else {
//         document.getElementById('lbl').innerHTML = "Invalid";
//     }
// }