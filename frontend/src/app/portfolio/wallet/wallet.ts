import { Component, inject, signal } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { AddWallet } from './add-wallet/add-wallet';
import { WalletService } from './wallet.service';
import { Router } from '@angular/router';

@Component({
  imports: [],
  selector: 'app-wallet',
  styleUrl: './wallet.css',
  templateUrl: './wallet.html',
})
export class Wallet {
  private dialog = inject(MatDialog);
  private walletService = inject(WalletService);
  private router = inject(Router);

  private readonly name = signal('');

  public readonly wallets = this.walletService.wallets;

  openDialog(): void {
    const dialogRef = this.dialog.open(AddWallet, {
      width: '250px',
      data: { name: this.name }
    });

    dialogRef.afterClosed().subscribe();
  }

  onClick(id: string, name: string) {
    this.router.navigate(['wallet', id, name])
  }
}
