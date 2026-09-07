import { Component, signal } from '@angular/core';
import { Auth } from "./auth/auth";

@Component({
  selector: 'app-root',
  imports: [Auth],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {
  protected readonly title = signal('financial-portfolio');
}
