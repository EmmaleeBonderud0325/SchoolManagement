import { AcademicLevelService } from './../../../services/academic-level/academic-level.service';
import { DatatableComponent } from '@swimlane/ngx-datatable';
import { FormGroup, FormBuilder } from '@angular/forms';
import { Component, OnInit, ViewChild } from '@angular/core';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { ToastrService } from 'ngx-toastr';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-academic-level-list',
  templateUrl: './academic-level-list.component.html',
  styleUrls: ['./academic-level-list.component.sass'],
  providers: [ToastrService],
})
export class AcademicLevelListComponent implements OnInit {

  @ViewChild(DatatableComponent, { static: false }) table: DatatableComponent;
  data = [];
  scrollBarHorizontal = window.innerWidth < 1200;
  loadingIndicator = false;

  reorderable = true;

  constructor(
    private fb: FormBuilder,
    private modalService: NgbModal,
    private academicLevelService:AcademicLevelService,
    private toastr: ToastrService) { }

  ngOnInit(): void {
    this.getAll();
  }

  getAll()
  {
    this.loadingIndicator=true;
    this.academicLevelService.getAll().subscribe(response=>
    {
        this.data= response;
        this.loadingIndicator=false;
    },error=>{
      this.loadingIndicator=false;
    });
  }


    onAddRowSave(form: FormGroup) {

    }


  editRow(row, rowIndex, content) {
    this.modalService.open(content, {
      ariaLabelledBy: 'modal-basic-title',
      size: 'lg',
    });

    
  }

    deleteSingleRow(row) {

    }
}
