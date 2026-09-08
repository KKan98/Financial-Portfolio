import { Component, DestroyRef } from '@angular/core';
import { FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { LoginService } from './login.service';
import { LoginResponse } from './loginResponse.model';

@Component({
  imports: [ReactiveFormsModule],
  selector: 'app-login',
  styleUrl: './login.css',
  templateUrl: './login.html',
})
export class Login {
  constructor(
    private loginService: LoginService,
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
      const subscription = this.loginService.login({email: enteredEmail, password: enteredPassword}).subscribe({
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
