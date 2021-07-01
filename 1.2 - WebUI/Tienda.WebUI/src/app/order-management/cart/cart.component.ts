import { Component, OnInit } from '@angular/core';
import { ProductInCart } from 'src/app/common/dtos/productInCart';

@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.scss']
})
export class CartComponent implements OnInit {
  productsInCart: ProductInCart[] = [
    {id: null, name: 'Esponja', quantity: 2, unitPrice: 15.00},
    {id: null, name: 'Torta', quantity: 5, unitPrice: 25.00},
    {id: null, name: 'Plato', quantity: 2, unitPrice: 45.00},
    {id: null, name: 'Mate', quantity: 4, unitPrice: 20.00}
  ]

  constructor() { }

  ngOnInit(): void {
  }

  sendData(){
    console.log(this.productsInCart)
  }

}
