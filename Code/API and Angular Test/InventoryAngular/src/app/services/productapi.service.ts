import { map, catchError } from 'rxjs/operators';
import { AppError } from './app-error';
import { BadInpute } from './bad-inpute';
import { NotFoundError } from './not-found-error';
import { Observable, throwError } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class ProductapiService {

  url = "https://localhost:44312/api/Product";
  headers = new HttpHeaders().set('Content-Type', 'application/json');
  
  constructor(private http: HttpClient) { }

  //Get Count of total records
  getTotalRecord(): Observable<any>{
    return this.http.get(this.url);
  }
  
  //Get Product List
  getAllProduct(page:number, itemPerPage:number): Observable<any>{
    return this.http.get(this.url + '?PageNo=' + page + '&PageSize=' + itemPerPage)
    .pipe(
      map(response => response),
      catchError(this.handleError)
    );
  }

  //Create New Product
  createProduct(data:any): Observable<any>{
    return this.http.post(this.url, data)
    .pipe(
      map(response => response),
      catchError(this.handleError)
    );
  }

  //Get Data by ProductID
  getProductByID(id:number): Observable<any>{
    return this.http.get(this.url + '/' + id)
    .pipe(
      map(response => response),
      catchError(this.handleError)
    );
  }

  //Update Product
  updateProduct(id:number, data:any): Observable<any>{
    return this.http.put(this.url + '/' + id, data)
    .pipe(
      map(response => response),
      catchError(this.handleError)
    );
  }

  //Delete Product
  deleteProduct(id:any): Observable<any>{
    return this.http.delete(this.url + '/' + id)
    .pipe(
      map(response => response),
      catchError(this.handleError)
    );
  }

  //Search By Product Name
  searchProductName(page:number, itemPerPage:number, searchtxt:any){
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
