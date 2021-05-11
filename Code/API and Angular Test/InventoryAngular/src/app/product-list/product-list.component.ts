import { Title } from '@angular/platform-browser';
import { ProductapiService } from './../services/productapi.service';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.css']
})
export class ProductListComponent implements OnInit {

  product : any = [];
  totalRecords : any;
  page:number = 1;
  itemsPerPage:number = 10;
  message!:string;

  constructor(private service: ProductapiService, private router: Router, private title: Title) { }

  ngOnInit(): void {
    this.title.setTitle("Product List | Inventory Management");

    //Check User are Login or not
    if(sessionStorage.getItem('UserName') != null){
      this.getProductData();
    }else{
      this.router.navigate(['/']);
    }
  }

  pageChanged(PageNo:any){
    this.page = PageNo;     //Set Page No
    this.getProductData();
  }

  //Get Product List
  getProductData(){
    this.getTotalRecord();
    this.service.getAllProduct(this.page, this.itemsPerPage)
      .subscribe((products:any) => {
        this.product = products
      });
  }

  //Get Count of total Record
  getTotalRecord(){
    this.service.getTotalRecord()
      .subscribe((rec:any) => {this.totalRecords = rec});
  }

  //Edit Product
  editProduct(id:any){
    this.router.navigate(['products/edit', btoa(id)])
  }

  //Delete Product
  deleteProduct(id:number){
    this.service.deleteProduct(id)
      .subscribe(res => this.getProductData());
  }

  //Search by Product Name
  searchProduct(text:any){
    if(text.target.value != null){
      this.service.searchProductName(this.page, this.itemsPerPage, text.target.value.trim())
        .subscribe(res => {
          if(res !== "No Data"){
            this.product = res
          } else{
            this.product = null;
          }
        });
      console.log(text.target.value);
    } else {
      this.getProductData();
    }
  }

}
