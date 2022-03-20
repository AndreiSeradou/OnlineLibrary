import { Component, OnInit } from '@angular/core';
import { responceOrderModel } from '../Models/responceOrderModel';
import { UserService } from '../service/user.service';

@Component({
  selector: 'app-user-message',
  templateUrl: './user-message.component.html',
  styleUrls: ['./user-message.component.scss']
})
export class UserMessageComponent implements OnInit {

  public overdueList: responceOrderModel[] = [];
  constructor(private userService:UserService) { }

  ngOnInit(): void {
    this.GetOverdueOrders();
  }

  GetOverdueOrders()
  {
    this.userService.GetOverdueOrders().subscribe((data:any)=>{
      this.overdueList = data;
    })
  } 

}
