import { MessageService } from 'primeng/api';
import { FormGroup, FormBuilder, FormControl, Validators } from '@angular/forms';
import { UserMasterModel } from './../models/user/user.master';
import { NgxSpinnerService } from 'ngx-spinner';
import { UserModel } from './../models/user/user.model';
import { UserService } from './../services/user/user.service';
import { User } from './../core/models/user';
import { AuthService } from './../core/service/auth.service';
import { Component, Input, OnInit } from '@angular/core';
import { throwIfAlreadyLoaded } from '../core/guard/module-import.guard';
import { ThumbsDown } from 'angular-feather/icons';
import {ButtonModule} from 'primeng/button';
import { EMPTY, Observable } from 'rxjs';
import { Upload } from '../models/common/upload';
@Component({
  selector: 'app-user-profile',
  templateUrl: './user-profile.component.html',
  styleUrls: ['./user-profile.component.scss'],
  providers: [MessageService]
})
export class UserProfileComponent implements OnInit {
  active;
  currentUser:UserMasterModel;
  loggedInUserName:string;
  user:UserModel;

  updateProfileForm:FormGroup;
  updatePasswrodForm:FormGroup;

  data=[];

  constructor(
    private formBuilder: FormBuilder,
    private authService: AuthService,
    private userService: UserService,
    private spinner: NgxSpinnerService,
    private messageService: MessageService
  ) { 

    this.updateProfileForm = this.createNewProfile();
    this.updatePasswrodForm = this.createUpdatePasswrodForm();
  }

  ngOnInit(): void {
    //this.getLoggedInUser();
    this.getuserDetails();
    //this.spinner.hide();
  }

  createNewProfile():FormGroup
  {
    return this.formBuilder.group({

      fullName:['',Validators.required],
      email:['',Validators.required],
      mobileNumber:['',Validators.required],
      userName:['',Validators.required],
      address:['',Validators.required],
        
    });
  }

  createUpdatePasswrodForm():FormGroup
  {
      return this.formBuilder.group({

        currentPassword:['',Validators.required],
        newPassword:['',Validators.required],
        confirmPassword:['',Validators.required]
          
      });
  };



 getLoggedInUser(){
    this.spinner.show();
    this.authService.currentUser.subscribe(user=>{
      this.loggedInUserName=user.username;
      console.log("LoggedInUser");
      
     console.log(user.username);
      
    })
  }

  getuserDetails(){

    this.userService.getUserDetails().subscribe(response=>{
      this.currentUser = response;

      console.log(response);
      

      this.updateProfileForm.get('fullName').setValue(response.fullName);
      this.updateProfileForm.get('email').setValue(response.email);
      this.updateProfileForm.get('mobileNumber').setValue(response.mobileNumber);
      this.updateProfileForm.get('userName').setValue(response.userName);
      this.updateProfileForm.get('address').setValue(response.address);
      
    })
  
  }




  @Input() accept = 'image/*';
  fileName: string = '';
  upload$: Observable<Upload> = EMPTY;
  precentage:any;
  onFileChange(event: any)
  {
    let fi = event.srcElement;
    const formData = new FormData();
    //formData.set("id",this.currentUser.);

    console.log(formData);
    
    
    if(fi.files.length>0)
    {
        //this._fuseProgressBarService.show();
        for (let index = 0; index < fi.files.length; index++) {
          
          formData.append('file', fi.files[index], fi.files[index].name);
        }
        this.userService.uploadUserImage(formData).subscribe(res=>
          {
            this.precentage =res;

            if(res.state=="DONE")
            {
              //item.isUploading=false;
              //this._fuseProgressBarService.hide();
              this.getuserDetails();
            }
            //progress
          },error=>{
            //this._fuseProgressBarService.hide();
            //item.isUploading=false;


          });
/*         this._quotationService.uploadQuotationFiles(formData)
          .subscribe(response=>{
 
          },error=>{
            console.log("Error occured");
            
          }); */
    } 
  }
 

    updateUserProfile(currentUser:UserMasterModel)
    {
      this.userService.UpdateUserMasterData(this.updateProfileForm.value).subscribe(response=>{

        this.spinner.hide();
        if(response.isSuccess)
        {
           
            this.messageService.add({severity:'success', summary: 'Success', detail: response.message});
            this.getuserDetails();
        }
        else
        {
           this.messageService.add({severity:'error', summary: 'Error', detail: response.message});
        }
            
      })
    }
  

}
