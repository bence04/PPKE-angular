import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LoginComponent } from './login/login.component';
import { LayoutComponent } from './layout/layout.component';
import { RouterModule } from '@angular/router';
import { MenuComponent } from './menu/menu.component';
import { SharedModule } from '../shared/shared.module';
import { RegisterComponent } from './dialog/register/register.component';
import { AuthInterceptor } from './auth.interceptor';
import { HTTP_INTERCEPTORS } from '@angular/common/http';



@NgModule({
  declarations: [LoginComponent, LayoutComponent, MenuComponent, RegisterComponent],
  imports: [
    CommonModule,
    RouterModule,
    SharedModule
  ],
  entryComponents: [
    RegisterComponent
  ],
  providers: [
    {
      provide: HTTP_INTERCEPTORS, useClass: AuthInterceptor, multi: true }
  ]
})
export class CoreModule { }
