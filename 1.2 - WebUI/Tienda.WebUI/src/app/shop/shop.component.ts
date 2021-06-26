import { Component, OnInit } from '@angular/core';
import { ProductsService } from '../common/services/products.service';
import { Category } from '../common/dtos/category';
import { CategoryParams } from '../common/params/categoryParams';
import { Product } from '../common/dtos/product';
import { ProductParams } from '../common/params/productParams';

@Component({
  selector: 'app-shop',
  templateUrl: './shop.component.html',
  styleUrls: ['./shop.component.scss']
})
export class ShopComponent implements OnInit {
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
    this.getProductsByCategory();
  }

  // -Requests-

  // Gets Categories For Input Select
  getCategories(){
    this.productsService.getCategories().subscribe(categories=>{
      this.categories = categories;
    })
  }

  //Gets All Products In Current Category
  getProductsByCategory(){
    let categoryParams: CategoryParams = {
      category: this.selectedCategory
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
    let productParams: ProductParams = {
      pageIndex: page,
      pageSize: 8,
      orderBy: this.selectedOrderBy,
      orderDirection: this.selectedOrderDirection,
      category: this.selectedCategory,
    }

    this.productsService.getProductsPaginated(productParams).subscribe(products =>{
      this.products = products;
      this.currentPage = productParams.pageIndex;
    })
  }

}
