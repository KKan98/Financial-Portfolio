import { Component, inject, signal } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { AddWallet } from '../wallet/add-wallet/add-wallet';
import { Wallet } from '../wallet/wallet';

@Component({
  imports: [Wallet],
  selector: 'app-dashboard',
  styleUrl: './dashboard.css',
  templateUrl: './dashboard.html'
})
export class Dashboard { //opening dashboard does not fetch, when on new user I still see old wallets.
  private dialog = inject(MatDialog)
  name = signal('');

  openDialog(): void {
    const dialogRef = this.dialog.open(AddWallet, {
      width: '250px',
      data: { name: this.name}
    })

    dialogRef.afterClosed().subscribe();
  }
}
