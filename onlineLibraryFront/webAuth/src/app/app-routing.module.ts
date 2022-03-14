import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AddInformationComponent } from './add-information/add-information.component';
import { AuthService } from './guards/auth.service';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { UserBooksComponent } from './user-books/user-books.component';
import { UserCreateOrderComponent } from './user-create-order/user-create-order.component';
import { UserManagementComponent } from './user-management/user-management.component';
import { UserOrdersComponent } from './user-orders/user-orders.component';

const routes: Routes = [
  {path:"login",component:LoginComponent},
  {path:"register",component:RegisterComponent},
  {path:"user-management",component:UserManagementComponent,canActivate:[AuthService]},
  {path:"user-books",component:UserBooksComponent},
  {path:"user-orders",component:UserOrdersComponent},
  {path:"user-create-order",component:UserCreateOrderComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
