import { ClassModel } from './../../../models/class/class.model';
import { DropDownModel } from './../../../models/common/drop-down.model';
import { ToastrService } from 'ngx-toastr';
import { ClassService } from './../../../services/class/class.service';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { DatatableComponent } from '@swimlane/ngx-datatable';
import { Component, OnInit, ViewChild } from '@angular/core';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-class-list',
  templateUrl: './class-list.component.html',
  styleUrls: ['./class-list.component.sass'],
  providers: [ToastrService],
})
export class ClassListComponent implements OnInit {

  @ViewChild(DatatableComponent, { static: false }) table: DatatableComponent;
  data = [];
  scrollBarHorizontal = window.innerWidth < 1200;
  loadingIndicator = false;
  saveClassForm:FormGroup;
  reorderable = true;
  class:ClassModel;
  classNames:DropDownModel[] = [];
  academicLavels:DropDownModel[] = [];
  academicYears:DropDownModel[] = [];
  classCategories:DropDownModel[] = [];
  languageStreams:DropDownModel[] = [];


  constructor(
    private fb: FormBuilder,
    private modalService: NgbModal,
    private classService:ClassService,
    private toastr: ToastrService) { }

    ngOnInit(): void {
      this.saveClassForm = this.fb.group({
        selectclassNameId: [null, [Validators.required]],
        selectedacademicLevelId: [null, [Validators.required]],
        Name:['', Validators.required],
        classCategory:['', Validators.required],
        languageStream:['', Validators.required],
      });
      this.getAll();
      this.getAllClassNames();
      this.getAllAcademicLevels();
      this.getAllAcademicYears();
      this.getAllClassCategories();
      this.getAllLanguageStreams();
    }

    getAllClassNames(){
      this.classService.getAllClassNames()
        .subscribe(response=>{

          console.log(response);
          
          this.classNames = response;
        },error=>{

        });
    }

    getAllAcademicYears(){
    this.classService.getAllAcademicYears()
      .subscribe(response=>{

        console.log(response);
        
        this.academicLavels = response;
      },error=>{

      });
    }

  getAllAcademicLevels(){
    this.classService.getAllAcademicLevels()
      .subscribe(response=>{

        console.log(response);
        
        this.academicYears = response;
      },error=>{

      });
  }

  getAllClassCategories(){
    this.classService.getAllClassCategories()
      .subscribe(response=>{

        console.log(response);
        
        this.classCategories = response;
      },error=>{

      });
  }

  getAllLanguageStreams(){
    this.classService.getAllLanguageStreams()
      .subscribe(response=>{

        console.log(response);
        
        this.languageStreams = response;
      },error=>{

      });
  }
  
    getAll(){
      this.loadingIndicator=true;
      this.classService.getAll().subscribe(response=>
    {
        this.data= response;
        this.loadingIndicator=false;
    },error=>{
      this.loadingIndicator=false;
    });
    }

    addNewClass(content) {

      this.saveClassForm = this.fb.group({
        name: ['', [Validators.required, Validators.pattern('[a-zA-Z]+')]],
        selectclassNameId: [null, [Validators.required]],
        selectacademicLevelId: [null, [Validators.required]],
        selectacademicYearId: [null, [Validators.required]],
        classCategory:['', Validators.required],
        languageStream:['', Validators.required],
      });
  
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

    editRow(row:ClassModel, rowIndex:number, content:any) {
      this.modalService.open(content, {
        ariaLabelledBy: 'modal-basic-title',
        size: 'lg',
      });

      this.saveClassForm = this.fb.group({
        name: [row.name, [Validators.required, Validators.pattern('[a-zA-Z]+')]],
        selectclassNameId: [row.selectedClassNameId, [Validators.required]],
        selectacademicLevelId: [row.selectedAcademicLevelId, [Validators.required]],
        ademicYearId: [row.academicYearId, [Validators.required]],
        classCategory: [row.classCategory, [Validators.required]],
        languageStream: [row.languageStream, [Validators.required]],
      });
    }
  
    deleteSingleRow(row) {
  
    }
  
    addRecordSuccess() {
      this.toastr.success('Class Add Successfully', '');
    }

}
