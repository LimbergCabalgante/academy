import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { MatButtonModule } from '@angular/material/button';
import { ShopComponent } from './shop.component';
import { ProductComponent } from './product/product.component';
import { ViewProductComponent } from './view-product/view-product.component';

@NgModule({
    declarations: [
        ShopComponent,
        ProductComponent,
        ViewProductComponent
    ],
    imports: [
        CommonModule,
        BrowserAnimationsModule,
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