import { Component } from '@angular/core';
import { Wallet } from '../wallet/wallet';

@Component({
  imports: [Wallet],
  selector: 'app-dashboard',
  styleUrl: './dashboard.css',
  templateUrl: './dashboard.html'
})
export class Dashboard {
}
