import { DatatableComponent } from '@swimlane/ngx-datatable';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Component, OnInit, ViewChild } from '@angular/core';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { ToastrService } from 'ngx-toastr';
import { StudentModel } from './../../../models/student/student.model'
import { StudentService } from './../../../services/student/student.service'
import Swal from 'sweetalert2';
import { DropDownModel } from 'src/app/models/common/drop-down.model';

@Component({
  selector: 'app-student-list',
  templateUrl: './student-list.component.html',
  styleUrls: ['./student-list.component.sass'],
  providers: [ToastrService],
})
export class StudentListComponent implements OnInit {
  @ViewChild(DatatableComponent, { static: false }) table: DatatableComponent;
  data = [];
  scrollBarHorizontal = window.innerWidth < 1200;
  loadingIndicator = false;
  saveStudentForm:FormGroup;
  reorderable = true;
  user:StudentModel;
  allGenders:DropDownModel[] = [];
  studentClass:DropDownModel[] = [];
  
  constructor(
    private fb: FormBuilder,
    private modalService: NgbModal,
    private studentService:StudentService,
    private toastr: ToastrService) { }

  ngOnInit(): void {
    this.getAll();
    this.getAllGenders();
    this.getClasses();
  }

  getAll(){
    this.loadingIndicator=true;
    this.studentService.getAll().subscribe(response=>
    {
        this.data= response;
        console.log(response);
        this.loadingIndicator=false;
    },error=>{
        this.loadingIndicator=false;
    });
  }

  //create new user (Reactive Form)
  addNewStudent(content) {

    this.saveStudentForm = this.fb.group({
      fullName: ['', [Validators.required]],
      admissionNo: ['', [Validators.required]],
      address: ['', [Validators.required]],
      mobileNo: ['', [Validators.required]],
      emegencyContactNo: ['', [Validators.required]],
      password: ['', [Validators.required]],
      dateOfBirth: ['', [Validators.required]],
      gender: ['', [Validators.required]],
      email: ['', [Validators.required]],
      classes: ['', [Validators.required]],
    });

    this.modalService.open(content, {
      ariaLabelledBy: 'modal-basic-title',
      size: 'lg',
    });
  }

  getAllGenders()
  {
    this.studentService.getAllGenders()
      .subscribe(response=>
      { 
        this.allGenders = response;
      },error=>{
        
       });
  }

  saveStudent(){   
    
    console.log(this.saveStudentForm.value);
    
    this.studentService.saveStudent(this.saveStudentForm.value)
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
      this.toastr.error("Network error has been occured. Please try again.","Error");
    });

  }

  deleteStudent(row) {
    Swal.fire({
      title: 'Are you sure Delete Student?',
      showCancelButton: true,
      confirmButtonColor: 'red',
      cancelButtonColor: 'green',
      confirmButtonText: 'Yes',
    }).then((result) => {
      if (result.value) {

        this.studentService.delete(row.id).subscribe(response=>{

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

  editRow(row:StudentModel, rowIndex:number, content:any) {

    console.log(row);

    this.saveStudentForm = this.fb.group({
      id:[row.id],
      fullName:[row.fullName, [Validators.required]],
      admissionNo:[row.admissionNo, [Validators.required]],
      address:[row.address, [Validators.required]],
      dateOfBirth:[row.dateOfBirth, [Validators.required]],
      mobileNo:[row.mobileNo, [Validators.required]],
      emegencyContactNo:[row.emegencyContactNo, [Validators.required]],
      gender:[row.gender, [Validators.required]],
      email:[row.email, [Validators.required]],
      password:[row.password],
      isActive:[true],
      classes:[row.classes, [Validators.required]],
    });

    this.modalService.open(content, {
      ariaLabelledBy: 'modal-basic-title',
      size: 'lg',
    });
  }

  getClasses() {
    this.studentService.getAllClasses().subscribe(response => {
      console.log(response);
      this.studentClass = response;
    }, error=>{

    });
  }

}
