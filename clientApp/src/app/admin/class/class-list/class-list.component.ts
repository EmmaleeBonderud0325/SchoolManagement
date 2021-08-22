import { ClassModel } from './../../../models/class/class.model';
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
  user:ClassModel;

  constructor(
    private fb: FormBuilder,
    private modalService: NgbModal,
    private classService:ClassService,
    private toastr: ToastrService) { }

    ngOnInit(): void {
      this.getAll();
      this.saveClassForm = this.fb.group({
        Name:['', Validators.required],
        Description:['', Validators.required],
      });
    }
  
    getAll(){
  
    }

    saveClass(content){
      this.modalService.open(content, {
        ariaLabelledBy: 'modal-basic-title',
        size: 'lg',
      })
    }
  
    editRow(row, rowIndex, content) {
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
  
    deleteSingleRow(row) {
  
    }
  
    addRecordSuccess() {
      this.toastr.success('Class Add Successfully', '');
    }

}
