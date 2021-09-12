import { Injectable } from '@angular/core';
import { ClassSubjectTeacherModel } from "./class.subject.teacher.model";

@Injectable()
export class ClassModel {
    academicYearId: number;
    academicLevelId: number;
    classNameId: number;
    name: string;
    classCategoryId: number;
    languageStreamId: number;
    classTeacherId: number;

    classSubjectTeachers: ClassSubjectTeacherModel[];
}