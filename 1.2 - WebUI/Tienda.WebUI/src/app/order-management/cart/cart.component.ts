import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Router } from '@angular/router';
import { Cart } from 'src/app/common/dtos/cart';
import { Order } from 'src/app/common/dtos/order';
import { OrderManagementService } from '../order-management.service';
import { ConfirmationDialogComponent } from './confirmation-dialog/confirmation-dialog.component';
import { DeletionConfirmationDialogComponent } from './deletion-confirmation-dialog/deletion-confirmation-dialog.component';

@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.scss']
})
export class CartComponent implements OnInit {
  cart: Cart;
  totalPrice: number;

  constructor(public orderManagementService: OrderManagementService, private dialog: MatDialog, private snackBar: MatSnackBar, private router: Router) { 
    this.cart = orderManagementService.cart;
    if(this.cart.cartEntries.length > 0){
      this.totalPrice = this.cart.cartEntries.map(item => item.product.price * item.quantity).reduce((prev, next) => (prev + next));
    }
    else{
      this.totalPrice = 0;
    }
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
    let dialogRef = this.dialog.open(DeletionConfirmationDialogComponent, {
      disableClose: true,
      autoFocus: false
    })
    dialogRef.afterClosed().subscribe(result => {
      if(result == "true"){
        this.orderManagementService.removeItemFromCart(product);
        if(this.cart.cartEntries.length > 0){
          this.totalPrice = this.cart.cartEntries.map(item => item.product.price * item.quantity).reduce((prev, next) => (prev + next));
        }
        else{
          this.totalPrice = 0;
        }
      }
    })
  }

  createOrder(){
    let dialogRef = this.dialog.open(ConfirmationDialogComponent, {
      disableClose: true,
      autoFocus: false
    })
    dialogRef.afterClosed().subscribe(result => {
      if(result == "true"){
        let order: Order = {
          totalPrice: this.totalPrice
        }
        this.orderManagementService.createOrder(order).subscribe({
          next: ()=>{
            this.orderManagementService.clearCart();
            this.snackBar.open("Orden concretada. Gracias por su compra.", "OK", {panelClass: "success-snackbar"});
            this.cart = this.orderManagementService.cart;
            this.totalPrice = 0;
            this.router.navigate(["/orders"])
          },
          error: ()=>{
            this.snackBar.open("Hubo un error al concretar la orden...", "OK", {panelClass: "error-snackbar"});
          }
        })
      }
    });
  }

}
