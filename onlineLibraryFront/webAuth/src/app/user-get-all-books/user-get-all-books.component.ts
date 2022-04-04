import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { responceBookModel } from '../Models/responceBookModel';
import { UserService } from '../service/user.service';

@Component({
  selector: 'app-user-get-all-books',
  templateUrl: './user-get-all-books.component.html',
  styleUrls: ['./user-get-all-books.component.scss']
})
export class UserGetAllBooksComponent implements OnInit {

  public filterForm=this.formBuilder.group({
    filter:['',[Validators.required]],
  })

  public bookList: responceBookModel[] = [];
  constructor(private formBuilder:FormBuilder,private userService:UserService) { }

  ngOnInit(): void {
    this.getAllBooks();
  }

  onSubmit(num:number){
    this.userService.createOrder(num).subscribe(data => {
      if (data) {
        alert("Successfully added");
        console.log(data);
        location.reload();
      }
      else
      {
        alert("Order exists");
        console.log("Order exists");
      }
    })
   }

   onSubmitOrderByName(){
    this.userService.getAllBooks("Name").subscribe((data:any)=>{
      this.bookList = data;
    })
   }

   onSubmitFilter(){
    let filter=this.filterForm.controls["filter"].value;
    this.userService.getFilteredBooks(filter).subscribe((data:any)=>{
      this.bookList = data;
    })
  }

   onSubmitOrderByCount(){
    this.userService.getAllBooks("Count").subscribe((data:any)=>{
      this.bookList = data;
    })
   }

   onSubmitOrderById(){
    this.userService.getAllBooks("Id").subscribe((data:any)=>{
      this.bookList = data;
    })
   }

   onSubmitOrderByDescription(){
    this.userService.getAllBooks("Text").subscribe((data:any)=>{
      this.bookList = data;
    })
   }

  getAllBooks()
  {
    this.userService.getAllBooks("").subscribe((data:any)=>{
      this.bookList = data;
    })
  }
}
