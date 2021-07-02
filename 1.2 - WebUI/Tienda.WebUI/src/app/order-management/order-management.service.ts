import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Cart } from '../common/dtos/cart';
import { Product } from '../common/dtos/product';
import { CartEntry } from '../common/dtos/cartEntry';

@Injectable({
    providedIn: 'root'
})
export class OrderManagementService {
    cart: Cart;

    constructor(private http: HttpClient) {
        this.cart = JSON.parse(localStorage.getItem("Cart"));
        if(!this.cart){
            this.cart = new Cart();
        }
    }

    addItemToCart(product: Product, quantity: number){
        let cartEntry = this.getEntryByProductId(product.id);
        if(cartEntry){
            cartEntry.quantity = cartEntry.quantity + quantity;
        }
        else{
            cartEntry = new CartEntry();
            cartEntry.product = product;
            cartEntry.quantity = quantity;
            if(!this.cart){
                this.cart = new Cart();
            }
            this.cart.cartEntries.push(cartEntry);         
        }
        this.persistCart();
        
    }

    removeItemFromCart(product: Product){
        if(this.cart){
            this.cart.cartEntries.forEach((p, i)=>{
                if(p.product.id == product.id){
                    this.cart.cartEntries.splice(i, 1);
                    return;
                }
            })
        }
        this.persistCart();
    }

    updateItemQuantity(product: Product, quantity: number){
        let cartEntry = this.getEntryByProductId(product.id);
        if(cartEntry){
            cartEntry.quantity = quantity;
        }
        this.persistCart();

    }

    getEntryByProductId(id: number): CartEntry{
        if(this.cart){
            return this.cart.cartEntries.find((ce)=> ce.product.id == id)
        }
        else{
            return null;
        }
    }

    persistCart(){
        localStorage.setItem("Cart", JSON.stringify(this.cart));
    }

}