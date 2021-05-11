import { LoginComponent } from './login/login.component';
import { DashbordComponent } from './dashbord/dashbord.component';
import { OrderAddEditComponent } from './order-add-edit/order-add-edit.component';
import { OrderlistComponent } from './orderlist/orderlist.component';
import { ProductAddEditComponent } from './product-add-edit/product-add-edit.component';
import { ProductListComponent } from './product-list/product-list.component';
import { CustomerAddEditComponent } from './customer-add-edit/customer-add-edit.component';
import { CustomerListComponent } from './customer-list/customer-list.component';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  {path:'', component: LoginComponent},
  {path:'dashbord', component: DashbordComponent},
  {path:'customers', component: CustomerListComponent},
  {path:'customer/add', component: CustomerAddEditComponent},
  {path:'customer/edit/:id', component: CustomerAddEditComponent},
  {path:'products', component: ProductListComponent},
  {path:'products/add', component: ProductAddEditComponent},
  {path:'products/edit/:id', component: ProductAddEditComponent},
  {path:'orders', component: OrderlistComponent},
  {path:'orders/add', component: OrderAddEditComponent},
  {path:'orders/edit/:id', component: OrderAddEditComponent},

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
