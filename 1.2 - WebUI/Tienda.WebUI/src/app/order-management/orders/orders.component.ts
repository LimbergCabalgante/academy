import { Component, OnInit } from '@angular/core';
import { Order } from 'src/app/common/dtos/order';

@Component({
  selector: 'app-orders',
  templateUrl: './orders.component.html',
  styleUrls: ['./orders.component.scss']
})
export class OrdersComponent implements OnInit {
  orders: Order[] = [
    {
      createdDate: new Date(),
      statusId: 1,
      totalPrice: 153.00
    },
    {
      createdDate: new Date(),
      statusId: 2,
      totalPrice: 23.00
    },
    {
      createdDate: new Date(),
      statusId: 3,
      totalPrice: 123223.00
    },
]

  constructor() { }

  ngOnInit(): void {
  }

}
