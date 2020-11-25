import { Injectable } from '@angular/core';
import { FormBuilder, FormGroup, Validators  } from '@angular/forms';
import { Router } from '@angular/router';
import { RestService } from './rest.service';

@Injectable({
  providedIn: 'root'
})
export class LoginService {

  constructor(private fb:FormBuilder, private rest: RestService, private router: Router) { }

  login(formData: any) {
    return this.rest.sendLoginRequest('api/login', formData);
  }

  hastoken(): boolean
  {
    return this.gettoken() != null;
  }

  gettoken(): string
  {
    return localStorage.getItem('token');
  }

  addtoken(token: string)
  {
    localStorage.setItem('token', token);
  }

  cleartoken()
  {
    localStorage.removeItem('token');
  }

  logout() {
    this.cleartoken();
    this.router.navigate(['/user/login']);
  }
}
