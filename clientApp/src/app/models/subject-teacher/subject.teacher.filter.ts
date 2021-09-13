import { Injectable } from '@angular/core';

@Injectable()
export class SubjectTeacherFilter {
    searchText: number;
    selectedAcademicYearId: number;
    selectedAcademicLevelId: number;
    selectedSubjectId: string;
}