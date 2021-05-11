import { DashbordService } from './../services/dashbord.service';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Title } from '@angular/platform-browser';

@Component({
  selector: 'app-dashbord',
  templateUrl: './dashbord.component.html',
  styleUrls: ['./dashbord.component.css']
})
export class DashbordComponent implements OnInit {

  dashbord: any = [];

  constructor(private service: DashbordService, private router: Router, private title: Title) { }

  ngOnInit(): void {
    this.title.setTitle("DashBord | Inventory Management");   //Set Title in Titlebar

    //Check User are Login or not
    if(sessionStorage.getItem('UserName') != null){
      //Get data from API
      this.service.getDashbord()
        .subscribe((dashbords:any) => {this.dashbord = dashbords});
    }else {
      this.router.navigate(['/']);
    }
  }

}
