import { Component, inject, signal } from '@angular/core';
import { AssetService } from './asset.service';
import { ActivatedRoute } from '@angular/router';
import { Asset } from './asset.model';
import { toSignal } from '@angular/core/rxjs-interop';
import { map, switchMap } from 'rxjs';

@Component({
  imports: [],
  selector: 'app-wallet-overview',
  styleUrl: './wallet-overview.css',
  templateUrl: './wallet-overview.html',
})
export class WalletOverview {
  private readonly assetService = inject(AssetService);
  private readonly activatedRoute = inject(ActivatedRoute);

  public readonly assets = toSignal(
    this.activatedRoute.paramMap.pipe(
      map((params) => {
        const walletId = Number(params.get('id'));

        if (!Number.isInteger(walletId) || walletId <= 0) {
          throw new Error('Invalid wallet ID');
        }

        return walletId;
    }),
    switchMap((walletId) => this.assetService.get(walletId)),
    ),
    { initialValue: [] },
  );
}
