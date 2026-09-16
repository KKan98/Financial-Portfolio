import { Component, computed, inject } from '@angular/core';
import { RouterLink } from "@angular/router";
import { AuthService } from '../auth/auth.service';

@Component({
  imports: [RouterLink],
  selector: 'app-header',
  styleUrl: './header.css',
  templateUrl: './header.html',
})
export class Header {
  private authService = inject(AuthService);

  public isAuthenticated = computed(() => this.authService.user());

  onLogout() {
    this.authService.logout();
  }
}
