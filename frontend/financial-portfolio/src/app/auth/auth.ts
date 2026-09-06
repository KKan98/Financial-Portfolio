import { Component } from '@angular/core';
import { FormControl, FormGroup, ReactiveFormsModule } from '@angular/forms';
import { AuthService } from './auth.service';

@Component({
  imports: [ReactiveFormsModule],
  selector: 'app-auth',
  styleUrl: './auth.css',
  templateUrl: './auth.html',
})
export class Auth {
  constructor(private authService: AuthService) {}

  form = new FormGroup({
    email: new FormControl(''),
    password: new FormControl('')
  })

  onSubmit() {
    const enteredEmail = this.form.value.email;
    const enteredPassword = this.form.value.password;

    if(typeof enteredEmail === 'string' && typeof enteredPassword === 'string') {
      this.authService.login(enteredEmail, enteredPassword);
    } else {
      console.log("Enter E-mail and Password");
    }
  }
}
