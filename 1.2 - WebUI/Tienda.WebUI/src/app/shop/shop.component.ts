import { Component, OnInit } from '@angular/core';
import { ProductsService } from '../common/services/products.service';
import { Category } from '../common/dtos/category';
import { CategoryParams } from '../common/params/categoryParams';
import { Product } from '../common/dtos/product';
import { ProductParams } from '../common/params/productParams';
import { FormControl } from '@angular/forms';

@Component({
  selector: 'app-shop',
  templateUrl: './shop.component.html',
  styleUrls: ['./shop.component.scss']
})
export class ShopComponent implements OnInit {
  currentSearch = new FormControl();

  categories: Category[] = [];
  selectedCategory: number = 0;

  orderBys = [{value: "name", option: "Nombre"}, {value: "price", option: "Precio"}];
  selectedOrderBy: string = "name";

  orderDirections = [{id: 0, option: "Ascendente"}, {id: 1, option: "Descendente"}];
  selectedOrderDirection: number = 0;

  products: Product[] = [];
  totalProductsByCategory: Product[] = [];

  existingPages: number;
  currentPage: number;

  constructor(private productsService: ProductsService) {  
  }

  ngOnInit(): void {
    this.getCategories();
    this.getPagesInfo();
  }

  // -Requests-

  // Gets Categories For Input Select
  getCategories(){
    this.productsService.getCategories().subscribe(categories=>{
      this.categories = categories;
    })
  }

  //Gets All Products in the Current Category that Match the Current Search
  getPagesInfo(){
    let categoryParams: CategoryParams = {
      category: this.selectedCategory,
      search: this.currentSearch.value
    }

    this.productsService.getProductsByCategory(categoryParams).subscribe(products=>{
      this.totalProductsByCategory = products;
      this.filterProducts();
    })
  }

  // Applies All Filters
  filterProducts(){
    let productParams: ProductParams = {
      pageIndex: 1,
      pageSize: 8,
      orderBy: this.selectedOrderBy,
      orderDirection: this.selectedOrderDirection,
      search: this.currentSearch.value,
      category: this.selectedCategory,
    }

    this.productsService.getProductsPaginated(productParams).subscribe(products =>{
      this.products = products;
      this.currentPage = productParams.pageIndex;
      this.existingPages = this.totalProductsByCategory.length / productParams.pageSize;
    })
  }

  // -Page Navigation-

  // Next
  nextPage(){
    if(this.currentPage < this.existingPages){
      let productParams: ProductParams = {
        pageIndex: this.currentPage + 1,
        pageSize: 8,
        orderBy: this.selectedOrderBy,
        orderDirection: this.selectedOrderDirection,
        search: this.currentSearch.value,
        category: this.selectedCategory,
      }

      this.productsService.getProductsPaginated(productParams).subscribe(products =>{
        this.products = products;
        this.currentPage = productParams.pageIndex;
      })
    }
  }

  // Previous
  previousPage(){
    if(this.currentPage > 1){
      let productParams: ProductParams = {
        pageIndex: this.currentPage - 1,
        pageSize: 8,
        orderBy: this.selectedOrderBy,
        orderDirection: this.selectedOrderDirection,
        search: this.currentSearch.value,
        category: this.selectedCategory,
      }
  
      this.productsService.getProductsPaginated(productParams).subscribe(products =>{
        this.products = products;
        this.currentPage = productParams.pageIndex;
      })
    }
  }
  
  // By Id
  goToPage(page){
    if(this.currentPage != page){
      let productParams: ProductParams = {
        pageIndex: page,
        pageSize: 8,
        orderBy: this.selectedOrderBy,
        orderDirection: this.selectedOrderDirection,
        search: this.currentSearch.value,
        category: this.selectedCategory,
      }

      this.productsService.getProductsPaginated(productParams).subscribe(products =>{
        this.products = products;
        this.currentPage = productParams.pageIndex;
      })
    }
  }
  
}
