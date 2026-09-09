import { HttpClient, HttpErrorResponse } from "@angular/common/http";
import { inject, Service } from "@angular/core";
import { catchError, throwError } from "rxjs";
import { LoginModel } from "./login/login.model";
import { LoginResponse } from "./login/loginResponse.model";
import { SignupModel } from "./signup/signup.model";

@Service()
export class AuthService {
  private httpClient = inject(HttpClient);
  private readonly loginUrl = "https://localhost:44359/api/AuthApi/login";
  private readonly signupUrl = "https://localhost:44359/api/AuthApi/signup"

  login(login: LoginModel) {
    return this.httpClient.post<LoginResponse>(this.loginUrl, {
      email: login.email,
      password: login.password
    }).pipe(
      catchError((err: HttpErrorResponse) => {
        return throwError(() => new Error(`${err.error} (status: ${err.status})`));
      })
    )
  }

  signup(signup: SignupModel) {
    return this.httpClient.post(this.signupUrl, {
      email: signup.email,
      password: signup.password,
      role: signup.role
    }).pipe(
      catchError((err: HttpErrorResponse) => {
        return throwError(() => new Error(`${err.error} (status ${err.status})`))
      })
    )
  }

  getAllUsers() {
    return this.httpClient.get<UsersModel[]>("https://localhost:44359/api/AuthApi").pipe(
      catchError((err: HttpErrorResponse) => {
        return throwError(() => new Error(`${err.error} (status ${err.status})`))
      })
     )
  }
  
  getToken() : string | null {
    const token = localStorage.getItem('jwt');
    if(!token) return null;

    const parsedToken = JSON.parse(token) as LoginResponse;
    return parsedToken.jwt;
  }
}


type UsersModel = {
  id: number,
  email: string,
  password: string,
  role: 'None' | 'Basic' | 'Pro' | 'Administratorr'
}
