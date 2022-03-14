import { Component } from '@angular/core';
import { Constants } from './Helper/constants';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'webAuth';
  constructor(){}
  onLogout()
  {
    localStorage.removeItem(Constants.USER_KEY);
  }

 get isUserLogin()
  {
    const user = localStorage.getItem(Constants.USER_KEY);
    return user && user.length>0;
  }
}
