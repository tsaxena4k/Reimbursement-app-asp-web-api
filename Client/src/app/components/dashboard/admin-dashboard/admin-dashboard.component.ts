import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Reimburse } from 'src/app/models/reimburse.model';
import { ReimbursementService } from 'src/app/services/reimbursement.service';

@Component({
  selector: 'app-admin-dashboard',
  templateUrl: './admin-dashboard.component.html',
  styleUrls: ['./admin-dashboard.component.scss']
})
export class AdminDashboardComponent implements OnInit {
  reimbursements?: Reimburse[];
  pendingReimbursements?: Reimburse[];
  approvedReimbursements?: Reimburse[];
  declinedReimbursements?: Reimburse[];
  loading: Boolean;
  selected: string;
  searchByEmail:string;

  currentReimburse: Reimburse = {
    approvedBy: '',
    approvedValue: 0,
    internalNotes: ''
  }

  reimburse: Reimburse = {
    date: '',
    reimbursementType: '',
    requestedValue: 0,
    currency: '',
    image: ''
  }
  message = '';

  constructor(private reimbursementService: ReimbursementService, private router: Router) {
    this.loading = true;
    this.selected = "All"
    this.searchByEmail='';
  }

  ngOnInit(): void {
    this.getAllReimbursements();
  }

  onChange(e: any): void {
    var optn = e.target.value;
    console.log(optn)
    if (optn !== "All") {
      this.pendingReimbursements = this.reimbursements?.filter((reimburse) => reimburse.approvalStatus === null).filter((reimburse) => reimburse.reimbursementType == optn);
      this.declinedReimbursements = this.reimbursements?.filter((reimburse) => reimburse.approvalStatus === "Declined").filter((reimburse) => reimburse.reimbursementType == optn);
      this.approvedReimbursements = this.reimbursements?.filter((reimburse) => reimburse.approvalStatus === "Approved").filter((reimburse) => reimburse.reimbursementType == optn);
    } else {
      this.getPendingReimbursements();
      this.getApprovedReimbursements();
      this.getDeclinedReimbursements();
    }
  }


  onChangeEmail(e: any): void {
    var optn = e.target.value;
    console.log(optn)
    if (optn !== "" && this.selected != "All") {
      this.pendingReimbursements = this.reimbursements?.filter((reimburse) => reimburse.approvalStatus === null).filter((reimburse) => { reimburse.userId == optn && reimburse.reimbursementType == this.selected });
      this.declinedReimbursements = this.reimbursements?.filter((reimburse) => reimburse.approvalStatus === "Declined").filter((reimburse) => reimburse.userId == optn && reimburse.reimbursementType == this.selected);
      this.approvedReimbursements = this.reimbursements?.filter((reimburse) => reimburse.approvalStatus === "Approved").filter((reimburse) => reimburse.userId == optn && reimburse.reimbursementType == this.selected);
    } else if (optn != "") {
      this.pendingReimbursements = this.reimbursements?.filter((reimburse) => reimburse.approvalStatus === null).filter((reimburse) => reimburse.userId == optn);
      this.declinedReimbursements = this.reimbursements?.filter((reimburse) => reimburse.approvalStatus === "Declined").filter((reimburse) => reimburse.userId == optn);
      this.approvedReimbursements = this.reimbursements?.filter((reimburse) => reimburse.approvalStatus === "Approved").filter((reimburse) => reimburse.userId == optn);
    } else {
      this.getPendingReimbursements();
      this.getApprovedReimbursements();
      this.getDeclinedReimbursements();
    }
  }

  getAllReimbursements(): void {
    this.reimbursementService.reimburse_get_all()
      .subscribe({
        next: (res) => {
          console.log(res);
          this.reimbursements = res;
          this.getPendingReimbursements();
          this.getApprovedReimbursements();
          this.getDeclinedReimbursements();
          this.loading = false;
        },
        error: (e) => console.log(e)
      })
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

  approveReimbursement(): void {
    this.reimbursementService.reimburse_approve(this.currentReimburse.id, this.currentReimburse)
      .subscribe({
        next: (res) => {
          console.log(res);
          this.router.navigate(['/admindashboard'])
            .then(() => {
              window.location.reload();
            });
        },
        error: e => console.log(e)
      })
  }

  declineReimbursement(id: any): void {
    this.reimbursementService.reimburse_decline(id)
      .subscribe({
        next: (res) => {
          console.log(res);
          this.router.navigate(['/admindashboard'])
            .then(() => {
              window.location.reload();
            });
        },
        error: e => console.log(e)
      })
  }


  getPendingReimbursements() {
    this.pendingReimbursements = this.reimbursements?.filter((reimburse) => reimburse.approvalStatus === null)
  }

  getDeclinedReimbursements() {
    this.declinedReimbursements = this.reimbursements?.filter((reimburse) => reimburse.approvalStatus === "Declined")
  }

  getApprovedReimbursements() {
    this.approvedReimbursements = this.reimbursements?.filter((reimburse) => reimburse.approvalStatus === "Approved")
  }

  Reset():void{
    this.getAllReimbursements();
    this.selected="All"
    this.searchByEmail='';
  }

}
