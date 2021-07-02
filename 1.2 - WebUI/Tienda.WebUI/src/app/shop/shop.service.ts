import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Category } from '../common/dtos/category';
import { ProductsWithPageCount } from '../common/dtos/productsWithPageCount';

@Injectable({
  providedIn: 'root'
})
export class ShopService {

  constructor(private http: HttpClient) { }

  getCategories(){
    return this.http.get<Category[]>(environment.apiUrl + "Product/categories");
  }

  getProductsPaginated(productParams){
    return this.http.get<ProductsWithPageCount>(environment.apiUrl + "Product/pagination", {params: productParams});
  }

}
