import { DropdownService } from './../../../services/drop-down/dropdown.service';
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
  subjectTypes:DropDownModel[]=[];

  constructor(
    private fb: FormBuilder,
    private modalService: NgbModal,
    private subjectService:SubjectService,
    private dropDownService:DropdownService,
    private toastr: ToastrService) { }

  ngOnInit(): void {
    this.getAll();
    this.getSubjectTypes()
    this.getAllSubjectStreams();
    this.getAllAcademicLevels();
    this.getAllSubjectCategorys();
    this.getAllParentBasketSubjects();
  }
  //getAll Subject
  getAll()
  {
    this.loadingIndicator=true;
    this.subjectService.getAll()
    .subscribe(response=>
    {
        this.data= response;
        this.loadingIndicator=false;
    },error=>{
        this.loadingIndicator=false;
    });
  }
  //get Subject Types DropDown Meta Data
  getSubjectTypes()
  {
    this.dropDownService.getAllSubjectTypes()
    .subscribe(response=>
    {
      this.subjectTypes = response;
    },error=>{
        
    })
  }
  //get Subject Stream Master Meta Data
  getAllSubjectStreams()
  {
    this.dropDownService.getAllSubjectStreams()
      .subscribe(response=>
      { 
        this.subjectstreams = response;  
      },error=>{
        
       });
  }
  //get Academic Levels DropDown Meta Data
  getAllAcademicLevels()
  {
    this.dropDownService.getAllAcademicLevels()
     .subscribe(response=>
      {
        this.subjectAcademicLevels = response;  
      },error=>{
      
      });
  }
   //get Subject Categorys DropDown Meta Data
  getAllSubjectCategorys()
  {
    this.dropDownService.getAllSubjectCategorys()
     .subscribe(response=>
    {
        this.subjectCategorys = response;
    },error=>{
      this.toastr.error("Network error has been occured. Please try again.","Error");
    });
  }
  //get All Parent Basket Subjects DropDown Meta Data
  getAllParentBasketSubjects()
  {
    this.dropDownService.getAllParentBasketSubjects()
     .subscribe(response=>{
        this.parentBasketSubjects = response;
    },error=>{
      
    });
  }
  //save Subject Form 
  addNewSubject(content)
   {

    this.subjectForm = this.fb.group({
      id:[0],
      name: ['', [Validators.required]],
      subjectstreamId: [null, [Validators.required]],
      categorysId:[null,[Validators.required]],
      subjectCode:['',[Validators.required]],
      subjectType:[null,[Validators.required]], 
      subjectAcademicLevels:[null,[Validators.required]],
      parentBasketSubjectId:[null],
          
    });

    this.modalService.open(content, {
      ariaLabelledBy: 'modal-basic-title',
      size: 'lg',
    });

  }
  //Save Subject 
  saveSubject()
  {   
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
  //Delete subject 
  deleteSubject(row) {
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
  //update Subject
  updateSubject(row:SubjectModel, rowIndex:number, content:any) 
  {

    console.log(row);
    
    let selectedRoles = [];

    this.subjectForm = this.fb.group({
      id:[row.id], 
      name: [row.name, [Validators.required]],
      subjectstreamId: [row.subjectStreamId, [Validators.required]],
      categorysId:[row.subjectCategory,[Validators.required]],
      subjectCode:[row.subjectCode,[Validators.required]],
      subjectType:[row.subjectType,[Validators.required]], 
      subjectAcademicLevels:[row.subjectAcademicLevels,[Validators.required]],
      parentBasketSubjectId:[row.parentBasketSubjectId],
    });

    this.modalService.open(content, {
      ariaLabelledBy: 'modal-basic-title',
      size: 'lg',
    });
  }
  //Suject Type Getter
  get subjectType()
  {
    return this.subjectForm.get("subjectType").value;
  }
  
}

