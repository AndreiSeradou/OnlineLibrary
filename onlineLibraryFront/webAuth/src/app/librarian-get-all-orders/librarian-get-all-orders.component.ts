import { Component, OnInit } from '@angular/core';
import { responceOrderModel } from '../Models/responceOrderModel';
import { UserService } from '../service/user.service';

@Component({
  selector: 'app-librarian-get-all-orders',
  templateUrl: './librarian-get-all-orders.component.html',
  styleUrls: ['./librarian-get-all-orders.component.scss']
})
export class LibrarianGetAllOrdersComponent implements OnInit {

  public orderList: responceOrderModel[] = [];
  constructor(private userService:UserService) { }

  ngOnInit(): void {
    this.getAllBooks();
  }

  getAllBooks()
  {
    this.userService.getAllOrders().subscribe((data:any)=>{
      this.orderList = data;
    })
  } 

}
