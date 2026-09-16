import { HttpClient, HttpErrorResponse } from "@angular/common/http";
import { inject, Service, signal } from "@angular/core";
import { catchError, tap, throwError } from "rxjs";
import { LoginModel } from "./login/login.model";
import { LoginResponse } from "./login/loginResponse.model";
import { SignupModel } from "./signup/signup.model";
import { User } from "./user.model";
import { Router } from "@angular/router";

@Service()
export class AuthService {
  private httpClient = inject(HttpClient);
  private router = inject(Router);

  private readonly loginUrl = "https://localhost:44359/api/AuthApi/login";
  private readonly signupUrl = "https://localhost:44359/api/AuthApi/signup"

  user = signal<User | null>(null);
  

  login(login: LoginModel) {
    return this.httpClient.post<LoginResponse>(this.loginUrl, {
      email: login.email,
      password: login.password
    }).pipe(
      catchError(this.handleError),
      tap(respData => this.handleAuthentication(respData))
    )
  }

  signup(signup: SignupModel) {
    return this.httpClient.post(this.signupUrl, {
      email: signup.email,
      password: signup.password,
      role: signup.role
    }).pipe(
      catchError(this.handleError)
    )
  }

  logout() {
    this.user.set(null);
    this.clearToken();
    this.router.navigate(['/login']);
  }
  
  getToken() : string | null {
    const token = localStorage.getItem('jwt');
    if(!token) return null;

    const parsedToken = JSON.parse(token) as LoginResponse;
    return parsedToken.jwt;
  }

  setToken(token: LoginResponse) : void {
    localStorage.setItem('jwt', JSON.stringify(token));
  }

  clearToken() {
    localStorage.removeItem('jwt');
  }

  private handleError(errorRes: HttpErrorResponse) {
    return throwError(() => new Error(`${errorRes.error} (status ${errorRes.status})`))
  } 

  private handleAuthentication(respData: LoginResponse) {
    const user = new User(
          respData.id,
          respData.email,
          respData.role,
          respData.jwt,
          respData.expiresAt
        );
      this.user.set(user);       
  }
}
