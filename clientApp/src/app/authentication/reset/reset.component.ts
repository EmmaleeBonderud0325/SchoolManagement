import { MessageService } from 'primeng/api';
import { AuthService } from 'src/app/core/service/auth.service';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-reset',
  templateUrl: './reset.component.html',
  styleUrls: ['./reset.component.sass'],
  providers: [MessageService]
})
export class ResetComponent implements OnInit {

  chanagePasswordForm:FormGroup;

  constructor(
    private formBuilder: FormBuilder,
    private authService: AuthService,
    private messageService: MessageService
  ) { }

  ngOnInit(): void {
    this.chanagePasswordForm = this.formBuilder.group({
      schoolDomain:['', Validators.required],
      password:['', Validators.required],
      confirmPassword:['', Validators.required]
    });
  }

  get f() {
    return this.chanagePasswordForm.controls;
  }

  onSubmit() {}

}
