import { CustomerapiService } from './../services/customerapi.service';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Title } from '@angular/platform-browser';

@Component({
  selector: 'app-customer-add-edit',
  templateUrl: './customer-add-edit.component.html',
  styleUrls: ['./customer-add-edit.component.css']
})
export class CustomerAddEditComponent implements OnInit {

  form !: FormGroup;
  success = false;
  isAdd !: boolean;
  id !: number;

  constructor(private fb: FormBuilder, private data: CustomerapiService, private router:Router, private activatedRoute: ActivatedRoute, private title:Title) { }

  //Initialize Form Controls
  InitializeFormControls(){
    this.form = this.fb.group({
      CustomerName: ['', Validators.required],
      Email: ['', [
          Validators.required,
          Validators.pattern("^[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}$")
        ]
      ],
      Phone: ['', [
        Validators.required,
        Validators.pattern("^[0-9]*$"),
        Validators.minLength(10)]
      ]
    })
  }

  ngOnInit(): void {
    //Check User is Login Or Not
    if(sessionStorage.getItem('UserName') != null){

      //CHeck Id is Null or not
      if(this.activatedRoute.snapshot.params['id'] != null){
        this.id = parseInt(atob(this.activatedRoute.snapshot.params['id']));
      }
      
      if(this.id != null){
        this.title.setTitle("Edit Customer | Inventory Management");

        //If id is available then fill data in form
        this.data.getCustomerByID(this.id)
          .subscribe((cus:any)=> this.form.patchValue(cus));
      }else{
        this.title.setTitle("Add Customer | Inventory Management");
      }
      this.InitializeFormControls();
    }else{
      this.router.navigate(['/']);  //If User are Not Login then redrect to Login Page
    }
  }

  get _form(){
    return this.form.controls;
  }

  onsubmit(){
    //Check Form is valid or not
    if(this.form.valid){
      if(this.id == null){
        this.addCustomer();
      }
      else{
        this.updateCustomer();
      }
    }
  }

  //Add new Customer
  addCustomer(){
    this.data.createCustomer(this.form.value).subscribe(result => {
      if(result){
        this.form.reset();
        this.success = true;
      }else{
        alert(result);
      }
    })
  }

  //Update Customer
  updateCustomer(){
    this.data.updateCustomer(this.id, this.form.value).subscribe(result => {
      this.router.navigate(['/customers']);
    })
  }

}
