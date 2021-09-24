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
  currentUser:User;
  loggedUserId: number;
  user:UserModel;

  data=[];

  constructor(
    private authService: AuthService,
    private userService: UserService,
    private spinner: NgxSpinnerService
  ) { }

  ngOnInit(): void {
    this.getLoggedInUser();
    this.getUserById();
    this.spinner.hide();
  }

  getLoggedInUser(){
    this.spinner.show();
    this.authService.currentUser.subscribe(user=>{
      this.loggedUserId=user.id;
      console.log("LoggedInUser");
      
      console.log(user);
      
    })
  }

  getUserById(){
    
    this.userService.getUserById(this.loggedUserId).subscribe(response=>{
        this.user = response;
        console.log(response);
        

    },error=>{
        this.spinner.show();
    })

  }


  

}
