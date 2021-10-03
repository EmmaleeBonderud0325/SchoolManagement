import { BasicStudentMCQQuestionAnswerModel } from './basic.studentmcqquestionanswer.model';
import { PaginatedItemsModel } from './../common/paginated.Items.model';
import { Injectable } from '@angular/core';
@Injectable()

export class StudentMCQQuestionAnswerPaginatedItemsViewModel extends PaginatedItemsModel
{
    data:BasicStudentMCQQuestionAnswerModel[];
}