import { Component, DestroyRef, signal } from '@angular/core';
import { FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { LoginResponse } from './loginResponse.model';
import { AuthService } from '../auth.service';

@Component({
  imports: [ReactiveFormsModule],
  selector: 'app-login',
  styleUrl: './login.css',
  templateUrl: './login.html',
})
export class Login {
  constructor(
    private authService: AuthService,
    private destroyRef: DestroyRef
  ) {}

  errorMessage = signal('');

  form = new FormGroup({
    email: new FormControl('', {
      validators: [Validators.required, Validators.email]
    }
    ),
    password: new FormControl('', {
      validators: [Validators.required]
    })
  })
  
  onSubmit() {
    const enteredEmail = this.form.value.email ?? '';
    const enteredPassword = this.form.value.password ?? '';

    if(this.form.valid) {
      const subscription = this.authService.login({
        email: enteredEmail, 
        password: enteredPassword
      }).subscribe({
        next: (token: LoginResponse) => {
          localStorage.setItem('jwt', JSON.stringify(token));
          this.errorMessage.set('');
        },
        error: (err: Error) => this.errorMessage.set(err.message)
      });

      this.destroyRef.onDestroy(() => subscription.unsubscribe())
    } else {
      this.errorMessage.set("Enter correct E-mail and Password");
    }
  }
}
