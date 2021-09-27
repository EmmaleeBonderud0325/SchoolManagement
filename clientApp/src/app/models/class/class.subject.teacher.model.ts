import { Injectable } from '@angular/core';
import { DropDownModel } from '../common/drop-down.model';

@Injectable()
export class ClassSubjectTeacherModel {
    id: number;
    classNameId: number;
    academicLevelId: number;
    academicYearId: number;
    subjectId: number;
    subjectTeacherId: number;
    subjectName: string;

    allSubjectTeachers: DropDownModel[];
}