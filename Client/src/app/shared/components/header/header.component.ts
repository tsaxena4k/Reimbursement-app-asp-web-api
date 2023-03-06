import { Component, OnInit } from '@angular/core';
import { Router, NavigationEnd, ActivatedRoute, Event } from '@angular/router';
import { ReimbursementService } from 'src/app/services/reimbursement.service';
import { filter } from 'rxjs/operators';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent implements OnInit {
  user: any;
  currentRoute: string='';

  constructor(private router: Router, private activatedRoute: ActivatedRoute, private reimbursementService: ReimbursementService) {
    this.user = localStorage.getItem('user');
    this.user = JSON.parse(this.user);
  }

  ngOnInit(): void {
    this.getCurrentRoute();
  }

  logout(): void {
    this.reimbursementService.user_logout(this.user.id)
      .subscribe({
        next: (res) => {
          localStorage.clear();
          this.router.navigate(['/'])
            .then(() => {
              window.location.reload();
            });
        },
        error: (e) => console.log(e)
      })
  }

  getCurrentRoute(): void {
    this.router.events.subscribe((event: Event) => {
      if (event instanceof NavigationEnd) {
        this.currentRoute=event.url;
        console.log(this.currentRoute);
      }
    });

  }

}
