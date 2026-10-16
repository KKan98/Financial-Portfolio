import { Component, inject, signal } from '@angular/core';
import { DatePipe, DecimalPipe } from '@angular/common';
import { AssetService } from './asset.service';
import { ActivatedRoute } from '@angular/router';
import { toSignal } from '@angular/core/rxjs-interop';
import { map, switchMap, tap } from 'rxjs';

@Component({
  imports: [DatePipe, DecimalPipe],
  selector: 'app-wallet-overview',
  styleUrl: './wallet-overview.css',
  templateUrl: './wallet-overview.html',
})
export class WalletOverview {
  private readonly assetService = inject(AssetService);
  private readonly activatedRoute = inject(ActivatedRoute);
  readonly walletName = signal('');

  public readonly assets = toSignal(
    this.activatedRoute.paramMap.pipe(
      map((params) => {
        const walletId = Number(params.get('id'));
        this.walletName.set(params.get('name')!);

        if (!Number.isInteger(walletId) || walletId <= 0) {
          throw new Error('Invalid wallet ID');
        }

        return walletId;
    }),
    switchMap((walletId) => this.assetService.get(walletId)),
    ).pipe(tap((data) => console.log(data)
    )),
    { initialValue: [] },
  );
}
