import { Component, DestroyRef } from '@angular/core';
import { FormControl, FormGroup, ReactiveFormsModule } from '@angular/forms';
import { AuthService } from './auth.service';
import { LoginResponse } from './loginResponse.model';

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
    email: new FormControl(''),
    password: new FormControl('')
  })

  onSubmit() {
    const enteredEmail = this.form.value.email;
    const enteredPassword = this.form.value.password;

    if(typeof enteredEmail === 'string' && typeof enteredPassword === 'string') {
      const subscription = this.authService.login({email: enteredEmail, password: enteredPassword}).subscribe({
        next: (token: LoginResponse) => console.log(token)
      });

      this.destroyRef.onDestroy(() => subscription.unsubscribe())
    } else {
      console.log("Enter E-mail and Password");
    }
  }
}
