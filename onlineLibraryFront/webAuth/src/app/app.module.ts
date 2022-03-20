import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginComponent } from './login/login.component';
import {HttpClientModule} from '@angular/common/http';
import { RegisterComponent } from './register/register.component';
import { AddInformationComponent } from './add-information/add-information.component';
import { UserBooksComponent } from './user-books/user-books.component';
import { UserOrdersComponent } from './user-orders/user-orders.component';
import { UserGetAllBooksComponent } from './user-get-all-books/user-get-all-books.component';
import { LibrarianCreateBookComponent } from './librarian-create-book/librarian-create-book.component';
import { LibrarianGetAllOrdersComponent } from './librarian-get-all-orders/librarian-get-all-orders.component';
import { UserMessageComponent } from './user-message/user-message.component';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    RegisterComponent,
    AddInformationComponent,
    UserBooksComponent,
    UserOrdersComponent,
    UserGetAllBooksComponent,
    LibrarianCreateBookComponent,
    LibrarianGetAllOrdersComponent,
    UserMessageComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule,
    ReactiveFormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
