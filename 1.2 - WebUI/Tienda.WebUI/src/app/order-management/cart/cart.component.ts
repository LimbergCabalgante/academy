import { Component, OnInit } from '@angular/core';
import { Cart } from 'src/app/common/dtos/cart';
import { OrderManagementService } from '../order-management.service';

@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.scss']
})
export class CartComponent implements OnInit {
  cart: Cart;
  totalPrice: number;

  constructor(public orderManagementService: OrderManagementService) { 
    this.cart = orderManagementService.cart;
    this.totalPrice = this.cart.cartEntries.map(item => item.product.price * item.quantity).reduce((prev, next) => (prev + next));
  }

  ngOnInit(): void {
  }

  areItemsValid(){
    if(this.cart.cartEntries.find((e)=> e.quantity == 0) || this.cart.cartEntries.find((e)=> e.quantity == undefined)){
      return false;
    }
    else{
      return true;
    }
  }

  updateItemQuantity(product, quantity){
    this.orderManagementService.updateItemQuantity(product, quantity);
    this.totalPrice = this.cart.cartEntries.map(item => item.product.price * item.quantity).reduce((prev, next) => (prev + next));
  }

  removeItemFromCart(product){
    this.orderManagementService.removeItemFromCart(product);
    this.totalPrice = this.cart.cartEntries.map(item => item.product.price * item.quantity).reduce((prev, next) => (prev + next));
  }

  createOrder(){
    console.log(this.cart);
  }

}
