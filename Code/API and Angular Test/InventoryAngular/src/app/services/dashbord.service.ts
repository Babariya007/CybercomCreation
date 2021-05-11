import { AppError } from './app-error';
import { BadInpute } from './bad-inpute';
import { NotFoundError } from './not-found-error';
import { map, catchError } from 'rxjs/operators';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { throwError } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class DashbordService {

  url = "https://localhost:44312/api/DashBord";
  headers = new HttpHeaders().set('Content-Type', 'application/json');

  constructor(private http: HttpClient) { }

  //Get Data for Dashbord
  getDashbord(){
    return this.http.get(this.url)
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
