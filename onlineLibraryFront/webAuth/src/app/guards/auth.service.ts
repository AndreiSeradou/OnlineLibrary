import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot, UrlTree } from '@angular/router';
import { Constants } from '../Helper/constants';

@Injectable({
  providedIn: 'root'
})
export class AuthService implements CanActivate {

  constructor(private router:Router) { }
  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean {
    const token = localStorage.getItem(Constants.USER_KEY);
    const role = localStorage.getItem(Constants.USER_ROLE);
 
    if (token)
    {
      if (role == "AppUser" && route.url.toString().includes('user'))
      {
        return true
      }

      if (role == "AppLibrarian" && route.url.toString().includes('librarian'))
      {
        return true
      }

      alert("Don't touch");
      this.router.navigate(["login"]);
      return false;
    }
    else
    {
      alert("Don't touch");
      this.router.navigate(["login"]);
      return false;
    }
  }
}
