import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit {

  UserName = sessionStorage.getItem('UserName');
  
  constructor(private router: Router) { }

  ngOnInit(): void {
  }

  //Logout Button event
  logOut(){
    sessionStorage.removeItem('UserName');
    this.router.navigate(['/']);
  }

}
