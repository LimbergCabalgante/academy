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
import { RangePipe } from '../common/pipes/range.pipe';
import { MatInputModule } from '@angular/material/input';
import { MatIconModule } from '@angular/material/icon';
import { MatDialogModule } from '@angular/material/dialog';
import { MatSnackBarModule, MAT_SNACK_BAR_DEFAULT_OPTIONS } from '@angular/material/snack-bar';

@NgModule({
    declarations: [
        ShopComponent,
        ProductComponent,
        ViewProductComponent,
        RangePipe
    ],
    imports: [
        CommonModule,
        BrowserAnimationsModule,
        HttpClientModule,
        FormsModule,
        ReactiveFormsModule,
        MatFormFieldModule,
        MatInputModule,
        MatSelectModule,
        MatButtonModule,
        MatIconModule,
        MatDialogModule,
        MatSnackBarModule
    ],
    exports: [
        ShopComponent,
        ProductComponent,
        ViewProductComponent
    ],
    providers: [
        { provide: MAT_SNACK_BAR_DEFAULT_OPTIONS, useValue: { duration: 2500 } }
    ]
})
export class ShopModule { }