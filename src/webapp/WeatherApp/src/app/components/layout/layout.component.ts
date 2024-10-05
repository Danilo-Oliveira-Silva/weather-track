import { Component, inject } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Router, RouterLink, RouterOutlet } from '@angular/router';
import { jwtDecode } from 'jwt-decode';

@Component({
  selector: 'app-layout',
  standalone: true,
  imports: [RouterOutlet, RouterLink, FormsModule],
  templateUrl: './layout.component.html',
  styleUrl: './layout.component.css'
})
export class LayoutComponent {
  loggedUserData: any;

  constructor(private router: Router) {}

  tokenObj = JSON.parse(localStorage.getItem('token')!);
  
  token = jwtDecode(this.tokenObj.token) as any;
  
  greeting = "";

  logout() {
     localStorage.removeItem('token');
     this.router.navigateByUrl("login");
  }
}
