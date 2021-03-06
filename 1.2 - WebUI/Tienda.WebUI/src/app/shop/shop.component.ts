import { Component, OnInit } from '@angular/core';
import { Category } from '../common/dtos/category';
import { Product } from '../common/dtos/product';
import { FormControl } from '@angular/forms';
import { ShopService } from './shop.service';

@Component({
  selector: 'app-shop',
  templateUrl: './shop.component.html',
  styleUrls: ['./shop.component.scss']
})
export class ShopComponent implements OnInit {
  loading: boolean;

  currentSearch = new FormControl();

  categories: Category[] = [];
  selectedCategory: number = 0;

  orderBys = [{value: "name", option: "Nombre"}, {value: "price", option: "Precio"}];
  selectedOrderBy: string = "name";

  orderDirections = [{id: 0, option: "Ascendente"}, {id: 1, option: "Descendente"}];
  selectedOrderDirection: number = 0;

  products: Product[] = [];
  totalProductsByCategory: Product[] = [];

  pageSize: number = 8;
  existingPages: number;
  currentPage: number = 1;

  constructor(private shopService: ShopService) {  
  }

  ngOnInit(): void {
    this.loading = true;
    this.getCategories();
    this.filterProducts();
    this.loading = false;
  }

  getCategories(){
    this.shopService.getCategories().subscribe(categories=>{
      this.categories = categories;
    })
  }

  filterProducts(){
    let productParams = this.buildPagingData();

    this.shopService.getProductsPaginated(productParams).subscribe(result =>{
      this.getPagesInfo(result)
    })
  }

  nextPage(){
    if(this.currentPage < this.existingPages){
      this.currentPage ++;
      this.filterProducts()
      }
  }

  previousPage(){
    if(this.currentPage > 1){
      this.currentPage --;
      this.filterProducts();
    }
  }
  
  goToPage(page){
    this.currentPage = page;
    this.filterProducts();
  }

  getPagesInfo(result){
    this.products = result.products;
    this.existingPages = result.productCount / this.pageSize;
  }

  buildPagingData(){
    return {
      pageIndex: this.currentPage,
      pageSize: this.pageSize,
      orderBy: this.selectedOrderBy,
      orderDirection: this.selectedOrderDirection,
      search: this.currentSearch.value,
      category: this.selectedCategory
    }
  }
  
}
