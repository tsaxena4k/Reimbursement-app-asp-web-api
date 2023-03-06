import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Role } from 'src/app/models/Role/role';
import { ReimbursementService } from 'src/app/services/reimbursement.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {
  loginData = {
    email: null,
    password: null
  }

  message = ''

  constructor(
    private reimbursementService: ReimbursementService,
    private router: Router
  ) { }

  ngOnInit(): void {
    if (localStorage.getItem('token') != null)
      this.router.navigateByUrl(localStorage.getItem('role') == Role.Basic ? '/userdashboard' : 'admindashboard')
  }

  login(): void {
    this.reimbursementService.user_login_post(this.loginData)
      .subscribe({
        next: (res) => {
          console.log(res);
          localStorage.setItem('token', res.token);
          localStorage.setItem('user', JSON.stringify(res.user));
          localStorage.setItem('role', res.role);
          this.router.navigateByUrl(res.role == Role.Basic ? '/userdashboard' : 'admindashboard')
            .then(() => {
              window.location.reload();
            });
        },
        error: (e) => {
          if (e.status = "401")
            this.message = "Email or Password Invalid"
        }
      })
  }

  getRole(): void {
    this.reimbursementService.user_role()
      .subscribe({
        next: (res) => {
          localStorage.setItem('userRole', res);
          console.log(res);
        },
        error: (e) => console.log(e)
      })
  }
}
