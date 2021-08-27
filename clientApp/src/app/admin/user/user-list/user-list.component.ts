import { DropDownModel } from './../../../models/common/drop-down.model';
import { UserModel } from './../../../models/user/user.model';
import { ToastrService } from 'ngx-toastr';
import { UserService } from './../../../services/user/user.service';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { FormGroup, FormBuilder, Validators, FormArray, FormControl } from '@angular/forms';
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

  userRoles:DropDownModel[]=[];

  constructor(
    private fb: FormBuilder,
    private modalService: NgbModal,
    private userService:UserService,
    private toastr: ToastrService) { }

  ngOnInit(): void {
    this.getAll();
    this.getUserRoles();
  
  }

  //create new user (Reactive Form)
  createNewUser(content)
  {
    this.saveUserForm = this.fb.group({
      fullName:['', [Validators.required]],
      email:['', [Validators.required]],
      mobileNo:['', [Validators.required]],
      userName:['', [Validators.required]],
      address:['', [Validators.required]],
      password:['', [Validators.required]],
      isActive:[true],
      roles:[null,[Validators.required]]
    });

    this.modalService.open(content, {
      ariaLabelledBy: 'modal-basic-title',
      size: 'lg',
    });
  }

  getUser()
  {
    
  }

  //getUserByRole
  getAll()
  {
     this.loadingIndicator = true;
     this.userService.getAll().subscribe(response=>
    {
      this.data=response;
      this.loadingIndicator = false;
     },error=>{
       this.loadingIndicator = false;
       this.toastr.error("Network error has been occured. Please try again.","Error");
     });
  }

  getUserRoles()
  {
    this.userService.getAllRoles().subscribe(response=>{
        this.userRoles= response;
    },error=>{

    });
  }

  //save User 
  saveUser()
  {
    console.log(this.saveUserForm.value);

    this.userService.saveUser(this.saveUserForm.value)
      .subscribe(response=>{
        
        if(response.isSuccess)
        {
            this.modalService.dismissAll();
            this.toastr.success(response.message,"Success");
            this.getAll();
        }
        else
        {
            this.toastr.error(response.message,"Error");
        }
      },error=>{

            this.toastr.error("Network error has been occre.Please try again","Error");
      });
    
  }

  editRow(row, rowIndex, content) 
  {
    this.modalService.open(content, {
      ariaLabelledBy: 'modal-basic-title',
      size: 'lg',
    });
  }

  onAddRowSave(form: FormGroup)
   {

    
  }

  deleteSingleRow(row) 
  {

  }






}
