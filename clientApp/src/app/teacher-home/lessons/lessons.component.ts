import { Component, OnInit, ViewChild } from '@angular/core';
import { DatatableComponent } from '@swimlane/ngx-datatable';
@Component({
  selector: 'app-lessons',
  templateUrl: './lessons.component.html',
  styleUrls: ['./lessons.component.sass']
})
export class LessonsComponent implements OnInit {
  @ViewChild(DatatableComponent, { static: false }) table: DatatableComponent;
  rows = [];
  scrollBarHorizontal = window.innerWidth < 1200;
  newUserImg = 'assets/images/users/user-2.png';
  data = [];
  filteredData = [];
  loadingIndicator = true;
  isRowSelected = false;
  selectedOption: string;
  reorderable = true;
  constructor() { }

  ngOnInit(): void {
  }

}
