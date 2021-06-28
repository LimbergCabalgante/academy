import { Component, Input, OnInit } from '@angular/core';
import { ViewProductComponent } from './view-product/view-product.component';
import { MatDialog } from '@angular/material/dialog';
import { Product } from 'src/app/common/dtos/product';

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.scss']
})
export class ProductComponent implements OnInit {
  @Input() product: Product

  constructor(private dialog: MatDialog) { }

  ngOnInit(): void {
  }

  handleImageError(){
    this.product.imageUrl = "../../../../assets/no-product.png"
  }

  viewProduct(){
    this.dialog.open(ViewProductComponent,{
      disableClose: true,
      autoFocus: false,
      width: '500px',
      data: {
        product: this.product,
      }
    });
  }

}
