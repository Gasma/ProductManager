import { HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { tap } from "rxjs/operators";
import { LoginService } from '../services/login.service';

@Injectable()
export class AuthInterceptor implements HttpInterceptor {

  /**
   *
   */
  constructor(private router: Router, private service: LoginService) {

  }
  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    if(this.service.hastoken()) {
      const cloneReq = req.clone({
        headers: req.headers
            .set('Authorization', 'Bearer ' + this.service.gettoken())
            .set('Content-Type', 'application/json')
      });
      // let token = this.service.gettoken();
      // const cloneReq = req.clone({
      //   setHeaders: {
      //     Authorization: `Bearer ${token}`
      // }});
      return next.handle(cloneReq).pipe(
        tap(
          succ => { },
          err => {
            if (err.status == 401){
              this.service.cleartoken();
              this.router.navigateByUrl('/user/login');
            }
          }
        )
      );
    }
    else
      return next.handle(req.clone({
        headers: req.headers
          .set('Content-Type', 'application/json')
      }));
  }

}
