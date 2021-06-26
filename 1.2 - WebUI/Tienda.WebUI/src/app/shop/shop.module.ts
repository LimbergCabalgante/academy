import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { HttpClientModule } from '@angular/common/http'
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { ShopComponent } from './shop.component';
import { ProductComponent } from './product/product.component';
import { ViewProductComponent } from './product/view-product/view-product.component';
import { MatFormFieldModule } from '@angular/material/form-field';

import { MatSelectModule } from '@angular/material/select';
import { MatButtonModule } from '@angular/material/button';
import { CartComponent } from './cart/cart.component';

@NgModule({
    declarations: [
        ShopComponent,
        ProductComponent,
        ViewProductComponent,
        CartComponent
    ],
    imports: [
        CommonModule,
        BrowserAnimationsModule,
        HttpClientModule,
        FormsModule,
        ReactiveFormsModule,
        MatFormFieldModule,
        MatSelectModule,
        MatButtonModule
    ],
    exports: [
        ShopComponent,
        ProductComponent,
        ViewProductComponent
    ],
    providers: [],
})
export class ShopModule { }