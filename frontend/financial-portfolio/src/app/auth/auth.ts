import { Component, DestroyRef } from '@angular/core';
import { FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { AuthService } from './auth.service';
import { LoginResponse } from './loginResponse.model';
import { required } from '@angular/forms/signals';

@Component({
  imports: [ReactiveFormsModule],
  selector: 'app-auth',
  styleUrl: './auth.css',
  templateUrl: './auth.html',
})
export class Auth {
  constructor(
    private authService: AuthService,
    private destroyRef: DestroyRef
  ) {}

  form = new FormGroup({
    email: new FormControl('', {
      validators: [Validators.required, Validators.email]
    }
    ),
    password: new FormControl('', {
      validators: [Validators.required]
    })
  })

  get emailIsInvalid() {
    return (
      this.form.controls.email.invalid &&
      this.form.controls.email.touched &&
      this.form.controls.email.dirty
    )
  }

  get passwordIsInvalid() {
    return (
      this.form.controls.password.invalid &&
      this.form.controls.password.touched &&
      this.form.controls.password.dirty
    )
  }
  
  onSubmit() {
    const enteredEmail = this.form.value.email;
    const enteredPassword = this.form.value.password;

    if(typeof enteredEmail === 'string' && typeof enteredPassword === 'string') {
      const subscription = this.authService.login({email: enteredEmail, password: enteredPassword}).subscribe({
        next: (token: LoginResponse) => {
          console.log(token);
          localStorage.setItem('jwt', JSON.stringify(token));
        }
      });

      this.destroyRef.onDestroy(() => subscription.unsubscribe())
    } else {
      console.log("Enter E-mail and Password");
    }
  }
}
