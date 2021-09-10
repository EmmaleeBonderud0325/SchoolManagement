import { DropDownModel } from './../common/drop-down.model';
import { Injectable } from "@angular/core";

@Injectable()
export class ClassSubjectModel
{
    classId:number;
    subjectId:number;
    subjectName:string;
    subjectTeacherId:number;
    subjectTeachers:DropDownModel[];
}