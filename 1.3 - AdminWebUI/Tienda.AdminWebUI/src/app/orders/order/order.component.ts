import { Component, Input, OnInit } from '@angular/core';
import { OrdersService } from '../orders.service';
import { Order } from './order';

@Component({
  selector: 'app-order',
  templateUrl: './order.component.html',
  styleUrls: ['./order.component.scss']
})
export class OrderComponent implements OnInit {
  @Input() order: Order

  constructor(private ordersService: OrdersService) { }

  ngOnInit() {
  }

  changeStatus(){
    console.log(this.order.id);
  }

}
