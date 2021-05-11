import { AppError } from './app-error';
import { BadInpute } from './bad-inpute';
import { NotFoundError } from './not-found-error';
import { map, catchError } from 'rxjs/operators';
import { Observable, throwError } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class OrderapiService {

  url = "https://localhost:44312/api/Orders";
  headers = new HttpHeaders().set('Content-Type', 'application/json');

  constructor(private http: HttpClient) { }

  //Get count of total record
  getTotalRecord(): Observable<any>{
    return this.http.get(this.url);
  }

  //Get List of Order
  getAllOrder(page:number, itemsPerPage:number, direction: boolean): Observable<any>{
    return this.http.get(this.url + '?PageNo=' + page + '&PageSize=' + itemsPerPage + '&Dir=' + direction)
    .pipe(
      map(response => response),
      catchError(this.handleError)
    );
  }

  //Get data base on seaech Dates
  getAllBySearchDate(data:any) {
    return this.http.post(this.url, data)
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
