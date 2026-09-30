import { HttpClient, HttpErrorResponse } from "@angular/common/http";
import { inject, Service } from "@angular/core";
import { catchError, throwError } from "rxjs";
import { WalletModel } from "./wallet.model";
import { toSignal } from "@angular/core/rxjs-interop";

@Service()
export class WalletService {
  private httpClient = inject(HttpClient);

  private readonly getWalletsUrl = "https://localhost:44359/api/WalletApi"
  private readonly addWalletUrl = "https://localhost:44359/api/WalletApi/add"

  public wallets = toSignal(this.get(), {
    initialValue: []
  });

  get() {
    return this.httpClient.get<WalletModel[]>(this.getWalletsUrl)
      .pipe(catchError(this.handleError));
  }

  add(name: string) {
    return this.httpClient.post(
      this.addWalletUrl,
      JSON.stringify(name),
      {
        headers: {
          "Content-Type": "application/json"
        }
      }
    )
      .pipe(catchError(this.handleError));
  }

  private handleError(errorRes: HttpErrorResponse) {
    return throwError(() => new Error(`${errorRes.error} (status ${errorRes.status})`))
  } 
}
