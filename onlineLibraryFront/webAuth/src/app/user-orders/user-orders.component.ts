import { Component, OnInit } from '@angular/core';
import { responceOrderModel } from '../Models/responceOrderModel';
import { UserService } from '../service/user.service';

@Component({
  selector: 'app-user-orders',
  templateUrl: './user-orders.component.html',
  styleUrls: ['./user-orders.component.scss']
})
export class UserOrdersComponent implements OnInit {

  public orderList: responceOrderModel[] = [];
  
  constructor(private userService:UserService) { }

  ngOnInit(): void {
    this.getUserOrders();
  }

  getUserOrders()
  {
    this.userService.getUserOrders().subscribe((data:any)=>{
      this.orderList = data;
    })
  } 
}
