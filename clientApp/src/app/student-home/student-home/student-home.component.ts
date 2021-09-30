import { Component, OnInit } from '@angular/core';
import { NgbCarouselConfig } from '@ng-bootstrap/ng-bootstrap';

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
  
  constructor(config: NgbCarouselConfig) {
    config.showNavigationArrows = true;
    config.showNavigationIndicators = true;
   }

  ngOnInit(): void {
  }

}
