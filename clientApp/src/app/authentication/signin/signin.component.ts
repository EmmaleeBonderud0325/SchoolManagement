
import { AuthService } from 'src/app/core/service/auth.service';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MessageService } from 'primeng/api';
@Component({
  selector: 'app-signin',
  templateUrl: './signin.component.html',
  styleUrls: ['./signin.component.scss'],
  providers: [MessageService]
})
export class SigninComponent implements OnInit {
  loginForm: FormGroup;

  submitted = false;

  returnUrl: string;

  error = '';

  hide = true;
  
  constructor(
    private formBuilder: FormBuilder,
    private router: Router,
    private authService: AuthService,
    private messageService: MessageService
  ) {}
  ngOnInit() {
    this.loginForm = this.formBuilder.group({
      schoolDomain:['', Validators.required],
      username: ['', Validators.required],
      password: ['', Validators.required],
    });
  }
  get f() {
    return this.loginForm.controls;
  }
  onSubmit() {
    this.submitted = true;
    this.error = 'School Domain,Username and Password not valid !';

    if (this.loginForm.invalid) {
     
      this.messageService.add({severity:'warn', summary: 'warn', detail: this.error});
      
      
      return;
    } else {
      this.authService
        .login(this.loginForm.value)
        .subscribe(
          (res) => {
            if (res) 
            {
              const token = this.authService.currentUserValue.token;
              if (token) 
              {
                this.router.navigate(['/teacher-home/lessons']);
              }
              else
              {
                this.error = 'Invalid Login';
                this.messageService.add({severity:'error', summary: 'error', detail: this.error});
              }
            } else 
            {
              this.error = 'NetWork Error has been occurred';
              this.messageService.add({severity:'error', summary: 'error', detail: this.error});
            }
          },
          (error) => {
            this.error = 'NetWork Error has been occurred';
            this.messageService.add({severity:'error', summary: 'error', detail: this.error});
            this.submitted = false;
          }
        );
    }
  }
}
