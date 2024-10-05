import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { inject } from '@angular/core/testing';
import { FormsModule } from '@angular/forms';
import { ApiService } from '../../services/api.service';
import { RoleResponse } from '../../models/interfaces/role';
import { Router } from '@angular/router';


@Component({
  selector: 'app-signup',
  standalone: true,
  imports: [FormsModule, CommonModule],
  templateUrl: './signup.component.html',
  styleUrl: './signup.component.css'
})
export class SignupComponent implements OnInit{


  userSignup: any = {
    Name: '',
    Email: '',
    Password: '',
    Roles: []
  };

  roles: RoleResponse[] = [];


  constructor(private apiService: ApiService, private router: Router) {
    
  }

  ngOnInit(): void {
    this.getRoles();
  }

  getRoles(): void {
    this.apiService.getRoles().subscribe((res: any) => {
      this.roles = res;
    }, error => {
      alert("Error on get roles: " + error.error.message);
    });
  }

  onCheckRoles(event: any): void {
    
    const id = parseInt(event.target.id);
    const status = event.target.checked;

    if (status) {
      if (this.userSignup.Roles.indexOf(id) == -1) this.userSignup.Roles.push(id);
    } else {
      this.userSignup.Roles.pop(id);
    }
  }


  onSignup() {
    this.apiService.signup(this.userSignup).subscribe((res: any) => {
      this.router.navigateByUrl("login");
    }, error => {
      alert('Error on signup: '+ error.error.message);
    });
    
  }
}
