import { Component, signal } from '@angular/core';
import { Auth } from "./auth/auth";
import { RouterOutlet } from '@angular/router';
import { Header } from "./header/header";

@Component({
  selector: 'app-root',
  imports: [Auth, RouterOutlet, Header],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {
  protected readonly title = signal('financial-portfolio');
}
