import { Component, OnInit } from '@angular/core';
import { Reimburse } from 'src/app/models/reimburse.model';
import { ReimbursementService } from 'src/app/services/reimbursement.service';

@Component({
  selector: 'app-month-wise-charts',
  templateUrl: './month-wise-charts.component.html',
  styleUrls: ['./month-wise-charts.component.scss']
})
export class MonthWiseChartsComponent implements OnInit {

  reimbursements?: Reimburse[];
  Months = {
    January: 0,
    Febrary: 0,
    March: 0,
    April: 0,
    May: 0,
    June: 0,
    July: 0,
    August: 0,
    September: 0,
    October: 0,
    Novemeber: 0,
    December: 0
  }
  constructor(private reimbursementService: ReimbursementService) { }
  ngOnInit(): void {
    this.getAllReimbursements();
  }
  chartData = [
    {
      data: [
        this.Months.January,
        this.Months.Febrary,
        this.Months.March,
        this.Months.April,
        this.Months.May,
        this.Months.June,
        this.Months.July,
        this.Months.August,
        this.Months.September,
        this.Months.October,
        this.Months.Novemeber,
        this.Months.December
      ],
      backgroundColor: ['rgba(255, 99, 132, 0.2)',
        'rgba(255, 159, 64, 0.2)',
        'rgba(255, 205, 86, 0.2)',
        'rgba(75, 192, 192, 0.2)',
        'rgba(54, 162, 235, 0.2)',
        'rgba(153, 102, 255, 0.2)',
        'rgba(201, 203, 207, 0.2)',
        'rgba(255, 159, 64, 0.2)',
        'rgba(255, 205, 86, 0.2)',
        'rgba(75, 192, 192, 0.2)',
        'rgba(54, 162, 235, 0.2)',
        'rgba(153, 102, 255, 0.2)',
        'rgba(201, 203, 207, 0.2)'],
      hoverBackgroundColor: [],
      borderColor: [
        'rgb(255, 99, 132)',
        'rgb(255, 159, 64)',
        'rgb(255, 205, 86)',
        'rgb(75, 192, 192)',
        'rgb(54, 162, 235)',
        'rgb(153, 102, 255)',
        'rgb(201, 203, 207)',
        'rgb(255, 159, 64)',
        'rgb(255, 205, 86)',
        'rgb(75, 192, 192)',
        'rgb(54, 162, 235)',
        'rgb(153, 102, 255)',
        'rgb(201, 203, 207)'
      ],
      hoverBorderColor:[],
      borderWidth: 1
    }
  ];


  chartLabels = [
    'Jaunary',
    'Febrary',
    'March',
    'April',
    'May',
    'June',
    'July',
    'August',
    'September',
    'October',
    'November',
    'December'
  ];

  chartOptions = {
    responsive: true,
    scales: {
      yAxes: [{
        ticks: {
          steps: 10,
          stepValue: 10,
          max: 10,
          min: 0
        }
      }]
    },
  };
  getAllReimbursements(): void {
    this.reimbursementService.reimburse_get_all()
      .subscribe({
        next: (res) => {
          this.reimbursements = res;
          this.Months.January = this.reimbursements.filter((reimbursement) => reimbursement.date?.split('-')[1] === '01').length;
          this.Months.Febrary = this.reimbursements.filter((reimbursement) => reimbursement.date?.split('-')[1] === '02').length;
          this.Months.March = this.reimbursements.filter((reimbursement) => reimbursement.date?.split('-')[1] === '03').length;
          this.Months.April = this.reimbursements.filter((reimbursement) => reimbursement.date?.split('-')[1] === '04').length;
          this.Months.May = this.reimbursements.filter((reimbursement) => reimbursement.date?.split('-')[1] === '05').length;
          this.Months.June = this.reimbursements.filter((reimbursement) => reimbursement.date?.split('-')[1] === '06').length;
          this.Months.July = this.reimbursements.filter((reimbursement) => reimbursement.date?.split('-')[1] === '07').length;
          this.Months.August = this.reimbursements.filter((reimbursement) => reimbursement.date?.split('-')[1] === '08').length;
          this.Months.September = this.reimbursements.filter((reimbursement) => reimbursement.date?.split('-')[1] === '09').length;
          this.Months.October = this.reimbursements.filter((reimbursement) => reimbursement.date?.split('-')[1] === '10').length;
          this.Months.Novemeber = this.reimbursements.filter((reimbursement) => reimbursement.date?.split('-')[1] === '11').length;
          this.Months.December = this.reimbursements.filter((reimbursement) => reimbursement.date?.split('-')[1] === '12').length;
          console.log(this.Months);
          this.chartData = [
            {
              data: [
                this.Months.January,
                this.Months.Febrary,
                this.Months.March,
                this.Months.April,
                this.Months.May,
                this.Months.June,
                this.Months.July,
                this.Months.August,
                this.Months.September,
                this.Months.October,
                this.Months.Novemeber,
                this.Months.December
              ], backgroundColor: ['rgba(255, 99, 132, 0.2)',
                'rgba(255, 159, 64, 0.2)',
                'rgba(255, 205, 86, 0.2)',
                'rgba(75, 192, 192, 0.2)',
                'rgba(54, 162, 235, 0.2)',
                'rgba(153, 102, 255, 0.2)',
                'rgba(201, 203, 207, 0.2)',
                'rgba(255, 159, 64, 0.2)',
                'rgba(255, 205, 86, 0.2)',
                'rgba(75, 192, 192, 0.2)',
                'rgba(54, 162, 235, 0.2)',
                'rgba(153, 102, 255, 0.2)',
                'rgba(201, 203, 207, 0.2)'],
              hoverBackgroundColor: [],
              borderColor: [
                'rgb(255, 99, 132)',
                'rgb(255, 159, 64)',
                'rgb(255, 205, 86)',
                'rgb(75, 192, 192)',
                'rgb(54, 162, 235)',
                'rgb(153, 102, 255)',
                'rgb(201, 203, 207)',
                'rgb(255, 159, 64)',
                'rgb(255, 205, 86)',
                'rgb(75, 192, 192)',
                'rgb(54, 162, 235)',
                'rgb(153, 102, 255)',
                'rgb(201, 203, 207)'
              ],
              hoverBorderColor:[],
              borderWidth: 1
            }
          ];
        },
        error: (e) => console.log(e)
      })
  }


}
