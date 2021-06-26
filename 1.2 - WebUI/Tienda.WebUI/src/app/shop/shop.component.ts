import { Component, OnInit } from '@angular/core';
import { ProductsService } from '../common/services/products.service';
import { Product } from '../common/dtos/product';
import { ProductParams } from '../common/params/productParams';
import { Category } from '../common/dtos/category';

@Component({
  selector: 'app-shop',
  templateUrl: './shop.component.html',
  styleUrls: ['./shop.component.scss']
})
export class ShopComponent implements OnInit {
  products: Product[] = [];
  categories: Category[] = [];
  selectedCategory: number;

  constructor(private productsService: ProductsService) { }

  ngOnInit(): void {

    let productParams: ProductParams = {
      pageIndex: 1,
      pageSize: 6,
      orderBy: "name",
      orderDirection: 1,
      category: 0
    }

    this.productsService.getProductsPaginated(productParams).subscribe(products =>{
      this.products = products;
    })

    this.productsService.getCategories().subscribe(categories=>{
      this.categories = categories;
    })

  }

}
