import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot, UrlTree } from '@angular/router';
import { Observable } from 'rxjs';
import { ReimbursementService } from './services/reimbursement.service';

@Injectable({
    providedIn: 'root'
})
export class AuthGuard implements CanActivate {
    constructor(private router: Router, private remibursementService: ReimbursementService) { }

    canActivate(
        route: ActivatedRouteSnapshot,
        state: RouterStateSnapshot): Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree {
        const user = this.remibursementService.user_get();
        const userRole = localStorage.getItem('role');
        
        if (user) {
            if (route.data['roles'] && route.data['roles'].indexOf(userRole) == -1) {
                // role not authorised so redirect to home page
                this.router.navigate(['/']);
                return false;
            }

            return true;
        }
        // if (localStorage.getItem('token')) {
        //     console.log(userRole)
        //     return true;
        // }
        this.router.navigate(['/'], { queryParams: { returnUrl: state.url } });
        return false;
    }

}
