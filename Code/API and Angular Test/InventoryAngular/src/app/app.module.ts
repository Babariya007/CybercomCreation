import { OrderlistComponent } from './orderlist/orderlist.component';
import { OrderapiService } from './services/orderapi.service';
import { ProductapiService } from './services/productapi.service';
import { CustomerapiService } from './services/customerapi.service';
import { AppErrorHandler } from './services/app-error-handler';
import { ErrorHandler } from '@angular/core';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HttpClientModule } from '@angular/common/http';
import { CustomerListComponent } from './customer-list/customer-list.component';
import { CustomerAddEditComponent } from './customer-add-edit/customer-add-edit.component';
import { NavbarComponent } from './navbar/navbar.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { ProductListComponent } from './product-list/product-list.component';
import { ProductAddEditComponent } from './product-add-edit/product-add-edit.component';
import { OrderAddEditComponent } from './order-add-edit/order-add-edit.component';
import { DashbordComponent } from './dashbord/dashbord.component';
import { LoginComponent } from './login/login.component';
import { NgxPaginationModule } from 'ngx-pagination';
import { CustomerSearchPipe } from './pipes/customer-search.pipe';
import { ProductSearchPipe } from './pipes/product-search.pipe';

@NgModule({
  declarations: [
    AppComponent,
    CustomerListComponent,
    CustomerAddEditComponent,
    NavbarComponent,
    ProductListComponent,
    ProductAddEditComponent,
    OrderAddEditComponent,
    OrderlistComponent,
    DashbordComponent,
    LoginComponent,
    CustomerSearchPipe,
    ProductSearchPipe,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    NgxPaginationModule
  ],
  providers: [
    CustomerapiService,
    ProductapiService,
    OrderapiService,
    { provide: ErrorHandler, useClass: AppErrorHandler}
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
