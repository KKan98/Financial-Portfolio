import { HttpClient, HttpErrorResponse } from "@angular/common/http";
import { inject, Service, signal } from "@angular/core";
import { catchError, tap, throwError } from "rxjs";
import { LoginModel } from "./login/login.model";
import { LoginResponse } from "./login/loginResponse.model";
import { SignupModel } from "./signup/signup.model";
import { User } from "./user.model";
import { Router } from "@angular/router";
import { Role } from "./role.model";

@Service()
export class AuthService {
  private httpClient = inject(HttpClient);
  private router = inject(Router);

  private readonly AUTH_TOKEN_KEY = "financial_portfolio_user_data";
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

  autoLogin() {
    const userData : {
      id: string,
      email: string,
      role: Role,
      _token: string,
      _expiresAt: string
    } = this.getUserData();

    if(!userData) return;

    const loadedUser = new User(
      userData.id,
      userData.email,
      userData.role,
      userData._token,
      new Date(userData._expiresAt)
    )

    if(loadedUser.token) this.user.set(loadedUser);
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
    this.clearUserData();
    this.router.navigate(['/login']);
  }
  
  getUserData() {
    const token = localStorage.getItem(this.AUTH_TOKEN_KEY);
    if(!token) return null;

    const parsedToken = JSON.parse(token);
    return parsedToken;
  }

  setUserData(userData: User) : void {
    localStorage.setItem(this.AUTH_TOKEN_KEY, JSON.stringify(userData));
  }

  clearUserData() {
    localStorage.removeItem(this.AUTH_TOKEN_KEY);
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
          new Date(respData.expiresAt)
        );
      this.user.set(user);     
      this.setUserData(user);
  }
}
