import { DatatableComponent } from '@swimlane/ngx-datatable';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Component, OnInit, ViewChild } from '@angular/core';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { ToastrService } from 'ngx-toastr';
import { StudentModel } from './../../../models/student/student.model'
import { StudentService } from './../../../services/student/student.service'
import Swal from 'sweetalert2';

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
  
  constructor(
    private fb: FormBuilder,
    private modalService: NgbModal,
    private studentService:StudentService,
    private toastr: ToastrService) { }

  ngOnInit(): void {
    this.getAll();
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
      name: ['', [Validators.required]],
      admission: ['', [Validators.required]],
      address: ['', [Validators.required]],
      phone1: ['', [Validators.required]],
    });

    this.modalService.open(content, {
      ariaLabelledBy: 'modal-basic-title',
      size: 'lg',
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

}
