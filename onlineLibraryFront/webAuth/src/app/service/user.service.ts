import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { responceBookModel } from '../Models/responceBookModel';
import { ResponceModel } from '../Models/responceModel';
import { responceOrderModel } from '../Models/responceOrderModel';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  private readonly baseURL:string="https://localhost:44357/api/";

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

  public getAllBooks()
  {
    let token = localStorage.getItem("token");

    const headers=new HttpHeaders({
      'Content-Type': 'application/json',
      'Authorization': `Bearer ${token}`
    });
    return  this.httpClient.get<responceBookModel[]>(this.baseURL+"User/GetAllBooksAsync",{headers:headers});
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
}
