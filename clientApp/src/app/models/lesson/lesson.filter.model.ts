import { Injectable } from '@angular/core';
 
@Injectable()
export class LessonFilterModel
{
    searchText:string;
    selectedAcademicYearId:number
    selectedAcademicLevelId:number
    selectedClassNameId:number
    selectedSubjectId:number
}