import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable, retry } from 'rxjs';
import { Reimburse } from '../models/reimburse.model';
import { User } from '../models/User/user.model';
const baseUrl = 'http://www.tsreimbursementapp.somee.com/api/';
const tokenHeader = new HttpHeaders({ 'Authorization': 'Bearer ' + localStorage.getItem('token') });

@Injectable({
  providedIn: 'root'
})
export class ReimbursementService {
  private userSubject: BehaviorSubject<User>;
  public user: Observable<User>;
  public userObject: any = localStorage.getItem('user');

  constructor(private http: HttpClient) {
    this.userSubject = new BehaviorSubject<User>(JSON.parse(this.userObject));
    this.user = this.userSubject.asObservable();
  }

  user_signup_post(data: any): Observable<any> {
    console.log(data);
    return this.http.post(`${baseUrl}/Users/RegisterUser`, data);
  }

  user_login_post(data: any): Observable<any> {
    console.log(data)
    return this.http.post(`${baseUrl}/Users/Login`, data)
  }

  user_logout(userId:any): Observable<any> {
    console.log(userId);
    return this.http.get(`${baseUrl}/Users/Logout?userID=${userId}`)
  }

  user_get(): User {
    return this.userSubject.value;
  }
  
  user_profile(): Observable<User> {
    return this.http.get<User>(`${baseUrl}/UserProfile`, { headers: tokenHeader })
  }

  user_role(): Observable<any> {
    return this.http.get(`${baseUrl}/Users/GetRole`, { headers: tokenHeader, responseType: 'text' })
  }

  //Reimbursement Services

  reimburse_get(id: any): Observable<Reimburse> {
    return this.http.get<Reimburse>(`${baseUrl}/Reimbursement/GetReimbursement/${id}`)
  }

  reimburse_get_all(): Observable<Reimburse[]> {
    return this.http.get<Reimburse[]>(`${baseUrl}/Reimbursement/GetAll`);
  }

  reimburse_get_my(email:any): Observable<Reimburse[]> {
    return this.http.get<Reimburse[]>(`${baseUrl}/Reimbursement/GetReimbursementByEmail?email=${email}`);
  }
  reimburse_delete(id: any): Observable<any> {
    return this.http.delete<any>(`${baseUrl}/Reimbursement/Delete/${id}`);
  }

  reimburse_add(data: any): Observable<Reimburse> {
    console.log(data);
    return this.http.post<Reimburse>(`${baseUrl}/Reimbursement/AddReimbursement`, data, { headers: tokenHeader });
  }

  reimburse_edit(id: any, data: any): Observable<Reimburse> {
    console.log(data);
    return this.http.put<Reimburse>(`${baseUrl}/Reimbursement/Update/${id}`, data);
  }

  reimburse_approve(id: any, data: any): Observable<Reimburse> {
    return this.http.put<Reimburse>(`${baseUrl}/Admin/ApproveReimbursement/${id}`, data);
  }

  reimburse_decline(id: any): Observable<Reimburse> {
    return this.http.put<Reimburse>(`${baseUrl}/Admin/DeclineReimbursement/${id}`, id);
  }
}
