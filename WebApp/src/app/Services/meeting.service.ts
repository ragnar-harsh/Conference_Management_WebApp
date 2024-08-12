import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';

const httpOptions = {
  headers: new HttpHeaders({'Content-Type':'application/x-www-form-urlencoded'})
}

@Injectable({
  providedIn: 'root'
})
export class MeetingService {

  apiUrl = "http://localhost:5274/api/Meeting";

  constructor(private http: HttpClient) { }

  GetAllMeeting(){
    var url = `${this.apiUrl}`;
    return this.http.get<any>(url);
  }

  AddNewMeeting(title:string, desc:string, date:any, time:any, loc:string){
    var url = `${this.apiUrl}/AddMeeting`;
    let urlBody = new URLSearchParams();
    urlBody.append('Title', title);
    urlBody.append('Description', desc);
    urlBody.append('Date', date);
    urlBody.append('Time', time);
    urlBody.append('Location', loc);
    return this.http.post<any>(url, urlBody, httpOptions);
  }

  EditMeeting(id: string, title:string, desc:string, date:any, time:any, loc:string){
    var url = `${this.apiUrl}/EditMeeting`;
    let urlBody = new URLSearchParams();
    urlBody.append('Title', title);
    urlBody.append('Description', desc);
    urlBody.append('Date', date);
    urlBody.append('Time', time);
    urlBody.append('Location', loc);
    urlBody.append('Id', id);
    return this.http.post<any>(url, urlBody, httpOptions);
  }

  RemoveMeeting(Id:number){
    var url = `${this.apiUrl}/removeMeeting/`+ Id;
    return this.http.delete<any>(url);
  }
}
