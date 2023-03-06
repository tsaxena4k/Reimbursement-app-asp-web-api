import { Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ReimbursementService } from 'src/app/services/reimbursement.service';

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.scss']
})
export class SignupComponent implements OnInit {
  @Input() Email: any;
  @Input() FullName: any;
  @Input() Password: any;
  @Input() ConfirmPassword: any;
  @Input() PANNumber: any;
  @Input() Bank: any;
  @Input() BankAccNumber: any;

  message = '';

  constructor(
    private reimbursementService: ReimbursementService,
    private router: Router
  ) { }

  ngOnInit(): void {
    if (localStorage.getItem('token') != null)
      this.router.navigateByUrl('/userdashboard')
  }

  Signup(): void {
    if (this.Password != this.ConfirmPassword) {
      this.message = "Password doesn't match";
    } else {
      const data = {
        Email: this.Email,
        FullName: this.FullName,
        Password: this.Password,
        PANNumber: this.PANNumber,
        Bank: this.Bank,
        BankAccNumber: this.BankAccNumber
      }
      console.log(data);
      this.reimbursementService.user_signup_post(data)
        .subscribe({
          next: (res) => {
            console.log(res)
            this.message = "Signup Sucess Please login";
          },
          error: (e) => console.log(e)
        })
    }
  }

}
