import { Injectable } from '@angular/core';
import { DropDownModel } from "../common/drop-down.model";

@Injectable()
export class SubjectTeacherMasterDataModel {

    currentAcademicYear: number;
    academicYears: DropDownModel[];
    academicLevels: DropDownModel[];
}