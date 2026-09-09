import { Component, DestroyRef, inject, OnInit, signal } from '@angular/core';
import { AuthService } from '../auth/auth.service';

@Component({
  imports: [],
  selector: 'app-home',
  styleUrl: './home.css',
  templateUrl: './home.html',
})
export class Home implements OnInit{
  private authService = inject(AuthService);
  private destroyRef = inject(DestroyRef);
  
  users = signal<UsersModel[] | null>(null);
  errorMessage = signal<string>('');
  
  ngOnInit(): void {
    const subscription = this.authService.getAllUsers().subscribe({
      next: (data) => { 
        console.log(data);
        return this.users.set(data) 
      },
      error: (err) => this.errorMessage.set(err)
      })

    this.destroyRef.onDestroy(() => subscription.unsubscribe());
  }
}

export type UsersModel = {
  id: number,
  email: string,
  password: string,
  role: 'None' | 'Basic' | 'Pro' | 'Administratorr'
}
