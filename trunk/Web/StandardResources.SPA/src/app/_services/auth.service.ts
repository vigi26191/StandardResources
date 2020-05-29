import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { JwtHelperService } from '@auth0/angular-jwt';
import { Observable, BehaviorSubject } from 'rxjs';
import { map } from 'rxjs/operators'
import { environment } from 'src/environments/environment';
import { IAppUser } from '../_ models/app-user.model';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  jwtHelper = new JwtHelperService();
  // loggedInUserName: string;

  // appUserSubject = new BehaviorSubject<string>(null);
  // appUserObservable = this.appUserSubject.asObservable();

  constructor(private http: HttpClient) { }

  login(authRequest: any): Observable<any> {
    let body = new URLSearchParams();

    if (authRequest.email) {
      body.set('email', authRequest.email ?? null);
    }

    body.set('username', authRequest.userName);
    body.set('password', authRequest.password);
    body.set('grant_type', 'password');

    let options = {
      headers: new HttpHeaders().set('content-type', 'application/x-www-form-urlencoded')
    }

    return this.http.post(environment.authApiUrl, body.toString(), options).pipe(
      map((response: any) => {
        const user = response;

        if (user) {
          sessionStorage.setItem('token', user.access_token);
          // this.assignLoggedInUserName();
          // this.appUserSubject.next(this.loggedInUserName);
        }
      })
    );
  }

  get decodedToken(): any {
    const token = sessionStorage.getItem('token');
    if (token) {
      return this.jwtHelper.decodeToken(token);
    }
  }

  get loggedInUserName() {
    return this.decodedToken.userName;
  }

  // assignLoggedInUserName(): void {
  //   this.loggedInUserName = this.decodedToken.userName;
  // }

  appUserEmitter(appUser: IAppUser) {
    // this.appUserSubject.next(appUser);
  }

  loggedIn() {
    const token = sessionStorage.getItem('token');
    return !this.jwtHelper.isTokenExpired(token);
  }

  logout() {
    sessionStorage.removeItem('token');
  }
}
