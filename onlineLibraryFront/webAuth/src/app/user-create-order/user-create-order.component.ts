import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { UserService } from '../service/user.service';

@Component({
  selector: 'app-user-create-order',
  templateUrl: './user-create-order.component.html',
  styleUrls: ['./user-create-order.component.scss']
})
export class UserCreateOrderComponent implements OnInit {
  public createOrderForm=this.formBuilder.group({
    bookId:['',[Validators.required, Validators.pattern(/^-?(0|[1-9]\d*)?$/)]]
  })
  constructor(private formBuilder:FormBuilder, private userService:UserService) { }

  ngOnInit(): void {
  }

  onSubmit(){
    let bookId=this.createOrderForm.controls["bookId"].value;
    this.userService.createOrder(bookId).subscribe(data => {
      if (data) {
        console.log(data)
      }
    })
   }
}
