import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { SignupComponent } from './user/signup/signup.component';
import { LoginComponent } from './user/login/login.component';
import { OrdersComponent } from './user/orders/orders.component';
import { ShopComponent } from './shop/shop.component';
import { CartComponent } from './shop/cart/cart.component';

const routes: Routes = [

  { path: 'signup', component: SignupComponent },
  { path: 'login', component: LoginComponent },
  { path: 'shop', component: ShopComponent },
  { path: 'cart', component: CartComponent },
  { path: 'orders', component: OrdersComponent },
  { path: '', component: ShopComponent, pathMatch: 'full' },

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
