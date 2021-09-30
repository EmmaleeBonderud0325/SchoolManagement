import { NgxSpinnerService } from 'ngx-spinner';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { DropdownService } from './../../../services/drop-down/dropdown.service';
import { Router } from '@angular/router';
import { Component, OnInit } from '@angular/core';
import { FormGroupDirective, FormBuilder } from '@angular/forms';
import { PrimeNGConfig } from 'primeng/api';

@Component({
  selector: 'app-lesson-detail',
  templateUrl: './lesson-detail.component.html',
  styleUrls: ['./lesson-detail.component.sass']
})
export class LessonDetailComponent implements OnInit {

  menuItems: LessonMenu[];
  selectedMenu:LessonMenu;
  lessonId:number=0;
 // lesson:LessonModel = new LessonModel();
  //:FormGroup;

  isDisable:boolean=false;


  constructor( private dropDownService:DropdownService,
    private rootFormGroup: FormGroupDirective,
    private router: Router,
    private primengConfig: PrimeNGConfig,
    private formBuilder: FormBuilder,
    private modalService: NgbModal,
    private spinner: NgxSpinnerService) { }

  ngOnInit(): void {
  }

  routeLesonContent(){
    this.router.navigate(['/teacher-home/lesson/lesson-content']);

  }

  
  

}
interface LessonMenu {
  name: string,
  code: string,
  id:number
}