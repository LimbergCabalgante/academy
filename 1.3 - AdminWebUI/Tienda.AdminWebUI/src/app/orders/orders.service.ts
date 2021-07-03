import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Order } from './order/order';

@Injectable({
    providedIn: 'root'
})
export class OrdersService {

    constructor(private http: HttpClient) {

    }

    getOrders(){
        return this.http.get<Order[]>(environment.apiUrl + "Order");
    }

    updateOrderStatus(id, statusId){
        return this.http.put(environment.apiUrl + "Order", {id: id, statusId: statusId})
    }

}