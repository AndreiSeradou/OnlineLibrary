import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { UserService } from '../service/user.service';

@Component({
  selector: 'app-librarian-update-order',
  templateUrl: './librarian-update-order.component.html',
  styleUrls: ['./librarian-update-order.component.scss']
})
export class LibrarianUpdateOrderComponent implements OnInit {
  public updateOrderForm=this.formBuilder.group({
    id:['',[Validators.required, Validators.pattern(/^-?(0|[1-9]\d*)?$/)]]
  })
  constructor(private formBuilder:FormBuilder, private userService:UserService) { }

  ngOnInit(): void {
  }

  onSubmit(){
    let id=this.updateOrderForm.controls["id"].value;
    this.userService.updateOrder(id).subscribe(data => {
      if (data) {
        console.log(data)
      }
    })
   }
}
