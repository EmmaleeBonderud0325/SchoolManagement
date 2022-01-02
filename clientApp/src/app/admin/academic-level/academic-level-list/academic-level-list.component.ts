import { MessageService } from 'primeng/api';
import { AcademicLevelModel } from './../../../models/academic-level/acdemic.level.model';
import { DropDownModel } from './../../../models/common/drop-down.model';
import { AcademicLevelService } from './../../../services/academic-level/academic-level.service';
import { DatatableComponent } from '@swimlane/ngx-datatable';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Component, OnInit, ViewChild } from '@angular/core';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { ToastrService } from 'ngx-toastr';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-academic-level-list',
  templateUrl: './academic-level-list.component.html',
  styleUrls: ['./academic-level-list.component.scss'],
  providers: [MessageService]
})
export class AcademicLevelListComponent implements OnInit {

  @ViewChild(DatatableComponent, { static: false }) table: DatatableComponent;
  data = [];
  scrollBarHorizontal = window.innerWidth < 1200;
  loadingIndicator = false;
  academicLevelFrom:FormGroup;
  reorderable = true;
  academicLevel:AcademicLevelModel;
  levelHeads:DropDownModel[] = [];

  constructor(
    private fb: FormBuilder,
    private modalService: NgbModal,
    private academicLevelService:AcademicLevelService,
    private messageService: MessageService) { }

  ngOnInit(): void {
    this.getAll();
    this.getAllLevelHeads();
  }
  
  getAllLevelHeads()
  {
    this.academicLevelService.getAllLevelHeads()
      .subscribe(response=>
      { 
        this.levelHeads = response;
      },error=>{
        //this.toastr.error("Network error has been occured. Please try again.","Error");
        this.messageService.add({severity:'error', summary: 'Error', detail: 'Network error has been occured. Please try again.'});
       });
  }
  getAll()
  {
    this.loadingIndicator=true;
    this.academicLevelService.getAll()
    .subscribe(response=>
    {
        this.data= response;
        this.loadingIndicator=false;
    },error=>{
      this.loadingIndicator=false;
      this.messageService.add({severity:'error', summary: 'Error', detail: 'Network error has been occured. Please try again.'});
    });
  }


  addNewAcademicLevel(content) {

    this.academicLevelFrom = this.fb.group({
      id:[0],
      name: ['', [Validators.required]],
      levelHeadId: [null, [Validators.required]],
    });

    this.modalService.open(content, {
      ariaLabelledBy: 'modal-basic-title',
      size: 'lg',
    });

  }

  saveAcademicLevel(){   
    
    console.log(this.academicLevelFrom.value);
    
    this.academicLevelService.saveAcademicLevel(this.academicLevelFrom.value)
    .subscribe(response=>{

        if(response.isSuccess)
        {
          this.modalService.dismissAll();
          //this.toastr.success(response.message,"Success");
          this.messageService.add({severity:'success', summary: 'Success', detail: response.message});
          this.getAll();
        }
        else
        {
          this.messageService.add({severity:'error', summary: 'error', detail: response.message});
        }

    },error=>{
      this.messageService.add({severity:'error', summary: 'Error', detail: 'Network error has been occured. Please try again.'});
    });

  }




  editRow(row:AcademicLevelModel, rowIndex:number, content:any) {

    console.log(row);
    
    this.academicLevelFrom = this.fb.group({
      id:[row.id],
      name: [row.name, [Validators.required]],
      levelHeadId: [row.levelHeadId, [Validators.required]],
    });

    this.modalService.open(content, {
      ariaLabelledBy: 'modal-basic-title',
      size: 'lg',
    });
  }

  //deleteAcademic Level
  deleteAcademicLevel(row) {
    Swal.fire({
      title: 'Are you sure Delete Academic level ?',
      showCancelButton: true,
      confirmButtonColor: 'red',
      cancelButtonColor: 'green',
      confirmButtonText: 'Yes',
    }).then((result) => {

      if (result.value) {

        this.academicLevelService.delete(row.id).subscribe(response=>{

          if(response.isSuccess)
          {
            this.messageService.add({severity:'success', summary: 'Success', detail: response.message});
            this.getAll();
          }
          else
          {
            this.messageService.add({severity:'error', summary: 'error', detail: response.message});
          }
    
        },error=>{
          this.messageService.add({severity:'error', summary: 'Error', detail: 'Network error has been occured. Please try again.'});
        });
      }
    });
  }
  
  get academicLevelId()
  {
    return this.academicLevelFrom.get('id').value;
  }
  

  
}
