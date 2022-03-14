import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthService } from './guards/auth.service';
import { LibrarianCreateBookComponent } from './librarian-create-book/librarian-create-book.component';
import { LibrarianGetAllOrdersComponent } from './librarian-get-all-orders/librarian-get-all-orders.component';
import { LibrarianUpdateOrderComponent } from './librarian-update-order/librarian-update-order.component';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { UserBooksComponent } from './user-books/user-books.component';
import { UserCreateOrderComponent } from './user-create-order/user-create-order.component';
import { UserGetAllBooksComponent } from './user-get-all-books/user-get-all-books.component';


import { UserOrdersComponent } from './user-orders/user-orders.component';

const routes: Routes = [
  {path:"login",component:LoginComponent},
  {path:"register",component:RegisterComponent},
  {path:"user-books",component:UserBooksComponent,canActivate:[AuthService]},
  {path:"user-orders",component:UserOrdersComponent,canActivate:[AuthService]},
  {path:"user-create-order",component:UserCreateOrderComponent,canActivate:[AuthService]},
  {path:"user-get-all-books",component:UserGetAllBooksComponent,canActivate:[AuthService]},
  {path:"librarian-create-book",component:LibrarianCreateBookComponent,canActivate:[AuthService]},
  {path:"librarian-get-all-orders",component:LibrarianGetAllOrdersComponent,canActivate:[AuthService]},
  {path:"librarian-update-order",component:LibrarianUpdateOrderComponent,canActivate:[AuthService]}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
