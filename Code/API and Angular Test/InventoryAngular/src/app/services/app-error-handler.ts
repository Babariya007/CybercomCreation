import { ErrorHandler } from "@angular/core";

export class AppErrorHandler implements ErrorHandler {
    handleError(error:any){
        alert('Somthing was Worang! Please try again');
        console.log(error);
    }
}