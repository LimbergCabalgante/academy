import { Cart } from "./cart";

export class Order {
    billingNumber: number;
    createdDate: Date;
    userId: number;
    statusId: number;
    orderLines: Cart;
}
