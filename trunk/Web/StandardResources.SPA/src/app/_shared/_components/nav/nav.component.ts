import { Component, OnInit } from '@angular/core';
import { AuthService } from 'src/app/_services/auth.service';
import { Router } from '@angular/router';
import { ROUTE_PATH } from 'src/app/_constants/route-names.constant';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {
  readonly routePath = ROUTE_PATH;

  public userName: string;

  appUserSubscription: Subscription

  constructor(
    private router: Router,
    private authService: AuthService) { }

  ngOnInit(): void {
    this.userName = this.authService.loggedInUserName;

    // this.appUserSubscription = this.authService.appUserObservable.subscribe(username => {
    //   this.userName = username;
    // })
  }

  logout() {
    this.authService.logout();
    this.router.navigate([ROUTE_PATH.LOGIN]);
  }

}
