import { Component } from '@angular/core';
import { AuthenticationService } from '../Services/authentication.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.css']
})
export class SignupComponent {

  firstname: string;
  lastname: string;
  password: string;
  confirmPassword: string;
  email: string;
  role: string;

  constructor(private authService: AuthenticationService, private router: Router) {}

  registerUser(){
    if(this.firstname && this.lastname && this.email && this.role && this.password && this.confirmPassword){
      if(this.confirmPassword === this.password){
        this.authService.registerUser(this.firstname, this.lastname, this.password, this.confirmPassword, this.email, this.role).subscribe((res) => {
          alert(res.message);
          this.router.navigate(['./login']);
        })
      }
      else{
        console.log("password doesnot match");
      }
    }
    else{
      alert("Some fields are missing");
    }
  }
}
