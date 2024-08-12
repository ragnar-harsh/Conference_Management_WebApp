import { Component, OnInit } from '@angular/core';
import { MeetingService } from '../Services/meeting.service';
import { AuthenticationService } from '../Services/authentication.service';
import { UserStoreService } from '../Services/user-store.service';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit {

  AddMode = false;
  AllMeetings : any;
  role:any;

  title: any;
  desc: any;
  date: any;
  time: any;
  location:any;

  constructor(private meetingService : MeetingService,
    private userStore: UserStoreService, private authService: AuthenticationService) {
    
  }
  ngOnInit(): void {
    
    this.userStore.getRoleFromStore().subscribe((res:any)=> {
      var roleFromToken = this.authService.getRoleFromToken();
      this.role = res || roleFromToken;
    })

    this.meetingService.GetAllMeeting().subscribe((res:any) => {
      this.AllMeetings = res;
    } )
  }


  logout(){
    this.authService.logout();
  }

  addNewMeeting(){
    this.AddMode = true
  }
  editMeeting(id: number){
    // this.meetingService.EditMeeting
  }

  removeMeeting(id: number){
    this.meetingService.RemoveMeeting(id).subscribe((res:any) => {
      alert(res.message);
    })
  }

  AddTheMeeting(){
    this.AddMode = false;
    this.meetingService.AddNewMeeting(this.title, this.desc, this.date, this.time, this.location).subscribe((res: any) => {
      alert(res.message);
    })
  }
}
