import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Product } from '../dtos/product';
import { Category } from '../dtos/category';

@Injectable({
  providedIn: 'root'
})
export class ProductsService {

  constructor(private http: HttpClient) { }

  getCategories(){
    return this.http.get<Category[]>(environment.apiUrl + "Product/categories");
  }

  getProductsByCategory(categoryParams){
    return this.http.get<Product[]>(environment.apiUrl + "Product/products-by-category", {params: categoryParams});
  }

  getProductsPaginated(productParams){
    return this.http.get<Product[]>(environment.apiUrl + "Product/pagination", {params: productParams});
  }

}
