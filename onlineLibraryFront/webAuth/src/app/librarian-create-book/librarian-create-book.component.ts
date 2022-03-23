import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { UserService } from '../service/user.service';

@Component({
  selector: 'app-librarian-create-book',
  templateUrl: './librarian-create-book.component.html',
  styleUrls: ['./librarian-create-book.component.scss']
})
export class LibrarianCreateBookComponent implements OnInit {

  constructor(private formBuilder:FormBuilder, private userService:UserService) { }
  public createBookForm=this.formBuilder.group({
    name:['',[Validators.required]],
    text:['',[Validators.required]],
    count:['',[Validators.required, Validators.pattern(/^-?(0|[1-9]\d*)?$/)]]
  })
  ngOnInit(): void {
  }

  onSubmit(){
    let name=this.createBookForm.controls["name"].value;
    let text=this.createBookForm.controls["text"].value;
    let count=this.createBookForm.controls["count"].value;
    this.userService.createBook(name, text, count).subscribe(data => {
      if (data) {
        alert("Successfully create");
        console.log(data)
      }
      else
      {
        alert("Error create");
      }
    })
   }
}
