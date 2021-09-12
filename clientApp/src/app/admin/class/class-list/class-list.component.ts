
import { DropdownService } from './../../../services/drop-down/dropdown.service';
import { ClassModel } from './../../../models/class/class.model';
import { DropDownModel } from './../../../models/common/drop-down.model';
import { ToastrService } from 'ngx-toastr';
import { ClassService } from './../../../services/class/class.service';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { DatatableComponent } from '@swimlane/ngx-datatable';
import { Component, OnInit, ViewChild } from '@angular/core';
import Swal from 'sweetalert2';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ClassSubjectTeacherModel } from 'src/app/models/class/class.subject.teacher.model';
import { BasicClassModel } from 'src/app/models/class/basic.class.model';
import { NgxSpinnerService } from 'ngx-spinner';

@Component({
  selector: 'app-class-list',
  templateUrl: './class-list.component.html',
  styleUrls: ['./class-list.component.sass'],
  providers: [ToastrService],
})
export class ClassListComponent implements OnInit {

  @ViewChild(DatatableComponent, { static: false }) table: DatatableComponent;

  scrollBarHorizontal = window.innerWidth < 1200;
  loadingIndicator = false;
  reorderable = true;
  class: ClassModel;
  classSubjects: ClassSubjectTeacherModel[] = [];

  selectedRowData: BasicClassModel;

  classNames: DropDownModel[] = [];
  academicLevels: DropDownModel[] = [];
  academicYears: DropDownModel[] = [];
  classCategories: DropDownModel[] = [];
  languageStreams: DropDownModel[] = [];
  allTeachers: DropDownModel[] = [];
  currentAcadmicYearId: number = 0;

  filterForm: FormGroup;
  classForm: FormGroup;
  classSubjectTeachers: ClassSubjectTeacherModel[] = [];
  allClassSubjectTeacherSelected: boolean = false;

  data = new Array<BasicClassModel>();

  currentPage: number = 0;
  pageSize: number = 25;
  totalRecord: number = 0;

  constructor(
    private formBuilder: FormBuilder,
    private modalService: NgbModal,
    private classService: ClassService,
    private dropDownService: DropdownService,
    private spinner: NgxSpinnerService,
    private toastr: ToastrService) { }

  ngOnInit(): void {
    this.spinner.show();
    this.getMasterData();
    this.filterForm = this.createFilterForm();
    this.classForm = this.createNewClassForm();
  }

  createFilterForm(): FormGroup {
    return new FormGroup({
      academicYearId: new FormControl(0),
      academicLevelId: new FormControl(0),
      searchText: new FormControl("")
    });
  }

  createNewClassForm(): FormGroup {
    return this.formBuilder.group({
      academicYearId: [0, Validators.required],
      academicLevelId: [null, Validators.required],
      classNameId: [null, Validators.required],
      name: ['', Validators.required],
      classCategoryId: [null, Validators.required],
      languageStreamId: [null, Validators.required],
      classTeacherId: [null, Validators.required],
      classSubjectTeachers: [null]
    });
  }


  //get class Names DropDown Meta Data
  getMasterData() {
    this.classService.getClassMasterData()
      .subscribe(response => {
        this.classNames = response.classNames;
        this.academicYears = response.academicYears;
        this.academicLevels = response.academicLevels;
        this.classCategories = response.classCategories;
        this.languageStreams = response.languageStreams;
        this.allTeachers = response.allTeachers;
        this.currentAcadmicYearId = response.currentAcademicYear;

        this.filterForm.get("academicYearId").setValue(this.currentAcadmicYearId);
        this.filterForm.get("academicYearId").disable();
        this.filterForm.get("academicLevelId").setValue(this.academicLevels[0].id);

        this.getAll();

      }, error => {
        this.spinner.hide();
      });
  }

  //get Class
  getAll() {
    this.loadingIndicator = true;
    this.classService.getClassList(this.searchTextFilterId, this.currentPage + 1, this.pageSize, this.academicYearFilterId, this.academicLevelFilterId)
      .subscribe(response => {
        this.data = response.data;
        this.totalRecord = response.totalRecordCount;
        this.spinner.hide();
        this.loadingIndicator = false;
      }, error => {
        this.spinner.hide();
        this.loadingIndicator = false;
        this.toastr.error("Network error has been occured. Please try again.", "Error");
      });
  }

