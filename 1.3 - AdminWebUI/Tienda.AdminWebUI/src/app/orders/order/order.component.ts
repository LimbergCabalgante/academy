import { Component, Input, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatSnackBar } from '@angular/material/snack-bar';
import { OrdersService } from '../orders.service';
import { ConfirmationDialogComponent } from './confirmation-dialog/confirmation-dialog.component';
import { Order } from './order';

@Component({
  selector: 'app-order',
  templateUrl: './order.component.html',
  styleUrls: ['./order.component.scss']
})
export class OrderComponent implements OnInit {
  @Input() order: Order

  constructor(private ordersService: OrdersService, private dialog: MatDialog, private snackBar: MatSnackBar) { }

  ngOnInit() {
  }

  updateOrderStatus(){
    let dialogRef = this.dialog.open(ConfirmationDialogComponent,{
      disableClose: true,
      autoFocus: false,
      data: {
        order: this.order,
      }
    });
    dialogRef.afterClosed().subscribe(newStatus=>{
      this.ordersService.updateOrderStatus(this.order.id, newStatus).subscribe({
        next: ()=>{
          this.order.statusId = newStatus;
          this.snackBar.open("Estado actualizado con éxito.", "OK", {panelClass: "success-snackbar"});
        },
        error: ()=>{
          this.snackBar.open("Algo salió mal al actualizar el estado.", "OK", {panelClass: "error-snackbar"});
        },
      });
    })  
  }

}
