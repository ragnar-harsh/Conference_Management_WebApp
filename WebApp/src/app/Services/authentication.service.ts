import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { JwtHelperService } from '@auth0/angular-jwt';

const httpOptions = {
  headers: new HttpHeaders({'Content-Type':'application/x-www-form-urlencoded'})
}

@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {

  apiUrl = "http://localhost:5274/api/Authentication";
  payload : any;

  constructor(private http: HttpClient, private router : Router) { 
    this.payload = this.decodeToken();
  }

  registerUser(firstname:any, lastname:any, password:any, confirmPassword:any, email:any, role:any){
    console.log(firstname+ " " + password);
    var url = `${this.apiUrl}/signup`;
    let urlBody = new URLSearchParams();
    urlBody.append('firstname', firstname);
    urlBody.append('lastname', lastname);
    urlBody.append('email', email);
    urlBody.append('password', password);
    urlBody.append('confirmPassword', confirmPassword);
    urlBody.append('role', role);
    return this.http.post<any>(url, urlBody, httpOptions);
  }


  login(password:any, email:any){
    console.log(password);
    var url = `${this.apiUrl}/login`;
    let urlBody = new URLSearchParams();
    urlBody.append('email', email);
    urlBody.append('password', password);
    return this.http.post<any>(url, urlBody, httpOptions);
  }

  storeToken(token : string){
    localStorage.setItem('MeetingRoom', token);
  }

  getToken(){
    return localStorage.getItem('MeetingRoom');
  }

  isLoggedIn(): boolean{
    return !!this.getToken();
  }

  logout(){
    localStorage.removeItem('MeetingRoom');
    this.router.navigate(['/login']);
  }


  decodeToken(){
    const token = this.getToken();
    const jwtHelper = new JwtHelperService();
    return jwtHelper.decodeToken(token);
  }

  getFirstNameFromToken(){
    if(this.payload){
      return this.payload.unique_name;
    }
  }

  getRoleFromToken(){
    if(this.payload){
      console.log(this.payload.role);
      return this.payload.role;
    }
  }
}
