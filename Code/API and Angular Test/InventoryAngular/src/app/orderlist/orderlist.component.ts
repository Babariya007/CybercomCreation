import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Title } from '@angular/platform-browser';
import { OrderapiService } from './../services/orderapi.service';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-orderlist',
  templateUrl: './orderlist.component.html',
  styleUrls: ['./orderlist.component.css']
})
export class OrderlistComponent implements OnInit {

  order : any =[];
  searchForm !: FormGroup;
  totalRecords : any;
  page:number = 1;
  itemsPerPage:number = 10;
  asc = true;

  constructor(private service: OrderapiService,private fb: FormBuilder, private router: Router, private title: Title) { }

  ngOnInit(): void {
    this.title.setTitle("Order List | Inventory Management");

    //Check User are Login or not
    if(sessionStorage.getItem('UserName') != null){
      this.getTotalRecords();
      this.getAllOrderList();
      this.InitializeFormControls();
    }else{
      this.router.navigate(['/']);
    }
  }

  //Initialize Form Controls
  InitializeFormControls(){
    this.searchForm = this.fb.group({
      FromDate : ['', Validators.required],
      ToDate : ['', Validators.required]
    })
  }

  get _form(){
    return this.searchForm.controls;
  }
  
  pageChanged(PageNo:any){
    this.page = PageNo;     //Set Page No
    this.getAllOrderList();
  }
  
  //Get List of Orders
  getAllOrderList(){
    this.service.getAllOrder(this.page, this.itemsPerPage, this.asc)
        .subscribe((orders:any) => {
          this.order = orders
        });
  }

  //Get Total Records of Order
  getTotalRecords(){
    this.service.getTotalRecord()
      .subscribe((rec:any) => {this.totalRecords = rec});
  }

  //Searcch Record by Dates
  searchOrder(){
    if(this.searchForm.valid){
      this.service.getAllBySearchDate(this.searchForm.value)
        .subscribe((ord:any) => {
          if(ord !== "No Data"){
            this.order = ord
          } else {
            this.order = null;
          }
        });
    }
  }

  //Reset dates
  reset(){
    this.getAllOrderList();
  }

  //Fillter for order date Ascending or Descending order
  ascDesc(){
    this.asc = !this.asc;
    console.log(this.asc);

    this.getAllOrderList();
  }

}
