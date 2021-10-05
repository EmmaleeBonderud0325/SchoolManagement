import { Injectable } from "@angular/core";
import { BasicEssayStudentAnswerModel}from './../essay-student-answer/basic.essay.student.answer.model'
import { PaginatedItemsModel } from './../common/paginated.Items.model';

@Injectable()

export class EssayStudentAnswerPaginatedItemsViewModel extends PaginatedItemsModel
{
    data:BasicEssayStudentAnswerModel[];
}