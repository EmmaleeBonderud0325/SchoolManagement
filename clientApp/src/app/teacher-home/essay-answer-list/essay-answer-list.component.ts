
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { ToastrService } from 'ngx-toastr';

import {​​​​​​​​ FormGroup, FormBuilder, Validators }​​​​​​​​ from'@angular/forms';
import {​​​​​​​​ DatatableComponent }​​​​​​​​ from'@swimlane/ngx-datatable';
import {​​​​​​​​ Component, OnInit, ViewChild }​​​​​​​​ from'@angular/core';



@Component({
  selector: 'app-essay-answer-list',
  templateUrl: './essay-answer-list.component.html',
  styleUrls: ['./essay-answer-list.component.sass'],
  providers: [ToastrService],

})

export class EssayAnswerListComponent implements OnInit {

  @ViewChild(DatatableComponent, { static: false }) table: DatatableComponent;
  data = [];
  scrollBarHorizontal = window.innerWidth < 1200;
  loadingIndicator = false;
  essayQuestionAnswerForm:FormGroup;
  reorderable = true;
  


 constructor(
    private fb: FormBuilder,
    private modalService: NgbModal,
    
    private toastr: ToastrService) { }

 ngOnInit(): void {
    this.getAll();
    this.essayQuestionAnswerForm = this.fb.group({
      Name:['', Validators.required],
      Question:['', Validators.required],
      AnswerText:['', Validators.required],
    });
  }
 
  getAll(){
 
  }
    
  }

  //ngOnInit(): void {
    //this.academicLevelFrom = this.fb.group({
      //name: ['', [Validators.required, Validators.pattern('[a-zA-Z]+')]],
      //selectlevelHeadId: [null, [Validators.required]],
      //isActive: ['', [Validators.required]],

function ngOnInit() {
  throw new Error('Function not implemented.');
}

