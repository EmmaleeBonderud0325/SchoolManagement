import { DatatableComponent } from '@swimlane/ngx-datatable';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Component, OnInit, ViewChild } from '@angular/core';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { ToastrService } from 'ngx-toastr';
import { StudentModel } from './../../../models/student/student.model'
import { StudentService } from './../../../services/student/student.service'

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
  saveClassForm:FormGroup;
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

}
