import { SubjectModel } from './../../../models/subject/subject.model';
import { DropDownModel } from 'src/app/models/common/drop-down.model';
import { SubjectService} from './../../../services/subject/subject.service';
import { DatatableComponent } from '@swimlane/ngx-datatable';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Component, OnInit, ViewChild } from '@angular/core';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { ToastrService } from 'ngx-toastr';


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
  saveSubject:FormGroup;
  reorderable = true;
  subject:SubjectModel;
  

  constructor(
    private fb: FormBuilder,
    private modalService: NgbModal,
    private subjectService:SubjectService,
    private toastr: ToastrService) { }

  ngOnInit(): void {
    this.getAll();
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
 
  
/*
  addSubject(content) {
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
  
  editRow(row, rowIndex, content) {
    this.modalService.open(content, {
      ariaLabelledBy: 'modal-basic-title',
      size: 'lg',
    });
  }
  
  deleteSingleRow(row) {
  }
  
  addRecordSuccess() {
    this.toastr.success('Acedemic Level Add Successfully', '');
  }*/

  
}

