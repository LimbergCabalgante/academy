import { NgModule } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatMenuModule } from '@angular/material/menu';
import { MatListModule } from '@angular/material/list';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';

const MaterialComponents = [
  MatButtonModule,
  MatToolbarModule,
  MatSidenavModule,
  MatMenuModule,
  MatListModule,
  MatFormFieldModule,
  MatInputModule
]

@NgModule({
  declarations: [],
  imports: [MaterialComponents],
  exports: [MaterialComponents],
})
export class MaterialModule { }
