import { Component, OnInit } from '@angular/core';
import { responceBookModel } from '../Models/responceBookModel';
import { UserService } from '../service/user.service';

@Component({
  selector: 'app-user-get-all-books',
  templateUrl: './user-get-all-books.component.html',
  styleUrls: ['./user-get-all-books.component.scss']
})
export class UserGetAllBooksComponent implements OnInit {

  public bookList: responceBookModel[] = [];
  constructor(private userService:UserService) { }

  ngOnInit(): void {
    this.getAllBooks();
  }

  getAllBooks()
  {
    this.userService.getAllBooks().subscribe((data:any)=>{
      this.bookList = data;
    })
  } 
}
