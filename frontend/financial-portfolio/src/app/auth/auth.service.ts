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
    }, {
      responseType: 'text'
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
    }, {
      responseType: 'text'
    }).pipe(
      catchError((err: HttpErrorResponse) => {
        return throwError(() => new Error(`${err.error} (status ${err.status})`))
      })
    )
  }
  
}
