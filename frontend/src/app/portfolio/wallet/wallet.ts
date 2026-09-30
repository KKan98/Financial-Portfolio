import { Component, inject } from '@angular/core';
import { WalletService } from './wallet.service';

@Component({
  imports: [],
  selector: 'app-wallet',
  styleUrl: './wallet.css',
  templateUrl: './wallet.html',
})
export class Wallet {
  private walletService = inject(WalletService);

  public readonly wallets = this.walletService.wallets;
}
