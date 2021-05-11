import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'productSearch'
})
export class ProductSearchPipe implements PipeTransform {

  //Heare use for searching Product Name (Not For server side After search filter use server side so this is ignore)
  transform(value: any, searchTerm: any): any {
    return value.filter(function(search: any){
      return search.ProductName.toLowerCase().indexOf(searchTerm.toLowerCase()) > -1
    });
  }

}
