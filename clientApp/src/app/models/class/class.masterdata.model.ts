import { Injectable } from '@angular/core';
import { DropDownModel } from "../common/drop-down.model";

@Injectable()
export class ClassMasterDataModel {

    currentAcademicYear: number;
    academicYears: DropDownModel[];
    academicLevels: DropDownModel[];
    classNames: DropDownModel[];
    classCategories: DropDownModel[];
    languageStreams: DropDownModel[];
    allTeachers: DropDownModel[];
}