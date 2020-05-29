import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ROUTE_PATH } from 'src/app/_constants/route-names.constant';
import { AuthService } from 'src/app/_services/auth.service';
import { FormBuilder, NgForm } from '@angular/forms';
import { AlertifyService } from '../../_services/alertify.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  constructor(
    private router: Router,
    private authService: AuthService,
    private alertify: AlertifyService
  ) { }

  ngOnInit(): void {
    if (this.authService.loggedIn())
      this.router.navigate([ROUTE_PATH.DASHBOARD]);

  }

  login(loginForm: NgForm) {
    this.alertify.clear();

    this.authService.login(loginForm.value)
      .subscribe(next => {

      },
        (error) => {
          if (error.error.error == 'invalid_login') {
            loginForm.reset();
            document.getElementById('txtRegisterEmail').focus();
          }

          this.alertify.error(error.error.error_description);
        }
      )
  }

  register(registerForm: NgForm) {
    this.alertify.clear();

    this.authService.login(registerForm.value)
      .subscribe(next => {

      },
        (error) => {
          this.alertify.error(error.error.error_description);
        }
      )
  }


}
