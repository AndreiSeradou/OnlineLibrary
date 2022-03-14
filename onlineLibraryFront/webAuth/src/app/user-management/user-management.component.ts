import { Component, OnInit } from '@angular/core';
import { Constants } from '../Helper/constants';
import { responceBookModel } from '../Models/responceBookModel';
import { User } from '../Models/user';
import { UserResume } from '../Models/userResume';
import { UserService } from '../service/user.service';

@Component({
  selector: 'app-user-management',
  templateUrl: './user-management.component.html',
  styleUrls: ['./user-management.component.scss']
})
export class UserManagementComponent implements OnInit {
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
