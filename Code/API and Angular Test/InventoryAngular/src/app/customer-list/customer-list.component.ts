import { CustomerapiService } from './../services/customerapi.service';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Title } from '@angular/platform-browser';

@Component({
  selector: 'app-customer-list',
  templateUrl: './customer-list.component.html',
  styleUrls: ['./customer-list.component.css']
})
export class CustomerListComponent implements OnInit {

  customer: any =[];
  totalRecords : any;
  page:number = 1;
  itemsPerPage:number = 10;

  constructor(private service: CustomerapiService, private router: Router, private title: Title) { }

  ngOnInit(): void {
    //Check User are Login or Not
    if(sessionStorage.getItem('UserName') != null){
      this.title.setTitle("Customer List | Inventory Management");
      this.getCustomerData();
    }else{
      this.router.navigate(['/']);    //If User are not Login then redirect to Login Page
    }
  }

  //Page change 
  pageChanged(PageNo:any){
    this.page = PageNo;     //Set Page No
    this.getCustomerData();
  }

  //List Of Customer Data
  getCustomerData(){
      this.getTotalRecords();
        this.service.getAllCustomer(this.page, this.itemsPerPage)
          .subscribe((customers:any) => {
            this.customer = customers
          });
  }

  //Get total records of Customer
  getTotalRecords(){
    this.service.getTotalRecord()
      .subscribe((rec:any) => {this.totalRecords = rec});
  }

  //Edit Customer
  editCustomer(id: any){
    this.router.navigate(['customer/edit', btoa(id)]);
  }

  //Delete Customer
  deleteCustomer(id:any){
    if(confirm("Are you sure want to delete this record?")){
    this.service.deleteCustomer(id)
      .subscribe(res => this.getCustomerData());
    }else{
      return;
    }
  }

  
  //Search by Customer Name
  searchCustomer(text:any){
    if(text.target.value != null){
      this.service.searchCustomerName(this.page, this.itemsPerPage, text.target.value.trim())
        .subscribe(res => {
          if(res !== "No have any Data"){
            this.customer = res
            console.log(res);
          } else{
            this.customer = null;
            console.log('empty : ' + this.customer);
          }
        });
      console.log(text.target.value);
    } else {
      this.getCustomerData();
    }
  }

}
