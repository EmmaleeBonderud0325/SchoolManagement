import { UserModel } from './../../../models/user/user.model';
import { ToastrService } from 'ngx-toastr';
import { UserService } from './../../../services/user/user.service';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { DatatableComponent } from '@swimlane/ngx-datatable';
import { Component, OnInit, ViewChild } from '@angular/core';

@Component({
  selector: 'app-user-list',
  templateUrl: './user-list.component.html',
  styleUrls: ['./user-list.component.sass'],
  providers: [ToastrService],
})
export class UserListComponent implements OnInit {

  @ViewChild(DatatableComponent, { static: false }) table: DatatableComponent;
  data = [];
  scrollBarHorizontal = window.innerWidth < 1200;
  loadingIndicator = false;
  saveUserForm:FormGroup;
  reorderable = true;
  user:UserModel;

  constructor(
    private fb: FormBuilder,
    private modalService: NgbModal,
    private userService:UserService,
    private toastr: ToastrService) { }

  ngOnInit(): void {
    this.getAll();
    this.saveUserForm = this.fb.group({
      fullName:['', Validators.required],
      email:['', Validators.required],
      mobileNo:['', Validators.required],
      userName:['', Validators.required],
      passwrod:['', Validators.required],

    });
  }

  getAll(){
     
  }

  saveUser(content){
    this.modalService.open(content, {
      ariaLabelledBy: 'modal-basic-title',
      size: 'lg',
    });
  }

  editRow(row, rowIndex, content) {
    this.modalService.open(content, {
      ariaLabelledBy: 'modal-basic-title',
      size: 'lg',
    });
  }

  onAddRowSave(form: FormGroup) {
    this.data.push(form.value);
    this.data = [...this.data];
    form.reset();
    this.modalService.dismissAll();
    this.addRecordSuccess();
  }

  deleteSingleRow(row) {

  }

  addRecordSuccess() {
    this.toastr.success('Acedemic Level Add Successfully', '');
  }


}
