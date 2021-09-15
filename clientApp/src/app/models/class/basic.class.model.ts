import { Injectable } from '@angular/core';

@Injectable()
export class BasicClassModel {
    id: number;
    name: string;
    academicYearId: number;
    academicLevelId: number;
    classNameId: number;
    classTeacherName: string;
    totalStudentCount: string;
}