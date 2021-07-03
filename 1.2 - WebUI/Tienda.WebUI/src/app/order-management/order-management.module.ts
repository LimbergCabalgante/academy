import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { HttpClientModule } from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { CartComponent } from './cart/cart.component';
import { OrdersComponent } from './orders/orders.component';
import { OrderComponent } from './orders/order/order.component';
import { ConfirmationDialogComponent } from './cart/confirmation-dialog/confirmation-dialog.component';
import { DeletionConfirmationDialogComponent } from './cart/deletion-confirmation-dialog/deletion-confirmation-dialog.component';

import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatDividerModule } from '@angular/material/divider';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { MatDialogModule } from '@angular/material/dialog';
import { MatSnackBarModule, MAT_SNACK_BAR_DEFAULT_OPTIONS } from '@angular/material/snack-bar';
import { MatTooltipModule } from '@angular/material/tooltip';

@NgModule({
    declarations: [
        CartComponent,
        OrdersComponent,
        OrderComponent,
        ConfirmationDialogComponent,
        DeletionConfirmationDialogComponent
    ],
    imports: [
        CommonModule,
        BrowserAnimationsModule,
        HttpClientModule,
        FormsModule,
        ReactiveFormsModule,
        MatFormFieldModule,
        MatInputModule,
        MatDividerModule,
        MatButtonModule,
        MatIconModule,
        MatDialogModule,
        MatSnackBarModule,
        MatTooltipModule
    ],
    exports: [
        CartComponent,
        OrdersComponent,
        OrderComponent,
        ConfirmationDialogComponent,
        DeletionConfirmationDialogComponent
    ],
    providers: [
        { provide: MAT_SNACK_BAR_DEFAULT_OPTIONS, useValue: { duration: 2500 } }
    ]
})
export class OrderManagementModule { }