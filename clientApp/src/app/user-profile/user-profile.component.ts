import { UserMasterModel } from './../models/user/user.master';
import { NgxSpinnerService } from 'ngx-spinner';
import { UserModel } from './../models/user/user.model';
import { UserService } from './../services/user/user.service';
import { User } from './../core/models/user';
import { AuthService } from './../core/service/auth.service';
import { Component, OnInit } from '@angular/core';
import { throwIfAlreadyLoaded } from '../core/guard/module-import.guard';

@Component({
  selector: 'app-user-profile',
  templateUrl: './user-profile.component.html',
  styleUrls: ['./user-profile.component.sass']
})
export class UserProfileComponent implements OnInit {
  active;
  currentUser:UserMasterModel;
  loggedInUserName:string;
  user:UserModel;
  userName = "avdunusinghe@gmail.com"

  data=[];

  constructor(
    private authService: AuthService,
    private userService: UserService,
    private spinner: NgxSpinnerService
  ) { }

  ngOnInit(): void {
    this.getLoggedInUser();
    this.getuserDetails();
    this.spinner.hide();
  }



 getLoggedInUser(){
    this.spinner.show();
    this.authService.currentUser.subscribe(user=>{
      this.loggedInUserName=user.username;
      console.log("LoggedInUser");
      
     console.log(user.username);
      
    })
  }

  getuserDetails(){

    this.userService.getUserDetails(this.userName).subscribe(response=>{
      this.currentUser = response;
      console.log(response);
      
    })
  
  }

  

}
