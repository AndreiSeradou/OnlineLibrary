import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { UserService } from '../service/user.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent implements OnInit {
  public registerForm=this.formBuilder.group({
    fullName:['',[Validators.required]],
    email:['',[Validators.email,Validators.required]],
    password:['',Validators.required]
  })
  constructor(private formBuilder:FormBuilder, private userService:UserService, private router:Router) { }

  ngOnInit(): void {
  }

  onSubmit(){
   let fullName=this.registerForm.controls["fullName"].value;
   let email=this.registerForm.controls["email"].value;
   let password=this.registerForm.controls["password"].value;
   this.userService.register(fullName,email,password).subscribe((data)=>{
    console.log("response",data.token);
    if (data.success) {
      localStorage.setItem("token", data.token);
      localStorage.setItem("name", data.name);
      localStorage.setItem("role", data.role);
      this.router.navigateByUrl('user-management');
    }
   },error=>{
    console.log("error",error);
   })
  }
}
