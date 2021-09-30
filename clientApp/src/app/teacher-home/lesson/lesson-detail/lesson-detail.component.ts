import { Router } from '@angular/router';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-lesson-detail',
  templateUrl: './lesson-detail.component.html',
  styleUrls: ['./lesson-detail.component.sass']
})
export class LessonDetailComponent implements OnInit {

  constructor( private router:Router) { }

  ngOnInit(): void {
  }

  routeLesonContent(){
    this.router.navigate(['/teacher-home/lesson/lesson-content']);

  }
  

}
