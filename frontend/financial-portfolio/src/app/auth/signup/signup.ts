import { Component, DestroyRef, inject, signal } from '@angular/core';
import { FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { AuthService } from '../auth.service';
import { Router } from '@angular/router';

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
    password: new FormControl('', {
      validators: [Validators.required]
    }),
    role: new FormControl<'Basic' | 'Pro' | 'Administrator'>('Basic', {
      validators: [Validators.required]
    }),
  })

  onSubmit() {
    const enteredEmail = this.form.value.email ?? '';
    const enteredPassword = this.form.value.password ?? '';
    const enteredRole = this.form.value.role ?? 'None';
    if(this.form.valid) {
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
