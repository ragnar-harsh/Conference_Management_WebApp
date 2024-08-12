import { Component, OnInit } from '@angular/core';
import { AuthenticationService } from '../Services/authentication.service';
import { Router } from '@angular/router';
import { UserStoreService } from '../Services/user-store.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  email: string;
  password: string;

  constructor(private authService: AuthenticationService, private router : Router,
    private userStore : UserStoreService
  ) {}
  ngOnInit(): void {
  }

  loginUser(){
    if(this.email && this.password){
      this.authService.login(this.password, this.email).subscribe((res) => {
        this.authService.storeToken(res.token);
        const tokenPayload = this.authService.decodeToken();
        this.userStore.setRoleForStore(tokenPayload.role);
        alert(res.message);
        this.router.navigate(['./dashboard']);
      })
    }
    else{
      console.log("Please fill fields");
    }
  }

}
