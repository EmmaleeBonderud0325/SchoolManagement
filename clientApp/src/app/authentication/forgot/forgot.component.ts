import { AuthService } from 'src/app/core/service/auth.service';
import { ForgotPasswordModel } from './../../models/user/forgot.password.model';
import { MessageService } from 'primeng/api';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-forgot',
  templateUrl: './forgot.component.html',
  styleUrls: ['./forgot.component.scss'],
  providers: [MessageService]
})
export class ForgotComponent implements OnInit {

  sendEmailForm: FormGroup;
  submitted = false;
  returnUrl: string;
  forgotPasswordModel:ForgotPasswordModel;
  error=''
  constructor(
    private formBuilder: FormBuilder,
    private authService: AuthService,
    private messageService: MessageService
  ) {}

  ngOnInit(): void {
    this.sendEmailForm = this.formBuilder.group({
      email:['', Validators.required]
    });
  }
  get f() {
    return this.sendEmailForm.controls;
  }

  onSubmit() {

    this.submitted = true;
    this.error = 'School Domain,Username and Password not valid !';

    if (this.sendEmailForm.invalid) {
      //this.error = 'Username and Password not valid !';
      this.messageService.add({severity:'warn', summary: 'warn', detail: this.error});
      return;
    }
    else
    {
      this.authService.forgotPassword(this.sendEmailForm.value)
      .subscribe(response=>{
  
          if(response.isSuccess)
          {
            this.messageService.add({severity:'success', summary: 'Success', detail: response.message});
          }
          else
          {
            this.messageService.add({severity:'error', summary: 'error', detail: response.message});
          }
      },error=>{
        this.messageService.add({severity:'error', summary: 'error', detail:"Network error has been occured. Please try again."});
      });  
    }
    
  }
}
