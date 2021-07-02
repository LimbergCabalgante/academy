import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Inject } from '@angular/core';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';
import { MatSnackBar } from '@angular/material/snack-bar';
import { OrderManagementService } from 'src/app/order-management/order-management.service';

@Component({
  selector: 'app-view-product',
  templateUrl: './view-product.component.html',
  styleUrls: ['./view-product.component.scss']
})
export class ViewProductComponent implements OnInit {
  form: FormGroup;

  constructor(@Inject(MAT_DIALOG_DATA) public product: any, private snackBar: MatSnackBar, private formBuilder: FormBuilder, public orderManagementService: OrderManagementService) { }

  ngOnInit(): void {

    console.log(this.product.product);

    let self = this;
      self.form = this.formBuilder.group({
        product: this.product.product.id,
        amount: [null, [Validators.required, Validators.min(1)]],
    });

  }

  AddProduct(form){
    this.orderManagementService.addItemToCart(this.product.product, this.form.get('amount').value);
    this.snackBar.open("Has añadido " + this.product.product.name.toLowerCase() + " (x" + this.form.get('amount').value + ")" + " a tu carrito.", "OK", {panelClass: "success-snackbar"});
    form.resetForm();
    this.form.setValue({product: this.product.product.id, amount: null});

  }

}
