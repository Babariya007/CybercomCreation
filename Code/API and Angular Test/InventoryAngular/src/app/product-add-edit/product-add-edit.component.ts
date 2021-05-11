import { Title } from '@angular/platform-browser';
import { ProductapiService } from './../services/productapi.service';
import { ActivatedRoute, Router } from '@angular/router';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-product-add-edit',
  templateUrl: './product-add-edit.component.html',
  styleUrls: ['./product-add-edit.component.css']
})
export class ProductAddEditComponent implements OnInit {

  productForm !: FormGroup;
  success = false;
  isAdd !: boolean;
  id !: number;

  constructor(private fb: FormBuilder, private data: ProductapiService, private router:Router, private activatedRoute: ActivatedRoute, private title: Title) { }

  ngOnInit(): void {

    //Check User are login or not
    if(sessionStorage.getItem('UserName') != null){
      //check id is null or not in route
      if(this.activatedRoute.snapshot.params['id'] != null){
        this.id = parseInt(atob(this.activatedRoute.snapshot.params['id']));
      }

      if(this.id != null){
        this.title.setTitle("Edit Product | Inventory Management");

        //If id is available then fill data in form
        this.data.getProductByID(this.id)
          .subscribe((pro:any)=> this.productForm.patchValue(pro));
      } else{
        this.title.setTitle("Add Product | Inventory Management");
      }
      this.InitializeFormControls();
    } else{
      this.router.navigate(['/']);
    }
  }

  //Initialize Form Controls
  InitializeFormControls(){
    this.productForm = this.fb.group({
      ProductName: ['', Validators.required],
      Stock: ['', Validators.required],
      Price: ['', Validators.required]
    })
  }

  get _form(){
    return this.productForm.controls;
  }

  onsubmit(){
    //Check Form is valid or not
    if(this.productForm.valid){
      if(this.id == null){
        this.addProduct();
      }
      else{
        this.updateOrder();
      }
    }
  }

  //Add new Product
  addProduct(){
    this.data.createProduct(this.productForm.value).subscribe(result => {
      if(result){
        this.productForm.reset();
        this.success = true;
      }else{
        alert(result);
      }
    })
  }

  //Update Product
  updateOrder(){
    this.data.updateProduct(this.id, this.productForm.value).subscribe(result => {
      this.router.navigate(['/products']);
    })
  }

}
