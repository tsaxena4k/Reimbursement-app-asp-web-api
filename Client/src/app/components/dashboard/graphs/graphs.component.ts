import { Component, OnInit } from '@angular/core';
import { Chart } from 'chart.js';
import { Reimburse } from 'src/app/models/reimburse.model';
import { ReimbursementService } from 'src/app/services/reimbursement.service';

@Component({
  selector: 'app-graphs',
  templateUrl: './graphs.component.html',
  styleUrls: ['./graphs.component.scss']
})
export class GraphsComponent implements OnInit {
  reimbursements?:Reimburse[];
  reimbursementType={
    Medical:0,
    Travel:0,
    Food:0,
    Entertainment:0,
    Misc:0
  }
  constructor(private reimbursementService:ReimbursementService) { }
  ngOnInit(): void {
    this.getAllReimbursements();
    
  }
  chartData = [
    {
      data: [this.reimbursementType.Medical,this.reimbursementType.Entertainment,this.reimbursementType.Travel,this.reimbursementType.Food],
      backgroundColor:['rgba(255, 99, 132, 0.2)',
      'rgba(255, 159, 64, 0.2)',
      'rgba(255, 205, 86, 0.2)',
      'rgba(75, 192, 192, 0.2)',
      'rgba(54, 162, 235, 0.2)',],
      hoverBackgroundColor:['rgba(255, 99, 132, 0.2)',
      'rgba(255, 159, 64, 0.2)',
      'rgba(255, 205, 86, 0.2)',
      'rgba(75, 192, 192, 0.2)',
      'rgba(54, 162, 235, 0.2)',],
      borderColor: [
        'rgb(255, 99, 132)',
        'rgb(255, 159, 64)',
        'rgb(255, 205, 86)',
        'rgb(75, 192, 192)',
        'rgb(54, 162, 235)',
      ],
      borderWidth: 1
    }
  ];

  
  chartLabels = [
    'Medical',
    'Travel',
    'Food',
    'Entertainment',
    'Misc'
  ];

  chartOptions = {
    responsive: true,
    scales : {
      yAxes: [{
         ticks: {
            steps : 10,
            stepValue : 10,
            max : 10,
            min: 0
          }
      }]
    },
  };
  getAllReimbursements(): void {
    this.reimbursementService.reimburse_get_all()
      .subscribe({
        next: (res) => {
          console.log(res);
          this.reimbursements = res;
          this.reimbursementType.Medical=this.reimbursements.filter((reimbursement)=>reimbursement.reimbursementType==='Medical').length;
          this.reimbursementType.Food=this.reimbursements.filter((reimbursement)=>reimbursement.reimbursementType==='Food').length;
          this.reimbursementType.Travel=this.reimbursements.filter((reimbursement)=>reimbursement.reimbursementType==='Travel').length;
          this.reimbursementType.Entertainment=this.reimbursements.filter((reimbursement)=>reimbursement.reimbursementType==='Entertainment').length;
          this.reimbursementType.Misc=this.reimbursements.filter((reimbursement)=>reimbursement.reimbursementType==='Misc').length;
          console.log(this.reimbursementType);
          this.chartData = [
            {
              data: [this.reimbursementType.Medical,this.reimbursementType.Entertainment,this.reimbursementType.Travel,this.reimbursementType.Food],
              backgroundColor:['rgba(255, 99, 132, 0.2)',
              'rgba(255, 159, 64, 0.2)',
              'rgba(255, 205, 86, 0.2)',
              'rgba(75, 192, 192, 0.2)',
              'rgba(54, 162, 235, 0.2)',],
              hoverBackgroundColor:['rgba(255, 99, 132, 0.2)',
              'rgba(255, 159, 64, 0.2)',
              'rgba(255, 205, 86, 0.2)',
              'rgba(75, 192, 192, 0.2)',
              'rgba(54, 162, 235, 0.2)',],
              borderColor: [
                'rgb(255, 99, 132)',
                'rgb(255, 159, 64)',
                'rgb(255, 205, 86)',
                'rgb(75, 192, 192)',
                'rgb(54, 162, 235)',
              ],
              borderWidth: 1
            }
          ];
        },
        error: (e) => console.log(e)
      })
  }

  
}
