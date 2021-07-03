import { Component, OnInit } from '@angular/core';
import { Order } from './order/order';
import { OrdersService } from './orders.service';

@Component({
  selector: 'app-orders',
  templateUrl: './orders.component.html',
  styleUrls: ['./orders.component.scss']
})
export class OrdersComponent implements OnInit {
  orders: Order[] = [
    {
      id: 1,
      createdDate: new Date(),
      statusId: 1,
      totalPrice: 153.00
    },
    {
      id: 2,
      createdDate: new Date(),
      statusId: 2,
      totalPrice: 23.00
    },
    {
      id: 3,
      createdDate: new Date(),
      statusId: 3,
      totalPrice: 123223.00
    },
]

  constructor(private ordersService: OrdersService) { }

  ngOnInit(): void {
  }

}
