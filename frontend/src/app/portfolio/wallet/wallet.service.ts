import { HttpClient, HttpErrorResponse } from "@angular/common/http";
import { inject, Service } from "@angular/core";
import { catchError, of, Subject, switchMap, throwError, merge, tap } from "rxjs";
import { WalletModel } from "./wallet.model";
import { toObservable, toSignal } from "@angular/core/rxjs-interop";
import { AuthService } from "../../auth/auth.service";

@Service()
export class WalletService {
  private httpClient = inject(HttpClient);
  private authService = inject(AuthService);
  private readonly refresh$ = new Subject<void>();

  private readonly getWalletsUrl = "https://localhost:44359/api/WalletApi"
  private readonly addWalletUrl = "https://localhost:44359/api/WalletApi/add"

  public readonly wallets = toSignal(
    toObservable(this.authService.user).pipe(
      switchMap(user => {
        if (!user?.token) {
          return of<WalletModel[]>([]);
        }

        return merge(
          of(null),
          this.refresh$).pipe(
          switchMap(() => this.get().pipe(
            catchError(() => of<WalletModel[]>([]))
          ))
        )
      })
        
    ),
    { initialValue: [] }
  )

  get() {
    return this.httpClient.get<WalletModel[]>(this.getWalletsUrl);
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
      .pipe(
        catchError(this.handleError),
        tap(() => this.refresh$.next())
      );
  }

  private handleError(errorRes: HttpErrorResponse) {
    return throwError(() => new Error(errorRes.error.detail))
  } 
}
