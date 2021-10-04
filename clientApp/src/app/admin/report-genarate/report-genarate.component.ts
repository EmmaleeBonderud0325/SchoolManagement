import { ReportTypeModel } from './../../models/report/report.type.model';
import { DropdownService } from './../../services/drop-down/dropdown.service';
import { FormGroup, FormControl } from '@angular/forms';
import { ReportService } from './../../services/report/report.service';
import { NgxSpinnerService } from 'ngx-spinner';
import { DropDownModel } from './../../models/common/drop-down.model';
import { Component, OnInit } from '@angular/core';
import { HttpEventType, HttpResponse } from '@angular/common/http';

@Component({
  selector: 'app-report-genarate',
  templateUrl: './report-genarate.component.html',
  styleUrls: ['./report-genarate.component.sass']
})
export class ReportGenarateComponent implements OnInit {

  reportsTypes:DropDownModel[]=[];
  reportForm:FormGroup
  reportTypeId:ReportTypeModel;
  constructor(
    private spinner:NgxSpinnerService,
    private reportService:ReportService,
    private dropDownService:DropdownService
  ) 
  {
    this.reportForm = this.createReportForm();
  }

  ngOnInit(): void {
    
    this.getReportMasterrData();
  }

  excelTypeOnChanged(item:any)
  {

  }

  onSelectedReportChanged(item:any)
  {

  }

  getReportMasterrData()
  {
      this.dropDownService.getReportMasterrData().subscribe(response=>{
        this.spinner.show();
        this.reportsTypes = response;
        this.spinner.hide();
      },error=>{
        this.spinner.hide();
      })
  }

  downloadPercentage:number=0;
  isDownloading:boolean;
  generateReport()
  {
    this.isDownloading = true;
    this.spinner.show();

    this.reportService.downloadUserList(this.reportForm.value).subscribe((response:HttpResponse<Blob>)=>{
      if(response.type === HttpEventType.Response)
      {
        if(response.status == 204)
        {
          this.isDownloading = false;
          this.downloadPercentage = 0;
          this.spinner.hide();
        }
        else
        {
          let contentDisposition = response.headers.get('content-disposition');
          const objectUrl:string=URL.createObjectURL(response.body);
          const a:HTMLAnchorElement = document.createElement('a') as HTMLAnchorElement;

          a.href = objectUrl;
          a.download = this.parseFilenameFromContentDisposition(contentDisposition);
          document.body.appendChild(a);
          a.click();

          document.body.removeChild(a);
          URL.revokeObjectURL(objectUrl);
          this.isDownloading=false;
          this.downloadPercentage=0;
          this.spinner.hide();


        }
      }
    },error=>{
        this.spinner.hide();
        this.isDownloading=false;
        this.downloadPercentage=0;
    });
  }


  parseFilenameFromContentDisposition(contentDisposition) {
    if (!contentDisposition) return null;
    let matches = /filename="(.*?)"/g.exec(contentDisposition);

    return matches && matches.length > 1 ? matches[1] : null;
  }

  createReportForm():FormGroup{
    return new FormGroup({
      selectedReportId:new FormControl(0)
    })
  }
}
