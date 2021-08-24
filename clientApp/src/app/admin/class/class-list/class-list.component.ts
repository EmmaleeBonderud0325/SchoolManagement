import { ClassModel } from './../../../models/class/class.model';
import { DropDownModel } from './../../../models/common/drop-down.model';
import { ToastrService } from 'ngx-toastr';
import { ClassService } from './../../../services/class/class.service';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { DatatableComponent } from '@swimlane/ngx-datatable';
import { Component, OnInit, ViewChild } from '@angular/core';


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


  constructor(
    private fb: FormBuilder,
    private modalService: NgbModal,
    private classService:ClassService,
    private toastr: ToastrService) { }

    ngOnInit(): void {
      this.saveClassForm = this.fb.group({
        Name:['', Validators.required],
        ClassCategory:['', Validators.required],
        LanguageStream:['', Validators.required],
      });
      this.getAll();
      this.getAllClassNames();
      this.getAllAcademicLevels();
      this.getAllAcademicYears();
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
        
        this.classNames = response;
      },error=>{

      });
    }

  getAllAcademicLevels(){
    this.classService.getAllAcademicLevels()
      .subscribe(response=>{

        console.log(response);
        
        this.classNames = response;
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

    addNewAcademicLevel(content) {

      this.saveClassForm = this.fb.group({
        name: ['', [Validators.required, Validators.pattern('[a-zA-Z]+')]],
        selectclassNameId: [null, [Validators.required]],
        selectacademicLevelId: [null, [Validators.required]],
        selectacademicYearId: [null, [Validators.required]],
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
        selectclassNameId: [row.classNameId, [Validators.required]],
        selectacademicLevelId: [row.academicLevelId, [Validators.required]],
        selectacademicYearId: [row.academicYearId, [Validators.required]],
      });
    }
  
    deleteSingleRow(row) {
  
    }
  
    addRecordSuccess() {
      this.toastr.success('Class Add Successfully', '');
    }

}
