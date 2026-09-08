import { HttpClient, HttpErrorResponse } from "@angular/common/http";
import { inject, Service } from "@angular/core";
import { catchError, throwError } from "rxjs";
import { Login } from "./login.model";
import { LoginResponse } from "./loginResponse.model";

@Service()
export class LoginService {
  private httpClient = inject(HttpClient);
  private readonly loginUrl = "https://localhost:44359/api/LoginApi/login";

  login(login: Login) {
    return this.httpClient.post<LoginResponse>(this.loginUrl, {
      email: login.email,
      password: login.password
    }, {
      responseType: 'text'
    }).pipe(
      catchError((err: HttpErrorResponse) => {
        const apiMessage = typeof err.error === "string" ? err.error : "Login request failed";
        return throwError(() => new Error(`${apiMessage} (status: ${err.status})`));
      })
    )
  }

  
}
