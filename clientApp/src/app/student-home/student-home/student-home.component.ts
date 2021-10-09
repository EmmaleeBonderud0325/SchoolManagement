import { Component, OnInit } from '@angular/core';
import { NgbCarouselConfig } from '@ng-bootstrap/ng-bootstrap';
import { DropDownModel } from 'src/app/models/common/drop-down.model';
import { DropdownService } from './../../services/drop-down/dropdown.service';


@Component({
  selector: 'app-student-home',
  templateUrl: './student-home.component.html',
  styleUrls: ['./student-home.component.sass'],
  providers: [NgbCarouselConfig],
})
export class StudentHomeComponent implements OnInit {
  showNavigationArrows = false;
  showNavigationIndicators = false;
  images = [1, 2, 3].map((n) => `assets/images/carousel/${n}.jpg`);

  subjectAcademicLevels:DropDownModel[]=[];
  
  constructor(config: NgbCarouselConfig, private dropDownService:DropdownService) {
    config.showNavigationArrows = true;
    config.showNavigationIndicators = true;
   }

  ngOnInit(): void {
    this.getAllAcademicLevels();
  }

   //get Academic Levels DropDown Meta Data
   getAllAcademicLevels()
   {
     this.dropDownService.getAllAcademicLevels()
      .subscribe(response=>
       {
         console.log(response)
         this.subjectAcademicLevels = response;  
       },error=>{
       
       });
   }

}
