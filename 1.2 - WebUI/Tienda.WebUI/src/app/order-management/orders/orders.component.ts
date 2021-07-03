import { Component, OnInit } from '@angular/core';
import { Order } from 'src/app/common/dtos/order';
import { OrderManagementService } from '../order-management.service';

@Component({
  selector: 'app-orders',
  templateUrl: './orders.component.html',
  styleUrls: ['./orders.component.scss']
})
export class OrdersComponent implements OnInit {
  orders: Order[];

  constructor(public orderManagementService: OrderManagementService) { }

  ngOnInit(): void {
    this.orderManagementService.getOrders().subscribe(orders=>{
      this.orders = orders;
    })
  }

}
