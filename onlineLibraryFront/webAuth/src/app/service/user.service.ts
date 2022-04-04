import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { responceBookModel } from '../Models/responceBookModel';
import { ResponceModel } from '../Models/responceModel';
import { responceOrderModel } from '../Models/responceOrderModel';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  private readonly baseURL:string="http://localhost:8090/api/";

  constructor(private httpClient:HttpClient) { }

  public login(email:string,password:string)
  {
    const body={
      email:email,
      password:password
    }

    return this.httpClient.post<ResponceModel>(this.baseURL+"AuthManagement/Login",body);
  }

  public register(fullname:string,email:string,password:string)
  {

    const body={
      username:fullname,
      email:email,
      password:password
    }

    return this.httpClient.post<ResponceModel>(this.baseURL+"AuthManagement/Register",body);
  }

  public getAllBooks(text : string)
  {
    let token = localStorage.getItem("token");

    const body={
      Text:text
    }

    const headers=new HttpHeaders({
      'Content-Type': 'application/json',
      'Authorization': `Bearer ${token}`
    });
    return  this.httpClient.post<responceBookModel[]>(this.baseURL+"User/GetAllBooksAsync",body,{headers:headers});
  }

  public getFilteredBooks(text : string)
  {
    let token = localStorage.getItem("token");

    const body={
      Text:text
    }

    const headers=new HttpHeaders({
      'Content-Type': 'application/json',
      'Authorization': `Bearer ${token}`
    });
    return  this.httpClient.post<responceBookModel[]>(this.baseURL+"User/GetFilteredBooksAsync",body,{headers:headers});
  }

  public getUserBooks()
  {
    let token = localStorage.getItem("token");

    const headers=new HttpHeaders({
      'Content-Type': 'application/json',
      'Authorization': `Bearer ${token}`
    });
    return  this.httpClient.get<responceBookModel[]>(this.baseURL+"User/GetUserBooksAsync",{headers:headers});
  }

  public GetOverdueOrders()
  {
    let token = localStorage.getItem("token");

    const headers=new HttpHeaders({
      'Content-Type': 'application/json',
      'Authorization': `Bearer ${token}`
    });
    return  this.httpClient.get<responceOrderModel[]>(this.baseURL+"User/GetOverdueOrdersAsync",{headers:headers});
  }

  public getUserOrders()
  {
    let token = localStorage.getItem("token");

    const headers=new HttpHeaders({
      'Content-Type': 'application/json',
      'Authorization': `Bearer ${token}`
    });
    return  this.httpClient.get<responceOrderModel[]>(this.baseURL+"User/GetUserOrdersAsync",{headers:headers});
  }

  public createOrder(bookId:number)
  {
    let token = localStorage.getItem("token");
    const headers=new HttpHeaders({
      'Content-Type': 'application/json',
      'Authorization': `Bearer ${token}`
    });

    const body={
      BookId:bookId
    }

    return this.httpClient.post<boolean>(this.baseURL+"User/CreateOrderAsync/",body,{headers:headers});
  }

  public createBook(name:string, text:string, count:number)
  {
    let token = localStorage.getItem("token");
    const headers=new HttpHeaders({
      'Content-Type': 'application/json',
      'Authorization': `Bearer ${token}`
    });

    const body={
      name:name,
      text:text,
      count:count
    }

    return this.httpClient.post<boolean>(this.baseURL+"Librarian/CreateBook/",body,{headers:headers});
  }

  public getAllOrdersConditionFalse()
  {
    let token = localStorage.getItem("token");

    const headers=new HttpHeaders({
      'Content-Type': 'application/json',
      'Authorization': `Bearer ${token}`
    });
    return  this.httpClient.get<responceOrderModel[]>(this.baseURL+"Librarian/GetAllOrdersConditionFalseAsync",{headers:headers});
  }

  public getAllOrdersConditionTrue()
  {
    let token = localStorage.getItem("token");

    const headers=new HttpHeaders({
      'Content-Type': 'application/json',
      'Authorization': `Bearer ${token}`
    });
    return  this.httpClient.get<responceOrderModel[]>(this.baseURL+"Librarian/GetAllOrdersConditionTrueAsync",{headers:headers});
  }

  public updateOrder(id:number)
  {
    let token = localStorage.getItem("token");
    const headers=new HttpHeaders({
      'Content-Type': 'application/json',
      'Authorization': `Bearer ${token}`
    });

    const body={
      id:id
    }

    return this.httpClient.post<boolean>(this.baseURL+"Librarian/UpdateOrderAsync/", body,{headers:headers});
  }

  public deleteOrder(id:number)
  {
    let token = localStorage.getItem("token");
    const headers=new HttpHeaders({
      'Content-Type': 'application/json',
      'Authorization': `Bearer ${token}`
    });

    const body={
      id:id
    }

    return this.httpClient.post<boolean>(this.baseURL+"Librarian/DeleteOrderAsync/", body,{headers:headers});
  }
}
