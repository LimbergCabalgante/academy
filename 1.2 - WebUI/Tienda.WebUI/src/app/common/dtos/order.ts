import { Cart } from "./cart";

export class Order {
    billingNumber?: number;
    createdDate: Date;
    userId?: number;
    statusId: number;
    totalPrice: number;
    orderLines?: Cart;
}
