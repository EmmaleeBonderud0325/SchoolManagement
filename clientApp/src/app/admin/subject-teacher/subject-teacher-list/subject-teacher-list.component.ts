import { Component, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { DatatableComponent } from '@swimlane/ngx-datatable';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { DropDownModel } from 'src/app/models/common/drop-down.model';
import { DropdownService } from 'src/app/services/drop-down/dropdown.service';
import { SubjectTeachersModel } from "../../../models/subject-teacher/subject.teachers.model";
import { SubjectTeacherService } from "../../../services/subject-teachers/subject-teacher.service";

@Component({
  selector: 'app-subject-teacher-list',
  templateUrl: './subject-teacher-list.component.html',
  styleUrls: ['./subject-teacher-list.component.sass']
})
export class SubjectTeacherListComponent implements OnInit {

  @ViewChild(DatatableComponent, { static: false }) table: DatatableComponent;

  scrollBarHorizontal = window.innerWidth < 1200;
  loadingIndicator = false;
  reorderable = true;


  selectedRowData: SubjectTeachersModel;

  academicLevels: DropDownModel[] = [];
  academicYears: DropDownModel[] = [];
  subjects: DropDownModel[] = [];
  allTeachers: DropDownModel[] = [];
  currentAcadmicYearId: number = 0;

  filterForm: FormGroup;
  subjectTeacherForm: FormGroup;

  data = new Array<SubjectTeachersModel>();

  currentPage: number = 0;
  pageSize: number = 25;
  totalRecord: number = 0;

  constructor(private formBuilder: FormBuilder,
    private modalService: NgbModal,
    private subjectTeacherService: SubjectTeacherService,
    private dropDownService: DropdownService,
    private spinner: NgxSpinnerService,
    //private toastr: ToastrService
  ) { }

  ngOnInit(): void {
    this.spinner.show();
    this.getMasterData();
    this.filterForm = this.createFilterForm();
    this.subjectTeacherForm = this.createNewSubjectTeacherForm();
  }

  createFilterForm(): FormGroup {
    return new FormGroup({
      selectedAcademicYearId: new FormControl(0),
      selectedAcademicLevelId: new FormControl(0),
      searchText: new FormControl("")
    });
  }

  createNewSubjectTeacherForm(): FormGroup {
    return this.formBuilder.group({
      id: [0, Validators.required],
      academicYearId: [0, Validators.required],
      academicLevelId: [null, Validators.required],
      subjectId: [null, Validators.required],
      assignedTeacherIds: [[], Validators.required],
    });
  }

  //get  DropDown Master  Meta Data
  getMasterData() {
    this.subjectTeacherService.getSubjectTeacherMasterData()
      .subscribe(response => {
        this.academicYears = response.academicYears;
        this.academicLevels = response.academicLevels;
        this.currentAcadmicYearId = response.currentAcademicYear;
       
        this.filterForm.get("selectedAcademicYearId").setValue(this.currentAcadmicYearId);
        this.filterForm.get("selectedAcademicYearId").disable();
        this.filterForm.get("selectedAcademicLevelId").setValue(this.academicLevels[0].id);

        this.getSubjects();

      }, error => {
        this.spinner.hide();
      });
  }

  //get subject
  getSubjects() {

    this.subjectTeacherService.getSubjectsForSelectedAcademicLevel(this.academicLevelFilterId)
      .subscribe(response => {

        this.subjects = response;
        this.getAll();

      }, error => {
        this.spinner.hide();
      })
  }

  //get Class
  getAll() {
    this.loadingIndicator = true;
    this.subjectTeacherService.getClassSubjectsForSelectedAcademiclevel(this.filterForm.getRawValue())
      .subscribe(response => {
        this.data = response;
        this.spinner.hide();
        this.loadingIndicator = false;
      }, error => {
        this.spinner.hide();
        this.loadingIndicator = false;
        //this.toastr.error("Network error has been occured. Please try again.", "Error");
      });
  }


  onAcademicLevelFilterChanged(item: any) {
    this.currentPage = 0;
    this.pageSize = 25;
    this.totalRecord = 0;
    this.spinner.show();
    this.getSubjects();

  }

  onSubjectFilterChanged(item: any) {
    this.currentPage = 0;
    this.pageSize = 25;
    this.totalRecord = 0;
    this.spinner.show();
    this.getAll();
  }

  filterDatatable(event) {
    this.currentPage = 0;
    this.pageSize = 25;
    this.totalRecord = 0;
    const val = event.target.value.toLowerCase();
    this.spinner.show();
    this.getAll();
  }

  get academicLevelFilterId() {
    return this.filterForm.get("selectedAcademicLevelId").value;
  }

  //For Add/Edit Subject Teachers


  editRow(row: SubjectTeachersModel, rowIndex: number, content: any) {

    //this.spinner.show();
    this.selectedRowData = row;
    this.allTeachers = row.allTeachers;
    this.subjectTeacherForm = this.formBuilder.group({
      id: [row.id, Validators.required],
      academicYearId: [row.academicYearId, Validators.required],
      academicLevelId: [row.academicLevelId, Validators.required],
      subjectId: [row.subjectId, Validators.required],
      assignedTeacherIds: [row.assignedTeacherIds, Validators.required],
    });

    this.subjectTeacherForm.get("academicYearId").disable();
    this.subjectTeacherForm.get("academicLevelId").disable();
    this.subjectTeacherForm.get("subjectId").disable();

    this.modalService.open(content, {
      ariaLabelledBy: 'modal-basic-title',
      size: 'lg',
    });
  }

  save() {

    this.spinner.show();

    this.subjectTeacherService.saveSubjectTeacher(this.subjectTeacherForm.getRawValue())
      .subscribe(response => {
        this.spinner.hide();
        if (response.isSuccess) {
          this.modalService.dismissAll();
          //this.toastr.success(response.message, "Success");
          this.getAll();
        }
        else {
          //this.toastr.error(response.message, "Error");
        }

      }, error => {
        this.spinner.hide();
        //this.toastr.error("Network error has been occured. Please try again.", "Error");
      });

  }
}
