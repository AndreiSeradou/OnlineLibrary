import { Component, OnInit } from '@angular/core';
import { responceOrderModel } from '../Models/responceOrderModel';
import { UserService } from '../service/user.service';

@Component({
  selector: 'app-librarian-get-all-orders',
  templateUrl: './librarian-get-all-orders.component.html',
  styleUrls: ['./librarian-get-all-orders.component.scss']
})
export class LibrarianGetAllOrdersComponent implements OnInit {

  public orderListConditionFalse: responceOrderModel[] = [];
  public orderListConditionTrue: responceOrderModel[] = [];
  constructor(private userService:UserService) { }

  ngOnInit(): void {
    this.getAllOrdersConditionFalse();
    this.getAllOrdersConditionTrue();
  }

  onSubmit(num:number){
    this.userService.updateOrder(num).subscribe(data => {
      if (data) {
        console.log(data)
      }
    })
   }

   onSubmitDelete(num:number){
    this.userService.deleteOrder(num).subscribe(data => {
      if (data) {
        console.log(data)
      }
    })
   }

  getAllOrdersConditionFalse()
  {
    this.userService.getAllOrdersConditionFalse().subscribe((data:any)=>{
      this.orderListConditionFalse = data;
    })
  } 
  getAllOrdersConditionTrue()
  {
    this.userService.getAllOrdersConditionTrue().subscribe((data:any)=>{
      this.orderListConditionTrue = data;
    })
  } 

}
