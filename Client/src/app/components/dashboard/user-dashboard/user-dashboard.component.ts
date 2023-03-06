import { Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Reimburse } from 'src/app/models/reimburse.model';
import { User } from 'src/app/models/User/user.model';
import { ReimbursementService } from 'src/app/services/reimbursement.service';

@Component({
  selector: 'app-user-dashboard',
  templateUrl: './user-dashboard.component.html',
  styleUrls: ['./user-dashboard.component.scss']
})
export class UserDashboardComponent implements OnInit {
  reimbursements?: Reimburse[];
  loading: Boolean;
  user: any;
  length: Boolean;
  reimburse: Reimburse = {
    date: '',
    reimbursementType: '',
    requestedValue: 0,
    currency: '',
    image: ''
  }

  @Input() currentReimburse: Reimburse = {
    date: '',
    reimbursementType: '',
    requestedValue: 0,
    currency: '',
    image: ''
  }

  message = '';

  constructor(
    private router: Router,
    private reimbursementService: ReimbursementService
  ) { this.loading = true, this.user = this.reimbursementService.user_get(), this.length = false }

  ngOnInit(): void {
    this.getMyReimbursements();
  }

  getAllReimbursements(): void {
    this.reimbursementService.reimburse_get_all()
      .subscribe({
        next: (res) => {
          this.reimbursements = res;
          this.loading = false;
        },
        error: (e) => console.log(e)
      })
  }

  getMyReimbursements(): void {
    this.reimbursementService.reimburse_get_my(this.user.email)
      .subscribe({
        next: (res) => {
          console.log(res);
          if (res.length == 0)
            this.length = true;
          this.reimbursements = res;
          console.log(this.reimbursements.forEach((reimburse) => reimburse.date = reimburse.date?.split('T')[0]))
          this.loading = false;
        },
        error: (e) => console.log(e)
      })
  }

  deleteReimbursement(id: any): void {
    this.reimbursementService.reimburse_delete(id)
      .subscribe({
        next: (res) => {
          console.log(res);
          this.router.navigate(['/userdashboard'])
            .then(() => {
              window.location.reload();
            });
        },
        error: (e) => console.error(e)
      });
  }

  addReimbursement(): void {
    const data = {
      date: this.reimburse.date,
      reimbursementType: this.reimburse.reimbursementType,
      requestedValue: this.reimburse.requestedValue,
      currency: this.reimburse.currency,
      image: this.reimburse.image,
      userID: this.user.email,
    }

    this.reimbursementService.reimburse_add(data)
      .subscribe({
        next: (res) => {
          console.log(res);
          this.getMyReimbursements();
          this.message = "Result Added Succesfully !";
          this.router.navigate(['/userdashboard'])
            .then(() => {
              window.location.reload();
            });
        },
        error: (e) => console.log(e)
      });
  }

  getReimbursement(id: any): void {
    this.reimbursementService.reimburse_get(id)
      .subscribe({
        next: (res) => {
          this.currentReimburse = res;
          console.log(res);
        },
        error: e => console.log(e)
      });
  }

  updateReimbursement(): void {
    this.reimbursementService.reimburse_edit(this.currentReimburse.id, this.currentReimburse)
      .subscribe({
        next: (res) => {
          console.log(res);
          this.message = "This Result was updated successfully !";
        },
        error: e => console.log(e)
      })
  }

  convertToINR(): void {
    this.reimbursements?.forEach((reimbursement) => {
      if (reimbursement.currency != 'INR') {
        if (reimbursement.currency == 'USD') {
          reimbursement.requestedValue = Math.round(76.67 * reimbursement.requestedValue!);
          reimbursement.approvedValue = Math.round(76.67 * reimbursement.approvedValue!);
        }
        if (reimbursement.currency == 'EURO') {
          reimbursement.requestedValue = Math.round(80.54 * reimbursement.requestedValue!);
          reimbursement.approvedValue = Math.round(80.54 * reimbursement.approvedValue!);
        }
        reimbursement.currency = 'INR';
      }
    })
  }
  convertToUSD(): void {
    this.reimbursements?.forEach((reimbursement) => {
      if (reimbursement.currency != 'USD') {
        if (reimbursement.currency == 'INR') {
          reimbursement.requestedValue = Math.round(0.013*reimbursement.requestedValue!);
          reimbursement.approvedValue = Math.round(0.013*reimbursement.approvedValue!);
        }
        if (reimbursement.currency == 'EURO') {
          reimbursement.requestedValue = Math.round(1.05 * reimbursement.requestedValue!);
          reimbursement.approvedValue = Math.round(1.05 * reimbursement.approvedValue!);
        }
        reimbursement.currency = 'USD';
      }
    })
  }
  convertToEURO(): void {
    this.reimbursements?.forEach((reimbursement) => {
      if (reimbursement.currency != 'EURO') {
        if (reimbursement.currency == 'USD') {
          reimbursement.requestedValue = Math.round(0.95 * reimbursement.requestedValue!);
          reimbursement.approvedValue = Math.round(0.95 * reimbursement.approvedValue!);
        }
        if (reimbursement.currency == 'INR') {
          reimbursement.requestedValue = Math.round(0.012 * reimbursement.requestedValue!);
          reimbursement.approvedValue = Math.round(0.012 * reimbursement.approvedValue!);
        }
        reimbursement.currency = 'EURO';
      }
    })
  }

  ResetCurrency():void{
    this.getMyReimbursements()
  }

}
