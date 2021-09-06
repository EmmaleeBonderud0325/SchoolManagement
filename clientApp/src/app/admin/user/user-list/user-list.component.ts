import Swal from 'sweetalert2';
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
  isDisabled: boolean;
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
      id:[0],
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

  deleteUser(row) {
    Swal.fire({
      title: 'Are you sure Delete User ?',
      showCancelButton: true,
      confirmButtonColor: 'red',
      cancelButtonColor: 'green',
      confirmButtonText: 'Yes',
    }).then((result) => {

      if (result.value) {

        this.userService.delete(row.id).subscribe(response=>{

          if(response.isSuccess)
          {
            this.toastr.success(response.message,"Success");
            this.getAll();
          }
          else
          {
            this.toastr.error(response.message,"Error");
          }
    
        },error=>{
          this.toastr.error("Network error has been occured. Please try again.","Error");
        });
      }
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

  updateUser(row:UserModel, rowIndex:number, content:any) {

    console.log(row);
    
    this.saveUserForm = this.fb.group({
      id:[row.id],
      fullName:[row.fullName, [Validators.required]],
      email:[row.email, [Validators.required]],
      mobileNo:[row.email, [Validators.required]],
      userName:[row.username, [Validators.required]],
      address:[row.address, [Validators.required]],
      password:[row.password],
      isActive:[true],
      roles:[row.roles,[Validators.required]]
    });

    this.modalService.open(content, {
      ariaLabelledBy: 'modal-basic-title',
      size: 'lg',
    });
  }

}
