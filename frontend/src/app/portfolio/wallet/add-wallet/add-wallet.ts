import { Component, inject, signal } from '@angular/core';
import { ɵInternalFormsSharedModule, ReactiveFormsModule, FormGroup, FormControl, Validators } from '@angular/forms';
import { MatDialogRef } from '@angular/material/dialog';
import { WalletService } from '../wallet.service';

@Component({
  imports: [ɵInternalFormsSharedModule, ReactiveFormsModule],
  selector: 'app-add-wallet',
  styleUrl: './add-wallet.css',
  templateUrl: './add-wallet.html',
})
export class AddWallet {
  private dialogRef = inject(MatDialogRef<AddWallet>);
  private walletService = inject(WalletService);

  public errorMessage = signal('');

  form = new FormGroup({
    name: new FormControl('', {
      nonNullable: true,
      validators: [Validators.required] //DoesNotExist validator
    })
  })

  onSubmit() {
    if (this.form.invalid) {
      this.form.markAllAsTouched();
      this.errorMessage.set('Wallet name cannot be empty!');
      return;
    }

    const nameEntered = this.form.controls.name.value.trim();

    if (nameEntered.length <= 0) {
      this.errorMessage.set('Wallet name cannot be empty!')
    } else {
      this.walletService.add(nameEntered).subscribe({
        next: () => this.closeDialog(),
        error: (err: Error) => this.errorMessage.set(err.message)
      })
    }
  }

  closeDialog() {
    this.dialogRef.close();
  }
}
