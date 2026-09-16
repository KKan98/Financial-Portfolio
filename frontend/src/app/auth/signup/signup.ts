import { Component, DestroyRef, inject, signal } from '@angular/core';
import { FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { AuthService } from '../auth.service';
import { Router } from '@angular/router';
import { Role } from '../role.model';

@Component({
  imports: [ReactiveFormsModule],
  selector: 'app-signup',
  styleUrl: './signup.css',
  templateUrl: './signup.html',
})
export class Signup {
  private authService = inject(AuthService);
  private destroyRef = inject(DestroyRef);
  private router = inject(Router);

  errorMessage = signal('');

  form = new FormGroup({
    email: new FormControl('', {
      validators: [Validators.required, Validators.email]
    }
    ),
    passwords: new FormGroup({
      password: new FormControl('', {
        validators: [Validators.required]
      }),
      confirmPassword: new FormControl('', {
        validators: [Validators.required]
      })
    }),
    role: new FormControl<Role>(Role.Basic, {
      validators: [Validators.required]
    }),
  });

  onSubmit() {
    const enteredEmail = this.form.value.email ?? '';
    const enteredPassword = this.form.value.passwords?.password ?? '';
    const enteredConfirmPassword = this.form.value.passwords?.confirmPassword ?? '';
    const enteredRole = this.form.value.role ?? Role.None;
    if(this.form.valid &&
       enteredPassword === enteredConfirmPassword &&
       enteredConfirmPassword !== '' &&
       enteredPassword !== ''
      ) {
      const subscription = this.authService.signup({
        email: enteredEmail,
        password: enteredPassword,
        role: enteredRole
      }).subscribe({
        next: () => this.router.navigate(['login']),
        error: (err) => this.errorMessage.set(err.message)
      });

      this.destroyRef.onDestroy(() => subscription.unsubscribe());
    }
  }
}
