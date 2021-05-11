import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'customerSearch'
})
export class CustomerSearchPipe implements PipeTransform {

  //Heare use for searching Customer Name (Not For server side After search filter use server side so this is ignore)
  transform(value: any, searchTerms: any): any {
    return value.filter(function(search:any){
      return search.CustomerName.toLowerCase().indexOf(searchTerms.toLowerCase()) > -1
    });
  }

}
