import { Component, OnInit } from '@angular/core';
import { responceBookModel } from '../Models/responceBookModel';
import { UserService } from '../service/user.service';

@Component({
  selector: 'app-user-books',
  templateUrl: './user-books.component.html',
  styleUrls: ['./user-books.component.scss']
})
export class UserBooksComponent implements OnInit {

  public bookList: responceBookModel[] = [];
  constructor(private userService:UserService) { }

  ngOnInit(): void {
    this.getUserBooks();
  }

  getUserBooks()
  {
    this.userService.getUserBooks().subscribe((data:any)=>{
      this.bookList = data;
    })
  } 
}
