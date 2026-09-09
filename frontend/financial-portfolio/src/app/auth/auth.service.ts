import { HttpClient, HttpErrorResponse } from "@angular/common/http";
import { afterNextRender, inject, Service, signal } from "@angular/core";
import { catchError, tap, throwError } from "rxjs";
import { LoginModel } from "./login/login.model";
import { LoginResponse } from "./login/loginResponse.model";
import { SignupModel } from "./signup/signup.model";
import { Role } from "./role.model";
import { User } from "./user.model";

@Service()
export class AuthService {
  private httpClient = inject(HttpClient);
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

  getAllUsers() {
    return this.httpClient.get<UsersModel[]>("https://localhost:44359/api/AuthApi").pipe(
      catchError(this.handleError)
     )
  }
  
  getToken() : string | null {
    const token = localStorage.getItem('jwt');
    if(!token) return null;

    const parsedToken = JSON.parse(token) as LoginResponse;
    return parsedToken.jwt;
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
        console.log(user);
        
  }
}


type UsersModel = {
  id: number,
  email: string,
  password: string,
  role: Role
}
