import { SubjectModel } from './../../../models/subject/subject.model';
import { DropDownModel } from 'src/app/models/common/drop-down.model';
import { SubjectService} from './../../../services/subject/subject.service';
import { DatatableComponent } from '@swimlane/ngx-datatable';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Component, OnInit, ViewChild } from '@angular/core';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { ToastrService } from 'ngx-toastr';
import Swal from 'sweetalert2';


@Component({
  selector: 'app-subject-list',
  templateUrl: './subject-list.component.html',
  styleUrls: ['./subject-list.component.sass'],
  providers: [ToastrService],
})
export class SubjectListComponent implements OnInit {

  
  @ViewChild(DatatableComponent, { static: false }) table: DatatableComponent;
  data = [];
  scrollBarHorizontal = window.innerWidth < 1200;
  loadingIndicator = false;
  subjectForm:FormGroup;
  reorderable = true;
  subject:SubjectModel;
  subjectstreams:DropDownModel[] = [];
  subjectAcademicLevels:DropDownModel[]=[];
  subjectCategorys:DropDownModel[]=[];
  parentBasketSubjects:DropDownModel[]=[];

  constructor(
    private fb: FormBuilder,
    private modalService: NgbModal,
    private subjectService:SubjectService,
    private toastr: ToastrService) { }

  ngOnInit(): void {
    this.getAll();
    this.getAllSubjectStreams();
    this.getAllAcademicLevels();
    this.getAllSubjectCategorys();
    this.getAllParentBasketSubjects();
  }

  getAll()
  {
    this.loadingIndicator=true;
    this.subjectService.getAll().subscribe(response=>
    {
        this.data= response;
        console.log(response);
        this.loadingIndicator=false;
    },error=>{
        this.loadingIndicator=false;
    });
  }

  getAllSubjectStreams()
  {
    this.subjectService.getAllSubjectStreams()
      .subscribe(response=>
      { 
        this.subjectstreams = response;
        
      },error=>{
        this.toastr.error("Network error has been occured. Please try again.","Error");
       });
  }

  getAllAcademicLevels()
  {
    this.subjectService.getAllAcademicLevels()
     .subscribe(response=>{
        this.subjectAcademicLevels = response;
        
    },error=>{
      this.toastr.error("Network error has been occured. Please try again.","Error");
    });
  }

  getAllSubjectCategorys()
  {
    this.subjectService.getAllSubjectCategorys()
     .subscribe(response=>{
        this.subjectCategorys = response;
        
    },error=>{
      this.toastr.error("Network error has been occured. Please try again.","Error");
    });
  }

  getAllParentBasketSubjects()
  {
    this.subjectService.getAllParentBasketSubjects()
     .subscribe(response=>{
        this.parentBasketSubjects = response;
        console.log(response);
    },error=>{
      this.toastr.error("Network error has been occured. Please try again.","Error");
    });
  }
 
  addNewSubject(content) {

    this.subjectForm = this.fb.group({
      name: ['', [Validators.required]],
      subjectstreamId: [null, [Validators.required]],
      categorysId:[null,[Validators.required]],
      subjectCode:['',[Validators.required]],
      academicLevels:[null,[Validators.required]],
      parentBasketSubjectId:[null],
      isParentBasketSubject:[null],
      isBuscketSubject:[null],
    });

    this.modalService.open(content, {
      ariaLabelledBy: 'modal-basic-title',
      size: 'lg',
    });

  }

  saveSubject(){   
    
    console.log(this.subjectForm.value);
    
    this.subjectService.saveSubject(this.subjectForm.value)
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
  
/*
 
  
  onAddRowSave(form: FormGroup) {
    this.data.push(form.value);
    this.data = [...this.data];
    form.reset();
    this.modalService.dismissAll();
    this.addRecordSuccess();
  }
  
  editRow(row, rowIndex, content) {
    this.modalService.open(content, {
      ariaLabelledBy: 'modal-basic-title',
      size: 'lg',
    });
  }
  
 
  
  addRecordSuccess() {
    this.toastr.success('Acedemic Level Add Successfully', '');
  }*/
  deleteSubject(row) {
    Swal.fire({
      title: 'Are you sure Delete Subject ?',
      showCancelButton: true,
      confirmButtonColor: 'red',
      cancelButtonColor: 'green',
      confirmButtonText: 'Yes',
    }).then((result) => {

      if (result.value) {

        this.subjectService.delete(row.id).subscribe(response=>{

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