  setPage(pageInfo) {
    this.spinner.show();
    this.loadingIndicator = true;
    this.currentPage = pageInfo.offset;
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

  onAcademicLevelFilterChanged(item: any) {
    this.currentPage = 0;
    this.pageSize = 25;
    this.totalRecord = 0;
    this.spinner.show();
    this.getAll();
  }


  get academicYearFilterId() {
    return this.filterForm.get("academicYearId").value;
  }

  get academicLevelFilterId() {
    return this.filterForm.get("academicLevelId").value;
  }

  get searchTextFilterId() {
    return this.filterForm.get("searchText").value;
  }


  //Add/Edit Class Modal popup

  addRow(content) {

    this.selectedRowData = null;
    this.classForm = this.formBuilder.group({
      academicYearId: [null, [Validators.required]],
      academicLevelId: [null, [Validators.required]],
      classNameId: [null, [Validators.required]],
      name: ['', [Validators.required]],
      classCategoryId: [null, [Validators.required]],
      languageStreamId: [null, [Validators.required]],
      classTeacherId: [null, [Validators.required]],
      classSubjectTeachers: [null]
    });

    this.modalService.open(content, {
      ariaLabelledBy: 'modal-basic-title',
      size: 'lg',
    });
  }

  editRow(row: BasicClassModel, rowIndex: number, content: any) {

    this.spinner.show();
    this.selectedRowData = row;
    this.classService.getClassDetails(row.academicYearId, row.academicLevelId, row.classNameId)
      .subscribe(response => {

        this.classForm = this.formBuilder.group({
          academicYearId: [response.academicYearId, [Validators.required]],
          academicLevelId: [response.academicLevelId, [Validators.required]],
          classNameId: [response.classNameId, [Validators.required]],
          name: [response.name, [Validators.required]],
          classCategoryId: [response.classCategoryId, [Validators.required]],
          languageStreamId: [response.languageStreamId, [Validators.required]],
          classTeacherId: [response.classTeacherId, [Validators.required]],
          classSubjectTeachers: [null]
        });

        this.classForm.get("academicYearId").disable();
        this.classForm.get("academicLevelId").disable();
        this.classForm.get("classNameId").disable();
        this.classForm.get("name").disable();
        this.classForm.get("classCategoryId").disable();

        this.classSubjectTeachers = response.classSubjectTeachers;

        this.modalService.open(content, {
          ariaLabelledBy: 'modal-basic-title',
          size: 'lg',
        });

        this.spinner.hide();
      }, error => {
        this.spinner.hide();
      });

  }

  getSubjectClassTeacherDetails() {

    this.spinner.show();
    this.classService.getClassSubjectsForSelectedAcademiclevel(this.academicYearId, this.academicLevelId)
      .subscribe(response => {
        this.spinner.hide();
        this.classSubjectTeachers = response;
        this.checkAllClassSubjectTeacherSelected();
      }, error => {
        this.spinner.hide();
      });
  }

  save() {

    this.spinner.show();
    var classModel = this.classForm.getRawValue();
    classModel.classSubjectTeachers = this.classSubjectTeachers;

    this.classService.saveClassDetail(classModel)
      .subscribe(response => {
        this.spinner.hide();
        if (response.isSuccess) {
          this.modalService.dismissAll();
          this.toastr.success(response.message, "Success");
          this.getAll();
        }
        else {
          this.toastr.error(response.message, "Error");
        }

      }, error => {
        this.spinner.hide();
        this.toastr.error("Network error has been occured. Please try again.", "Error");
      });

  }

  deleteClass(row: BasicClassModel) {
    Swal.fire({
      title: 'Are you sure Delete Class ?',
      showCancelButton: true,
      confirmButtonColor: 'red',
      cancelButtonColor: 'green',
      confirmButtonText: 'Yes',
    }).then((result) => {
      if (result.value) {

        this.classService.deleteClass(row.academicYearId, row.academicLevelId, row.classNameId).subscribe(response => {

          if (response.isSuccess) {
            this.toastr.success(response.message, "Success");
            this.getAll();
          }
          else {
            this.toastr.error(response.message, "Error");
          }

        }, error => {
          this.toastr.error("Network error has been occured. Please try again.", "Error");
        });
      }
    });
  }

  onAcademicLevelChanged(item: any) {
    this.spinner.show();
    this.getSubjectClassTeacherDetails();
    this.setClassName();
  }

  onClassNameChanged(item: any) {
    this.setClassName();
  }

  onSubjectTeacherChange(item: any) {
    this.checkAllClassSubjectTeacherSelected();
  }

  setClassName() {
    let selectedAcademicLevel: string = "";
    let selectedClassName: string = "";

    for (let index = 0; index < this.academicLevels.length; index++) {
      if (this.academicLevels[index].id == this.academicLevelId) {
        selectedAcademicLevel = this.academicLevels[index].name;
      }
    }

    for (let index = 0; index < this.classNames.length; index++) {
      if (this.classNames[index].id == this.classNameId) {
        selectedClassName = this.classNames[index].name;
      }
    }

    this.classForm.get("name").setValue(selectedAcademicLevel + " " + selectedClassName);

  }

  checkAllClassSubjectTeacherSelected() {

    if (this.classSubjectTeachers.length <= 0) {
      this.allClassSubjectTeacherSelected = false;
      return;
    }

    for (let index = 0; index < this.classSubjectTeachers.length; index++) {
      if (!this.classSubjectTeachers[index].subjectTeacherId) {
        this.allClassSubjectTeacherSelected = false;
        return;
      }

    }

    this.allClassSubjectTeacherSelected = true;;
  }

  get academicYearId() {
    return this.classForm.get("academicYearId").value;
  }

  get academicLevelId() {
    return this.classForm.get("academicLevelId").value;
  }

  get classNameId() {
    return this.classForm.get("classNameId").value;
  }

}
