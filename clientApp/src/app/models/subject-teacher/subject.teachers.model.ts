import { Injectable } from '@angular/core';
import { DropDownModel } from '../common/drop-down.model';

@Injectable()
export class SubjectTeachersModel {
    id: number;
    academicLevelId: number;
    academicYearId: number;
    subjectId: string;
    startDate: Date;
    isActive: boolean;
    subject: string;

    assignedSubjectTeachersName: string;
    assignedTeacherIds: number[];
    assignedTeachersCount: number;

    allTeachers: DropDownModel[];
}