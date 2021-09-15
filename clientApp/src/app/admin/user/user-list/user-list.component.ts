import { BasicUserModel } from './../../../models/user/basic.user.model';
import { NgxSpinnerService } from 'ngx-spinner';
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
  scrollBarHorizontal = window.innerWidth < 1200;
  loadingIndicator = false;

  saveUserForm:FormGroup;
  userFilterForm:FormGroup;
  reorderable = true;
  user:UserModel;
  isDisabled: boolean;
  userRoles:DropDownModel[]=[];
  academicLevels:DropDownModel[]=[];

  data = new Array<BasicUserModel>();

  currentPage: number = 0;
  pageSize: number = 25;
  totalRecord: number = 0;

  constructor(
    private fb: FormBuilder,
    private modalService: NgbModal,
    private userService:UserService,
    private spinner: NgxSpinnerService,
    private toastr: ToastrService) { }

  ngOnInit(): void {
    this.spinner.show();
    //this.getAll();
    this.userFilterForm = this.createFilterForm();
    this.getUserRoles();
    this.getUserMasterData();
  }

  //Get paginatedUser Details
  getUserList()
  {
     this.loadingIndicator =true;
     this.userService.getUserList(this.searchTextFilterId, this.currentPage + 1, this.pageSize, this.roleFIlterId)
        .subscribe(response=>{
          this.data = response.data;
          console.log("==============");
          console.log(response.data);
          
          this.totalRecord = response.totalRecordCount;
          this.spinner.hide();
          this.loadingIndicator = false;
        },erroe=>{
          this.spinner.hide();
          this.loadingIndicator = false;
          this.toastr.error("Network error has been occured. Please try again.", "Error");
        });
  }

  //User Filter data
  createFilterForm():FormGroup{

    return this.fb.group({

      searchText: new FormControl(""),
      academicLevelId : new FormControl(0),
      roleId : new FormControl(0),
     

    })
  }

  onRoleFilterChanged(item:any)
  {
    this.currentPage = 0;
    this.pageSize = 25;
    this.totalRecord = 0;
    this.spinner.show();
    this.getUserList();
  }

  /* onAcademicLevelFilterChanged(item: any) {
    this.currentPage = 0;
    this.pageSize = 25;
    this.totalRecord = 0;
    this.spinner.show();
    this.getUserList();
  } */

  //getters
  get roleFIlterId(){
    return this.userFilterForm.get("roleId").value
  }
 /*  get academicLevelFilterId() {
    return this.userFilterForm.get("academicLevelId").value;
  } */

  get searchTextFilterId() {
    return this.userFilterForm.get("searchText").value;
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

  //get user Drop-Down Master Meta Data
  getUserMasterData()
  {
    this.userService.getClassMasterData().subscribe(response=>{

      this.userRoles = response.userRoles;
      this.academicLevels = response.academicLevels;

      this.getUserList();
    },error=>{
      this.spinner.hide();
    })


  }

  setPage(pageInfo) {
    this.spinner.show();
    this.loadingIndicator = true;
    this.currentPage = pageInfo.offset;
    this.getUserList();
  }
  //FIlter Master 
  filterDatatable(event) {
    this.currentPage = 0;
    this.pageSize = 25;
    this.totalRecord = 0;
    const val = event.target.value.toLowerCase();
    this.spinner.show();
    this.getUserList();
  }

  //delete user
/*   deleteUser(row) {
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
  } */

  deleteUser(row) {
    const swalWithBootstrapButtons = Swal.mixin({
      customClass: {
        confirmButton: 'btn btn-success',
        cancelButton: 'btn btn-danger',
      },
      buttonsStyling: false,
    });
    swalWithBootstrapButtons
      .fire({
        title: 'Are you sure?',
        text: "You won't be able to revert this!",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonText: 'Yes, delete it!',
        cancelButtonText: 'No, cancel!',
        reverseButtons: true,
      })
      .then((result) => {
        if (result.value) {
          this.userService.delete(row.id).subscribe(response=>{

            if(response.isSuccess)
            {
              this.toastr.success(response.message,"Success");
              this.getUserList();
            }
            else
            {
              this.toastr.error(response.message,"Error");
            }
      
          },error=>{
            this.toastr.error("Network error has been occured. Please try again.","Error");
          });
          swalWithBootstrapButtons.fire(
            'Deleted!',
            'Your file has been deleted.',
            'success'
          );
        } else if (
          /* Read more about handling dismissals below */
          result.dismiss === Swal.DismissReason.cancel
        ) {
          swalWithBootstrapButtons.fire(
            'Cancelled',
            'Your imaginary file is safe :)',
            'error'
          );
        }
      });
  }

  //get User By Role
  getAll()
  {
    
     this.loadingIndicator = true;
     this.userService.getAll().subscribe(response=>
    {
      //this.data=response;
      this.spinner.hide();
      this.loadingIndicator = false;
     },error=>{
       this.loadingIndicator = false;
       this.toastr.error("Network error has been occured. Please try again.","Error");
     });
  } 

  //get user roles Dropdown Model
  getUserRoles()
  {
    this.userService.getAllRoles().subscribe(response=>{
        this.userRoles= response;
        this.getUserList();
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
            this.getUserList();
        }
        else
        {
            this.toastr.error(response.message,"Error");
        }
      },error=>{

            this.toastr.error("Network error has been occre.Please try again","Error");
      });
    
  }

  //update user (Reactive Form)
  updateUser(row:UserModel, rowIndex:number, content:any) {

    console.log(row);
    
    let selectedRoles = [];

    this.saveUserForm = this.fb.group({
      id:[row.id],
      fullName:[row.fullName, [Validators.required]],
      email:[row.email, [Validators.required]],
      mobileNo:[row.mobileNo, [Validators.required]],
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

  //id getter
  get id()
  {
    return this.saveUserForm.get("id").value;
  }
}
