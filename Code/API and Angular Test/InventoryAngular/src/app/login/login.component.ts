import { Title } from '@angular/platform-browser';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  loginForm !: FormGroup;
  UserName !: String;
  Message !: String;

  constructor(private fb: FormBuilder, private router: Router, private title: Title) { }

  ngOnInit(): void {
    this.title.setTitle("Login | Inventory Management");
    this.InitializeFormControls();
  }

  get _form(){
    return this.loginForm.controls;
  }

  //Initialize Form Controls
  InitializeFormControls(){
    this.loginForm = this.fb.group({
      UserName : ['', [
        Validators.required
        // Validators.pattern("^[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}$")
        ]
      ],
      Password : ['', Validators.required]
    });
  }

  //Check Username and Password and Redirect Dashbord page
  onsubmit(){
    if(this.loginForm.valid){
      //Check UserName Password Valid or not
      if(this.loginForm.value.UserName === "a" && this.loginForm.value.Password === "a"){
        sessionStorage.setItem('UserName', this.loginForm.value.UserName)
        this.router.navigate(['/dashbord']);
      }
      else{
        this.Message = "Invalid UserName or Password";
      }
    }
  }

}
