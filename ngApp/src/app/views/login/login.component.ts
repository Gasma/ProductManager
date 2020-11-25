import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { LoginService } from 'src/app/services/login.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html'
})
export class LoginComponent implements OnInit {
  formModel = {
    UserName: '',
    Password: ''
  }
  constructor(private service: LoginService, private router: Router, private toastr: ToastrService) { }

  ngOnInit(): void {
    if (this.service.hastoken()) {
      this.router.navigateByUrl('/home');
    }
  }
  onSubmit(form: NgForm) {
    this.service.login(form.value).subscribe((res:any) => {
        if (res.token != null){
          this.service.addtoken(res.token);
          this.router.navigateByUrl('/home')
        } else {
            this.toastr.error("Não foi possivel conectar");
        }
      });
  }
}
