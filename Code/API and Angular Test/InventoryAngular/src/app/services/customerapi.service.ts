import { AppError } from './app-error';
import { BadInpute } from './bad-inpute';
import { NotFoundError } from './not-found-error';
import { map, catchError } from 'rxjs/operators';
import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CustomerapiService {

  url = "https://localhost:44312/api/Customer";
  headers = new HttpHeaders().set('Content-Type', 'application/json');
  
  constructor(private http: HttpClient) { }

  //Get Count of Total record
  getTotalRecord(): Observable<any>{
    return this.http.get(this.url)
    .pipe(
      map(response => response),
      catchError(this.handleError)
    );
  }

  //Get Customer List
  getAllCustomer(page:number, itemPerPage:number): Observable<any>{
    return this.http.get(this.url + '?PageNo=' + page + '&PageSize=' + itemPerPage)
      .pipe(
        map(response => response),
        catchError(this.handleError)
      );
  }

  //Create Customer
  createCustomer(data:any): Observable<any>{
    return this.http.post(this.url, data)
    .pipe(
      map(response => response),
      catchError(this.handleError)
    );
  }

  //Get Customer Data By ID
  getCustomerByID(id:number): Observable<any>{
    return this.http.get(this.url + '/' + id)
    .pipe(
      map(response => response),
      catchError(this.handleError)
    );
  }

  //Update Customer
  updateCustomer(id:number, data:any): Observable<any>{
    return this.http.put(this.url + '/' + id, data)
    .pipe(
      map(response => response),
      catchError(this.handleError)
    );
  }

  //Delete Customer
  deleteCustomer(id:any): Observable<any>{
    return this.http.delete(this.url + '/' + id)
      .pipe(
        map(response => response),
        catchError(this.handleError)
      );
  }

  //Search By Customer Name
  searchCustomerName(page:number, itemPerPage:number, searchtxt:any){
    return this.http.get(this.url + '?PageNo=' + page + '&PageSize=' + itemPerPage + '&SearchText=' + searchtxt)
    .pipe(
      map(response => response),
      catchError(this.handleError)
    );
  }

  //Handle Error
  private handleError(error:Response){
    if(error.status === 404){
      return throwError(new NotFoundError());
    }
    else if(error.status === 400){
      return throwError(new BadInpute(error.json()));
    }
    return throwError(new AppError(error));
 }

}
