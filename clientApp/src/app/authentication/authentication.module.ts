import { ToastModule } from 'primeng/toast';

import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { AuthenticationRoutingModule } from './authentication-routing.module';
import { SigninComponent } from './signin/signin.component';
import { ReactiveFormsModule } from '@angular/forms';
import { SignupComponent } from './signup/signup.component';
import { FeatherModule } from 'angular-feather';
import {
  Facebook,
  Twitter,
  Github,
  Gitlab,
  User,
  Key,
  UserCheck,
  Mail,
} from 'angular-feather/icons';
import { ForgotComponent } from './forgot/forgot.component';
import { Page500Component } from './page500/page500.component';
import { Page404Component } from './page404/page404.component';
import { ResetComponent } from './reset/reset.component';
//import { MessageService } from 'primeng/api';

const icons = {
  Facebook,
  Twitter,
  Github,
  Gitlab,
  User,
  Key,
  UserCheck,
  Mail,
};

@NgModule({
  declarations: [SigninComponent, SignupComponent, ForgotComponent, Page500Component, Page404Component, ResetComponent],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    AuthenticationRoutingModule,
    FeatherModule.pick(icons),
    //MessageService
    ToastModule
  ],
})
export class AuthenticationModule {}
