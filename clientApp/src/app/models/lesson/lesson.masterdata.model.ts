import { Injectable } from '@angular/core';
import { DropDownModel } from "../common/drop-down.model";

@Injectable()
export class LessonMasterDataModel
{
    currentAcademicYear:number;
    academicLevels:DropDownModel[];
    classNames :DropDownModel[];
    academicYears :DropDownModel[];
    subjects :DropDownModel[];

}