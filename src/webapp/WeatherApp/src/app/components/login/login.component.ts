import { CommonModule } from '@angular/common';
import { Component, inject, Inject, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Router, RouterEvent } from '@angular/router';
import { ApiService } from '../../services/api.service';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [FormsModule, CommonModule],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent implements OnInit {
  ngOnInit(): void {
    //throw new Error('Method not implemented.');
    
  }
  
  userLogin: any = {
    Email: '',
    Password: ''
  };

  apiService = inject(ApiService);
  
  constructor(private router: Router) {}

  onLogin() {
    
    this.apiService.login(this.userLogin).subscribe((res: any) => {
      localStorage.setItem('token', JSON.stringify(res));
      this.router.navigateByUrl("measures");
    }, error => {
      alert(error.error.message);
    });
    
    
  }
}
