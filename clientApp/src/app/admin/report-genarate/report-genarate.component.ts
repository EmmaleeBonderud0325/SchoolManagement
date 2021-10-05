import { NgxSpinnerService } from 'ngx-spinner';
import { DropDownModel } from './../../models/common/drop-down.model';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-report-genarate',
  templateUrl: './report-genarate.component.html',
  styleUrls: ['./report-genarate.component.sass']
})
export class ReportGenarateComponent implements OnInit {

  reportsTypes:DropDownModel[]=[];

  constructor(
    private spinner:NgxSpinnerService
  ) { }

  ngOnInit(): void {
  }

  excelTypeOnChanged(item:any)
  {

  }
  
}
